using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WSTP3.Models.EntityFramework
{
    [Table("T_J_FAVORI_FAV")]
    public partial class Favori
    {

        [Key]
        [Column("CPT_ID")]
        public int CompteId { get; set; }

        [Key]
        [Column("FLM_ID")]
        public int FilmId { get; set; }

        [Column("FAV_COMMENTAIRE")]
        [StringLength(500)]
        public string Commentaire { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Compte))]
        [InverseProperty("FavorisCompte")]
        public virtual Compte CompteFavori { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Film))]
        [InverseProperty("FavorisFilm")]
        public virtual Film FilmFavori { get; set; }
    }
}
