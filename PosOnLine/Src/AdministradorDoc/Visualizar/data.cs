﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.AdministradorDoc.Visualizar
{
    
    public class data
    {
        
        private OOB.Documento.Entidad.FichaItem it;


        public string CodigoPrd { get { return it.Codigo; } }
        public string NombrePrd { get { return it.Nombre; } }
        public decimal Cantidad { get { return it.CantidadUnd; } }
        public decimal Precio { get { return it.PrecioItem; } }
        public decimal Importe { get { return it.Total; } }


        public data(OOB.Documento.Entidad.FichaItem it)
        {
            this.it = it;
        }

    }

}