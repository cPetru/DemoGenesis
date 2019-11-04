using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using ContactsApi.Repositories;
using ContactsApi.Models;

namespace ContactsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : EntityController<Employee>
    {
        public EmployeeController(IEntityRepository<Employee> repo, ILogger<EntityController<Employee>> logger) : base(repo, logger)
        {
        }
    }

}
