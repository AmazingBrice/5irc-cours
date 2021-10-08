using WSTP3.Models.EntityFramework;
using WSTP3.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSTP3.Models.DataManager
{
    public class CompteManager : IDataRepository<Compte>
    {
        readonly TP3DBContext _context;

        public CompteManager(TP3DBContext context)
        {
            _context = context;
        }

        public CompteManager()
        {
        }

        public async Task<ActionResult<IEnumerable<Compte>>> GetAllAsync()
        {
            return await _context.Comptes.ToListAsync();
        }

        public async Task<ActionResult<Compte>> GetByIdAsync(int id)
        {
            return await _context.Comptes
                .FirstOrDefaultAsync(e => e.CompteId == id);
        }

        public async Task<ActionResult<Compte>> GetByStringAsync(string mail)
        {
            return await _context.Comptes
                .FirstOrDefaultAsync(e => e.Mel.ToUpper() == mail.ToUpper());
        }

        public async Task<Compte> AddAsync(Compte entity)
        {
            await _context.Comptes.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(Compte compte, Compte entity)
        {
            _context.Entry(compte).State = EntityState.Modified;

            compte.CompteId = entity.CompteId;
            compte.Nom = entity.Nom;
            compte.Prenom = entity.Prenom;
            compte.Mel = entity.Mel;
            compte.Rue = entity.Rue;
            compte.CodePostal = entity.CodePostal;
            compte.Ville = entity.Ville;
            compte.Pays = entity.Pays;
            compte.Latitude = entity.Latitude;
            compte.Longitude = entity.Longitude;
            compte.Pwd = entity.Pwd;
            compte.TelPortable = entity.TelPortable;
            compte.FavorisCompte = entity.FavorisCompte;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Compte compte)
        {
            _context.Comptes.Remove(compte);
            await _context.SaveChangesAsync();
        }
    }
}
