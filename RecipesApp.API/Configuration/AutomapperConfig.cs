using AutoMapper;
using RecipesApp.Domain.Entities;
using RecipesApp.Domain.Models.Recipes;
using RecipesApp.Domain.Models.Users;

namespace RecipesApp.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            //Recipe -> Create a new recipe
            CreateMap<Recipe, RecipeAddDto>().ReverseMap();

            // User -> AuthenticateResponse
            CreateMap<User, LoginModel>().ReverseMap();

            //RegisterRequest->User
            CreateMap<RegisterModel, User>().ReverseMap();

            // UpdateRequest -> User
            //CreateMap<UpdateRequest, User>()
            //    .ForAllMembers(x => x.Condition(
            //        (src, dest, prop) =>
            //        {
            //            //ignore null & empty string properties
            //            if (prop == null) return false;
            //            if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

            //            return true;
            //        }
            //    ));
        }
    }
}
