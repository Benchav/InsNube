using FirebaseExamenple2.Models.DTO;
using FirebaseExamenple2.Models.Entities;
using FirebaseExamenple2.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly FirebaseService _firebaseService;

        public ProductoController(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductoDTO productoDTO)
        {
          ProductoEntities producto = new ProductoEntities
          {
            Name = productoDTO.Name,
            Price = productoDTO.Price
          };

          try
          {
           await _firebaseService.createProduct(producto);
           return Ok(producto);
          }

          catch (Exception ex)
          {
            Console.WriteLine($"Error:{ex.Message}");
            return StatusCode(500, "Internal server error");
          }
        }
    }
}