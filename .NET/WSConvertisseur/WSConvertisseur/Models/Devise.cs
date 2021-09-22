using System;
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
        public string Name { get; set; }
        public double Rate { get; set; }

        public Devise()
        {
        }

        public Devise(int id, string name, double rate)
        {
            this.Id = id;
            this.Name = name;
            this.Rate = rate;
        }
    }
}
