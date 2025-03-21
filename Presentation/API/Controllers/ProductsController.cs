using Application.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddAsync(new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Price = 100,
                CreatedDate = DateTime.UtcNow,
                Stock = 10
            });
           var count = await _productWriteRepository.SaveAsync();
        }
    }
}
