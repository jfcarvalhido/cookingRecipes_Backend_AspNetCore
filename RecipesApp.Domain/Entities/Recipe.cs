using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecipesApp.Domain.Entities
{
    public class Recipe : Entity
    {
        #region "Propriedades"

        [Required(ErrorMessage = "Recipe name´s cannot be empty")]
        [MaxLength(200), MinLength(5)]
        [Column(Order = 1)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Recipe serving´s cannot be empty")]
        [Column(Order = 2)]
        public int Serving { get; set; }

        [Column(Order = 3)]
        public Difficulty Difficulty { get; set; }

        [Required(ErrorMessage = "Recipe cooking time cannot be empty")]
        [Column(Order = 4)]
        public int CookingTime { get; set; }

        [Required(ErrorMessage = "Recipe preparation´s cannot be empty")]
        [MaxLength(3000), MinLength(5)]
        [Column(Order = 5)]
        public string Preparation { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }
        #endregion

        #region "EF Relation" 
        public ICollection<Category> Categories { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        #endregion
    }

    public enum Difficulty
    {
        easy,
        medium,
        hard
    }
}
