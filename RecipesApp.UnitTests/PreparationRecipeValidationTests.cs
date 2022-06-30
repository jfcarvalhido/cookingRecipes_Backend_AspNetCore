using RecipesApp.Validation;
using Xunit;

namespace RecipesApp.UnitTests
{
    public class PreparationRecipeValidationTests
    {
        private readonly PreparationRecipeValidation _validation;

        public PreparationRecipeValidationTests()
        {
            _validation = new PreparationRecipeValidation();
        }

        [Fact]
        public void IsValid_ValidPreparationRecipe_ReturnsTrue()
        {
            Assert.True(_validation.IsValid("Preheat oven to 400 degrees F (200 degrees C)..."));
        }

        [Fact]
        public void IsValid_PreparationNull_ReturnFalse()
        {
            Assert.False(_validation.IsValid(null));
        }

        [Theory]
        [InlineData("a")]
        [InlineData("afgb")]
        public void IsValid_PreparationLess5Charaters_ReturnFalse(string preparation)
        {
            Assert.False(_validation.IsValid(preparation));
        }
    }
}
