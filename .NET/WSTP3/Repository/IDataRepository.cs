using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSTP3.Models.EntityFramework;

namespace WSTP3.Repository
{
    public interface IDataRepository<TEntity>
    {
        Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync();
        Task<ActionResult<TEntity>> GetByIdAsync(int id);
        Task SaveChangesAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity favori, TEntity entity);
        Task DeleteAsync(TEntity favori);
    }
}
