using COBAShop.Data.Entities;
using COBAShop.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace COBAShop.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
              new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
              new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of eShopSolution" },
              new AppConfig() { Key = "HomeDescription", Value = "This is description of eShopSolution" }
              );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Status.Active
                },
                new Category()
                {
                    Id = 3,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 3,
                    Status = Status.Active,
                },
                new Category()
                {
                    Id = 4,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 4,
                    Status = Status.Active,
                },
                new Category()
                {
                    Id = 5,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 5,
                    Status = Status.Active,
                },
                new Category()
                {
                    Id = 6,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 6,
                    Status = Status.Active,
                }
                 );

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Bánh tráng phơi sương", LanguageId = "vi", SeoAlias = "banh-trang-phoi-suong-tay-ninh", SeoDescription = "Sản phẩm bánh tráng phơi sương", SeoTitle = "Sản phẩm bánh tráng phơi sương" },
                  new CategoryTranslation() { Id = 2, CategoryId = 2, Name = "Bánh tráng dẻo", LanguageId = "vi", SeoAlias = "banh-trang-deo-tay-ninh", SeoDescription = "Sản phẩm bánh tráng dẻo", SeoTitle = "Sản phẩm bánh tráng dẻo" },
                  new CategoryTranslation() { Id = 3, CategoryId = 3, Name = "Bánh tráng cuộn", LanguageId = "vi", SeoAlias = "banh-trang-cuon-tay-ninh", SeoDescription = "Sản phẩm bánh tráng cuộn", SeoTitle = "Sản phẩm bánh tráng cuộn" },
                  new CategoryTranslation() { Id = 4, CategoryId = 4, Name = "Bánh tráng xì-ke", LanguageId = "vi", SeoAlias = "banh-trang-xi-ke-tay-ninh", SeoDescription = "Sản phẩm bánh tráng xì-ke Tây Ninh", SeoTitle = "Sản phẩm bánh tráng xì-ke Tây Ninh" },
                  new CategoryTranslation() { Id = 5, CategoryId = 5, Name = "Muối", LanguageId = "vi", SeoAlias = "muoi-tom-tay-ninh", SeoDescription = "Sản phẩm muối tôm Tây Ninh", SeoTitle = "Sản phẩm muối tôm Tây Ninh" },
                  new CategoryTranslation() { Id = 6, CategoryId = 6, Name = "Nguyên liệu bánh tráng sỉ/lẻ", LanguageId = "vi", SeoAlias = "nguyen-lieu-banh-trang-tay-ninh", SeoDescription = "Nguyên liệu bánh tráng sỉ/lẻ", SeoTitle = "Nguyên liệu bánh tráng sỉ/lẻ" }
                  );

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               Id = 1,
               DateCreated = DateTime.Now,
               OriginalPrice = 100000,
               Price = 200000,
               Stock = 0,
               ViewCount = 0,
           });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Bánh tráng trộn xa tế",
                     LanguageId = "vi",
                     SeoAlias = "banh-trang-tron-xa-te",
                     SeoDescription = "Bánh tráng trộn xa tế",
                     SeoTitle = "Bánh tráng trộn xa tế",
                     Details = "Bánh tráng trộn xa tế",
                     Description = "Bánh tráng trộn xa tế"
                 }
                  );
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );

            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456"),
                SecurityStamp = string.Empty,
                FirstName = "super",
                LastName = "admin",
                Dob = new DateTime(2021, 01, 31)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

            modelBuilder.Entity<Slide>().HasData(
              new Slide() { Id = 1, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 1, Url = "#", Image = "/themes/images/carousel/1.png", Status = Status.Active },
              new Slide() { Id = 2, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 2, Url = "#", Image = "/themes/images/carousel/2.png", Status = Status.Active },
              new Slide() { Id = 3, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 3, Url = "#", Image = "/themes/images/carousel/3.png", Status = Status.Active },
              new Slide() { Id = 4, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 4, Url = "#", Image = "/themes/images/carousel/4.png", Status = Status.Active },
              new Slide() { Id = 5, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 5, Url = "#", Image = "/themes/images/carousel/5.png", Status = Status.Active },
              new Slide() { Id = 6, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 6, Url = "#", Image = "/themes/images/carousel/6.png", Status = Status.Active }
              );
        }
    }
}