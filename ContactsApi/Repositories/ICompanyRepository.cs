using ContactsApi.Models;
using System;
using System.Threading.Tasks;

namespace ContactsApi.Repositories
{
    public interface ICompanyRepository : IEntityRepository<Company>
    {
        Task<bool> SetMainAddress(Guid companyId, Guid addressId);
        Task<bool> AddAddress(Guid companyId, Guid addressId);
        Task<bool> AddContact(Guid companyId, Guid contactId);
        Task<bool> RemoveContact(Guid companyId, Guid contactId);
    }
}
