using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.Editar
{

    public partial class EditarFrm : Form
    {


        private Gestion _controlador;
        private bool modoInicializar;


        public EditarFrm()
        {
            InitializeComponent();
            Inicializar();
        }


        private void Inicializar()
        {
            CB_EMPAQUE_1.DisplayMember = "Nombre";
            CB_EMPAQUE_1.ValueMember = "Auto";
            CB_EMPAQUE_2.DisplayMember = "Nombre";
            CB_EMPAQUE_2.ValueMember = "Auto";
            CB_EMPAQUE_3.DisplayMember = "Nombre";
            CB_EMPAQUE_3.ValueMember = "Auto";
            CB_EMPAQUE_4.DisplayMember = "Nombre";
            CB_EMPAQUE_4.ValueMember = "Auto";
            CB_EMPAQUE_5.DisplayMember = "Nombre";
            CB_EMPAQUE_5.ValueMember = "Auto";
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void EditarFrm_Load(object sender, EventArgs e)
        {
            modoInicializar = true;
            CB_EMPAQUE_1.DataSource = _controlador.SourceEmpaque1;
            CB_EMPAQUE_2.DataSource = _controlador.SourceEmpaque2;
            CB_EMPAQUE_3.DataSource = _controlador.SourceEmpaque3;
            CB_EMPAQUE_4.DataSource = _controlador.SourceEmpaque4;
            CB_EMPAQUE_5.DataSource = _controlador.SourceEmpaque5;

            L_PRODUCTO.Text = _controlador.Producto;
            L_METODO.Text = _controlador.MetodoCalculoUtilidad;
            L_TASA_CAMBIO.Text = _controlador.TasaCambioActual;
            L_COSTO.Text = _controlador.CostoUnitario;
            L_ADM_DIVISA.Text = _controlador.AdmDivisa;
            L_TASA_IVA.Text = _controlador.TasaIva;
            L_FECHA_ACT.Text = _controlador.FechaUltActCosto;

            CB_EMPAQUE_1.SelectedValue = _controlador.Precio_1.autoEmpaque;
            L_PRECIO_1.Text = _controlador.Precio_1.etiqueta;
            TB_CONT_1.Text = _controlador.Precio_1.contenido.ToString("N0");
            TB_UTILIDAD_1.Text = _controlador.Precio_1.utilidad.ToString("N2").Replace(".","");
            TB_NETO_1.Text = _controlador.Precio_1.neto.ToString("N2").Replace(".", "");
            TB_FULL_1.Text = _controlador.Precio_1.full.ToString("N2").Replace(".", "");
            L_UT_VIGENTE_1.Text = _controlador.Precio_1.utilidadVigente.ToString("N2").Replace(".", "");

            CB_EMPAQUE_2.SelectedValue = _controlador.Precio_2.autoEmpaque;
            L_PRECIO_2.Text = _controlador.Precio_2.etiqueta;
            TB_CONT_2.Text = _controlador.Precio_2.contenido.ToString("N0");
            TB_UTILIDAD_2.Text = _controlador.Precio_2.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_2.Text = _controlador.Precio_2.neto.ToString("N2").Replace(".", "");
            TB_FULL_2.Text = _controlador.Precio_2.full.ToString("N2").Replace(".", "");
            L_UT_VIGENTE_2.Text = _controlador.Precio_2.utilidadVigente.ToString("N2").Replace(".", "");

            CB_EMPAQUE_3.SelectedValue = _controlador.Precio_3.autoEmpaque;
            L_PRECIO_3.Text = _controlador.Precio_3.etiqueta;
            TB_CONT_3.Text = _controlador.Precio_3.contenido.ToString("N0");
            TB_UTILIDAD_3.Text = _controlador.Precio_3.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_3.Text = _controlador.Precio_3.neto.ToString("N2").Replace(".", "");
            TB_FULL_3.Text = _controlador.Precio_3.full.ToString("N2").Replace(".", "");
            L_UT_VIGENTE_3.Text = _controlador.Precio_3.utilidadVigente.ToString("N2").Replace(".", "");

            CB_EMPAQUE_4.SelectedValue = _controlador.Precio_4.autoEmpaque;
            L_PRECIO_4.Text = _controlador.Precio_4.etiqueta;
            TB_CONT_4.Text = _controlador.Precio_4.contenido.ToString("N0");
            TB_UTILIDAD_4.Text = _controlador.Precio_4.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_4.Text = _controlador.Precio_4.neto.ToString("N2").Replace(".", "");
            TB_FULL_4.Text = _controlador.Precio_4.full.ToString("N2").Replace(".", "");
            L_UT_VIGENTE_4.Text = _controlador.Precio_4.utilidadVigente.ToString("N2").Replace(".", "");

            CB_EMPAQUE_5.SelectedValue = _controlador.Precio_5.autoEmpaque;
            L_PRECIO_5.Text = _controlador.Precio_5.etiqueta;
            TB_CONT_5.Text = _controlador.Precio_5.contenido.ToString("N0");
            TB_UTILIDAD_5.Text = _controlador.Precio_5.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_5.Text = _controlador.Precio_5.neto.ToString("N2").Replace(".", "");
            TB_FULL_5.Text = _controlador.Precio_5.full.ToString("N2").Replace(".", "");
            L_UT_VIGENTE_5.Text = _controlador.Precio_5.utilidadVigente.ToString("N2").Replace(".", "");

            CB_EMPAQUE_1.Enabled= _controlador.Habilitar_Empaque;
            CB_EMPAQUE_2.Enabled = _controlador.Habilitar_Empaque;
            CB_EMPAQUE_3.Enabled = _controlador.Habilitar_Empaque;
            CB_EMPAQUE_4.Enabled = _controlador.Habilitar_Empaque;
            CB_EMPAQUE_5.Enabled = _controlador.Habilitar_Empaque;
            TB_CONT_1.ReadOnly = !_controlador.Habilitar_ContenidoEmpaque;
            TB_CONT_2.ReadOnly = !_controlador.Habilitar_ContenidoEmpaque;
            TB_CONT_3.ReadOnly = !_controlador.Habilitar_ContenidoEmpaque;
            TB_CONT_4.ReadOnly = !_controlador.Habilitar_ContenidoEmpaque;
            TB_CONT_5.ReadOnly = !_controlador.Habilitar_ContenidoEmpaque;
            modoInicializar = false;
        }


        private void CB_EMPAQUE_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modoInicializar == true) { return; }
            _controlador.Precio_1.autoEmpaque = "";
            if (CB_EMPAQUE_1.SelectedIndex != -1) 
            {
                _controlador.Precio_1.autoEmpaque = CB_EMPAQUE_1.SelectedValue.ToString();
            }
        }
        private void TB_CONT_1_TextChanged(object sender, EventArgs e)
        {
            _controlador.Precio_1.contenido = int.Parse(TB_CONT_1.Text);
        }
        private void TB_CONT_1_Validating(object sender, CancelEventArgs e)
        {
            var cont = int.Parse(TB_CONT_1.Text);
            if (cont <= 0)
            {
                e.Cancel = true;
            }
        }
        private void TB_UTILIDAD_1_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_1.utilidad = decimal.Parse(TB_UTILIDAD_1.Text);
            TB_UTILIDAD_1.Text = _controlador.Precio_1.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_1.Text = _controlador.Precio_1.neto.ToString("N2").Replace(".", "");
            TB_FULL_1.Text = _controlador.Precio_1.full.ToString("N2").Replace(".","");
        }
        private void TB_NETO_1_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_1.neto = decimal.Parse(TB_NETO_1.Text);
            TB_UTILIDAD_1.Text = _controlador.Precio_1.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_1.Text = _controlador.Precio_1.neto.ToString("N2").Replace(".", "");
            TB_FULL_1.Text = _controlador.Precio_1.full.ToString("N2").Replace(".", ""); 
        }
        private void TB_FULL_1_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_1.full = decimal.Parse(TB_FULL_1.Text);
            TB_FULL_1.Text = _controlador.Precio_1.full.ToString("N2").Replace(".", "");
            TB_UTILIDAD_1.Text = _controlador.Precio_1.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_1.Text = _controlador.Precio_1.neto.ToString("N2").Replace(".", "");
        }


        private void CB_EMPAQUE_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modoInicializar == true) { return; }
            _controlador.Precio_2.autoEmpaque = "";
            if (CB_EMPAQUE_2.SelectedIndex != -1)
            {
                _controlador.Precio_2.autoEmpaque = CB_EMPAQUE_2.SelectedValue.ToString();
            }
        }
        private void TB_CONT_2_TextChanged(object sender, EventArgs e)
        {
            _controlador.Precio_2.contenido = int.Parse(TB_CONT_2.Text);
        }
        private void TB_CONT_2_Validating(object sender, CancelEventArgs e)
        {
            var cont = int.Parse(TB_CONT_2.Text);
            if (cont <= 0)
            {
                e.Cancel = true;
            }
        }
        private void TB_UTILIDAD_2_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_2.utilidad = decimal.Parse(TB_UTILIDAD_2.Text);
            TB_UTILIDAD_2.Text = _controlador.Precio_2.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_2.Text = _controlador.Precio_2.neto.ToString("N2").Replace(".", "");
            TB_FULL_2.Text = _controlador.Precio_2.full.ToString("N2").Replace(".", "");
        }
        private void TB_NETO_2_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_2.neto = decimal.Parse(TB_NETO_2.Text);
            TB_UTILIDAD_2.Text = _controlador.Precio_2.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_2.Text = _controlador.Precio_2.neto.ToString("N2").Replace(".", "");
            TB_FULL_2.Text = _controlador.Precio_2.full.ToString("N2").Replace(".", "");
        }
        private void TB_FULL_2_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_2.full = decimal.Parse(TB_FULL_2.Text);
            TB_FULL_2.Text = _controlador.Precio_2.full.ToString("N2").Replace(".", "");
            TB_UTILIDAD_2.Text = _controlador.Precio_2.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_2.Text = _controlador.Precio_2.neto.ToString("N2").Replace(".", "");
        }


        private void CB_EMPAQUE_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modoInicializar == true) { return; }
            _controlador.Precio_3.autoEmpaque = "";
            if (CB_EMPAQUE_3.SelectedIndex != -3)
            {
                _controlador.Precio_3.autoEmpaque = CB_EMPAQUE_3.SelectedValue.ToString();
            }
        }
        private void TB_CONT_3_TextChanged(object sender, EventArgs e)
        {
            _controlador.Precio_3.contenido = int.Parse(TB_CONT_3.Text);
        }
        private void TB_CONT_3_Validating(object sender, CancelEventArgs e)
        {
            var cont = int.Parse(TB_CONT_3.Text);
            if (cont <= 0)
            {
                e.Cancel = true;
            }
        }
        private void TB_UTILIDAD_3_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_3.utilidad = decimal.Parse(TB_UTILIDAD_3.Text);
            TB_UTILIDAD_3.Text = _controlador.Precio_3.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_3.Text = _controlador.Precio_3.neto.ToString("N2").Replace(".", "");
            TB_FULL_3.Text = _controlador.Precio_3.full.ToString("N2").Replace(".", "");
        }
        private void TB_NETO_3_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_3.neto = decimal.Parse(TB_NETO_3.Text);
            TB_UTILIDAD_3.Text = _controlador.Precio_3.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_3.Text = _controlador.Precio_3.neto.ToString("N2").Replace(".", "");
            TB_FULL_3.Text = _controlador.Precio_3.full.ToString("N2").Replace(".", "");
        }
        private void TB_FULL_3_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_3.full = decimal.Parse(TB_FULL_3.Text);
            TB_FULL_3.Text = _controlador.Precio_3.full.ToString("N2").Replace(".", "");
            TB_UTILIDAD_3.Text = _controlador.Precio_3.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_3.Text = _controlador.Precio_3.neto.ToString("N2").Replace(".", "");
        }


        private void CB_EMPAQUE_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modoInicializar == true) { return; }
            _controlador.Precio_4.autoEmpaque = "";
            if (CB_EMPAQUE_4.SelectedIndex != -4)
            {
                _controlador.Precio_4.autoEmpaque = CB_EMPAQUE_4.SelectedValue.ToString();
            }
        }
        private void TB_CONT_4_TextChanged(object sender, EventArgs e)
        {
            _controlador.Precio_4.contenido = int.Parse(TB_CONT_4.Text);
        }
        private void TB_CONT_4_Validating(object sender, CancelEventArgs e)
        {
            var cont = int.Parse(TB_CONT_4.Text);
            if (cont <= 0)
            {
                e.Cancel = true;
            }
        }
        private void TB_UTILIDAD_4_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_4.utilidad = decimal.Parse(TB_UTILIDAD_4.Text);
            TB_UTILIDAD_4.Text = _controlador.Precio_4.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_4.Text = _controlador.Precio_4.neto.ToString("N2").Replace(".", "");
            TB_FULL_4.Text = _controlador.Precio_4.full.ToString("N2").Replace(".", "");
        }
        private void TB_NETO_4_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_4.neto = decimal.Parse(TB_NETO_4.Text);
            TB_UTILIDAD_4.Text = _controlador.Precio_4.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_4.Text = _controlador.Precio_4.neto.ToString("N2").Replace(".", "");
            TB_FULL_4.Text = _controlador.Precio_4.full.ToString("N2").Replace(".", "");
        }
        private void TB_FULL_4_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_4.full = decimal.Parse(TB_FULL_4.Text);
            TB_FULL_4.Text = _controlador.Precio_4.full.ToString("N2").Replace(".", "");
            TB_UTILIDAD_4.Text = _controlador.Precio_4.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_4.Text = _controlador.Precio_4.neto.ToString("N2").Replace(".", "");
        }


        private void CB_EMPAQUE_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modoInicializar == true) { return; }
            _controlador.Precio_5.autoEmpaque = "";
            if (CB_EMPAQUE_5.SelectedIndex != -5)
            {
                _controlador.Precio_5.autoEmpaque = CB_EMPAQUE_5.SelectedValue.ToString();
            }
        }
        private void TB_CONT_5_TextChanged(object sender, EventArgs e)
        {
            _controlador.Precio_5.contenido = int.Parse(TB_CONT_5.Text);
        }
        private void TB_CONT_5_Validating(object sender, CancelEventArgs e)
        {
            var cont = int.Parse(TB_CONT_5.Text);
            if (cont <= 0)
            {
                e.Cancel = true;
            }
        }
        private void TB_UTILIDAD_5_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_5.utilidad = decimal.Parse(TB_UTILIDAD_5.Text);
            TB_UTILIDAD_5.Text = _controlador.Precio_5.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_5.Text = _controlador.Precio_5.neto.ToString("N2").Replace(".", "");
            TB_FULL_5.Text = _controlador.Precio_5.full.ToString("N2").Replace(".", "");
        }
        private void TB_NETO_5_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_5.neto = decimal.Parse(TB_NETO_5.Text);
            TB_UTILIDAD_5.Text = _controlador.Precio_5.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_5.Text = _controlador.Precio_5.neto.ToString("N2").Replace(".", "");
            TB_FULL_5.Text = _controlador.Precio_5.full.ToString("N2").Replace(".", "");
        }
        private void TB_FULL_5_Leave(object sender, EventArgs e)
        {
            _controlador.Precio_5.full = decimal.Parse(TB_FULL_5.Text);
            TB_FULL_5.Text = _controlador.Precio_5.full.ToString("N2").Replace(".", "");
            TB_UTILIDAD_5.Text = _controlador.Precio_5.utilidad.ToString("N2").Replace(".", "");
            TB_NETO_5.Text = _controlador.Precio_5.neto.ToString("N2").Replace(".", "");
        }


        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_MODO_PRECIO_Click(object sender, EventArgs e)
        {
            ModoPrecioSw();
        }

        private void ModoPrecioSw()
        {
            _controlador.ModoPrecioSw();
            TB_NETO_1.Text = _controlador.Precio_1.neto.ToString("N2").Replace(".", "");
            TB_FULL_1.Text = _controlador.Precio_1.full.ToString("N2").Replace(".", "");
            TB_NETO_2.Text = _controlador.Precio_2.neto.ToString("N2").Replace(".", "");
            TB_FULL_2.Text = _controlador.Precio_2.full.ToString("N2").Replace(".", "");
            TB_NETO_3.Text = _controlador.Precio_3.neto.ToString("N2").Replace(".", "");
            TB_FULL_3.Text = _controlador.Precio_3.full.ToString("N2").Replace(".", "");
            TB_NETO_4.Text = _controlador.Precio_4.neto.ToString("N2").Replace(".", "");
            TB_FULL_4.Text = _controlador.Precio_4.full.ToString("N2").Replace(".", "");
            TB_NETO_5.Text = _controlador.Precio_5.neto.ToString("N2").Replace(".", "");
            TB_FULL_5.Text = _controlador.Precio_5.full.ToString("N2").Replace(".", "");
            TB_CONT_1.Focus();
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
        }

        private void TB_NETO_1_Validating(object sender, CancelEventArgs e)
        {
            bool bStatus = true;
            var valor = decimal.Parse(TB_NETO_1.Text);
            if (valor != 0.0m)
            {
                if (valor <= _controlador.Precio_1.Costo)
                {
                    errorProvider1.SetError(TB_NETO_1, "Precio Por Debajo Del Costo, Verifique !!");
                    bStatus = false;
                }
                else
                    errorProvider1.SetError(TB_NETO_1, "");
            }
            else 
            {
                errorProvider1.SetError(TB_NETO_1, "");
            }

            e.Cancel =!bStatus;  
        }

        private void TB_FULL_1_Validating(object sender, CancelEventArgs e)
        {
            bool bStatus = true;
            var valor = decimal.Parse(TB_FULL_1.Text);
            if (valor != 0.0m)
            {
                if (valor <= _controlador.Precio_1.CostoFull)
                {
                    errorProvider1.SetError(TB_FULL_1, "Precio Por Debajo Del Costo, Verifique !!");
                    bStatus = false;
                }
                else
                    errorProvider1.SetError(TB_FULL_1, "");
            }
            else 
            {
                errorProvider1.SetError(TB_FULL_1, "");
            }

            e.Cancel = !bStatus;
        }

        private void TB_NETO_2_Validating(object sender, CancelEventArgs e)
        {
            bool bStatus = true;
            var valor = decimal.Parse(TB_NETO_2.Text);
            if (valor != 0.0m)
            {
                if (valor <= _controlador.Precio_2.Costo)
                {
                    errorProvider1.SetError(TB_NETO_2, "Precio Por Debajo Del Costo, Verifique !!");
                    bStatus = false;
                }
                else
                    errorProvider1.SetError(TB_NETO_2, "");
            }
            else
            {
                errorProvider1.SetError(TB_NETO_2, "");
            }

            e.Cancel = !bStatus;  
        }

        private void TB_FULL_2_Validating(object sender, CancelEventArgs e)
        {
            bool bStatus = true;
            var valor = decimal.Parse(TB_FULL_2.Text);
            if (valor != 0.0m)
            {
                if (valor <= _controlador.Precio_2.CostoFull)
                {
                    errorProvider1.SetError(TB_FULL_2, "Precio Por Debajo Del Costo, Verifique !!");
                    bStatus = false;
                }
                else
                    errorProvider1.SetError(TB_FULL_2, "");
            }
            else
            {
                errorProvider1.SetError(TB_FULL_2, "");
            }

            e.Cancel = !bStatus;
        }

    }

}
