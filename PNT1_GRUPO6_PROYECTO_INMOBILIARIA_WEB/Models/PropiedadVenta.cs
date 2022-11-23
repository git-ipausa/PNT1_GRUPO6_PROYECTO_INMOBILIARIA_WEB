using System;


namespace PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB
{
    public class PropiedadVenta : Propiedad
    {
        public override string Contrato()
        {
            return "La persona " + usuario.Nombre + " " + usuario.Apellido + " con E-mail: " + usuario.Email + " ha comprado esta propiedad";
        }

    }
}
