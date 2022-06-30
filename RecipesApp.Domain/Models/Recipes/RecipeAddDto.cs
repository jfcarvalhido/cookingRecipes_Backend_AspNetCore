using RecipesApp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Domain.Models.Recipes
{
    public class RecipeAddDto
    {
        [Required(ErrorMessage = "Recipe name´s cannot be empty")]
        [MaxLength(200), MinLength(5)]
        public string Title { get; set; }

        [Required]
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        [Required(ErrorMessage = "Recipe serving´s cannot be empty")]
        public int Serving { get; set; }

        [Required]
        public Difficulty Difficulty { get; set; }

        [Required(ErrorMessage = "Recipe cooking time cannot be empty")]
        public int CookingTime { get; set; }

        [Required]
        public IEnumerable<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        [Required(ErrorMessage = "Recipe preparation´s cannot be empty")]
        [MaxLength(3000), MinLength(5)]
        public string Preparation { get; set; }
    }
}
