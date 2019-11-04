using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ContactsApi.Repositories;
using ContactsApi.Models;

namespace ContactsApi.Controllers
{
    public abstract class EntityController<TEntity> : ControllerBase
                        where TEntity : BaseEntity, new()
    {
        protected readonly IEntityRepository<TEntity> entityRepo;
        protected readonly ILogger<EntityController<TEntity>> logger;

        public EntityController(IEntityRepository<TEntity> repo, ILogger<EntityController<TEntity>> logger)
        {
            this.entityRepo = repo;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.entityRepo.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<TEntity> GetById(Guid id)
        {
            return await this.entityRepo.GetById(id);
        }

        [HttpPost]
        public async Task<TEntity> Create([FromBody] TEntity address)
        {
            return await this.entityRepo.Create(address);
        }

        [HttpPut("{id}")]
        public async Task<TEntity> Update(Guid id, [FromBody] TEntity address)
        {
            return await this.entityRepo.Update(id, address);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await this.entityRepo.Delete(id);
            return success ? (StatusCodeResult)base.NoContent() : base.NotFound();
        }
    }
}
