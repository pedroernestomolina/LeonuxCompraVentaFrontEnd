using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Servicio
{
    
    public class Gestion
    {

        IniciarBDFrm frm;
        public void Inicia() 
        {
            if (frm==null)
            {
                frm = new IniciarBDFrm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }

        public void Procesar()
        {
            var msg = MessageBox.Show("Estas Seguro De Inicializar la BD ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                msg = MessageBox.Show("Confirma La Inicialización de la BD ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes) 
                {
                    var ficha = new OOB.LibSistema.Configuracion.Inicializar.Ficha()
                    {
                        CodSucursal = "01",
                        IdEquipo = "01",
                    };
                    var r01 = Sistema.MyData.Inicializar_BD(ficha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    Helpers.Msg.OK("PROCESO REALIZADO CON EXITO.........");
                }
            }
        }

    }

}