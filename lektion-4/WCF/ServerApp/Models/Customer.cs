using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    [DataContract]
    internal class Customer
    {
        public Customer()
        {
            Name = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
