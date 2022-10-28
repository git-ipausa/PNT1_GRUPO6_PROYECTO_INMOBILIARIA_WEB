using System;
using System.Collections.Generic;
using System.Text;

namespace PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB
{
    public class PropiedadAlquiler : Propiedad
    {
        public int CantMeses { get; set; }

        public override void CalcularContrato()
        {
            throw new NotImplementedException();
        }
    }
}
