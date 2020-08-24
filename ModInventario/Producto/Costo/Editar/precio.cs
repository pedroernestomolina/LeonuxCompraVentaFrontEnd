using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Costo.Editar
{

    public class precio
    {

        public enum enumUtilidadMetodo { Lineal=1, Financiero } ;


        private enumUtilidadMetodo  metodoCalculo;
        private decimal utilidad { get; set; }
        private decimal neto { get; set; }


        public decimal Neto { get { return neto; } }
        public decimal Utilidad { get { return utilidad; } }


        public precio()
        {
            Limpiar();
        }


        public void Limpiar()
        {
            utilidad = 0.0m;
            neto = 0.0m;
        }

        public void setFicha(decimal ut, decimal nt, enumUtilidadMetodo metodo)
        {
            utilidad = ut;
            neto = nt;
            metodoCalculo = metodo;
        }

        public void ActualizarPrecio(decimal cost)
        {
            if (metodoCalculo == enumUtilidadMetodo.Lineal) 
            {
                neto = cost + (cost * utilidad / 100);
            }
            if (metodoCalculo == enumUtilidadMetodo.Financiero) 
            {
                if (utilidad >= 100) { utilidad = 0; }
                neto = cost / ((100 - utilidad) / 100);
            }
            neto = Math.Round(neto, 2, MidpointRounding.AwayFromZero);
        }

        public void ActualizarUtilidad(decimal cost)
        {
            if (cost == 0.0m || neto == 0.0m)
            {
                utilidad = 0.0m;
            }
            else
            {
                if (metodoCalculo == enumUtilidadMetodo.Lineal)
                {
                    utilidad = ((neto / cost) - 1) * 100;
                }
                if (metodoCalculo == enumUtilidadMetodo.Financiero)
                {
                    utilidad = (1 - (cost / neto)) * 100;
                }
                utilidad = Math.Round(utilidad, 2, MidpointRounding.AwayFromZero);
            }
        }

    }

}