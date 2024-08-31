using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
               return;

            session.Store<Product>(GetConfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetConfiguredProducts() => new List<Product>() 
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "IPhone X",
                Description = "this iphone is the biggest company change in it's production",
                Catalog = new List<string>{"Smart Phone"},
                Price = 265.00m,
                ImageFile = "IPhone.png"
            },

            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung 10",
                Description = "this samsung phone is one the biggest change in it's features in the world",
                Catalog = new List<string> {"Smart Phone"},
                Price = 1250.60m,
                ImageFile = "SamsungPhone.png"
            },
            
        };
    }
}
