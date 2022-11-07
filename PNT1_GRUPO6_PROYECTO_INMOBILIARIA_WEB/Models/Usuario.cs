using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PNT1_GRUPO6_PROYECTO_INMOBILIARIA_WEB.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nombre/s:")]
        [Required(ErrorMessage = "Ingrese el nombre")]
        public string Nombre { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Apellido/s:")]
        [Required(ErrorMessage = "Ingrese el apellido")]
        public string Apellido { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Ingrese su correo electrónico")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Formato de Email no válido.")]
        [Display(Name = "Correo electrónico:")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Ingrese su contraseña")]
        [Display(Name = "Contraseña:")]
        public string Contrasena { get; set; }

    }
}
