
using Microsoft.AspNetCore.Http.HttpResults;
using Primer.Proyecto.Models;
using Primer.Proyecto.Repositories;
using Primer.Proyecto.Services;

namespace MyConsoleApp.Services{

    public class FoodService : IFoodService
    {
        private IFoodRepository foodRepository;
   //     private ImageService imageService;

   public FoodService(IFoodRepository foodRepository)
   {
       this.foodRepository = foodRepository;
   }

   public Food Save(Food food)
        {
           //if (file != null && file.isEmpty(){
             //  Image img = imagenService.uploadImage(file);
               //food.setImage(img);
           //}
           return foodRepository.save(food);
        }

        public List<Food> GetFoods()
        {
            return foodRepository.GetFoods();
        }

        public Food? getFoodById(int id)
        {
            return foodRepository.getFoodById(id);
        }

        public Food Delete(int id)
        {
            return foodRepository.delete(id);
        }

        public Food UpdateFood(Food food)
        {
            return foodRepository.updateFood(food);
        }

        public Food UpdateFoodImage(Food food, IFormFile file)
        {
            throw new NotImplementedException();
        }
}
}