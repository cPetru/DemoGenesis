using System.Collections.Generic;
namespace ContactsApi.Models
{
    public class Company : BaseEntity, IHaveMainAddress, IHaveVAT
    {
        public string Name { get; set; }
        public string VAT { get; set; }
        public Address MainAddress { get; set; }
        public ICollection<CompanyAddress> Offices { get; set; }
        public ICollection<Collaboration> Contacts { get; set; }
    }
}