namespace RecipesApp.Validation
{
    public class CategoryNameValidation
    {
        private const int minlength = 2;
        private const int maxlength = 100;
        private const string nameExistDb = "Meat";

        public bool IsValid(string name)
        {
            if (name == null)
            {
                return false;
            }

            if (name.Length < minlength || name.Length > maxlength)
            {
                return false;
            }

            if (name == nameExistDb)
            {
                return false;
            }

            return true;
        }
    }
}
