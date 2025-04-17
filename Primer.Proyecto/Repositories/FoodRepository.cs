using Microsoft.EntityFrameworkCore;
using Primer.Proyecto.Bd;
using Primer.Proyecto.Models;

namespace Primer.Proyecto.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly BloggingContext _context;

        public FoodRepository(BloggingContext context)
        {
            _context = context;
        }

        public List<Food> GetFoods()
        {
            return _context.Foods.ToList();
        }

        public Food getFoodById(int foodId)
        {
            return _context.Foods.Find(foodId);
        }

        public Food save(Food food)
        {
            _context.Foods.Add(food);
            _context.SaveChanges();
            return food;
        }

        public Food delete(int foodId)
        {
            var food = _context.Foods.Find(foodId);
            if (food != null)
            {
                _context.Foods.Remove(food);
                _context.SaveChanges();
            }
            return food;
        }

        public Food updateFood(Food food)
        {
            var existingFood = _context.Foods.Find(food.FoodId);

            if (existingFood != null)
            {
                _context.Entry(existingFood).CurrentValues.SetValues(food);
            }
            else
            {
                _context.Foods.Attach(food);
                _context.Entry(food).State = EntityState.Modified;
            }

            _context.SaveChanges();
            return food;
        }


        public Food updateFoodImage(Food food)
        {
            _context.Foods.Update(food);
            _context.SaveChanges();
            return food;
        }
    }
}
