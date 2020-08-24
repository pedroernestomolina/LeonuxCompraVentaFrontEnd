﻿using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.QR
{

    public partial class QRFrm : Form
    {

        private Gestion _controlador;


        public QRFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void QRFrm_Load(object sender, EventArgs e)
        {
            QrEncoder qrencoder = new QrEncoder( ErrorCorrectionLevel.H );
            QrCode qrcode = new QrCode();
            qrencoder.TryEncode("http://192.168.100.10/info.php?auto="+_controlador.AutoPrd, out qrcode);
            GraphicsRenderer render = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();
            render.WriteToStream(qrcode.Matrix, System.Drawing.Imaging.ImageFormat.Png, ms);
            var imagenTemporal = new Bitmap(ms);
            var image = new Bitmap(imagenTemporal, new Size(new Point(280, 280)));
            P_RESULTADO.BackgroundImage = image;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

    }

}