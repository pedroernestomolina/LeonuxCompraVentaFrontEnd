﻿using System;
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


        private Consulta _consulta;


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
            L_FULL_1.Text = "0.00";
            L_FULL_2.Text = "0.00";
            L_FULL_3.Text = "0.00";
            L_FULL_4.Text = "0.00";
            L_TASA.Text = "";
            L_IVA_1.Text = "0.00";
            L_CONT_2.Text = "";
            L_CONT_3.Text = "";
            L_CONT_4.Text = "";
        }

        private void TB_BUSCAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) 
            {
                var t=TB_BUSCAR.Text.Trim().ToUpper(); 
                if (t != "")
                {
                    if (Helpers.BuscarProducto.ActivarBusqueda(t))
                    {
                        _consulta = new Consulta(Helpers.BuscarProducto.Producto);
                        ActualizarFicha();
                    }
                    else 
                    {
                        Limpiar();
                    }
                    TB_BUSCAR.Text = "";
                }
            }
        }

        private void ActualizarFicha()
        {
            Limpiar();
            if (_consulta != null)
            {
                L_PRODUCTO.Text = _consulta.NombrePrd;
                L_DEPARTAMENTO.Text = _consulta.Departamento;
                L_GRUPO.Text = _consulta.Grupo;
                L_MARCA.Text = _consulta.Marca;
                L_MODELO.Text = _consulta.Modelo;
                L_REFERENCIA.Text = _consulta.Referencia;
                L_PASILLO.Text = _consulta.Pasillo;
                L_CODIGO.Text = _consulta.CodigoPrd;
                L_PLU.Text = _consulta.CodigoPlu;
                L_CODIGO_BARRA.Text = _consulta.CodigoBarra;

                L_NETO_1.Text = _consulta.Precio_1.Neto.ToString("n2");
                L_NETO_2.Text = _consulta.Precio_2.Neto.ToString("n2");
                L_NETO_3.Text = _consulta.Precio_3.Neto.ToString("n2");
                L_NETO_4.Text = _consulta.Precio_4.Neto.ToString("n2");

                L_FULL_1.Text = _consulta.Precio_1.Full.ToString("n2");
                L_FULL_2.Text = _consulta.Precio_2.Full.ToString("n2");
                L_FULL_3.Text = _consulta.Precio_3.Full.ToString("n2");
                L_FULL_4.Text = _consulta.Precio_4.Full.ToString("n2");

                L_CONT_2.Text = _consulta.Precio_2.ContenidoDescripcion;
                L_CONT_3.Text = _consulta.Precio_3.ContenidoDescripcion;
                L_CONT_4.Text = _consulta.Precio_4.ContenidoDescripcion;

                L_TASA.Text = _consulta.TasaDescripcion;
                L_IVA_1.Text = _consulta.Precio_1.Iva.ToString("n2");
                L_EMPAQUE_VENTA.Text = _consulta.Precio_1.EmpaqueContenidoDescripcion;

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

    }

}