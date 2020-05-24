using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Configuracion
{

    public partial class ConfigurarFrm : Form
    {

        private BindingSource bs_Deposito;
        private BindingSource bs_Cobrador;
        private BindingSource bs_Vendedor;
        private BindingSource bs_Transporte;
        private BindingSource bs_SerieFactura;
        private BindingSource bs_SerieNotaCredito ;
        private BindingSource bs_SerieNotaDebito;
        private BindingSource bs_MedioEfectivo;
        private BindingSource bs_MedioDivisa;
        private BindingSource bs_MedioElectronico;
        private BindingSource bs_MedioOtro;

        private List<OOB.LibVenta.PosOffline.Deposito.Ficha> LDeposito;
        private List<OOB.LibVenta.PosOffline.Cobrador.Ficha> LCobrador;
        private List<OOB.LibVenta.PosOffline.Vendedor.Ficha> LVendedor;
        private List<OOB.LibVenta.PosOffline.Transporte.Ficha> LTransporte;
        private List<OOB.LibVenta.PosOffline.Serie.Ficha > LSerieFactura;
        private List<OOB.LibVenta.PosOffline.Serie.Ficha> LSerieNotaCredito;
        private List<OOB.LibVenta.PosOffline.Serie.Ficha> LSerieNotaDebito;
        private List<OOB.LibVenta.PosOffline.MedioCobro.Ficha> LMedioEfectivo;
        private List<OOB.LibVenta.PosOffline.MedioCobro.Ficha> LMedioDivisa;
        private List<OOB.LibVenta.PosOffline.MedioCobro.Ficha> LMedioElectronico;
        private List<OOB.LibVenta.PosOffline.MedioCobro.Ficha> LMedioOtro;

        private OOB.LibVenta.PosOffline.Configuracion.Actual.Ficha _cnfActual;


        public ConfigurarFrm()
        {
            InitializeComponent();
            LDeposito = new List<OOB.LibVenta.PosOffline.Deposito.Ficha>();
            LVendedor = new List<OOB.LibVenta.PosOffline.Vendedor.Ficha>();
            LCobrador = new List<OOB.LibVenta.PosOffline.Cobrador.Ficha>();
            LTransporte = new List<OOB.LibVenta.PosOffline.Transporte.Ficha>();
            LSerieFactura= new List<OOB.LibVenta.PosOffline.Serie.Ficha>();
            LSerieNotaCredito = new List<OOB.LibVenta.PosOffline.Serie.Ficha>();
            LSerieNotaDebito= new List<OOB.LibVenta.PosOffline.Serie.Ficha>();
            LMedioEfectivo = new List<OOB.LibVenta.PosOffline.MedioCobro.Ficha>();
            LMedioDivisa = new List<OOB.LibVenta.PosOffline.MedioCobro.Ficha>();
            LMedioElectronico = new List<OOB.LibVenta.PosOffline.MedioCobro.Ficha>();
            LMedioOtro= new List<OOB.LibVenta.PosOffline.MedioCobro.Ficha>();

            bs_Deposito = new BindingSource();
            bs_Cobrador= new BindingSource();
            bs_Vendedor = new BindingSource();
            bs_Transporte = new BindingSource();
            bs_SerieFactura = new BindingSource();
            bs_SerieNotaCredito= new BindingSource();
            bs_SerieNotaDebito= new BindingSource();
            bs_MedioEfectivo = new BindingSource();
            bs_MedioDivisa = new BindingSource();
            bs_MedioElectronico = new BindingSource();
            bs_MedioOtro = new BindingSource();

            bs_Deposito.DataSource = LDeposito;
            bs_Cobrador.DataSource = LCobrador;
            bs_Vendedor.DataSource = LVendedor;
            bs_Transporte.DataSource = LTransporte;
            bs_SerieFactura.DataSource = LSerieFactura;
            bs_SerieNotaCredito.DataSource = LSerieNotaCredito;
            bs_SerieNotaDebito.DataSource = LSerieNotaDebito;
            bs_MedioEfectivo.DataSource = LMedioEfectivo;
            bs_MedioDivisa.DataSource = LMedioDivisa;
            bs_MedioElectronico.DataSource = LMedioElectronico;
            bs_MedioOtro.DataSource = LMedioOtro;
        }

        public bool CargarData() 
        {
            var rt = false;

            var r01 = Sistema.MyData2.Deposito_Lista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return rt;
            }
            LDeposito.Clear();
            LDeposito.AddRange(r01.Lista);

            var r02 = Sistema.MyData2.Cobrador_Lista ();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return rt;
            }
            LCobrador.Clear();
            LCobrador.AddRange(r02.Lista);

            var r03 = Sistema.MyData2.Vendedor_Lista();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return rt;
            }
            LVendedor.Clear();
            LVendedor.AddRange(r03.Lista);

            var r04 = Sistema.MyData2.Transporte_Lista();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return rt;
            }
            LTransporte.Clear();
            LTransporte.AddRange(r04.Lista);

            var r05 = Sistema.MyData2.MedioCobro_Lista ();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return rt;
            }
            LMedioEfectivo.Clear();
            LMedioEfectivo.AddRange(r05.Lista);
            LMedioDivisa.Clear();
            LMedioDivisa.AddRange(r05.Lista);
            LMedioElectronico.Clear();
            LMedioElectronico.AddRange(r05.Lista);
            LMedioOtro.Clear();
            LMedioOtro.AddRange(r05.Lista);

            var r06 = Sistema.MyData2.Serie_Lista();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return rt;
            }
            LSerieFactura.Clear();
            LSerieFactura.AddRange(r06.Lista);
            LSerieNotaDebito.Clear();
            LSerieNotaDebito.AddRange(r06.Lista);
            LSerieNotaCredito.Clear();
            LSerieNotaCredito.AddRange(r06.Lista);

            var r07 = Sistema.MyData2.Configuracion_ActualCargar();
            if (r07.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r07.Mensaje);
                return rt;
            }
            _cnfActual = r07.Entidad;

            rt = true;
            return rt;
        }

        private void Inicializar() 
        {
            CB_DEPOSITO.DisplayMember = "Nombre";
            CB_DEPOSITO.ValueMember = "Auto";
            CB_DEPOSITO.DataSource = bs_Deposito;

            CB_COBRADOR.DisplayMember = "Nombre";
            CB_COBRADOR.ValueMember = "Auto";
            CB_COBRADOR.DataSource = bs_Cobrador;

            CB_VENDEDOR.DisplayMember = "Nombre";
            CB_VENDEDOR.ValueMember = "Auto";
            CB_VENDEDOR.DataSource = bs_Vendedor;

            CB_TRANSPORTE.DisplayMember = "Nombre";
            CB_TRANSPORTE.ValueMember = "Auto";
            CB_TRANSPORTE.DataSource = bs_Transporte;

            CB_TRANSPORTE.DisplayMember = "Nombre";
            CB_TRANSPORTE.ValueMember = "Auto";
            CB_TRANSPORTE.DataSource = bs_Transporte;

            CB_FACTURA.DisplayMember = "Nombre";
            CB_FACTURA.ValueMember = "Auto";
            CB_FACTURA.DataSource = bs_SerieFactura;

            CB_NOTA_CREDITO.DisplayMember = "Nombre";
            CB_NOTA_CREDITO.ValueMember = "Auto";
            CB_NOTA_CREDITO.DataSource = bs_SerieNotaCredito;

            CB_NOTA_DEBITO.DisplayMember = "Nombre";
            CB_NOTA_DEBITO.ValueMember = "Auto";
            CB_NOTA_DEBITO.DataSource = bs_SerieNotaDebito;

            CB_MEDIO_EFECTIVO.DisplayMember = "Nombre";
            CB_MEDIO_EFECTIVO.ValueMember = "Auto";
            CB_MEDIO_EFECTIVO.DataSource = bs_MedioEfectivo;

            CB_MEDIO_DIVISA.DisplayMember = "Nombre";
            CB_MEDIO_DIVISA.ValueMember = "Auto";
            CB_MEDIO_DIVISA.DataSource = bs_MedioDivisa;

            CB_MEDIO_ELECTRONICO.DisplayMember = "Nombre";
            CB_MEDIO_ELECTRONICO.ValueMember = "Auto";
            CB_MEDIO_ELECTRONICO.DataSource = bs_MedioElectronico;

            CB_MEDIO_OTRO.DisplayMember = "Nombre";
            CB_MEDIO_OTRO.ValueMember = "Auto";
            CB_MEDIO_OTRO.DataSource = bs_MedioOtro;

            TB_CODIGO_SUCURSAL.Text = "";
            TB_LIMITE_INFERIOR.Text = "0,0";
            TB_LIMITE_SUPERIOR.Text = "0,0";
            CHB_REPESAJE.Checked = true;
            RB_BUSQUEDA_DESCRIPCION_SI.Checked = true;
            CHB_REPESAJE.Checked = false;
        }

        private void ConfigurarFrm_Load(object sender, EventArgs e)
        {
            Inicializar();

            CB_MEDIO_EFECTIVO.SelectedValue = _cnfActual.AutoMedioEfectivo;
            CB_MEDIO_DIVISA.SelectedValue = _cnfActual.AutoMedioDivisa;
            CB_MEDIO_ELECTRONICO.SelectedValue = _cnfActual.AutoMedioElectronico;
            CB_MEDIO_OTRO.SelectedValue = _cnfActual.AutoMedioOtro;

            CB_DEPOSITO.SelectedValue = _cnfActual.AutoDeposito;
            CB_TRANSPORTE.SelectedValue = _cnfActual.AutoTransporte;
            CB_COBRADOR.SelectedValue = _cnfActual.AutoCobrador;
            CB_VENDEDOR.SelectedValue = _cnfActual.AutoVendedor;

            CB_FACTURA.SelectedValue = _cnfActual.SerieFactura;
            CB_NOTA_CREDITO.SelectedValue = _cnfActual.SerieNotaCredito;
            CB_NOTA_DEBITO.SelectedValue = _cnfActual.SerieNotaDebito;

            RB_BUSQUEDA_DESCRIPCION_NO.Checked = true;
            TB_CODIGO_SUCURSAL.Text = _cnfActual.CodigoSucursal;
            TB_LIMITE_INFERIOR.Text = _cnfActual.LimiteInferiorRepesaje.ToString("n2");
            TB_LIMITE_SUPERIOR.Text = _cnfActual.LimiteSuperiorRepesaje.ToString("n2");
            CHB_REPESAJE.Checked = _cnfActual.ActivarRepesaje;
            RB_BUSQUEDA_DESCRIPCION_SI.Checked = _cnfActual.ActivarBusquedaPorDescripcion;
            CB_CLAVE.SelectedIndex = _cnfActual.ClavePos - 1;
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        private void GuardarCambios()
        {
            var sucursal = TB_CODIGO_SUCURSAL.Text.Trim().ToUpper();
            var lim_sup = decimal.Parse(TB_LIMITE_SUPERIOR.Text);
            var lim_inf = decimal.Parse(TB_LIMITE_INFERIOR.Text);

            if (CB_MEDIO_EFECTIVO.SelectedValue == null) 
            {
                return;
            }
            if (CB_MEDIO_DIVISA.SelectedValue == null)
            {
                return;
            }
            if (CB_MEDIO_ELECTRONICO.SelectedValue == null)
            {
                return;
            }
            if (CB_MEDIO_OTRO.SelectedValue == null)
            {
                return;
            }
            if (CB_FACTURA.SelectedValue == null)
            {
                return;
            }
            if (CB_NOTA_CREDITO.SelectedValue == null)
            {
                return;
            }
            if (CB_NOTA_DEBITO.SelectedValue == null)
            {
                return;
            }
            if (CB_DEPOSITO.SelectedValue == null)
            {
                return;
            }
            if (CB_TRANSPORTE.SelectedValue == null)
            {
                return;
            }
            if (CB_COBRADOR.SelectedValue == null)
            {
                return;
            }
            if (CB_VENDEDOR.SelectedValue == null)
            {
                return;
            }
            if (CB_CLAVE.SelectedIndex == -1)
            {
                return;
            }
            if (sucursal == "") 
            {
                return;
            }
            if (CHB_REPESAJE.Checked) 
            {
                //if (lim_sup == 0.0m || lim_inf==0.0m) 
                //{
                //    return;
                //}
                if (lim_sup < lim_inf )
                {
                    return;
                }
            }

            var msg = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes) 
            {
                var fichaCnf = new OOB.LibVenta.PosOffline.Configuracion.Guardar.Ficha()
                {
                    ActivarBusquedaPorDescripcion = RB_BUSQUEDA_DESCRIPCION_SI.Checked ? "S" : "N",
                    ActivarRepesaje = CHB_REPESAJE.Checked ? "S" : "N",
                    AutoCobrador = (string)CB_COBRADOR.SelectedValue,
                    AutoDeposito = (string)CB_DEPOSITO.SelectedValue,
                    AutoMedioDivisa = (string)CB_MEDIO_DIVISA.SelectedValue,
                    AutoMedioEfectivo = (string)CB_MEDIO_EFECTIVO.SelectedValue,
                    AutoMedioElectronico = (string)CB_MEDIO_ELECTRONICO.SelectedValue,
                    AutoMedioOtro = (string)CB_MEDIO_OTRO.SelectedValue,
                    AutoTransporte = (string)CB_TRANSPORTE.SelectedValue,
                    AutoVendedor = (string)CB_VENDEDOR.SelectedValue,
                    ClavePos = CB_CLAVE.SelectedIndex + 1,
                    CodigoSucursal = sucursal,
                    LimiteInferiorRepesaje = lim_inf,
                    LimiteSuperiorRepesaje = lim_sup,
                    SerieFactura = (string)CB_FACTURA.SelectedValue,
                    SerieNotaCredito = (string)CB_NOTA_CREDITO.SelectedValue,
                    SerieNotaDebito = (string)CB_NOTA_DEBITO.SelectedValue,
                };
                var r01 = Sistema.MyData2.Configuracion_GuardarCambio(fichaCnf);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                Helpers.Msg.EditarOk();
                Salir();
            }
        }

        private void CHB_REPESAJE_CheckedChanged(object sender, EventArgs e)
        {
            TB_LIMITE_INFERIOR.Enabled = CHB_REPESAJE.Checked;
            TB_LIMITE_SUPERIOR.Enabled = CHB_REPESAJE.Checked;
        }

    }

}