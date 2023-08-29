using Shared.Models.Dtos;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;

namespace Shared.Contracts
{
    [ServiceContract]
    public interface ICustomerContract
    {
        [OperationContract]
        IEnumerable<Customer> GetAllCustomers();

        [OperationContract]
        string GetAllCustomersAsJson();
    }
}
