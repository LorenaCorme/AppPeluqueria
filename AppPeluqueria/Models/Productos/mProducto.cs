﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPeluqueria.Models.Productos
{
    public class mProducto
    {
        [Required]
        [Range(0, short.MaxValue, ErrorMessage = "Debe ingresar un valor numérico.")]
        [MinLength(4)]
        [MaxLength(4)]
        [Display(Name = "Id Producto")]

        public string id_Prod { get; set; }

        [Required]
        [Display(Name = "Nombre Producto")]
        [MinLength(3), MaxLength(30)]
        public string nombre_Prod { get; set; }

        [Required]
        [Display(Name = "Cantidad Producto")]
        [Range(0, short.MaxValue, ErrorMessage = "Debe ingresar un valor numérico.")]
        [MinLength(4)]
        [MaxLength(4)]
        public string cantidad { get; set; }

        [Required]
        [Display(Name = "Id Casa Comercial")]
        [StringLength(30)]
        public string id_Casa { get; set; }

    }
}