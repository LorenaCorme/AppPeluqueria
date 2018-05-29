﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPeluqueria.Models.Productos
{
    public class InfoProducto
    {
        [Display(Name = "Id Producto")]
        public string id_Prod { get; set; }

        [Display(Name = "Nombre Producto")]
        public string nombre_Prod { get; set; }

        [Display(Name = "Cantidad")]
        public string cantidad { get; set; }

        [Display(Name = "Casa Comercial")]
        public string id_Casa { get; set; }


    }
}