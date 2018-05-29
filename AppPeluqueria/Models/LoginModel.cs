using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPeluqueria.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Debe ingresar un usuario")]
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

    }
}