using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos
{

    public partial class Form1 : Form
    {


        private Configuracion.configurar _configuracion;


        public Form1()
        {
            InitializeComponent();
            Sistema.MyBalanza = new Lib.BalanzaSoloPeso.BalanzaManual.Balanza();
            Sistema.Usuario = new OOB.LibVenta.PosOffline.Usuario.Ficha() { Auto = "0000000001", Codigo = "CAJA1T1", Descripcion = "CAJ. TURNO 1", IsActivo = true };
            _configuracion = new Configuracion.configurar();
        }


        public bool CargarData() 
        {
            var rt = true;

            return rt;
        }

        private void BT_POS_Click(object sender, EventArgs e)
        {
            ModuloVenta();
        }

        private void ModuloVenta()
        {
            if (Sistema.Usuario.IsInvitado) 
            {
                Helpers.Msg.Alerta("OPCION NO PERMITDA PARA USUARIO [ INVITADO]");
                return;
            }

            //var r01 = Sistema.MyData.PosOffLine_Permiso_ModuloVenta(Sistema._usuario.AutoGrupo);
            //if (r01.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return;
            //}
            //var permiso = r01.Entidad;
            //if (!permiso.IsHabilitado)
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return;
            //}

            var pass = true;
            //if (permiso.NivelSeguridad != OOB.LibVenta.PosOffline.Permiso.Enumerados.enumNivelSeguridad.Ninguna)
            //{
            //    pass = Helpers.VerificaPassword.Verificar();
            //}

            if (pass)
            {
                this.Hide();
                var frm = new Facturacion.PosVenta();
                if (frm.CargarData()) 
                {
                    frm.ShowDialog();
                }
                this.Visible = true;
            }
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Salida()
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void BT_ACTUALIZAR_DATA_Click(object sender, EventArgs e)
        {
            ActualizaDataDelServidor();
        }

        private void ActualizaDataDelServidor()
        {
            var msg = MessageBox.Show("Actualizar Data Del Servidor ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var r01 = Sistema.MyData2.Servidor_Test();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var r02 = Sistema.MyData2.Servidor_ActualizarData();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }

                Helpers.Msg.EditarOk();
            }
        }

        private void BT_CONFIGURACION_Click(object sender, EventArgs e)
        {
            ConfiguracionSistema();
        }

        private void ConfiguracionSistema()
        {
            _configuracion.Configura();
        }

    }

}