using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientConvertisseurV1.Models
{
    public class Devise
    {
        public int Id { get; set; }
        public string NomDevise { get; set; }
        public double Taux { get; set; }

        public Devise()
        {
        }

        public Devise(int id, string name, double rate)
        {
            Id = id;
            NomDevise = name;
            Taux = rate;
        }
    }
}
