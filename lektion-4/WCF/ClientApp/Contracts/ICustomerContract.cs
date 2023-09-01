﻿using ClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Contracts
{
    [ServiceContract]
    internal interface ICustomerContract
    {
        [OperationContract]
        int Create(string json);

        [OperationContract]
        string Get(string email);

        [OperationContract]
        string GetAll();

    }
}
