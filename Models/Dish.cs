using System.ComponentModel.DataAnnotations;
using System;
namespace CruDelicious.Models
{
    public class Dish
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        [Required]
        public int DishId { get; set; }
        [Required]
        [Display(Name = "Name of Dish:")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Chef's Name:")]
        public string Chef { get; set; }
        [Required]
        [Range(1, 5)]
        [Display(Name = "Tastiness:")]
        public int Tastiness { get; set; }
        [Required]
        [Range(1, 5000)]
        [Display(Name = "# of Calories:")]
        public int Calories { get; set; }
        [Required]
        [Display(Name = "Description:")]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
