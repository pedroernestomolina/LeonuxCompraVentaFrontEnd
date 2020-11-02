using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.TasaDivisa
{
    
    public class Gestion
    {

        private IGestion miGestion;


        public string TituloFuncion { get { return miGestion.TituloFuncion; } }
        public decimal ValorActual { get { return miGestion.ValorActual; } }
        public decimal ValorNuevo { set { miGestion.ValorNuevo= value; } }
        public bool ActualizacionIsOk { get; set; }


        public Gestion()
        {
        }


        public void setGestion(IGestion gestion) 
        {
            miGestion = gestion;
        }


        TasaDivisaFrm frm;
        public void Inicia() 
        {
            ActualizacionIsOk = false;
            if (miGestion.CargarData())
            {
                if (frm == null)
                {
                    frm = new TasaDivisaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void Procesar()
        {
            ActualizacionIsOk = miGestion.Procesar();
        }

    }

}