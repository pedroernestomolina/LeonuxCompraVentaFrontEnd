using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Precio
{
    
    public class Gestion
    {

        private OOB.LibSistema.Precio.Etiquetar.Ficha ficha;


        public string Etiqueta_1 { get; set; }
        public string Etiqueta_2 { get; set; }
        public string Etiqueta_3 { get; set; }
        public string Etiqueta_4 { get; set; }
        public string Etiqueta_5 { get; set; }
        public bool IsActualizarOk { get; set; }
        public bool CancelarCierreVentana { get; set; }


        public Gestion()
        {
            LimpiarEntradas();
        }


        private void LimpiarEntradas()
        {
            IsActualizarOk = false;
            CancelarCierreVentana = false;
            Etiqueta_1 = "";
            Etiqueta_2 = "";
            Etiqueta_3 = "";
            Etiqueta_4 = "";
            Etiqueta_5 = "";
        }

        ActualizarFrm frm ;
        public void Inicia() 
        {
            IsActualizarOk = false;
            CancelarCierreVentana = false;
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new ActualizarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Precio_Etiquetar_GetFicha();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            ficha = r01.Entidad;
            Etiqueta_1 = ficha.Precio1.descripcion;
            Etiqueta_2 = ficha.Precio2.descripcion;
            Etiqueta_3 = ficha.Precio3.descripcion;
            Etiqueta_4 = ficha.Precio4.descripcion;
            Etiqueta_5 = ficha.Precio5.descripcion;
            
            return rt;
        }

        public void Procesar()
        {
            CancelarCierreVentana = false;

            var msg = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var ficha = new OOB.LibSistema.Precio.Etiquetar.Actualizar()
                {
                    descripcion_1 = Etiqueta_1,
                    descripcion_2 = Etiqueta_2,
                    descripcion_3 = Etiqueta_3,
                    descripcion_4 = Etiqueta_4,
                    descripcion_5 = Etiqueta_5,
                };
                var r01 = Sistema.MyData.Precio_Etiquetar_Actualizar(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    CancelarCierreVentana = true;
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                IsActualizarOk = true;
            }
            else
                CancelarCierreVentana = true;
        }

        public void InicializarIsCerrarHabilitado()
        {
            CancelarCierreVentana = false;
        }

    }

}