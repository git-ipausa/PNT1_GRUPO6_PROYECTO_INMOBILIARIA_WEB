using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Models;

namespace PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB
{
    public class PropiedadAlquiler : Propiedad
    {
        [Display(Name = "Cantidad de meses:")]
        public int CantMeses { get; set; }

        public override void CalcularContrato()
        {
            throw new NotImplementedException();
        }

        //agregar usuario como nullable (poniendo ? adelante del tipo)
        
        //public int? IdUsuario { get; set; }
        
        //public Usuario usuario { get; set; }
        
    }
}
