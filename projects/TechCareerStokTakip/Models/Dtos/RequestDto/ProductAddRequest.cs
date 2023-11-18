using Models.Entities;

namespace Models.Dtos.RequestDto;

public record ProductAddRequest(string Name, int Stock, decimal Price, int CategoryId)
{
    public static Product ConvertToEntity(ProductAddRequest request)
    {
     return new Product
        {
            Name = request.Name,
            Stock = request.Stock,
            Price = request.Price,
            CategoryId = request.CategoryId
        };
    }
}
