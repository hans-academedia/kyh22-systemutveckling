using WebApi.Models.Entities;

namespace WebApi.Models.Dtos;

public class ProductDto
{
    public string? EAN { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }

    public static implicit operator ProductEntity(ProductDto dto)
    {
        return new ProductEntity
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Created = DateTime.Now,
            Modified = DateTime.Now
        };
    }

}
