using ContactsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContactsApi.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);

        Task<TEntity> Create(TEntity entity);

        Task<TEntity> Update(Guid id, TEntity entity);

        Task<bool> Delete(Guid id);
        Task<bool> Delete(TEntity entity);
    }
}
