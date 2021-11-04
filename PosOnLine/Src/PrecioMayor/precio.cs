using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.PrecioMayor
{

    public class precio
    {

        public string Id { get; set; }
        public decimal PrecioNeto { get; set; }
        public decimal UtilidadMargen { get; set; }
        public int ContEmpVenta { get; set; }
        public string DescEmpVenta { get; set; }
        public string Decimales { get; set; }
        public bool Habilitado { get { return PrecioNeto > 0.0m; } }


        public precio()
        {
            Limpiar();
        }

        public precio(string id, string emp, int cont , decimal pn, string dec)
            : this()
        {
            this.Id = id;
            this.DescEmpVenta=emp;
            this.ContEmpVenta = cont;
            this.PrecioNeto = pn;
            this.Decimales = dec;
        }


        public void Limpiar() 
        {
            Id = "";
            PrecioNeto = 0.0m;
            UtilidadMargen = 0.0m;
            ContEmpVenta = 0;
            DescEmpVenta = "";
            Decimales = "";
        }

    }

}