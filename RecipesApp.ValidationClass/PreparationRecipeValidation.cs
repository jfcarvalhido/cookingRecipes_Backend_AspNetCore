namespace RecipesApp.Validation
{
    public class PreparationRecipeValidation
    {
        private const int minlength = 5;
        private const int maxlength = 3000;

        public bool IsValid(string preparation)
        {
            if (preparation == null)
            {
                return false;
            }

            if (preparation.Length < minlength || preparation.Length > maxlength)
            {
                return false;
            }

            return true;
        }
    }
}
