﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Operador.Abrir
{

    public class Ficha
    {

        public int IdJornada { get; set; }
        public string AutoUsuario { get; set; }
        public string CodigoUsuario { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Estatus { get; set; }

    }

}