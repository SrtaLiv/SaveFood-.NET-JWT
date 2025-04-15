using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Primer.Proyecto.Bd;
using Primer.Proyecto.Models;

namespace Primer.Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class FoodController : ControllerBase
    {
        
        private readonly BloggingContext _context;  

        private readonly ILogger<FoodController> _logger;

        public FoodController(ILogger<FoodController> logger, BloggingContext context)
        {
            _logger = logger;
            _context = context;  // Se inicializa el contexto
        }

        // GET: api/Food
        [HttpGet(Name = "GetFoods")]
        public async Task<ActionResult<IEnumerable<Food>>> GetFoods()
        {
            return await _context.Foods.ToListAsync();  // Obtiene todos los alimentos de la base de datos
        }
       
        // POST: api/Food
        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();

            return Ok(food);;
        }
        
        // PUT: api/Food/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Food>> PutFood(Food food, int id)
        {
            if (id != food.FoodId)
            {
                return BadRequest();
            }
            
            try
            {
               _context.Foods.Update(food);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        
        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        private bool FoodExists(int id)
        {
            return _context.Foods.Any(e => e.FoodId == id);
        }
    }
}