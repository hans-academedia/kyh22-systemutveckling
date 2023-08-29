using Shared.Models.Dtos;
using System.Diagnostics;

namespace Shared.Models.Entities;

public class CustomerEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }

    public static implicit operator Customer(CustomerEntity entity)
    {
        try
        {
            return new Customer
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
