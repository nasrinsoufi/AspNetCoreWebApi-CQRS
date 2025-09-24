using Application.Features.Products.Commands;
using Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            var id = await _mediator.Send(new CreateProductCommand { Name = model.Name, Price = model.Price });
            return Ok(new { Id = id });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductViewModel model)
        {
            var result = await _mediator.Send(new UpdateProductCommand { Id = id, Name = model.Name, Price = model.Price });
            if (!result) return NotFound("Product notFounded");
            return Ok("Product Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand { Id = id });
            if (!result) return NotFound("Product notFounded");
            return Ok("Product Deleted");
        }
    }
}
