﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Puesto
    {
        public int PuestoId { get; set; }
        public string Descripcion { get; set; }
        public List<object> Puestos { get; set; }
    }
}
