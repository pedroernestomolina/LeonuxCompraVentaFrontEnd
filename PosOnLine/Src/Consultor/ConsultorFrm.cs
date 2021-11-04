using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Consultor
{

    public partial class ConsultorFrm : Form
    {


        private Gestion _controlador;


        public ConsultorFrm() 
        {
            InitializeComponent();
        }

        private void ConsultorFrm_Load(object sender, EventArgs e)
        {
            Limpiar();
            TB_BUSCAR.Focus();
        }

        private void Limpiar()
        {
            L_INACTIVO.Visible = false;
            P_PRODUCTO.BackColor = Color.Navy;
            L_PRODUCTO.ForeColor = Color.White;

            L_PRODUCTO.Text = "Por Favor, Pase El Producto Por El Lector De Barra !!!";
            L_CODIGO.Text = "";
            L_CODIGO_BARRA.Text = "";
            L_PLU.Text = "";
            L_DEPARTAMENTO.Text = "";
            L_GRUPO.Text = "";
            L_MARCA.Text = "";
            L_MODELO.Text = "";
            L_REFERENCIA.Text = "";
            L_PASILLO.Text = "";
            L_EMPAQUE_VENTA.Text = "";
            L_NETO_1.Text = "0.00";
            L_FULL_1.Text = "0.00";
            L_TASA.Text = "";
            L_IVA_1.Text = "0.00";
            L_DIVISA.Text = "0.00";
            L_EX_DISPONIBLE.Text = "";
            L_EX_CANTIDAD.Text = "";
            //
            L_NETO_MAY_1.Text = "";
            L_FULL_MAY_1.Text = "";
            L_EMPAQUE_MAY_1.Text = "";
            L_DIVISA_MAY_1.Text = "";
            //
            L_NETO_MAY_2.Text = "";
            L_FULL_MAY_2.Text = "";
            L_EMPAQUE_MAY_2.Text = "";
            L_DIVISA_MAY_2.Text = "";
        }

        private void TB_BUSCAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) 
            {
                _controlador.BuscarProducto(TB_BUSCAR.Text.Trim().ToUpper());
                if (_controlador.BusquedaIsOk)
                    ActualizarFicha();
                else
                    Limpiar();
                TB_BUSCAR.Text = "";
            }
        }

        private void ActualizarFicha()
        {
            Limpiar();
            L_PRODUCTO.Text = _controlador.NombrePrd;
            L_DEPARTAMENTO.Text = _controlador.Departamento;
            L_GRUPO.Text = _controlador.Grupo;
            L_MARCA.Text = _controlador.Marca;
            L_MODELO.Text = _controlador.Modelo;
            L_REFERENCIA.Text = _controlador.Referencia;
            L_PASILLO.Text = _controlador.Pasillo;
            L_CODIGO.Text = _controlador.CodigoPrd;
            L_PLU.Text = _controlador.CodigoPlu;
            L_CODIGO_BARRA.Text = _controlador.CodigoBarra;
            L_TASA.Text = _controlador.TasaIvaDescripcion;

            L_NETO_1.Text = _controlador.Precio.Neto.ToString("n2");
            L_FULL_1.Text = _controlador.Precio.Full.ToString("n2");
            L_IVA_1.Text = _controlador.Precio.Iva.ToString("n2");
            L_EMPAQUE_VENTA.Text = _controlador.Precio.EmpaqueContenidoDescripcion;
            L_DIVISA.Text = _controlador.Precio.FullDivisa.ToString("n2")+ "$";
            L_EX_DISPONIBLE.Text = _controlador.Existencia.HayDisponibilidad?"SI":"NO";
            L_EX_CANTIDAD.Text = _controlador.Existencia.Cantidad.ToString("n1");
            //
            L_NETO_MAY_1.Text = _controlador.PrecioMayor_Neto_1.ToString("n2");
            L_FULL_MAY_1.Text = _controlador.PrecioMayor_Full_1.ToString("n2");
            L_EMPAQUE_MAY_1.Text = _controlador.PrecioMayor_Contenido_1.ToString();
            L_DIVISA_MAY_1.Text = _controlador.PrecioMayor_Divisa_1.ToString("n2") + "$";
            //
            L_NETO_MAY_2.Text = _controlador.PrecioMayor_Neto_2.ToString("n2");
            L_FULL_MAY_2.Text = _controlador.PrecioMayor_Full_2.ToString("n2");
            L_EMPAQUE_MAY_2.Text = _controlador.PrecioMayor_Contenido_2.ToString();
            L_DIVISA_MAY_2.Text = _controlador.PrecioMayor_Divisa_2.ToString("n2") + "$";


            //if (_controlador.Habilitar_Precio5_VentaMayor)
            //{
            //    if (_controlador.PrecioMayor_Contenido > 1)
            //    {
            //        L_NETO_MAY_1.Text = _controlador.PrecioMayor_Neto.ToString("n2");
            //        L_FULL_MAY_1.Text = _controlador.PrecioMayor_Full.ToString("n2");
            //        L_EMPAQUE_MAY_1.Text = _controlador.PrecioMayor_Contenido.ToString();
            //        L_DIVISA_MAY_1.Text = _controlador.PrecioMayor_Divisa.ToString("n2")+"$";
            //    }
            //}
        }

        private void Salida() 
        {
            this.Close();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

    }

}