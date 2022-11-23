using System;
using System.ComponentModel.DataAnnotations;

namespace PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB
{
    public class PropiedadAlquiler : Propiedad
    {
        [Display(Name = "Cantidad de meses:")]
        public int CantMeses { get; set; }

        public override string Contrato()
        {
            return "La persona " + usuario.Nombre + " " + usuario.Apellido + " con E-mail: " + usuario.Email + " ha alquilado esta propiedad";
        }


        
    }
}
