using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Configuracion
{

    public partial class ConfigurarFrm : Form
    {


        private BindingSource bs_Deposito;
        private BindingSource bs_Cobrador;
        private BindingSource bs_Vendedor;


        public ConfigurarFrm()
        {
            InitializeComponent();
            bs_Deposito = new BindingSource();
            bs_Cobrador= new BindingSource();
            bs_Vendedor = new BindingSource();
        }

        public bool CargarData() 
        {
            var rt = false;

            var r01 = Sistema.MyData2.Deposito_Lista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return rt;
            }
           // bs_Deposito. = r01.Lista();

            var r02 = Sistema.MyData2.Cobrador_Lista ();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return rt;
            }

            var r03 = Sistema.MyData2.Vendedor_Lista();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return rt;
            }

            var r04 = Sistema.MyData2.Transporte_Lista();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return rt;
            }

            var r05 = Sistema.MyData2.MedioCobro_Lista ();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return rt;
            }

            var r06 = Sistema.MyData2.Serie_Lista();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return rt;
            }

            rt = true;
            return rt;
        }

        private void ConfigurarFrm_Load(object sender, EventArgs e)
        {
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

    }
}
