using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VT_Lab1.DAL.Data;
using VT_Lab1.DAL.Entities;

namespace VT_Lab1.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
 UserManager<ApplicationUser> userManager,
RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }
            //проверка наличия групп объектов
            if (!context.TileGroups.Any())
            {
                context.TileGroups.AddRange(
                new List<TileGroup>
                {
                    new TileGroup {GroupName="Половая плитка"},
                 new TileGroup {GroupName="Стеновая плитка"},
                 new TileGroup {GroupName="Тротуарная плитка"},
                 new TileGroup {GroupName="Плитка мозаика"},
                 new TileGroup {GroupName="Клинкерная плитка"},
                 new TileGroup {GroupName="Керамогранитная плитка"}

                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Tilees.Any())
            {
                context.Tilees.AddRange(
                new List<Tile>
                {new Tile {TileName="Cersanit",
                Description="18x59 Под дерево",
                Size =0.72, TileGroupId=1, Image="CERSANIT PATINAWOOD БЕЖ РЕЛЬЕФ 18,5X59,8.jpg" },
                new Tile {TileName="Cersanit WOOD",
                Description="18x59 Рисунок дерева(светлая)",
                Size =0.8, TileGroupId=3, Image="CERSANIT SANDWOOD БЕЛЫЙ 18,5X59,8.jpg" },
                new Tile {TileName="MOZ-MIX",
                Description="Черно-белая",Size =0.3, TileGroupId=4, Image="moz-mix.jpg" },
                new Tile {TileName="Skinali",
                Description="Узор",
                Size =0.9, TileGroupId=4, Image="skinali-5866.jpg" },
                new Tile {TileName="Carpet",
                Description="White",
                Size =0.25, TileGroupId=6, Image="Плитка Carpet Silver W M 25х75 NR Satin 1.jpg" }
                });
                await context.SaveChangesAsync();
            }

        }
    }
}
