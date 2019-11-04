using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using ContactsApi.Repositories;
using ContactsApi.Models;

namespace ContactsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FrelanceController : EntityController<Freelance>
    {
        public FrelanceController(IEntityRepository<Freelance> repo, ILogger<EntityController<Freelance>> logger) : base(repo, logger)
        {
        }
    }

}
