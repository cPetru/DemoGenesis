using ContactsApi.Models;
using ContactsApi.DataContext;
using System;
using System.Threading.Tasks;

namespace ContactsApi.Repositories
{
    public class CompanyRepository : EntityRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        { }

        public async Task<bool> SetMainAddress(Guid companyId, Guid addressId)
        {
            var company = await base.EntitySet.FindAsync(companyId);
            var address = await base.context.Set<Address>().FindAsync(addressId);
            if (company == null || address == null)
                return false;
            company.MainAddress = address;
            var count = await base.context.SaveChangesAsync();
            return count > 0;
        }

        public async Task<bool> AddAddress(Guid companyId, Guid addressId)
        {
            await base.context.CompanyAddresses.AddAsync(new CompanyAddress() { CompanyId = companyId, AddressId = addressId });
            var count = await base.context.SaveChangesAsync();
            return count > 0;
        }

        public async Task<bool> AddContact(Guid companyId, Guid contactId)
        {
            await base.context.Collaboration.AddAsync(new Collaboration { CompanyId = companyId, ContactId = contactId });
            var count = await base.context.SaveChangesAsync();
            return count > 0;
        }

        public async Task<bool> RemoveContact(Guid companyId, Guid contactId)
        {
            var item = await base.context.Collaboration.FindAsync(companyId, contactId);
            if (item == null)
                return false;
            base.context.Collaboration.Remove(item);
            var count = await context.SaveChangesAsync();
            return count > 0;
        }


    }

}
