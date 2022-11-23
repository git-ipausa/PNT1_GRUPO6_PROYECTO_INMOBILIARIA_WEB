using Microsoft.AspNetCore.Http;
using PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB
{
    public abstract class Propiedad
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPropiedad { get; set; }

        [StringLength(200)]
        [Display(Name = "Descripción:")]
        public string Descripcion { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Precio en dólares:")]
        public double Precio { get; set; }

        [NotMapped]
        [Display(Name = "Foto:")]
        [Required]
        public IFormFile FotoPropiedad { get; set; }
        public string FotoPropiedadUrl { get; set; }

        [Display(Name = "Tipo de propiedad:")]
        public TipoPropiedad Tipo { get; set; }

        [ForeignKey("Usuario")]
        [Column("IdUsuario")]
        [Display(Name = "Usuario:")]
        public Usuario usuario { get; set; }

        abstract public string Contrato();

    }
}
