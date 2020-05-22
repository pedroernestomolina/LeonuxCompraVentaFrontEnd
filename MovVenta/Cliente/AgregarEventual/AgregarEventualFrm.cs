using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MovVenta.Cliente.AgregarEventual
{

    public partial class AgregarEventualFrm : Form
    {

        public event EventHandler<string> AgregarOk;

        public AgregarEventualFrm()
        {
            InitializeComponent();
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            TB_CI_RIF.Text = "";
            TB_NOMBRE.Text = "";
            TB_DIRECCION.Text = "";
            TB_TELEFONO.Text = "";
            TB_CI_RIF.Focus();
        }

        private void AgregarEventualFrm_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BT_AGREGAR_Click(object sender, EventArgs e)
        {
            AgregarFicha();
        }

        private void AgregarFicha()
        {
            var ciRif=TB_CI_RIF.Text.Trim();
            var nombre=TB_NOMBRE.Text.Trim();
            var dirFiscal=TB_DIRECCION.Text.Trim();
            var telefono=TB_TELEFONO.Text.Trim();

            if (ciRif == "")
                return;
            if (nombre== "")
                return;
            if (dirFiscal== "")
                return;

            var ficha = new OOB.LibVenta.Cliente.AgregarEventual();
            ficha.CiRif = ciRif;
            ficha.NombreRazonSocial = nombre;
            ficha.DireccionFiscal = dirFiscal;
            ficha.Telefono = telefono;

            var r01 = Program.MyData.ClienteAgregarEventual(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            EventHandler<string> handler = AgregarOk;
            if (handler != null) 
            {
                handler(this, r01.Auto);
            }
        }

    }

}