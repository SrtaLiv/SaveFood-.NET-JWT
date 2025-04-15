using Primer.Proyecto.Models;

namespace Primer.Proyecto.Repositories
{
    public interface IFoodRepository
    {
        List<Food> GetFoods();
        Food getFoodById(int foodId);
        Food save(Food food);
        void delete(int foodId);
        Food updateFood(Food food);
        Food updateFoodImage(Food food); // falta file
    }
}