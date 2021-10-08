using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTP3.Models.EntityFramework;

namespace WSTP3.Repository
{
    public interface IFilmRepository : IDataRepository<Film>
    {
        Task<ActionResult<Film>> GetByIdAsync(int id);
        Task<ActionResult<Film>> GetByTitleAsync(string title);
    }
}
