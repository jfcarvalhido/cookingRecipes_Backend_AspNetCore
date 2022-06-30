using RecipesApp.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RecipesApp.UnitTests
{
    public class CategoryNameValidationTests
    {
        private readonly CategoryNameValidation _validation;

        public CategoryNameValidationTests()
        {
            _validation = new CategoryNameValidation();
        }

        [Fact]
        public void IsValid_ValidCategoryName_ReturnsTrue()
        {
            Assert.True(_validation.IsValid("Dessert"));
        }

        [Fact]
        public void IsValid_CategoryNameNull_ReturnFalse()
        {
            Assert.False(_validation.IsValid(null));
        }

        [Fact]

        public void Exist_CategoryName_ReturnFalse()
        {
            Assert.False(_validation.IsValid("Meat"));
        }

        [Theory]
        [InlineData("a")]
        public void IsValid_CategoryNameLess2Charaters_ReturnFalse(string name)
        {
            Assert.False(_validation.IsValid(name));
        }
    }
}
