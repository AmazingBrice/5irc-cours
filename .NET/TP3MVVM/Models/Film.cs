using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3MVVM.Models
{
    class Film
    {
        public int FilmId { get; set; }

        public string Titre { get; set; }

        public string Synopsys { get; set; }

        public DateTime DateParution { get; set; }

        public decimal Duree { get; set; }

        public string Genre { get; set; }

        public string UrlPhoto { get; set; }

        public virtual ICollection<Favori> FavorisFilm { get; set; }
    }
}
