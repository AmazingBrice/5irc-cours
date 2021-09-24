using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WSTP3.Models.EntityFramework
{
    [Table("T_E_FILM_FLM")]
    public partial class Film
    {

        [Key]
        [Column("FLM_ID")]
        public int FilmId { get; set; }

        [Column("FLM_TITRE")]
        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        public string Titre { get; set; }

        [Column("FLM_SYNOPSIS")]
        [StringLength(500)]
        public string Synopsys { get; set; }

        [Column("FLM_DATEPARUTION")]
        [Required]
        public DateTime DateParution { get; set; }

        [Required]
        [Column("FLM_DUREE")]
        public decimal Duree { get; set; }

        [Column("FLM_GENRE")]
        [StringLength(30)]
        [Required(AllowEmptyStrings = false)]
        public string Genre { get; set; }

        [Url]
        [Column("FLM_URLPHOTO")]
        [StringLength(200)]
        public string UrlPhoto { get; set; }


        [InverseProperty(nameof(Favori.FilmFavori))]
        public virtual ICollection<Favori> FavorisFilm { get; set; }
    }
}
