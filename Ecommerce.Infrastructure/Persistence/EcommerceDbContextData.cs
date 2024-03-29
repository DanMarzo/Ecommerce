using Ecommerce.Application.Models.Authorization;
using Ecommerce.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ecommerce.Infrastructure.Persistence;

public class EcommerceDbContextData
{
    public static async Task LoadDataAsync(EcommerceDbContext context, UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(RoleAuthorization.ADMIN));
                await roleManager.CreateAsync(new IdentityRole(RoleAuthorization.USER));
            }

            if (!userManager.Users.Any())
            {
                Usuario usuarioAdmin = new()
                {
                    Nombre = "Dan",
                    Apellido= "Marzo",
                    Email = "marzogildan@gmail.com",
                    UserName = "DanMarzo",
                    Telefono = "11932005778",
                    AvatarURL = "https://avatars.githubusercontent.com/u/88063716?v=4",
                    IsActive = true,
                };
                await userManager.CreateAsync(usuarioAdmin, "1q2w3e4r@AD");
                await userManager.AddToRoleAsync(usuarioAdmin, RoleAuthorization.ADMIN);

                Usuario usuario = new()
                {
                    Nombre = "Thiagao",
                    Apellido = "Roque",
                    Email = "boladon@gmail.com",
                    UserName = "Thiagao",
                    Telefono = "11932005778",
                    AvatarURL = "https://avatars.githubusercontent.com/u/102858868?v=4",
                    IsActive = true,
                };
                await userManager.CreateAsync(usuario, "1q2w3e4r@AD");
                await userManager.AddToRoleAsync(usuario, RoleAuthorization.USER);
            }
            if (!context.Categories!.Any())
            {
                var categoryData = File.ReadAllText("../Ecommerce.Infrastructure/Data/category.json");
                var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);
                await context.Categories!.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }
            if (!context.Products!.Any())
            {
                var productsData = File.ReadAllText("../Ecommerce.Infrastructure/Data/product.json");
                var products = JsonConvert.DeserializeObject<List<Product>>(productsData);
                await context.Products!.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
            if (!context.Images!.Any())
            {
                var imagesData = File.ReadAllText("../Ecommerce.Infrastructure/Data/image.json");
                var images = JsonConvert.DeserializeObject<List<Image>>(imagesData);
                await context.Images!.AddRangeAsync(images);
                await context.SaveChangesAsync();
            }

            if (!context.Reviews!.Any())
            {
                var reviewData = File.ReadAllText("../Ecommerce.Infrastructure/Data/review.json");
                var reviews = JsonConvert.DeserializeObject<List<Review>>(reviewData);
                await context.Reviews!.AddRangeAsync(reviews);
                await context.SaveChangesAsync();
            }

            if (!context.Countries!.Any())
            {
                var countriesData = File.ReadAllText("../Ecommerce.Infrastructure/Data/countries.json");
                var countries = JsonConvert.DeserializeObject<List<Country>>(countriesData);
                await context.Countries!.AddRangeAsync(countries);
                await context.SaveChangesAsync();
            }


        }
        catch (Exception e)
        {
            var logger = loggerFactory.CreateLogger<EcommerceDbContextData>();
            logger.LogError(e.Message);
        }

    }
}
