using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTP3.Models.EntityFramework;

namespace WSTP3.Repository
{
    public interface IFavoriRepository : IDataRepository<Favori>
    {
        Task<ActionResult<List<Favori>>> GetFavorisByCompteIdAsync(int id);
    }
}
