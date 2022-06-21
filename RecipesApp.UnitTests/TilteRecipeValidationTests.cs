using RecipesApp.Validation;
using System;
using Xunit;

namespace RecipesApp.UnitTests
{
    public class TilteRecipeValidationTests
    {
        private readonly TitleRecipeValidation _validation;

        public TilteRecipeValidationTests()
        {
            _validation = new TitleRecipeValidation();
        }

        [Fact]
        public void IsValid_ValidTitleRecipe_ReturnsTrue()
        {
            Assert.True(_validation.IsValid("Chocolate Cake"));
        }

        [Fact]        
        public void IsValid_titleNull_ReturnFalse()
        {
            Assert.False(_validation.IsValid(null));
        }

        [Theory]
        [InlineData("a")]
        [InlineData("afgb")]
        public void IsValid_titleLess5Charaters_ReturnFalse(string title)
        {
            Assert.False(_validation.IsValid(title));
        }
    }
}
