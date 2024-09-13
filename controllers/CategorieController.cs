using FirebaseExamenple2.Models.DTO;
using FirebaseExamenple2.Models.Entities;
using FirebaseExamenple2.Services;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly FirebaseService _firebaseService;

        public CategorieController(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategorie([FromBody] CategorieDTO categorieDTO)
        {
          CategorieEntities categorie = new CategorieEntities
          {
            Name = categorieDTO.Name,
          };

          try
          {
           await _firebaseService.createCategorie(categorie);
           return Ok(categorie);
          }

          catch (Exception ex)
          {
            Console.WriteLine($"Error:{ex.Message}");
            return StatusCode(500, "Internal server error");
          }
        }
    }
}