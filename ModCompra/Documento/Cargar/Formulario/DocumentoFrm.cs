using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Formulario
{

    public partial class DocumentoFrm : Form
    {


        private Controlador.Gestion _controlador;


        public DocumentoFrm()
        {
            InitializeComponent();
        }

        private void DocumentoFrm_Load(object sender, EventArgs e)
        {
            Inicializar_1();
        }

        private void Inicializar_1()
        {
            L_TITULO_DOCUMENTO.Text = _controlador.TituloDocumento;
            ActualizarDatosDocumento();

            L_TOTAL.Text = _controlador.Total.ToString("n2");
            L_IVA.Text = _controlador.MontoIva.ToString("n2");
            L_DIVISA.Text = _controlador.MontoDivisa.ToString("n2");

        }

        public void setControlador(Controlador.Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_NUEVO_Click(object sender, EventArgs e)
        {
            NuevoDocumento();
        }

        private void NuevoDocumento()
        {
            _controlador.NuevoDocumento();
            ActualizarDatosDocumento();
        }

        private void ActualizarDatosDocumento()
        {
            L_PROVEEDOR.Text = _controlador.Proveedor;
            L_FECHA_EMISION.Text = _controlador.FechaEmision.ToShortDateString();
            L_DOCUMENTO.Text = _controlador.DocumentoNro;
            L_CONTROL_NRO.Text = _controlador.ControlNro;
            L_FECHA_VENC.Text = _controlador.FechaVencimiento.ToShortDateString();
            L_FACTOR_DIVISA.Text = _controlador.FactorDivisa.ToString("n2");
            L_DEPOSITO.Text = _controlador.Deposito;
            L_SUCURSAL.Text = _controlador.Sucursal;
        }

    }

}