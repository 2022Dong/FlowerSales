using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace FlowerSales.Models
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Bouquetes" },
                new Category { CategoryId = 2, CategoryName = "Box Flowers" },
                new Category { CategoryId = 3, CategoryName = "Wrapps" },
                new Category { CategoryId = 4, CategoryName = "Single Flower" },
                new Category { CategoryId = 5, CategoryName = "Additional" });

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Flowers in the city", StoreLocation = "Canning Vale", PostCode = 6155, Price = 68, IsAvailable = true },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Gerberas", StoreLocation = "Willeton", PostCode = 6155, Price = 35, IsAvailable = true },
                new Product { ProductId = 3, CategoryId = 1, ProductName = "Aziatic Lilies", StoreLocation = "Palmyra", PostCode = 6123, Price = 33, IsAvailable = true },
                new Product { ProductId = 4, CategoryId = 1, ProductName = "European Lilies", StoreLocation = "Melville", PostCode = 6145, Price = 125, IsAvailable = true },
                new Product { ProductId = 5, CategoryId = 1, ProductName = "Chrisantemum", StoreLocation = "Canninghton", PostCode = 6112, Price = 60, IsAvailable = true },
                new Product { ProductId = 6, CategoryId = 1, ProductName = "Alstroemeria", StoreLocation = "Waikiki", PostCode = 6112, Price = 95, IsAvailable = true },
                new Product { ProductId = 7, CategoryId = 1, ProductName = "Snapdragon small", StoreLocation = "Tuart Hill", PostCode = 6112, Price = 65, IsAvailable = true },
                new Product { ProductId = 8, CategoryId = 1, ProductName = "V-Crocus", StoreLocation = "Willeton", PostCode = 6113, Price = 65, IsAvailable = true },
                new Product { ProductId = 9, CategoryId = 1, ProductName = "Crocus", StoreLocation = "Armadale", PostCode = 6114, Price = 17, IsAvailable = true },
                new Product { ProductId = 10, CategoryId = 2, ProductName = "Calla Lily", StoreLocation = "Aubin Grove", PostCode = 6115, Price = 99, IsAvailable = true },
                new Product { ProductId = 11, CategoryId = 2, ProductName = "Geranium small", StoreLocation = "Darch", PostCode = 6116, Price = 0, IsAvailable = false },
                new Product { ProductId = 12, CategoryId = 2, ProductName = "Grunge Skater Jeans", StoreLocation = "Jonndana", PostCode = 6117, Price = 68, IsAvailable = true },
                new Product { ProductId = 13, CategoryId = 2, ProductName = "Geranium Large", StoreLocation = "Joonedaloop", PostCode = 6112, Price = 125, IsAvailable = true },
                new Product { ProductId = 14, CategoryId = 2, ProductName = "Stretchy Dance Pants", StoreLocation = "GEralton", PostCode = 6118, Price = 55, IsAvailable = true },
                new Product { ProductId = 15, CategoryId = 2, ProductName = "Alstroemeria", StoreLocation = "Piara Waters", PostCode = 6121, Price = 22, IsAvailable = false },
                new Product { ProductId = 16, CategoryId = 2, ProductName = "Gerberas", StoreLocation = "Byford", PostCode = 6132, Price = 95, IsAvailable = true },
                new Product { ProductId = 17, CategoryId = 2, ProductName = "Marigold", StoreLocation = "Dianella", PostCode = 6342, Price = 17, IsAvailable = true },
                new Product { ProductId = 18, CategoryId = 3, ProductName = "Azalea", StoreLocation = "Leong", PostCode = 6123, Price = 2.8M, IsAvailable = true },
                new Product { ProductId = 19, CategoryId = 3, ProductName = "Lemon-LAzalea", StoreLocation = "Fremantle", PostCode = 6124, Price = 2.8M, IsAvailable = true },
                new Product { ProductId = 20, CategoryId = 3, ProductName = "Zinnia", StoreLocation = "BEaconsfield", PostCode = 6125, Price = 2.8M, IsAvailable = false },
                new Product { ProductId = 21, CategoryId = 3, ProductName = "Peach Zinnia", StoreLocation = "North Freo", PostCode = 6126, Price = 2.8M, IsAvailable = true },
                new Product { ProductId = 22, CategoryId = 3, ProductName = "Raspberry Zinnia", StoreLocation = "Munster", PostCode = 6127, Price = 2.8M, IsAvailable = true },
                new Product { ProductId = 23, CategoryId = 3, ProductName = "Snapdragon big", StoreLocation = "Coogee", PostCode = 6128, Price = 2.8M, IsAvailable = true },
                new Product { ProductId = 24, CategoryId = 4, ProductName = " Petunia", StoreLocation = "South Freo", PostCode = 6129, Price = 24.99M, IsAvailable = true },
                new Product { ProductId = 25, CategoryId = 5, ProductName = "Dahlia (long lasting)", StoreLocation = "City", PostCode = 6112, Price = 9.99M, IsAvailable = true },
                new Product { ProductId = 26, CategoryId = 5, ProductName = "Dahlia", StoreLocation = "West Perth", PostCode = 6130, Price = 12.49M, IsAvailable = true },
                new Product { ProductId = 27, CategoryId = 5, ProductName = "Orchid domestic", StoreLocation = "East Perth", PostCode = 6131, Price = 13.99M, IsAvailable = true },
                new Product { ProductId = 28, CategoryId = 5, ProductName = "Orchid Expensive", StoreLocation = "Bentley", PostCode = 6132, Price = 12.49M, IsAvailable = true },
                new Product { ProductId = 29, CategoryId = 5, ProductName = "Marigold", StoreLocation = "Carslie", PostCode = 6133, Price = 9.99M, IsAvailable = true },
                new Product { ProductId = 30, CategoryId = 5, ProductName = "Gardenia type C", StoreLocation = "Lathlain", PostCode = 6134, Price = 11.99M, IsAvailable = true },
                new Product { ProductId = 31, CategoryId = 5, ProductName = "Gardenia type-B", StoreLocation = "Booragoon", PostCode = 6135, Price = 12.99M, IsAvailable = true },
                new Product { ProductId = 32, CategoryId = 5, ProductName = "Gardenia", StoreLocation = "Applecross", PostCode = 6136, Price = 9.99M, IsAvailable = true },
                new Product { ProductId = 33, CategoryId = 5, ProductName = "Calla Lily", StoreLocation = "Rockyngham", PostCode = 6001, Price = 12.49M, IsAvailable = true });
        }
    }
}
