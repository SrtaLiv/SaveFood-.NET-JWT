using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Primer.Proyecto.Models
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Calories { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
