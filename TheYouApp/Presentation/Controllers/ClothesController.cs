using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IActionResult AddCloth([FromBody] Clothes cloth)
        {
                if (cloth is null)
                    return BadRequest("Cloth object is null.");

                _manager.ClothService.CreateOneCloth(cloth);

                return StatusCode(201, cloth);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCloth([FromRoute(Name = "id")] int id, [FromBody] Clothes cloth)
        {
                if (cloth is null)
                    return BadRequest("Cloth object is null.");

                _manager.ClothService.UpdateCloth(id, cloth, true);

                return NoContent(); // 204 No Content

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCloth([FromRoute(Name = "id")] int id)
        {
                _manager.ClothService.DeleteCloth(id, false);
                return NoContent();
        }
        [HttpPatch("{id}")]
        public IActionResult PartialUpdateOneCloth([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Clothes> clothPatch)
        {

                var existingCloth = _manager.ClothService.GetOneClothById(id, true);
                if (existingCloth is null)
                    return NotFound(); // 404 Not Found

                

                clothPatch.ApplyTo(existingCloth);
                _manager.ClothService.UpdateCloth(id, existingCloth, true);
                return NoContent();
        }
    }
}
