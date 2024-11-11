namespace Catalog.API.Products.GetProducts;

public record GetProductsRequest(int PageNumber = 1, int PageSize = 10);

public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
           {
               var command = request.Adapt<GetProductsQuery>();
               var result = await sender.Send(command);
               var response = result.Adapt<GetProductsResponse>();

               return Results.Ok(response);
           })
           .WithName("GetProduct")
           .Produces<GetProductsResponse>()
           .ProducesProblem(StatusCodes.Status400BadRequest)
           .WithSummary("Get Product")
           .WithDescription("Get Product");
    }
}