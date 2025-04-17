using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Primer.Proyecto.Models;

namespace Primer.Proyecto.Services
{
    public interface IFoodService
    {
        //Food Save(Food food, IFormFile file);
        Food Save(Food food);
        
        List<Food> GetFoods();
        Food? getFoodById(int id);
        Food Delete(int id);
        Food UpdateFood(Food food);
        //Food UpdateFoodImage(Food food, IFormFile file);
        Food UpdateFoodImage(Food food, IFormFile file);

    }
}
