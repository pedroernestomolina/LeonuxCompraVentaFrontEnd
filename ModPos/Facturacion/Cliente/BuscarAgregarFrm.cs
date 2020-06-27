using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion.Cliente
{

    public partial class BuscarAgregarFrm : Form
    {

        private Buscar _buscar;


        public BuscarAgregarFrm()
        {
            InitializeComponent();
            RB_CI.Checked = true;
        }

        private void Salida()
        {
            this.Close();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            GuardarCliente();
        }

        private void GuardarCliente()
        {
            var cirif=TB_CIRIF.Text.Trim().ToUpper();
            var nombre=TB_NOMBRE.Text.Trim().ToUpper();
            var dirFiscal=TB_DIRFISCAL.Text.Trim().ToUpper();
            var telefono=TB_TELEFONO.Text.Trim();
            var result= _buscar.AgregarCliente(cirif,nombre,dirFiscal,telefono);
            if (result) 
            {
                HabilitarAceptar();
            }
        }

        private void HabilitarAceptar()
        {
            BT_GUARDAR.Enabled = false;
            TB_CIRIF.Enabled = false;
            TB_NOMBRE.Enabled = false;
            TB_DIRFISCAL.Enabled = false;
            TB_TELEFONO.Enabled = false;
            BT_ACEPTAR.Enabled = true;
            BT_ACEPTAR.Focus();
        }

        private void BuscarAgregarFrm_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void IrFocoPrincipal()
        {
            TB_BUSCAR.Focus();
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            BuscarOn();

            TB_CIRIF.Text = "";
            TB_NOMBRE.Text = "";
            TB_DIRFISCAL.Text = "";
            TB_TELEFONO.Text = "";

            TB_CIRIF.Enabled = false;
            TB_NOMBRE.Enabled = false;
            TB_DIRFISCAL.Enabled = false;
            TB_TELEFONO.Enabled = false;

            BT_ACEPTAR.Enabled = false;
            BT_GUARDAR.Enabled = false;

            _buscar.Limpiar();

            IrFocoPrincipal();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void TB_BUSCAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (RB_CI.Checked)
                {
                    var cirif=TB_BUSCAR.Text.Trim().ToUpper();
                    var result= _buscar.BuscarPorCiRif(cirif);
                    if (result)
                    {
                        if (_buscar.FichaCliente.Id == 0)
                        {
                            var msg = MessageBox.Show("Cliente No Registrado !!, Deseas Agregarlo ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (msg == System.Windows.Forms.DialogResult.Yes)
                            {
                                BuscarOff();
                                TB_CIRIF.Enabled = false;
                                TB_CIRIF.Text = cirif;
                                TB_NOMBRE.Enabled = true;
                                TB_DIRFISCAL.Enabled = true;
                                TB_TELEFONO.Enabled = true;
                                BT_GUARDAR.Enabled = true;
                                TB_NOMBRE.Focus();
                                e.Handled = true;
                            }
                            else
                            {
                                e.Handled = false;
                            }
                        }
                        else
                        {
                            MostrarCargar();
                            e.Handled = true;
                        }
                    };

                }
                else 
                {
                    var nombre = TB_BUSCAR.Text.Trim().ToUpper();
                    if (_buscar.Listar(nombre)) 
                    {
                        MostrarCargar();
                        e.Handled = true;
                    }
                }
            }
        }

        private void MostrarCargar()
        {
            BuscarOff();
            TB_CIRIF.Text = _buscar.FichaCliente.CiRif;
            TB_NOMBRE.Text = _buscar.FichaCliente.NombreRazaonSocial;
            TB_DIRFISCAL.Text = _buscar.FichaCliente.DirFiscal;
            TB_TELEFONO.Text = _buscar.FichaCliente.Telefono;
            BT_ACEPTAR.Enabled = true;
            BT_ACEPTAR.Focus();
        }

        private void BuscarOff()
        {
            TB_BUSCAR.Text = "";
            TB_BUSCAR.Enabled = false;
            RB_CI.Enabled = false;
            RB_NOMBRE.Enabled = false;
        }

        private void BuscarOn()
        {
            TB_BUSCAR.Text = "";
            TB_BUSCAR.Enabled = true;
            RB_CI.Enabled = true;
            RB_NOMBRE.Enabled = true;
        }

        private void RB_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            TB_BUSCAR.Text = "";
            IrFocoPrincipal();
        }

        private void RB_CI_CheckedChanged(object sender, EventArgs e)
        {
            TB_BUSCAR.Text = "";
            IrFocoPrincipal();
        }

        public void setControlador(Buscar ctr) 
        {
            _buscar = ctr;
        }

    }

}