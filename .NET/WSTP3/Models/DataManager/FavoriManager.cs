using WSTP3.Models.EntityFramework;
using WSTP3.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace WSTP3.Models.DataManager
{
    public class FavoriManager : IFavoriRepository
    {
        readonly TP3DBContext _context;

        public FavoriManager(TP3DBContext context)
        {
            _context = context;
        }

        public FavoriManager()
        {
        }

        public async Task<ActionResult<IEnumerable<Favori>>> GetAllAsync()
        {
            return await _context.Favoris.ToListAsync();
        }

        public async Task<ActionResult<List<Favori>>> GetFavorisByCompteIdAsync(int id)
        {
            return await _context.Favoris
                .Where(e => e.CompteId == id)
                .ToListAsync();
        }

        public async Task<ActionResult<Favori>> GetByStringAsync(string commentary)
        {
            return await _context.Favoris
                .FirstOrDefaultAsync(e => e.Commentaire.ToUpper() == commentary.ToUpper());
        }

        public async Task<Favori> AddAsync(Favori entity)
        {
            await _context.Favoris.AddAsync(entity);
            await SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(Favori favori, Favori entity)
        {
            _context.Entry(favori).State = EntityState.Modified;

            favori.CompteId = entity.CompteId;
            favori.FilmId = entity.FilmId;
            favori.Commentaire = entity.Commentaire;

            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Favori favori)
        {
            _context.Favoris.Remove(favori);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task<ActionResult<Favori>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
