using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipesApp.DAL.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameIngredient = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Serving = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    CookingTime = table.Column<int>(type: "int", nullable: false),
                    Preparation = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryRecipe",
                columns: table => new
                {
                    RecipesId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRecipe", x => new { x.RecipesId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_CategoryRecipe_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientRecipe",
                columns: table => new
                {
                    RecipesId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientRecipe", x => new { x.RecipesId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_IngredientRecipe_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Appetizers" },
                    { 10, "Desserts" },
                    { 8, "Vegetarian" },
                    { 7, "Pasta" },
                    { 6, "Seafood" },
                    { 9, "Salads" },
                    { 4, "Chicken" },
                    { 3, "Beef" },
                    { 2, "Soups" },
                    { 5, "Pork" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "NameIngredient" },
                values: new object[,]
                {
                    { 47, "beef" },
                    { 52, "flour tortillas" },
                    { 51, "bunch coriander" },
                    { 50, "can black beans" },
                    { 49, "parsley" },
                    { 48, "cornflour" },
                    { 46, "beef stock cubes" },
                    { 41, "carrots" },
                    { 44, "tomato purée" },
                    { 43, "thyme" },
                    { 42, "bay leaves" },
                    { 53, "avocado or tub guacamole" },
                    { 40, "rapeseed oil" },
                    { 39, "celery sticks" },
                    { 45, "worcestershire sauce" },
                    { 54, "soured cream" },
                    { 59, "smoked paprika" },
                    { 56, "oil" },
                    { 71, "coriander" },
                    { 70, "double cream" },
                    { 69, "raw king prawns" },
                    { 68, "ground almonds" },
                    { 67, "brown basmati rice" },
                    { 66, "cardamom pods" },
                    { 65, "light brown soft sugar" },
                    { 64, "tomatoes" },
                    { 63, "tikka curry paste" },
                    { 62, "ginger" },
                    { 61, "lime" },
                    { 60, "ground cumin" },
                    { 38, "white chocolate" },
                    { 58, "chilli powder" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "NameIngredient" },
                values: new object[,]
                {
                    { 57, "red onion" },
                    { 55, "red or yellow pepper" },
                    { 37, "icing sugar" },
                    { 34, "ground ginger" },
                    { 35, "cinnamon" },
                    { 14, "celery" },
                    { 13, "kosher salt" },
                    { 12, "beef chuck" },
                    { 11, "pancetta or salt pork" },
                    { 10, "onion" },
                    { 9, "whole chicken" },
                    { 36, "bicarbonate of soda" },
                    { 8, "ground black pepper" },
                    { 6, "salt" },
                    { 5, "garlic" },
                    { 4, "red wine vinegar" },
                    { 3, "fresh oregano leaves" },
                    { 2, "olive oil" },
                    { 1, "fresh parsley" },
                    { 7, "rede pepper flakes" },
                    { 17, "tomato paste" },
                    { 15, "carrot" },
                    { 19, "white wine" },
                    { 33, "fine sea salt" },
                    { 32, "syrup" },
                    { 31, "milk" },
                    { 30, "large eggs" },
                    { 18, "bay leaf" },
                    { 28, "black treacle" },
                    { 27, "muscovado sugar" },
                    { 29, "golden syrup" },
                    { 25, "unsalted butter" },
                    { 24, "freshly grated Parmigiano-Reggiano" },
                    { 23, "cayenne pepper" },
                    { 22, "fresh marjoram leaves" },
                    { 21, "rigatoni" },
                    { 20, "yellow onions" },
                    { 26, "self-raising flour" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookingTime", "CreateDate", "Difficulty", "ModifiedDate", "Preparation", "Serving", "Title" },
                values: new object[,]
                {
                    { 5, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "To make the fajita mix, take two or three strips from each colour of pepper and finely chop them. Set aside. Heat the oil in a frying pan and fry the remaining pepper strips and the onion until soft and starting to brown at the edges. Cool slightly and mix in the chopped raw peppers. Add the garlic and cook for 1 min, then add the spices and stir. Cook for a couple of mins more until the spices become aromatic, then add half the lime juice and season. Transfer to a dish, leaving any juices behind, and keep warm. Tip the black beans into the same pan, then add the remaining lime juice and plenty of seasoning. Stir the beans around the pan to warm them through and help them absorb any flavours of the fajita mix, then stir through the coriander. Warm the tortillas in a microwave or in a low oven, then wrap them so they don’t dry out. Serve the tortillas with the fajita mix, beans, avocado and soured cream for everyone to help themselves.", 4, "Vegetarian fagitas" },
                    { 1, 1575, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Combine parsley, 2 1/2 tablespoons olive oil, oregano, vinegar, garlic, salt, red pepper flakes, and black pepper in a bowl; mix the chimichurri thoroughly. Place chicken on a cutting board and remove the backbone using kitchen shears. Press down on the breast with the heel of your hand to flatten. Loosen the skin of the chicken carefully and rub the chimichurri underneath, distributing it evenly. Wrap the chicken in plastic wrap and refrigerate for 24 hours. Allow chicken to come to room temperature for no more than 1 hour before baking. Preheat oven to 450 degrees F (230 degrees C). Rub 1 teaspoon olive oil over the chicken; season with salt and pepper. Place onion in a cast-iron skillet. Pour chicken broth over onion. Place seasoned chicken on top. Bake in the preheated oven until no longer pink at the bone and the juices run clear, about 45 minutes. An instant-read thermometer inserted into the thickest part of the meat, near the bone, should read 165 degrees F (74 degrees C). Allow chicken to rest in a warm area for 10 minutes before slicing.", 6, "Chimichurri Baked Chicken" },
                    { 2, 600, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heat oil in a large pot over medium heat. Cook pancetta until most of fat is rendered out, about 6 minutes. Remove cooked pancetta with a slotted spoon and save. Raise heat to high and transfer meat to the pot. Season with salt. Cook and stir until liquid releases from beef and begins to evaporate, and meat browns, 10 to 15 minutes. Reduce heat to medium-high. Add celery, carrots, reserved cooked pancetta, salt and pepper. Cook and stir about 5 minutes. Add a heaping tablespoon of tomato paste, bay leaf, and white wine. Cook and stir, scraping up the brownings from the bottom of the pan, 2 to 3 minutes. Add sliced onions. Reduce heat to medium. Cover pot and cook 30 minutes without stirring. After 30 minutes, stir onions and meat until well mixed. Cover again, and cook another 30 minutes. Stir. Reduce heat to low and cook uncovered 8 to 10 hours, stirring occasionally. Skim off fat as mixture cooks. If sauce seems to reduce too much, add water or broth as needed to maintain a sauce-like consistency. Cook until beef and onions seem to melt into each other.Bring a large pot of lightly salted water to a boil. Cook rigatoni in the boiling water, stirring occasionally until just barely al dente, 10 to 12 minutes. Drain. Add rigatoni to the sauce and cook until heated through. Serve topped with a pinch of marjoram and freshly grated Parmigiano-Reggiano cheese.", 8, "Rigatoni alla Genovese" },
                    { 3, 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heat the oven to 180C/160C fan/gas 4. Melt 1 tbsp butter in a small pan, then stir in ½ tbsp flour to create a wet paste. Brush it over the inside of a 9-inch bundt tin. Put the remaining butter, sugar, treacle and golden syrup in a pan set over a medium heat and stir until everything has melted together. Leave to cool a little. Pour the mixture into a large bowl and whisk in the eggs and milk. Fold in the stem ginger, remaining flour, salt, ground ginger, cinnamon and bicarb. Tip into the prepared tin and bake for 40-45 mins, or until firm to the touch. Leave to cool for 10 mins in the tin, then turn out onto a wire rack to cool completely. To make the icing, whisk the milk, ginger syrup and icing sugar together. Melt the chocolate in a heatproof bowl in the microwave in 1-min bursts. Leave to cool a little, then whisk into the milk mixture. Spoon the icing over the cake, then decorate with the crystallised ginger pieces.", 12, "Ginger & white chocolate cake" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookingTime", "CreateDate", "Difficulty", "ModifiedDate", "Preparation", "Serving", "Title" },
                values: new object[] { 4, 260, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fry the onion and celery in 1 tbsp oil over a low heat until they start to soften – about 5 mins. Add the carrots, bay and thyme, fry for 2 mins, stir in the purée and Worcestershire sauce, add 600ml boiling water, stir and tip everything into a slow cooker. Crumble over the stock cubes or add the stock pots and stir, then season with pepper (don’t add salt as the stock may be salty). Clean out the frying pan and fry the beef in the remaining oil in batches until it is well browned, then tip each batch into the slow cooker. Cook on low for 8-10 hrs, or on high for 4 hrs. If you want to thicken the gravy, mix the cornflour with a splash of cold water to make a paste, then stir in 2 tbsp of the liquid from the slow cooker. Tip back into the slow cooker, stir and cook for a further 30 mins on high. Stir in the parsley and season again to taste. Serve with mash, if you like. Leave to cool before freezing.", 12, "Slow-cooker beef stew" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookingTime", "CreateDate", "Difficulty", "ModifiedDate", "Preparation", "Serving", "Title" },
                values: new object[] { 6, 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Put the onion, ginger and garlic in a food processor and blitz to a smooth paste. Heat the oil in a large flameproof casserole dish or pan over a medium heat. Add the onion paste and fry for 8 mins or until lightly golden. Stir in the curry paste and fry for 1 min more. Add the tomatoes, tomato purée, sugar and cardamom pods. Bring to a simmer and cook, covered, for another 10 mins. Cook the rice following pack instructions. Scoop the cardamom out of the curry sauce and discard, then blitz with a hand blender, or in a clean food processor. Return to the pan, add the almonds and prawns, and cook for 5 mins. Season to taste and stir through the cream and coriander. Serve with the rice and naan breads, if you like.", 4, "Prawn tikka masala" });

            migrationBuilder.InsertData(
                table: "CategoryRecipe",
                columns: new[] { "CategoriesId", "RecipesId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 6, 6 },
                    { 8, 5 },
                    { 10, 3 },
                    { 7, 2 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "IngredientRecipe",
                columns: new[] { "IngredientsId", "RecipesId" },
                values: new object[,]
                {
                    { 6, 1 },
                    { 55, 5 },
                    { 54, 5 },
                    { 53, 5 },
                    { 52, 5 },
                    { 51, 5 },
                    { 39, 5 },
                    { 50, 5 },
                    { 56, 5 },
                    { 2, 1 },
                    { 48, 4 },
                    { 47, 4 },
                    { 46, 4 },
                    { 45, 4 },
                    { 44, 4 },
                    { 43, 4 },
                    { 42, 4 },
                    { 49, 4 },
                    { 41, 4 },
                    { 57, 5 },
                    { 58, 5 },
                    { 69, 6 },
                    { 68, 6 },
                    { 67, 6 },
                    { 66, 6 },
                    { 65, 6 },
                    { 44, 6 },
                    { 64, 6 },
                    { 5, 5 },
                    { 63, 6 },
                    { 5, 6 },
                    { 62, 6 },
                    { 10, 6 },
                    { 1, 1 },
                    { 61, 5 },
                    { 60, 5 }
                });

            migrationBuilder.InsertData(
                table: "IngredientRecipe",
                columns: new[] { "IngredientsId", "RecipesId" },
                values: new object[,]
                {
                    { 59, 5 },
                    { 40, 6 },
                    { 5, 1 },
                    { 40, 4 },
                    { 10, 4 },
                    { 20, 2 },
                    { 19, 2 },
                    { 18, 2 },
                    { 17, 2 },
                    { 8, 2 },
                    { 15, 2 },
                    { 14, 2 },
                    { 21, 2 },
                    { 13, 2 },
                    { 2, 2 },
                    { 11, 2 },
                    { 4, 1 },
                    { 10, 1 },
                    { 9, 1 },
                    { 8, 1 },
                    { 7, 1 },
                    { 12, 2 },
                    { 39, 4 },
                    { 22, 2 },
                    { 24, 2 },
                    { 70, 6 },
                    { 38, 3 },
                    { 37, 3 },
                    { 36, 3 },
                    { 35, 3 },
                    { 34, 3 },
                    { 33, 3 },
                    { 23, 2 },
                    { 32, 3 },
                    { 30, 3 },
                    { 29, 3 },
                    { 28, 3 },
                    { 27, 3 },
                    { 26, 3 },
                    { 25, 3 },
                    { 3, 1 },
                    { 31, 3 }
                });

            migrationBuilder.InsertData(
                table: "IngredientRecipe",
                columns: new[] { "IngredientsId", "RecipesId" },
                values: new object[] { 71, 6 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRecipe_CategoriesId",
                table: "CategoryRecipe",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_Email",
                table: "IdentityUser",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUser_UserName",
                table: "IdentityUser",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientRecipe_IngredientsId",
                table: "IngredientRecipe",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_NameIngredient",
                table: "Ingredients",
                column: "NameIngredient",
                unique: true,
                filter: "[NameIngredient] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CategoryRecipe");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropTable(
                name: "IngredientRecipe");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
