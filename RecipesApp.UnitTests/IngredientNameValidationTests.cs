using RecipesApp.Validation;
using Xunit;

namespace RecipesApp.UnitTests
{
    public class IngredientNameValidationTests
    {
        private readonly IngredientNameValidation _validation;

        public IngredientNameValidationTests()
        {
            _validation = new IngredientNameValidation();
        }

        [Fact]
        public void IsValid_ValidIngredientName_ReturnsTrue()
        {
            Assert.True(_validation.IsValid("Chocolate"));
        }

        [Fact]
        public void IsValid_IngredientNameNull_ReturnFalse()
        {
            Assert.False(_validation.IsValid(null));
        }

        [Fact]
        
        public void Exist_IngredientName_ReturnFalse()
        {
            Assert.False(_validation.IsValid("Salt"));            
        }

        [Theory]
        [InlineData("a")]        
        public void IsValid_IngredientNameLess2Charaters_ReturnFalse(string ingredientName)
        {
            Assert.False(_validation.IsValid(ingredientName));
        }
    }
}
