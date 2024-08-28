namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Catalog): IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Products);

public class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductByCategoryHandler> _logger) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetProductByCategoryHandler.Handle calling product using category{@Query}", query);

        var products = await session.Query<Product>()
            .Where(p => p.Catalog.Contains(query.Catalog))
            .ToListAsync();

        return new GetProductByCategoryResult(products);
    }
}

