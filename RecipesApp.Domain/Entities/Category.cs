using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecipesApp.Domain.Entities
{
    public class Category : Entity
    {
        #region "Propriedades"
        [MaxLength(100), MinLength(5)]
        public string Name { get; set; }
        #endregion

        #region "EF Relation"
        [JsonIgnore]
        public ICollection<Recipe> Recipes { get; set; }
        #endregion
    }
}
