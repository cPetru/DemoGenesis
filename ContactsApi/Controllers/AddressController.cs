using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using ContactsApi.Repositories;
using ContactsApi.Models;

namespace ContactsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : EntityController<Address>
    {
        public AddressController(IEntityRepository<Address> repo, ILogger<EntityController<Address>> logger) : base(repo, logger)
        {
        }
    }
}
