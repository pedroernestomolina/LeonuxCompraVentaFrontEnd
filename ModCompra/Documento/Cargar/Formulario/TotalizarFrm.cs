﻿using System;
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

    public partial class TotalizarFrm : Form
    {


        Controlador.GestionTotalizar _controlador; 


        public TotalizarFrm()
        {
            InitializeComponent();
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            _controlador.Guardar();
        }

        public void setControlador(Controlador.GestionTotalizar ctr)
        {
            _controlador = ctr;
        }

    }

}