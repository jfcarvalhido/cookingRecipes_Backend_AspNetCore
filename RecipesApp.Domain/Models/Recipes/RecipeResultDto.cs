using RecipesApp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RecipesApp.API.Dtos.Recipes
{
    public class RecipeResultDto
    {
        public int Id { get; set; }
        public string Title { get; set; }        
        public IEnumerable <Category> Categories { get; set; }
        public int Serving { get; set; }
        public Difficulty Difficulty { get; set; }
        public int CookingTime { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }       
        public string Preparation { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
