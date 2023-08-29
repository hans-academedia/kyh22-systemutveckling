using Shared.Models.Entities;
using System.Diagnostics;

namespace Shared.Models.Schemas;

public class CustomerSchema
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }

    public static implicit operator CustomerEntity(CustomerSchema schema)
    {
        try
        {
            return new CustomerEntity
            {
                Name = schema.Name,
                Email = schema.Email,
                PhoneNumber = schema.PhoneNumber ?? null!,
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
