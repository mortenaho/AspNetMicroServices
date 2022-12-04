using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Data;

public class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> mongoCollection)
    {
        var exist = mongoCollection.Find(p => true).Any();
        if (!exist)
        {
            mongoCollection.InsertManyAsync(GetPreConfigureProduct());
        }
    }

    public static IEnumerable<Product> GetPreConfigureProduct()
    {
        return new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Category = "Computers",
                Description = "description",
                Name = "Loptop Asus k556",
                Price = 2500000,
                Summery = "No Summery"
            },
            new Product()
            {
                Id =2,
                Category = "Computers",
                Description = "description",
                Name = "MacBook Pro",
                Price = 950000000,
                Summery = "No Summery"
            },
            new Product()
            {
                Id =3,
                Category = "Mobile",
                Description = "description",
                Name = "Samsung a21",
                Price = 87000,
                Summery = "No Summery"
            }
        };
    }
}