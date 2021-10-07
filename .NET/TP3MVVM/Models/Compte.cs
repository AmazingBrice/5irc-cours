using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3MVVM.Models
{
    class Compte
    {
        public int CompteId { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string TelPortable { get; set; }

        public string Mel { get; set; }

        public string Pwd { get; set; }

        public string Rue { get; set; }

        public string CodePostal { get; set; }

        public string Ville { get; set; }

        public string Pays { get; set; }

        public float? Latitude { get; set; }

        public float? Longitude { get; set; }

        public DateTime DateCreation { get; set; }

        public virtual ICollection<Favori> FavorisCompte { get; set; }
    }
}
