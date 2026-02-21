using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/clothes")]
    public class ClothesController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public ClothesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllClothes()
        {
                var clothes = _manager.ClothService.GetAllClothes(false);
                return Ok(clothes);
        }

        [HttpGet("{id}")]
        public IActionResult GetOneClothes([FromRoute(Name = "id")] int id)
        {
            var cloth =
                _manager.ClothService.GetOneClothById(id, false);
               

            return Ok(cloth);

        }

        [HttpPost]
        public IActionResult AddCloth([FromBody] ClothesDtoForInsertion clothDto)
        {
                if (clothDto is null)
                    return BadRequest("Cloth object is null.");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

                var cloth = _manager.ClothService.CreateOneCloth(clothDto);

                return StatusCode(201, cloth); //CreatedAtRoute()
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCloth([FromRoute(Name = "id")] int id, [FromBody] ClothesDtoForUpdate clothDto)
        {
                if (clothDto is null)
                    return BadRequest("Cloth object is null.");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

                _manager.ClothService.UpdateCloth(id, clothDto, false);

                return NoContent(); // 204 No Content

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCloth([FromRoute(Name = "id")] int id)
        {
                _manager.ClothService.DeleteCloth(id, false);
                return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult PartialUpdateOneCloth([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<ClothesDtoForUpdate> clothPatch)
        {

            if(clothPatch is null)
                return BadRequest();
            var result = _manager.ClothService.GetOneClothForPatch(id, false);
                

            clothPatch.ApplyTo(result.clothesDtoForUpdate, ModelState);

            TryValidateModel(result.clothesDtoForUpdate);

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _manager.ClothService.SaveChangesForPatch(result.clothesDtoForUpdate, result.cloth);
            return NoContent();
        }
    }
}
