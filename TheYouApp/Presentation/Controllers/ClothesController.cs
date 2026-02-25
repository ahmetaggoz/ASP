using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System.Threading.Tasks;


namespace Presentation.Controllers
{

    [ServiceFilter(typeof(LogFilterAttribute))]
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
        public async Task<IActionResult> GetAllClothesAsync()
        {
                var clothes = await _manager.ClothService.GetAllClothesAsync(false);
                return Ok(clothes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneClothesAsync([FromRoute(Name = "id")] int id)
        {
            var cloth =
               await _manager.ClothService.GetOneClothByIdAsync(id, false);
            return Ok(cloth);

        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> AddClothAsync([FromBody] ClothesDtoForInsertion clothDto)
        {
            
            var cloth = await _manager.ClothService.CreateOneClothAsync(clothDto);
            return StatusCode(201, cloth); //CreatedAtRoute()
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id}")]
        public async Task<IActionResult>
            UpdateClothAsync([FromRoute(Name = "id")] int id, [FromBody] ClothesDtoForUpdate clothDto)
        {
                await _manager.ClothService.UpdateClothAsync(id, clothDto, false);
                return NoContent(); // 204 No Content

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothAsync([FromRoute(Name = "id")] int id)
        {
                await _manager.ClothService.DeleteClothAsync(id, false);
                return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdateOneCloth([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<ClothesDtoForUpdate> clothPatch)
        {

            if(clothPatch is null)
                return BadRequest();
            var result = await _manager.ClothService.GetOneClothForPatchAsync(id, false);
                

            clothPatch.ApplyTo(result.clothesDtoForUpdate, ModelState);

            TryValidateModel(result.clothesDtoForUpdate);

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _manager.ClothService.SaveChangesForPatchAsync(result.clothesDtoForUpdate, result.cloth);
            return NoContent();
        }
    }
}
