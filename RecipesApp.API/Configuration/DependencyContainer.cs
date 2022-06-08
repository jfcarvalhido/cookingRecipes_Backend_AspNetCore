using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipesApp.DAL.Context;
using RecipesApp.DAL.Repositories;
using RecipesApp.Domain.Interfaces;
using RecipesApp.Services.Interfaces;
using RecipesApp.Services.Services;

namespace RecipesApp.API.Configuration
{
    public class DependencyContainer
    {
        public static void InjectServices(IServiceCollection services, IConfiguration Configuration)
        {
            RegisterDbContext(services, Configuration);
            RegisterRepositories(services);
            ResgisterServices(services);
        }
        public static void RegisterDbContext(IServiceCollection services, IConfiguration Configuration)
        {
            //Caminho usado para aceder a base de dados
            services.AddDbContext<AppDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
        }
        public static void RegisterRepositories(IServiceCollection services)
        {
            //
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRecipeRepository), typeof(RecipeRepository));
            services.AddScoped(typeof(IIngredientRepository), typeof(IngredientRepository));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            //services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));

        }
        public static void ResgisterServices(IServiceCollection services)
        {
            //
            services.AddTransient<IRecipeService, RecipeService>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<ICategoryService, CategoryService>();
            
            //services.AddTransient<ICommentService, CommentService>();
        }
    }
}
