﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSConvertisseur.Models
{
    public class Devise
    {
        public int Id { get; set; }

        [Required]
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

        public override bool Equals(object result)
        {
            return Id == ((Devise) result).Id && NomDevise == ((Devise)result).NomDevise && Taux == ((Devise)result).Taux;
        }
    }
}
