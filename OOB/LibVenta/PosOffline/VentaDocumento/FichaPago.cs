﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.VentaDocumento
{
    
    public class FichaPago
    {

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Lote { get; set; }
        public string Referencia { get; set; }
        public decimal Importe { get; set; }
        public decimal MontoRecibido { get; set; }
        public decimal Tasa { get; set; }

    }

}