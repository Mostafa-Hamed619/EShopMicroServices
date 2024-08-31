namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Catalog): IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Products);

public class GetProductByCategoryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {

        var products = await session.Query<Product>()
            .Where(p => p.Catalog.Contains(query.Catalog))
            .ToListAsync();

        return new GetProductByCategoryResult(products);
    }
}

