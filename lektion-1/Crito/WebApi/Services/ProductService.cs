using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Repositories;

namespace WebApi.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;

    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }



    public async Task AddAsync(ProductDto dto)
    {
        await _productRepository.AddAsync(dto);
    }
}
