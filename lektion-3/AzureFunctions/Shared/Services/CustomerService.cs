using Shared.Models.Dtos;
using Shared.Models.Schemas;
using Shared.Repositories;
using System.Diagnostics;

namespace Shared.Services;

public class CustomerService
{
    private readonly CustomerRepository _customerRepository;

    public CustomerService(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> CreateCustomerAsync(CustomerSchema schema)
    {
        try
        {
            var _customer = await _customerRepository.GetAsync(x => x.Email == schema.Email);
            if (_customer == null)
            {
                _customer = await _customerRepository.AddAsync(schema);
                return _customer;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public async Task<Customer> GetCustomerByEmailAsync(string email)
    {
        try
        {
            var _customer = await _customerRepository.GetAsync(x => x.Email == email);
            return _customer ?? null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        try
        {
            var list = new List<Customer>();
            var _customers = await _customerRepository.GetAllAsync();
            foreach (var customer in _customers)
                list.Add(customer);

            return list;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
