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
        Food? GetById(long id);
        void Delete(Food food);
        Food UpdateFood(Food food);
        //Food UpdateFoodImage(Food food, IFormFile file);
        Food UpdateFoodImage(Food food, IFormFile file);

    }
}
