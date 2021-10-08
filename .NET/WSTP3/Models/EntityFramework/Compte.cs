using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WSTP3.Models.EntityFramework
{
    [Table("T_E_COMPTE_CPT")]
    [Index(nameof(Mel), IsUnique = true)]
    public partial class Compte
    {

        [Key]
        [Column("CPT_ID")]
        public int CompteId { get; set; }

        [Column("CPT_NOM")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false)]
        public string Nom { get; set; }

        [Column("CPT_PRENOM")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false)]
        public string Prenom { get; set; }

        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Phone number is invalid")]
        [Column("CPT_TELPORTABLE", TypeName = "char(10)")]
        public string TelPortable { get; set; }

        // [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
        [Required(AllowEmptyStrings = false)]
        [Column("CPT_MEL")]
        public string Mel { get; set; }

        [RegularExpression(@"^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9])))(?=.{6,})$", ErrorMessage = "Password is invalid")]
        [Column("CPT_PWD")]
        [StringLength(64)]
        public string Pwd { get; set; }

        [Column("CPT_RUE")]
        [StringLength(200)]
        [Required(AllowEmptyStrings = false)]
        public string Rue { get; set; }

        [Column("CPT_CP", TypeName = "char(5)")]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "CP is invalid")]
        [Required(AllowEmptyStrings = false)]
        public string CodePostal { get; set; }

        [Column("CPT_VILLE")]
        [StringLength(50)]
        [Required(AllowEmptyStrings = false)]
        public string Ville { get; set; }

        [Column("CPT_PAYS")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Pays { get; set; }

        [Column("CPT_LATITUDE")]
        public float? Latitude { get; set; }

        [Column("CPT_LONGITUDE")]
        public float? Longitude { get; set; }

        [Column("CPT_DATECREATION")]
        [Required]
        public DateTime DateCreation { get; set; }


        [InverseProperty(nameof(Favori.CompteFavori))]
        public virtual ICollection<Favori> FavorisCompte { get; set; }

        public override bool Equals(object result)
        {
            return CompteId == ((Compte)result).CompteId
                && Mel == ((Compte)result).Mel;
        }
    }
}
