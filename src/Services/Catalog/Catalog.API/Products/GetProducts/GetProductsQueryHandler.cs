﻿
namespace Catalog.API.Products.GetProducts;

public record GetProductQuery(): IQuery<GetProductResult>;

public record GetProductResult(IEnumerable<Product> Products);

public class GetProductsQueryHandler(IDocumentSession session,ILogger<GetProductResult> _logger) : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetProductQueryHandler cailed {@Query}", query);
        var products =await session.Query<Product>().ToListAsync(cancellationToken);
        return new GetProductResult(products);
    }
}
