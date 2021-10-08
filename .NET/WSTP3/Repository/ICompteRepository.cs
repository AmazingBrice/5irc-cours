using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTP3.Models.EntityFramework;

namespace WSTP3.Repository
{
    public interface ICompteRepository : IDataRepository<Compte>
    {
        Task<ActionResult<Compte>> GetByIdAsync(int id);
        Task<ActionResult<Compte>> GetByMailAsync(string mail);
    }
}
