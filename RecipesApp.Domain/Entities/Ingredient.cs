using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecipesApp.Domain.Entities
{
    public class Ingredient : Entity
    {
        #region "Propriedades"  

        [MaxLength(100), MinLength(2)]
        public string NameIngredient { get; set; }



        #endregion

        #region "EF Relation"  
        [JsonIgnore]
        public ICollection<Recipe> Recipes { get; set; }        
        #endregion
    }
}
