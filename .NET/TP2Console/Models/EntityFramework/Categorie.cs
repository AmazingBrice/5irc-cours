using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace TP2Console.Models.EntityFramework
{
    [Table("categorie")]
    public partial class Categorie
    {
        private ILazyLoader _lazyLoader;
        public Categorie(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public Categorie()
        {
            Films = new HashSet<Film>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nom")]
        [StringLength(50)]
        public string Nom { get; set; }
        [Column("description")]
        public string Description { get; set; }

        //[InverseProperty(nameof(Film.CategorieNavigation))]
        //public virtual ICollection<Film> Films { get; set; }

        private ICollection<Film> films; //Doit être écrit de la même façon que la property Films mais en minuscule

        [InverseProperty("CategorieNavigation")]
        public virtual ICollection<Film> Films
        {
            get
            {
                return _lazyLoader.Load(this, ref films);
            }
            set { films = value; }
        }
    }
}
