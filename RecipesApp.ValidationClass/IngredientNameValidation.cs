namespace RecipesApp.Validation
{
    public class IngredientNameValidation
    {
        private const int minlength = 2;
        private const int maxlength = 100;
        private const string nameExistDb = "Salt";

        public bool IsValid(string nameIngredient)
        {
            if (nameIngredient == null)
            {
                return false;
            }

            if (nameIngredient.Length < minlength || nameIngredient.Length > maxlength)
            {
                return false;
            }

            if (nameIngredient == nameExistDb)
            {
                return false;
            }

            return true;
        }
    }
}
