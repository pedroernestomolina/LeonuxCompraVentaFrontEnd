using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion.Consultor
{

    public partial class ConsultorFrm : Form
    {


        private CtrConsulta _controlador; 


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
            L_NETO_2.Text = "0.00";
            L_NETO_3.Text = "0.00";
            L_NETO_4.Text = "0.00";
            L_NETO_5.Text = "0.00";
            L_FULL_1.Text = "0.00";
            L_FULL_2.Text = "0.00";
            L_FULL_3.Text = "0.00";
            L_FULL_4.Text = "0.00";
            L_FULL_5.Text = "0.00";
            L_TASA.Text = "";
            L_IVA_1.Text = "0.00";
            L_DIVISA.Text = "0.00";
            L_CONT_2.Text = "";
            L_CONT_3.Text = "";
            L_CONT_4.Text = "";
            L_CONT_5.Text = "";
        }

        private void TB_BUSCAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) 
            {
                var t=TB_BUSCAR.Text.Trim().ToUpper(); 
                if (t != "")
                {
                    _controlador.BuscarProducto(t);
                    ActualizarFicha();
                    TB_BUSCAR.Text = "";
                }
            }
        }

        private void ActualizarFicha()
        {
            Limpiar();
            var _consulta = _controlador.Ficha;
            if (_consulta != null)
            {
                L_PRODUCTO.Text =_consulta.NombrePrd;
                L_DEPARTAMENTO.Text = _consulta.Departamento;
                L_GRUPO.Text = _consulta.Grupo;
                L_MARCA.Text = _consulta.Marca;
                L_MODELO.Text = _consulta.Modelo;
                L_REFERENCIA.Text = _consulta.Referencia;
                L_PASILLO.Text = _consulta.Pasillo;
                L_CODIGO.Text = _consulta.CodigoPrd;
                L_PLU.Text = _consulta.CodigoPlu;
                L_CODIGO_BARRA.Text = _consulta.CodigoBarra;

                var tarifaPrecio = _controlador.TarifaPrecio;
                var pn = 0.0m;
                var pf = 0.0m;
                var iva = 0.0m;
                var emp = "";

                if (tarifaPrecio == "1") 
                {
                    pn = _consulta.Precio_1.Neto;
                    pf = _consulta.Precio_1.Full;
                    iva = _consulta.Precio_1.Iva;
                    emp = _consulta.Precio_1.EmpaqueContenidoDescripcion;
                }
                if (tarifaPrecio == "2")
                {
                    pn = _consulta.Precio_2.Neto;
                    pf = _consulta.Precio_2.Full;
                    iva = _consulta.Precio_2.Iva;
                    emp = _consulta.Precio_2.EmpaqueContenidoDescripcion;
                }
                if (tarifaPrecio == "3")
                {
                    pn = _consulta.Precio_3.Neto;
                    pf = _consulta.Precio_3.Full;
                    iva = _consulta.Precio_3.Iva;
                    emp = _consulta.Precio_3.EmpaqueContenidoDescripcion;
                }
                if (tarifaPrecio == "4")
                {
                    pn = _consulta.Precio_4.Neto;
                    pf = _consulta.Precio_4.Full;
                    iva = _consulta.Precio_4.Iva;
                    emp = _consulta.Precio_4.EmpaqueContenidoDescripcion;
                }
                if (tarifaPrecio == "5")
                {
                    pn = _consulta.Precio_5.Neto;
                    pf = _consulta.Precio_5.Full;
                    iva = _consulta.Precio_5.Iva;
                    emp = _consulta.Precio_5.EmpaqueContenidoDescripcion;
                }

                var mdivisa = 0.0m;
                if (_controlador.FactorCambio>0)
                    mdivisa=(pf / _controlador.FactorCambio);
                mdivisa=Math.Round(mdivisa,2, MidpointRounding.AwayFromZero);
                L_NETO_1.Text = pn.ToString("n2");
                L_FULL_1.Text = pf.ToString("n2");
                L_IVA_1.Text = iva.ToString("n2");
                L_EMPAQUE_VENTA.Text = emp;
                L_TASA.Text = _consulta.TasaDescripcion;
                L_DIVISA.Text = mdivisa.ToString("n2")+"$";

                if (!_controlador.EtiquetarPrecioPorTipoNegocio)
                {
                    L_NETO_2.Text = _consulta.Precio_2.Neto.ToString("n2");
                    L_NETO_3.Text = _consulta.Precio_3.Neto.ToString("n2");
                    L_NETO_4.Text = _consulta.Precio_4.Neto.ToString("n2");
                    L_NETO_5.Text = _consulta.Precio_5.Neto.ToString("n2");

                    L_FULL_2.Text = _consulta.Precio_2.Full.ToString("n2");
                    L_FULL_3.Text = _consulta.Precio_3.Full.ToString("n2");
                    L_FULL_4.Text = _consulta.Precio_4.Full.ToString("n2");
                    L_FULL_5.Text = _consulta.Precio_5.Full.ToString("n2");

                    L_CONT_2.Text = _consulta.Precio_2.ContenidoDescripcion;
                    L_CONT_3.Text = _consulta.Precio_3.ContenidoDescripcion;
                    L_CONT_4.Text = _consulta.Precio_4.ContenidoDescripcion;
                    L_CONT_5.Text = _consulta.Precio_5.ContenidoDescripcion;
                }

                L_INACTIVO.Visible = _consulta.IsInactivo;
                P_PRODUCTO.BackColor = _consulta.IsInactivo ? Color.Red : Color.Navy;
                L_PRODUCTO.ForeColor = _consulta.IsInactivo ? Color.Yellow : Color.White;
            }
        }

        private void Salida() 
        {
            this.Close();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        public void setControlador(CtrConsulta ctr) 
        {
            _controlador = ctr;
        }

    }

}