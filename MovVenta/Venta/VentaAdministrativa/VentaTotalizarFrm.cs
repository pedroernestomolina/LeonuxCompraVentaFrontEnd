using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MovVenta.Venta.VentaAdministrativa
{

    public partial class VentaTotalizarFrm : Form
    {

        public event EventHandler<Totalizar> ProcesarOk;
        private Totalizar _totalizar;
        private decimal _totalVenta;
        private bool _isContado;
        private OOB.LibVenta.Permiso.Ficha _permisoDsctoCargoGlobal;


        public VentaTotalizarFrm()
        {
            InitializeComponent();
            _permisoDsctoCargoGlobal = new OOB.LibVenta.Permiso.Ficha();
            _totalizar = new Totalizar();
        }

        public void Limpiar() 
        {
            _totalizar.setDsctoGlobal(0);
            _totalizar.setCargoGlobal(0);
            TB_DSCTO.Focus();
        }

        private void VentaTotalizarFrm_Load(object sender, EventArgs e)
        {
            L_SUB_TOTAL.Text = _totalVenta.ToString("n2");
            TB_DSCTO.Text = "0.00";
            TB_CARGO.Text = "0.00";
            L_TOTAL.Text = "0.00";
            TB_DSCTO.Enabled = _permisoDsctoCargoGlobal.IsHabilitado;
            TB_CARGO.Enabled = _permisoDsctoCargoGlobal.IsHabilitado;
            Actuailizar();
        }

        public void setSubTotalVenta(decimal monto )
        {
            _totalVenta = monto ;
            _totalizar.setSubTotal(monto);
        }

        public void setFormaPagoIsContado(bool modo)
        {
            _isContado = modo;
        }


        private void TB_DSCTO_Validated(object sender, EventArgs e)
        {
            _totalizar.setDsctoGlobal(decimal.Parse(TB_DSCTO.Text));
            Actuailizar();
        }

        private void TB_CARGO_Validating(object sender, CancelEventArgs e)
        {
            _totalizar.setCargoGlobal(decimal.Parse(TB_CARGO.Text));
            Actuailizar();
        }

        private void Actuailizar()
        {
            L_TOTAL.Text = _totalizar.Total.ToString("n2");
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            EventHandler<Totalizar> handler = ProcesarOk;
            if (handler != null) 
            {
                handler(this, _totalizar);
            }
            Close();
        }

        public void setPermisoDsctoCargoGlobal(OOB.LibVenta.Permiso.Ficha permiso)
        {
            _permisoDsctoCargoGlobal = permiso;
        }

        private void TB_DSCTO_Validating(object sender, CancelEventArgs e)
        {
            if (_permisoDsctoCargoGlobal.NivelSeguridad == OOB.LibVenta.Permiso.Enumerados.EnumNivelSeguridad.Niguna)
            {
                e.Cancel = false;
            }
            else 
            {
                Helpers.Msg.Alerta("NECESITAS CLAVE PARA ACTIVAR OPCION");
                e.Cancel = true;
            }
        }

    }

}