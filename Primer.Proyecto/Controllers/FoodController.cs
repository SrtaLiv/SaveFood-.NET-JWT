using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Primer.Proyecto.Bd;
using Primer.Proyecto.Models;
using Primer.Proyecto.Services;

namespace Primer.Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class FoodController : ControllerBase
    {
        
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        // GET: api/Food
        [HttpGet( "GetFoods")]
        public ActionResult<List<Food>> GetFoods()
        {
            return Ok(_foodService.GetFoods());
        }
        
        // GET: api/Food/1
        [HttpGet("GetFood")]
        public ActionResult<List<Food>> GetFoodById(int id)
        {
            return Ok(_foodService.getFoodById(id));
        }
       
        // POST: api/Food
        [HttpPost]
        public ActionResult<Food> PostFood(Food food)
        {
            if (!FoodExists(food.FoodId))
            {
                return BadRequest();
            }
            return Ok(_foodService.Save(food));;
        }
        
        // PUT: api/Food/5
        [HttpPut("{id}")]
        public ActionResult<Food> PutFood(Food food)
        {
            if(!FoodExists(food.FoodId))
                return BadRequest();
        
            return Ok(_foodService.UpdateFood(food));
        }
        
        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            if(!FoodExists(id))
                return BadRequest();
            
            return Ok(_foodService.Delete(id));
        }
        
        private bool FoodExists(int id)
        {
            return GetFoodById(id) != null;
        }
    }
}