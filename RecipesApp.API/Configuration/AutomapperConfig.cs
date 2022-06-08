using AutoMapper;
using RecipesApp.API.Dtos.Recipes;
using RecipesApp.Domain.Entities;
using RecipesApp.Domain.Models.Recipes;
using RecipesApp.Domain.Models.Users;

namespace RecipesApp.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
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

            CreateMap<Recipe, RecipeAddDto>().ReverseMap();
            CreateMap<Recipe, RecipeEditDto>().ReverseMap();
            //CreateMap<Recipe, RecipeResultDto>().ReverseMap();

        }

    }
}
