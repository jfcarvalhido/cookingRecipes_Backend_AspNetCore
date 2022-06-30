namespace RecipesApp.Validation
{
    public class TitleRecipeValidation
    {
        private const int minlength = 5;
        private const int maxlength = 200;

        public bool IsValid(string title)
        {
            if(title == null)
            {
                return false;
            }

            if(title.Length < minlength || title.Length > maxlength)
            { 
                return false; 
            }

            return true;
        }
    }
}
