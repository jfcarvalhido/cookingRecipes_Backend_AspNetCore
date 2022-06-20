using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipesApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipesApp.DAL.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        #region "Construtor"
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        #endregion

        #region "Entities"
        public DbSet<Ingredient> Ingredients { get; set; }
        //public DbSet<IngredientDetail> IngredientDetails { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        #endregion       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasIndex(iu => iu.UserName).IsUnique();

            modelBuilder.Entity<IdentityUser>().HasIndex(iu => iu.Email).IsUnique();

            modelBuilder.Entity<Ingredient>().HasIndex(i => i.NameIngredient).IsUnique();

            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<Category>()
                .HasData
                ( new Category { Id = 1, Name = "Appetizers" }, new Category { Id = 2, Name = "Soups" }, new Category { Id = 3, Name = "Beef" },
                  new Category { Id = 4, Name = "Chicken" }, new Category { Id = 5, Name = "Pork" }, new Category { Id = 6, Name = "Seafood" },
                  new Category { Id = 7, Name = "Pasta" }, new Category { Id = 8, Name = "Vegetarian" }, new Category { Id = 9, Name = "Salads" },
                  new Category { Id = 10, Name = "Desserts" });

            modelBuilder.Entity<Ingredient>()
                .HasData
                (new Ingredient { Id = 1, NameIngredient = "fresh parsley" }, new Ingredient { Id = 2, NameIngredient = "olive oil" },
                 new Ingredient { Id = 3, NameIngredient = "fresh oregano leaves" }, new Ingredient { Id = 4, NameIngredient = "red wine vinegar" },
                 new Ingredient { Id = 5, NameIngredient = "garlic" }, new Ingredient { Id = 6, NameIngredient = "salt" },
                 new Ingredient { Id = 7, NameIngredient = "rede pepper flakes" }, new Ingredient { Id = 8, NameIngredient = "ground black pepper" },
                 new Ingredient { Id = 9, NameIngredient = "whole chicken" }, new Ingredient { Id = 10, NameIngredient = "onion" },
                 new Ingredient { Id = 11, NameIngredient = "pancetta or salt pork" }, new Ingredient { Id = 12, NameIngredient = "beef chuck" },
                 new Ingredient { Id = 13, NameIngredient = "kosher salt" }, new Ingredient { Id = 14, NameIngredient = "celery" },
                 new Ingredient { Id = 15, NameIngredient = "carrot" }, 
                 new Ingredient { Id = 17, NameIngredient = "tomato paste" }, new Ingredient { Id = 18, NameIngredient = "bay leaf" },
                 new Ingredient { Id = 19, NameIngredient = "white wine" }, new Ingredient { Id = 20, NameIngredient = "yellow onions" },
                 new Ingredient { Id = 21, NameIngredient = "rigatoni" }, new Ingredient { Id = 22, NameIngredient = "fresh marjoram leaves" },
                 new Ingredient { Id = 23, NameIngredient = "cayenne pepper" }, new Ingredient { Id = 24, NameIngredient = "freshly grated Parmigiano-Reggiano" },
                 new Ingredient { Id = 25, NameIngredient = "unsalted butter" }, new Ingredient { Id = 26, NameIngredient = "self-raising flour" },
                 new Ingredient { Id = 27, NameIngredient = "muscovado sugar" }, new Ingredient { Id = 28, NameIngredient = "black treacle" },
                 new Ingredient { Id = 29, NameIngredient = "golden syrup" }, new Ingredient { Id = 30, NameIngredient = "large eggs" },
                 new Ingredient { Id = 31, NameIngredient = "milk" }, new Ingredient { Id = 32, NameIngredient = "syrup" },
                 new Ingredient { Id = 33, NameIngredient = "fine sea salt" }, new Ingredient { Id = 34, NameIngredient = "ground ginger" },
                 new Ingredient { Id = 35, NameIngredient = "cinnamon" }, new Ingredient { Id = 36, NameIngredient = "bicarbonate of soda" },
                 new Ingredient { Id = 37, NameIngredient = "icing sugar" }, new Ingredient { Id = 38, NameIngredient = "white chocolate" },
                 new Ingredient { Id = 39, NameIngredient = "celery sticks" }, new Ingredient { Id = 40, NameIngredient = "rapeseed oil" },
                 new Ingredient { Id = 41, NameIngredient = "carrots" }, new Ingredient { Id = 42, NameIngredient = "bay leaves" },
                 new Ingredient { Id = 43, NameIngredient = "thyme" }, new Ingredient { Id = 44, NameIngredient = "tomato purée" },
                 new Ingredient { Id = 45, NameIngredient = "worcestershire sauce" }, new Ingredient { Id = 46, NameIngredient = "beef stock cubes" },
                 new Ingredient { Id = 47, NameIngredient = "beef" }, new Ingredient { Id = 48, NameIngredient = "cornflour" },
                 new Ingredient { Id = 49, NameIngredient = "parsley" }, new Ingredient { Id = 50, NameIngredient = "can black beans" },
                 new Ingredient { Id = 51, NameIngredient = "bunch coriander" }, new Ingredient { Id = 52, NameIngredient = "flour tortillas" },
                 new Ingredient { Id = 53, NameIngredient = "avocado or tub guacamole" }, new Ingredient { Id = 54, NameIngredient = "soured cream" },
                 new Ingredient { Id = 55, NameIngredient = "red or yellow pepper" }, new Ingredient { Id = 56, NameIngredient = "oil" },
                 new Ingredient { Id = 57, NameIngredient = "red onion" }, new Ingredient { Id = 58, NameIngredient = "chilli powder" },
                 new Ingredient { Id = 59, NameIngredient = "smoked paprika" }, new Ingredient { Id = 60, NameIngredient = "ground cumin" },
                 new Ingredient { Id = 61, NameIngredient = "lime" }, new Ingredient { Id = 62, NameIngredient = "ginger" },
                 new Ingredient { Id = 63, NameIngredient = "tikka curry paste" }, new Ingredient { Id = 64, NameIngredient = "tomatoes" },
                 new Ingredient { Id = 65, NameIngredient = "light brown soft sugar" }, new Ingredient { Id = 66, NameIngredient = "cardamom pods" },
                 new Ingredient { Id = 67, NameIngredient = "brown basmati rice" }, new Ingredient { Id = 68, NameIngredient = "ground almonds" },
                 new Ingredient { Id = 69, NameIngredient = "raw king prawns" }, new Ingredient { Id = 70, NameIngredient = "double cream" },
                 new Ingredient { Id = 71, NameIngredient = "coriander" });

            modelBuilder.Entity<Recipe>()
                .HasData
                (
                new Recipe
                {
                    Id = 1,
                    Title = "Chimichurri Baked Chicken",
                    Serving = 6,
                    Difficulty = 0,
                    CookingTime = 1575,
                    Preparation = "Combine parsley, 2 1/2 tablespoons olive oil, oregano, vinegar, garlic, salt, red pepper flakes, and black pepper in a bowl; mix the chimichurri thoroughly. Place chicken on a cutting board and remove the backbone using kitchen shears. Press down on the breast with the heel of your hand to flatten. Loosen the skin of the chicken carefully and rub the chimichurri underneath, distributing it evenly. Wrap the chicken in plastic wrap and refrigerate for 24 hours. Allow chicken to come to room temperature for no more than 1 hour before baking. Preheat oven to 450 degrees F (230 degrees C). Rub 1 teaspoon olive oil over the chicken; season with salt and pepper. Place onion in a cast-iron skillet. Pour chicken broth over onion. Place seasoned chicken on top. Bake in the preheated oven until no longer pink at the bone and the juices run clear, about 45 minutes. An instant-read thermometer inserted into the thickest part of the meat, near the bone, should read 165 degrees F (74 degrees C). Allow chicken to rest in a warm area for 10 minutes before slicing."
                },
                new Recipe
                {
                    Id = 2,
                    Title = "Rigatoni alla Genovese",
                    Serving = 8,
                    Difficulty = 0,
                    CookingTime = 600,
                    Preparation = "Heat oil in a large pot over medium heat. Cook pancetta until most of fat is rendered out, about 6 minutes. Remove cooked pancetta with a slotted spoon and save. Raise heat to high and transfer meat to the pot. Season with salt. Cook and stir until liquid releases from beef and begins to evaporate, and meat browns, 10 to 15 minutes. Reduce heat to medium-high. Add celery, carrots, reserved cooked pancetta, salt and pepper. Cook and stir about 5 minutes. Add a heaping tablespoon of tomato paste, bay leaf, and white wine. Cook and stir, scraping up the brownings from the bottom of the pan, 2 to 3 minutes. Add sliced onions. Reduce heat to medium. Cover pot and cook 30 minutes without stirring. After 30 minutes, stir onions and meat until well mixed. Cover again, and cook another 30 minutes. Stir. Reduce heat to low and cook uncovered 8 to 10 hours, stirring occasionally. Skim off fat as mixture cooks. If sauce seems to reduce too much, add water or broth as needed to maintain a sauce-like consistency. Cook until beef and onions seem to melt into each other.Bring a large pot of lightly salted water to a boil. Cook rigatoni in the boiling water, stirring occasionally until just barely al dente, 10 to 12 minutes. Drain. Add rigatoni to the sauce and cook until heated through. Serve topped with a pinch of marjoram and freshly grated Parmigiano-Reggiano cheese."
                },
                new Recipe
                {
                    Id = 3,
                    Title = "Ginger & white chocolate cake",
                    Serving = 12,
                    Difficulty = 0,
                    CookingTime = 65,
                    Preparation = "Heat the oven to 180C/160C fan/gas 4. Melt 1 tbsp butter in a small pan, then stir in ½ tbsp flour to create a wet paste. Brush it over the inside of a 9-inch bundt tin. Put the remaining butter, sugar, treacle and golden syrup in a pan set over a medium heat and stir until everything has melted together. Leave to cool a little. Pour the mixture into a large bowl and whisk in the eggs and milk. Fold in the stem ginger, remaining flour, salt, ground ginger, cinnamon and bicarb. Tip into the prepared tin and bake for 40-45 mins, or until firm to the touch. Leave to cool for 10 mins in the tin, then turn out onto a wire rack to cool completely. To make the icing, whisk the milk, ginger syrup and icing sugar together. Melt the chocolate in a heatproof bowl in the microwave in 1-min bursts. Leave to cool a little, then whisk into the milk mixture. Spoon the icing over the cake, then decorate with the crystallised ginger pieces."
                },
                new Recipe
                {
                    Id = 4,
                    Title = "Slow-cooker beef stew",
                    Serving = 12,
                    Difficulty = 0,
                    CookingTime = 260,
                    Preparation = "Fry the onion and celery in 1 tbsp oil over a low heat until they start to soften – about 5 mins. Add the carrots, bay and thyme, fry for 2 mins, stir in the purée and Worcestershire sauce, add 600ml boiling water, stir and tip everything into a slow cooker. Crumble over the stock cubes or add the stock pots and stir, then season with pepper (don’t add salt as the stock may be salty). Clean out the frying pan and fry the beef in the remaining oil in batches until it is well browned, then tip each batch into the slow cooker. Cook on low for 8-10 hrs, or on high for 4 hrs. If you want to thicken the gravy, mix the cornflour with a splash of cold water to make a paste, then stir in 2 tbsp of the liquid from the slow cooker. Tip back into the slow cooker, stir and cook for a further 30 mins on high. Stir in the parsley and season again to taste. Serve with mash, if you like. Leave to cool before freezing."
                },
                new Recipe
                {
                    Id = 5,
                    Title = "Vegetarian fagitas",
                    Serving = 4,
                    Difficulty = 0,
                    CookingTime = 15,
                    Preparation = "To make the fajita mix, take two or three strips from each colour of pepper and finely chop them. Set aside. Heat the oil in a frying pan and fry the remaining pepper strips and the onion until soft and starting to brown at the edges. Cool slightly and mix in the chopped raw peppers. Add the garlic and cook for 1 min, then add the spices and stir. Cook for a couple of mins more until the spices become aromatic, then add half the lime juice and season. Transfer to a dish, leaving any juices behind, and keep warm. Tip the black beans into the same pan, then add the remaining lime juice and plenty of seasoning. Stir the beans around the pan to warm them through and help them absorb any flavours of the fajita mix, then stir through the coriander. Warm the tortillas in a microwave or in a low oven, then wrap them so they don’t dry out. Serve the tortillas with the fajita mix, beans, avocado and soured cream for everyone to help themselves."
                },
                new Recipe
                {
                    Id = 6,
                    Title = "Prawn tikka masala",
                    Serving = 4,
                    Difficulty = 0,
                    CookingTime = 40,
                    Preparation = "Put the onion, ginger and garlic in a food processor and blitz to a smooth paste. Heat the oil in a large flameproof casserole dish or pan over a medium heat. Add the onion paste and fry for 8 mins or until lightly golden. Stir in the curry paste and fry for 1 min more. Add the tomatoes, tomato purée, sugar and cardamom pods. Bring to a simmer and cook, covered, for another 10 mins. Cook the rice following pack instructions. Scoop the cardamom out of the curry sauce and discard, then blitz with a hand blender, or in a clean food processor. Return to the pan, add the almonds and prawns, and cook for 5 mins. Season to taste and stir through the cream and coriander. Serve with the rice and naan breads, if you like."
                });

            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Categories)
                .WithMany(c => c.Recipes)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryRecipe",
                    r => r.HasOne<Category>().WithMany().HasForeignKey("CategoriesId"),
                    l => l.HasOne<Recipe>().WithMany().HasForeignKey("RecipesId"),
                    je =>
                    {
                        je.HasKey("RecipesId", "CategoriesId");
                        je.HasData( new { RecipesId = 1, CategoriesId = 4 }, new { RecipesId = 2, CategoriesId = 7 },
                                    new { RecipesId = 3, CategoriesId = 10 }, new { RecipesId = 4, CategoriesId = 3 },
                                    new { RecipesId = 5, CategoriesId = 8 }, new { RecipesId = 6, CategoriesId = 6 });
                    });

            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.Ingredients)
                .WithMany(i => i.Recipes)
                .UsingEntity<Dictionary<string, object>>(
                    "IngredientRecipe",
                    r => r.HasOne<Ingredient>().WithMany().HasForeignKey("IngredientsId"),
                    l => l.HasOne<Recipe>().WithMany().HasForeignKey("RecipesId"),
                    je =>
                    {
                        je.HasKey("RecipesId", "IngredientsId");
                        je.HasData( new { RecipesId = 1, IngredientsId = 1 }, new { RecipesId = 1, IngredientsId = 2 }, new { RecipesId = 1, IngredientsId = 3 },
                                    new { RecipesId = 1, IngredientsId = 4 }, new { RecipesId = 1, IngredientsId = 5 }, new { RecipesId = 1, IngredientsId = 6 },
                                    new { RecipesId = 1, IngredientsId = 7 }, new { RecipesId = 1, IngredientsId = 8 }, new { RecipesId = 1, IngredientsId = 9 },
                                    new { RecipesId = 1, IngredientsId = 10 }, new { RecipesId = 2, IngredientsId = 11 }, new { RecipesId = 2, IngredientsId = 2 },
                                    new { RecipesId = 2, IngredientsId = 12 }, new { RecipesId = 2, IngredientsId = 13 }, new { RecipesId = 2, IngredientsId = 14 },
                                    new { RecipesId = 2, IngredientsId = 15 }, new { RecipesId = 2, IngredientsId = 8 },
                                    new { RecipesId = 2, IngredientsId = 17 }, new { RecipesId = 2, IngredientsId = 18 }, new { RecipesId = 2, IngredientsId = 19 },
                                    new { RecipesId = 2, IngredientsId = 20 }, new { RecipesId = 2, IngredientsId = 21 }, new { RecipesId = 2, IngredientsId = 22 },
                                    new { RecipesId = 2, IngredientsId = 23 }, new { RecipesId = 2, IngredientsId = 24 }, new { RecipesId = 3, IngredientsId = 25 },
                                    new { RecipesId = 3, IngredientsId = 26 }, new { RecipesId = 3, IngredientsId = 27 }, new { RecipesId = 3, IngredientsId = 28 },
                                    new { RecipesId = 3, IngredientsId = 29 }, new { RecipesId = 3, IngredientsId = 30 }, new { RecipesId = 3, IngredientsId = 31 },
                                    new { RecipesId = 3, IngredientsId = 32 }, new { RecipesId = 3, IngredientsId = 33 }, new { RecipesId = 3, IngredientsId = 34 },
                                    new { RecipesId = 3, IngredientsId = 35 }, new { RecipesId = 3, IngredientsId = 36 }, new { RecipesId = 3, IngredientsId = 37 },
                                    new { RecipesId = 3, IngredientsId = 38 }, new { RecipesId = 4, IngredientsId = 10 }, new { RecipesId = 4, IngredientsId = 39 },
                                    new { RecipesId = 4, IngredientsId = 40 }, new { RecipesId = 4, IngredientsId = 41 }, new { RecipesId = 4, IngredientsId = 42 },
                                    new { RecipesId = 4, IngredientsId = 43 }, new { RecipesId = 4, IngredientsId = 44 }, new { RecipesId = 4, IngredientsId = 45 },
                                    new { RecipesId = 4, IngredientsId = 46 }, new { RecipesId = 4, IngredientsId = 47 }, new { RecipesId = 4, IngredientsId = 48 },
                                    new { RecipesId = 4, IngredientsId = 49 }, new { RecipesId = 5, IngredientsId = 50 }, new { RecipesId = 5, IngredientsId = 39 },
                                    new { RecipesId = 5, IngredientsId = 51 }, new { RecipesId = 5, IngredientsId = 52 }, new { RecipesId = 5, IngredientsId = 53 },
                                    new { RecipesId = 5, IngredientsId = 54 }, new { RecipesId = 5, IngredientsId = 55 }, new { RecipesId = 5, IngredientsId = 56 },
                                    new { RecipesId = 5, IngredientsId = 57 }, new { RecipesId = 5, IngredientsId = 5 }, new { RecipesId = 5, IngredientsId = 58 },
                                    new { RecipesId = 5, IngredientsId = 59 }, new { RecipesId = 5, IngredientsId = 60 }, new { RecipesId = 5, IngredientsId = 61 },
                                    new { RecipesId = 6, IngredientsId = 10 }, new { RecipesId = 6, IngredientsId = 62 }, new { RecipesId = 6, IngredientsId = 5 },
                                    new { RecipesId = 6, IngredientsId = 40 }, new { RecipesId = 6, IngredientsId = 63 }, new { RecipesId = 6, IngredientsId = 64 },
                                    new { RecipesId = 6, IngredientsId = 44 }, new { RecipesId = 6, IngredientsId = 65 }, new { RecipesId = 6, IngredientsId = 66 },
                                    new { RecipesId = 6, IngredientsId = 67 }, new { RecipesId = 6, IngredientsId = 68 }, new { RecipesId = 6, IngredientsId = 69 },
                                    new { RecipesId = 6, IngredientsId = 70 }, new { RecipesId = 6, IngredientsId = 71 });
                    });
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is Recipe && e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((Recipe)entry.Entity).CreateDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        ((Recipe)entry.Entity).ModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}
