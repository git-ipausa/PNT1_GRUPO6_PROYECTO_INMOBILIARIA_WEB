using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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

        [Display(Name = "Precio en dólares:")]
        public double Precio { get; set; }

        [Display(Name = "Foto:")]
        public string SrcImagen { get; set; }

        [Display(Name = "Tipo de propiedad:")]
        public TipoPropiedad Tipo { get; set; }

        
        abstract public void CalcularContrato();

    }
}
