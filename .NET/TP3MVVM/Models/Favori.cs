using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3MVVM.Models
{
    class Favori
    {
        public int CompteId { get; set; }

        public int FilmId { get; set; }

        public string Commentaire { get; set; }

        public virtual Compte CompteFavori { get; set; }

        public virtual Film FilmFavori { get; set; }
    }
}
