using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPeluqueria.Models.Usuarios
{
    public class mUsuarios
    {
        [Required]
        [Display(Name = "Número Reserva")]
        public string id { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Contraseña")]
        public string contraseña { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Correo electrónico")]
        public string email { get; set; }
        
        [Display(Name = "Recordarme en este ordenador")]
        public bool recuerdame { get; set; }

    }
}