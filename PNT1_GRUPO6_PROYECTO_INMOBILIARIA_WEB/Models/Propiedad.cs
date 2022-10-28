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
        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public string SrcImagen { get; set; }

        public TipoPropiedad Tipo { get; set; }

        
        abstract public void CalcularContrato();

    }
}
