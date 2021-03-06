﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Principal
{

    public partial class PrincipalFrm : Form
    {
        
        private Gestion _controlador;
        private Timer timer;


        public PrincipalFrm()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var s = DateTime.Now;
            L_FECHA.Text = s.ToLongDateString();
            L_HORA.Text = s.ToLongTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
            L_VERSION.Text = _controlador.Version;
            L_HOST.Text = _controlador.Host;
            L_USUARIO.Text = _controlador.Usuario;
            L_FECHA.Text = "";
            L_HORA.Text = "";
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void TSM_ARCHIVO_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        public void setVisibilidadOff()
        {
            this.Visible = false;
        }

        public void setVisibilidadOn()
        {
            this.Visible = true;
        }

        private void MENU_DOCUMENTOS_ADMINISTRADOR_Click(object sender, EventArgs e)
        {
            AdministradorDoc();
        }

        private void AdministradorDoc()
        {
            _controlador.AdministradorDoc();
        }

        private void MENU_REPORTES_GENERAL_DOCUMENTOS_Click(object sender, EventArgs e)
        {
            Reporte_GeneralDocumentos();
        }

        private void Reporte_GeneralDocumentos()
        {
            _controlador.Reporte_GeneralDocumentos();
        }

        private void MENU_MAESTRO_GRUPO_Click(object sender, EventArgs e)
        {
            MaestroGrupo();
        }

        private void MaestroGrupo()
        {
            _controlador.MaestroGrupo();
        }

        private void MENU_MAESTRO_ZONA_Click(object sender, EventArgs e)
        {
            MaestroZona();
        }

        private void MaestroZona()
        {
            _controlador.MaestroZona();
        }

        private void MENU_REPORTES_GENERAL_POR_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            Reporte_GeneralPorDepartamento();
        }

        private void Reporte_GeneralPorDepartamento()
        {
            _controlador.Reporte_GeneralPorDepartamento();
        }

        private void MENU_REPORTES_GENERAL_POR_GRUPO_Click(object sender, EventArgs e)
        {
            Reporte_GeneralPorGrupo();
        }

        private void Reporte_GeneralPorGrupo()
        {
            _controlador.Reporte_GeneralPorGrupo();
        }

        private void MENU_MAESTRO_CLIENTES_Click(object sender, EventArgs e)
        {
            MaestroClientes();
        }

        private void MaestroClientes()
        {
            _controlador.MaestroClientes();
        }

        private void MENU_REPORTES_RESUMEN_Click(object sender, EventArgs e)
        {
            Reporte_Resumen();
        }

        private void Reporte_Resumen()
        {
            _controlador.Reporte_Resumen();
        }

        private void MENU_REPORTES_GENERAL_POR_PRODUCTO_Click(object sender, EventArgs e)
        {
            Reporte_GeneralPorProducto();
        }

        private void Reporte_GeneralPorProducto()
        {
            _controlador.Reporte_GeneralPorProducto();
        }

        private void MENU_REPORTES_GENERAL_DOCUMENTOS_DETALLE_Click(object sender, EventArgs e)
        {
            Reporte_GeneralDocumentoDetalle();
        }

        private void Reporte_GeneralDocumentoDetalle()
        {
            _controlador.Reporte_GeneralDocumentoDetalle();
        }

        private void MENU_MAESTRO_REPORTE_MAESTRO_CLIENTE_Click(object sender, EventArgs e)
        {
            MaestroCliente();
        }

        private void MaestroCliente()
        {
            _controlador.Reporte_Cliente_Maestro();
        }

        private void MENU_REPORTES_CONSOLIDADO_Click(object sender, EventArgs e)
        {
            Reporte_Consolidado();
        }

        private void Reporte_Consolidado()
        {
            _controlador.Reporte_Consolidado();
        }

    }

}