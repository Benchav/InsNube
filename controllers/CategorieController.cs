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


    /*   [HttpGet("{id}")]
        public async Task<IActionResult> GetCategorie(string id)
        {
            try
            {
                var categorie = await _firebaseService.VerCategories(id);
                if (categorie == null)
                {
                    return NotFound("Category not found");
                }
                return Ok(categorie);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }*/


   /*     [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategorie(string id, [FromBody] CategorieDTO categorieDTO)
        {
            try
            {
                var existingCategorie = await _firebaseService.getCategorieById(id);
                if (existingCategorie == null)
                {
                    return NotFound("Category not found");
                }

                existingCategorie.Name = categorieDTO.Name; // Actualizamos los valores

                await _firebaseService.updateCategorie(id, existingCategorie);
                return Ok(existingCategorie);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/categorie/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorie(string id)
        {
            try
            {
                var categorie = await _firebaseService.getCategorieById(id);
                if (categorie == null)
                {
                    return NotFound("Category not found");
                }

                await _firebaseService.deleteCategorie(id);
                return Ok("Category deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }*/

    }
}