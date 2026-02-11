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
            try
            {
                var clothes = _manager.ClothService.GetAllClothes(false);
                return Ok(clothes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOneClothes([FromRoute(Name = "id")] int id)
        {
            try
            {
                var cloth =
                _manager.ClothService.GetOneClothById(id, false);
                if (cloth is null)
                {
                    return NotFound();
                }
                return Ok(cloth);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult AddCloth([FromBody] Clothes cloth)
        {
            try
            {
                if (cloth is null)
                    return BadRequest("Cloth object is null.");

                _manager.ClothService.CreateOneCloth(cloth);

                return StatusCode(201, cloth);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCloth([FromRoute(Name = "id")] int id, [FromBody] Clothes cloth)
        {
            try
            {
                if (cloth is null)
                    return BadRequest("Cloth object is null.");

                _manager.ClothService.UpdateCloth(id, cloth, true);

                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCloth([FromRoute(Name = "id")] int id)
        {
            try
            {
                _manager.ClothService.DeleteCloth(id, false);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("{id}")]
        public IActionResult PartialUpdateOneCloth([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Clothes> clothPatch)
        {
            try
            {
                var existingCloth = _manager.ClothService.GetOneClothById(id, true);
                if (existingCloth is null)
                    return NotFound(); // 404 Not Found

                //check id
                if (id != existingCloth.Id)
                    return BadRequest("ID in the URL does not match ID in the body.");

                clothPatch.ApplyTo(existingCloth);
                _manager.ClothService.UpdateCloth(id, existingCloth, true);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
