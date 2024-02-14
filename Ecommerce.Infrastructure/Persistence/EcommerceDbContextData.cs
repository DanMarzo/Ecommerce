using Ecommerce.Application.Models.Authorization;
using Ecommerce.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce.Infrastructure.Persistence;

public class EcommerceDbContextData
{
    public static async Task LoadDataAsync(EcommerceDbContext context, UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Role.ADMIN));
                await roleManager.CreateAsync(new IdentityRole(Role.USER));
            }

            if (!userManager.Users.Any())
            {
                Usuario usuarioAdmin = new()
                {
                    Nome = "Dan",
                    Sobrenome = "Marzo",
                    Email = "marzogildan@gmail.com",
                    UserName = "DanMarzo",
                    Telefone = "11932005778",
                    AvatarURL = "https://avatars.githubusercontent.com/u/88063716?v=4",
                };
                await userManager.CreateAsync(usuarioAdmin, "1q2w3e4r@AD");
                await userManager.AddToRoleAsync(usuarioAdmin, Role.ADMIN);

                Usuario usuario = new()
                {
                    Nome = "Thiagao",
                    Sobrenome = "Roque",
                    Email = "boladon@gmail.com",
                    UserName = "Thiagao",
                    Telefone = "11932005778",
                    AvatarURL = "https://avatars.githubusercontent.com/u/102858868?v=4",
                };
                await userManager.CreateAsync(usuario, "1q2w3e4r@AD");
                await userManager.AddToRoleAsync(usuario, Role.USER);
            }
            if (!context.Categories!.Any())
            {
                var categoryData = File.ReadAllText("../Infrastructure/Data/category.json");
                var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);
                await context.Categories!.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }
            if (!context.Products!.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/product.json");
                var products = JsonConvert.DeserializeObject<List<Product>>(productsData);
                await context.Products!.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
            if (!context.Images!.Any())
            {
                var imagesData = File.ReadAllText("../Infrastructure/Data/image.json");
                var images = JsonConvert.DeserializeObject<List<Image>>(imagesData);
                await context.Images!.AddRangeAsync(images);
                await context.SaveChangesAsync();
            }

            if (!context.Reviews!.Any())
            {
                var reviewData = File.ReadAllText("../Infrastructure/Data/review.json");
                var reviews = JsonConvert.DeserializeObject<List<Review>>(reviewData);
                await context.Reviews!.AddRangeAsync(reviews);
                await context.SaveChangesAsync();
            }

            if (!context.Countries!.Any())
            {
                var countriesData = File.ReadAllText("../Infrastructure/Data/countries.json");
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
