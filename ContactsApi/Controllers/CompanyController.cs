using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ContactsApi.Repositories;
using ContactsApi.Models;

namespace ContactsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : EntityController<Company>
    {
        private ICompanyRepository companyRepo;
        public CompanyController(ICompanyRepository companyRepo, ILogger<CompanyController> logger) : base(companyRepo, logger)
        {
            this.companyRepo = companyRepo;
        }


        [HttpPost("{companyId}/MainAddress/{addressId}")]
        public async Task<Company> SetMainAddress(Guid companyId, Guid addressId)
        {
            await this.companyRepo.SetMainAddress(companyId, addressId);
            return await this.GetById(companyId);
        }

        [HttpPost("{companyId}/address/{addressId}")]
        public async Task<Company> AddAddress(Guid companyId, Guid addressId)
        {
            await this.companyRepo.AddAddress(companyId, addressId);
            return await this.GetById(companyId);
        }

        [HttpPost("{companyId}/contact/{contactId}")]
        public async Task<Company> AddContact(Guid companyId, Guid contactId)
        {
            await this.companyRepo.AddContact(companyId, contactId);
            return await this.GetById(companyId);
        }

        [HttpDelete("{companyId}/contact/{contactId}")]
        public async Task<Company> DeleteContact(Guid companyId, Guid contactId)
        {
            await this.companyRepo.RemoveContact(companyId, contactId);
            return await this.GetById(companyId);
        }

    }
}
