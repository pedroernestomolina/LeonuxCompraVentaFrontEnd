﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.OOB.Reportes.GeneralPorDepartamento
{
    
    public class Ficha
    {


        public string codDepart { get; set; }
        public string nombreDepart { get; set; }
        public decimal costo { get; set; }
        public decimal venta { get; set; }
        public decimal costoDivisa { get; set; }
        public decimal ventaDivisa { get; set; }
        public decimal utilidadMonto { get { return venta - costo; } }
        public decimal utilidadMontoDivisa { get { return ventaDivisa - costoDivisa; } }
        public decimal utilidadPorc 
        { 
            get 
            { 
                var rt =0.0m;
                if (costo>0)
                {
                    rt = ((venta / costo) - 1);

                }
                return rt;
            }
        }


        public Ficha()
        {
            codDepart = "";
            nombreDepart = "";
            costo = 0.0m;
            venta = 0.0m;
            costoDivisa = 0.0m;
            ventaDivisa = 0.0m;
        }

    }

}