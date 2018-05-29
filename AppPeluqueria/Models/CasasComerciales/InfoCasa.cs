using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPeluqueria.Models.CasasComerciales
{
    public class InfoCasa
    {
        [Required]
        [Display(Name = "Id Casa Comercial")]
        [StringLength(30)]
        public string id_Casa { get; set; }

        [Required]
        [Display(Name = "Nombre Casa Comercial")]
        [StringLength(30)]
        public string nombre_Casa { get; set; }

        [Required]
        [Display(Name = "Localización Casa Comercial")]
        [StringLength(30)]
        public string local_Casa { get; set; }

    }
}