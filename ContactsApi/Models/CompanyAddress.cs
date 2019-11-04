using System;

namespace ContactsApi.Models
{
    public class CompanyAddress
    {
        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}