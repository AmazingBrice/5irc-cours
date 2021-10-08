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
    public class FilmManager : IFilmRepository
    {
        readonly TP3DBContext _context;

        public FilmManager(TP3DBContext context)
        {
            _context = context;
        }

        public FilmManager()
        {
        }

        public async Task<ActionResult<IEnumerable<Film>>> GetAllAsync()
        {
            return await _context.Films.ToListAsync();
        }

        public async Task<ActionResult<Film>> GetByIdAsync(int id)
        {
            return await _context.Films
                .FirstOrDefaultAsync(e => e.FilmId == id);
        }

        public async Task<ActionResult<Film>> GetByTitleAsync(string title)
        {
            return await _context.Films
                .FirstOrDefaultAsync(e => e.Titre.ToUpper() == title.ToUpper());
        }

        public async Task<Film> AddAsync(Film entity)
        {
            await _context.Films.AddAsync(entity);
            await SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(Film film, Film entity)
        {
            _context.Entry(film).State = EntityState.Modified;

            film.FilmId = entity.FilmId;
            film.Titre = entity.Titre;
            film.Synopsys = entity.Synopsys;
            film.DateParution = entity.DateParution;
            film.Duree = entity.Duree;
            film.Genre = entity.Genre;

            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Film film)
        {
            _context.Films.Remove(film);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
