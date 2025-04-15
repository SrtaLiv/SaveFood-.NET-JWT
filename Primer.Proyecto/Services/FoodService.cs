
using Primer.Proyecto.Models;
using Primer.Proyecto.Repositories;
using Microsoft.AspNetCore.Http;
using Primer.Proyecto.Services;

namespace MyConsoleApp.Services{

    public class FoodService : IFoodService
    {
        private FoodRepository foodRepository;
   //     private ImageService imageService;

        public Food Save(Food food)
        {
           //if (file != null && file.isEmpty(){
             //  Image img = imagenService.uploadImage(file);
               //food.setImage(img);
           //}
           return this.foodRepository.save(food);
        }

        public List<Food> GetFoods()
        {
            throw new NotImplementedException();
        }

        public Food? GetById(long id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Food food)
        {
            throw new NotImplementedException();
        }

        public Food UpdateFood(Food food)
        {
            throw new NotImplementedException();
        }

        public Food UpdateFoodImage(Food food, IFormFile file)
        {
            throw new NotImplementedException();
        }
}
}