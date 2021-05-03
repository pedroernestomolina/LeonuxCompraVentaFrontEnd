﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Principal
{

    public partial class PrincipalFrm : Form
    {


        private Gestion _controlador;


        public PrincipalFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void PrincipalFrm_Load(object sender, EventArgs e)
        {
            ActualizarJornadaOperadorUsuario();
            BT_ABRIR_POS.Enabled = _controlador.ConfiguracionIsOk;
            BT_ADM_DOCUMENTOS.Enabled = _controlador.ConfiguracionIsOk;
            BT_CERRAR_POS.Enabled = _controlador.ConfiguracionIsOk;
        }

        private void BT_ABRIR_POS_Click(object sender, EventArgs e)
        {
            AbrirPos();
        }

        private void AbrirPos()
        {
            _controlador.AbrirPos();
        }

        private void BT_CERRAR_POS_Click(object sender, EventArgs e)
        {
            CerrarPos();
        }

        private void CerrarPos()
        {
            _controlador.CerrarPos();
        }

        public void setVisibilidad(bool p)
        {
            this.Visible = p;
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_ADM_DOCUMENTOS_Click(object sender, EventArgs e)
        {
            AdmDocumentos();
        }

        private void AdmDocumentos()
        {
            _controlador.AdmDocumentos();
        }

        private void ActualizarJornadaOperadorUsuario()
        {
            L_JORNADA.Text = _controlador.JornadaActiva;
            L_OPERADOR.Text = _controlador.OperadorActivo;
            L_USUARIO.Text = _controlador.UsuarioActual;
            L_EQUIPO_ID.Text = _controlador.EquipoId;
            L_SUCURSAL_ID.Text = _controlador.SucursalId;
            L_VERSION.Text = _controlador.Version;
            L_BD_NOMBRE.Text = _controlador.BD_Nombre;
            L_BD_RUTA.Text = _controlador.BD_Ruta;
        }

        private void MenuItem_Herramientas_TestBD_Click(object sender, EventArgs e)
        {
            Test_BD();
        }

        private void Test_BD()
        {
            _controlador.Test_BD();
        }

        private void MenuItem_Archivo_Salida_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void MenuItem_Configuracion_Sistema_Click(object sender, EventArgs e)
        {
            ConfiguracionSistema();
        }

        private void ConfiguracionSistema()
        {
            _controlador.ConfiguracionSistema();
            ActualizarJornadaOperadorUsuario();
        }

    }

}