﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibInventario.Movimiento.Ver
{
    
    public class Ficha
    {

        public string documentoNro { get; set; }
        public DateTime fecha { get; set; }
        public string tipoDocumento { get; set; }
        public string concepto { get; set; }
        public string codigoConcepto { get; set; }
        public string depositoOrigen { get; set; }
        public string codigoDepositoOrigen { get; set; }
        public string depositoDestino { get; set; }
        public string codigoDepositoDestino { get; set; }
        public string notas { get; set; }
        public string hora { get; set; }
        public string estacion { get; set; }
        public string autorizadoPor { get; set; }
        public decimal total { get; set; }
        public string usuario { get; set; }
        public string usuarioCodigo { get; set; }

        public List<Detalle> detalles { get; set; }

    }

}