using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProductManagerSystem.Features.Products.Dtos;


namespace ProductManagerSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto prodcutDto)
        {
            var command = new CreateProductCommand(prodcutDto);
            var productId = await _mediator.Send(command);
            return Ok(new { Id = productId });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Product ID mismatch.");
            }
            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound("Product not found.");
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var result = await _mediator.Send(new RemoveProductCommand(id));
            if (!result) return NotFound("Product not found.");

            return NoContent();
        }
    }
}
