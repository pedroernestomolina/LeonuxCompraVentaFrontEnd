using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.TasaDivisa.Pos
{
    
    public class Gestion : IGestion
    {

        private decimal _valorNuevo { get; set; }


        public string TituloFuncion
        {
            get { return "Tasa Recepción En (POS) ?"; }
        }

        public decimal ValorNuevo
        {
            set { _valorNuevo=value; }
        }

        public decimal ValorActual { get; set; }


        public bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_TasaRecepcionPos();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                rt = false;
            }

            ValorActual = r01.Entidad;
            return rt;
        }

        public bool Procesar()
        {
            var rt = false;

            if (_valorNuevo > 0)
            {
                var msg = MessageBox.Show("Actualizar Tasa Recepción (POS)?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var ficha = new OOB.LibSistema.Configuracion.ActualizarTasaRecepcionPos.Ficha()
                    {
                        valorNuevo = _valorNuevo,
                    };
                    var r01 = Sistema.MyData.Configuracion_Actualizar_TasaRecepcionPos(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return false;
                    }
                    rt = true;
                }
            }

            return rt;
        }

    }

}