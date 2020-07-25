﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema
{

    public partial class Form1 : Form
    {

        private Gestion _controlador;


        public Form1()
        {
            InitializeComponent();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            L_VERSION.Text = _controlador.Version;
        }

        private void TSM_MAESTRO_SucursalGrupo_Click(object sender, EventArgs e)
        {
            SucursalGrupo();
        }

        private void SucursalGrupo()
        {
            _controlador.MaestroSucursalGrupo();
        }

        private void TSM_MAESTRO_Sucursal_Click(object sender, EventArgs e)
        {
            Sucursales();
        }

        private void Sucursales()
        {
            _controlador.MaestroSucursales();
        }

    }

}