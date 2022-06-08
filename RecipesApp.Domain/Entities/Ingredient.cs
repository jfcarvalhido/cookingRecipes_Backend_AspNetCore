using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RecipesApp.Domain.Entities
{
    public class Ingredient : Entity
    {
        #region "Propriedades"        

        public string NameIngredient { get; set; }



        #endregion

        #region "EF Relation"  
        [JsonIgnore]
        public ICollection<Recipe> Recipes { get; set; }        
        #endregion
    }
}
