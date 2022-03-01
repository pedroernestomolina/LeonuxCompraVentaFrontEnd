using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Configuracion.Modulo
{

    public partial class CnfModuloFrm : Form
    {

        private Gestion _controlador;
        private bool _pv1;
        private bool _pv2;
        private bool _pv3;


        public CnfModuloFrm()
        {
            InitializeComponent();
            Inicializa();
        }

        private void Inicializa()
        {
            CB_PRD_INACTIVO.DisplayMember = "desc";
            CB_PRD_INACTIVO.ValueMember = "id";
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Abandonar();
        }
        private void Abandonar()
        {
            _controlador.AbandonarFicha();
            if (_controlador.AbandonarFichaIsOk) 
            {
                Salir();
            }
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            _controlador.ProcesarFicha();
            if (_controlador.ProcesarFichaIsOk)
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }

        private void CnfModuloFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarFichaIsOk || _controlador.ProcesarFichaIsOk)
            {
                e.Cancel = false;
            }
        }

        bool _modoInicializar;
        private void CnfModuloFrm_Load(object sender, EventArgs e)
        {
            _pv1 = false;
            _pv2 = false;
            _pv3 = false;

            _modoInicializar = true;
            CB_PRD_INACTIVO.DataSource = _controlador.SourcePrdInactivo;
            CB_PRD_INACTIVO.SelectedValue = _controlador.PrdInactivoID;
            TB_CLAVE_MAX.Text = _controlador.ClaveMaxima;
            TB_CLAVE_MED.Text = _controlador.ClaveMedia;
            TB_CLAVE_MIN.Text = _controlador.ClaveMinima;
            TB_CNT_DOC.Value = _controlador.CntDocVisualizar;
            _modoInicializar = false;
        }

        private void L_CLAVE_MAX_Click(object sender, EventArgs e)
        {
            _pv1 = !_pv1;
            if (_pv1) { TB_CLAVE_MAX.PasswordChar = '\0'; }
            else { TB_CLAVE_MAX.PasswordChar = '*'; }
        }

        private void L_CLAVE_MED_Click(object sender, EventArgs e)
        {
            _pv2 = !_pv2;
            if (_pv2) { TB_CLAVE_MED.PasswordChar = '\0'; }
            else { TB_CLAVE_MED.PasswordChar = '*'; }
        }

        private void L_CLAVE_MIN_Click(object sender, EventArgs e)
        {
            _pv3 = !_pv3;
            if (_pv3) { TB_CLAVE_MIN.PasswordChar = '\0'; }
            else { TB_CLAVE_MIN.PasswordChar = '*'; }
        }

        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_CLAVE_MAX_Leave(object sender, EventArgs e)
        {
            _controlador.setClaveMaxima(TB_CLAVE_MAX.Text);
        }
        private void TB_CLAVE_MED_Leave(object sender, EventArgs e)
        {
            _controlador.setClaveMedia(TB_CLAVE_MED.Text);
        }
        private void TB_CLAVE_MIN_Leave(object sender, EventArgs e)
        {
            _controlador.setClaveMinima(TB_CLAVE_MIN.Text);
        }
        private void TB_CNT_DOC_Leave(object sender, EventArgs e)
        {
            _controlador.setCntDocVisualizar(TB_CNT_DOC.Value);
        }
        private void CB_PRD_INACTIVO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoInicializar)
                return;

            _controlador.setPrdInactivo("");
            if (CB_PRD_INACTIVO.SelectedIndex != -1)
            {
                _controlador.setPrdInactivo(CB_PRD_INACTIVO.SelectedValue.ToString());
            }
        }

    }

}