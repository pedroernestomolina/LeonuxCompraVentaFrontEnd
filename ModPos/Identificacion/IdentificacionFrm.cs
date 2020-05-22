using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Identificacion
{

    public partial class IdentificacionFrm : Form
    {

        public event EventHandler SalidaOk;
        public event EventHandler UsuarioOk;


        public IdentificacionFrm()
        {
            InitializeComponent();
            Limpiar();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            NotificarSalida();
        }

        private void NotificarSalida()
        {
            EventHandler handler = SalidaOk;
            if (handler != null) 
            {
                handler(this, null);
            }
        }

        private void IdentificacionFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotificarSalida();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            if (VerificarData())
            {
                NotificaroK();
            }
            else 
            {
                Limpiar();
            }
        }

        private void Limpiar()
        {
            TB_CODIGO.Text = "";
            TB_CLAVE.Text = "";
            TB_CODIGO.Focus();
        }

        private bool VerificarData()
        {
            var rt = true;
            var codUsu = TB_CODIGO.Text.Trim().ToUpper();
            var pswUsu = TB_CLAVE.Text.Trim().ToUpper();

            //var r01=Sistema.MyData.PosOffLine_Usuario(codUsu, pswUsu);
            //if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return false;
            //}
            //if (!r01.Entidad.IsActivo)
            //{
            //    Helpers.Msg.Error("USUARIO INACTIVO");
            //    return false;
            //}
            //Sistema._usuario = r01.Entidad;

            return rt;
        }

        private void NotificaroK()
        {
            EventHandler handler = UsuarioOk;
            if (handler != null)
            {
                handler(this, null);
            }
        }

    }

}