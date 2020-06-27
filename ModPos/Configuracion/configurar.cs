using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Configuracion
{
    
    public class configurar
    {

        private BindingSource bs_Deposito;
        private BindingSource bs_Cobrador;
        private BindingSource bs_Vendedor;
        private BindingSource bs_Transporte;
        private BindingSource bs_SerieFactura;
        private BindingSource bs_SerieNotaCredito;
        private BindingSource bs_SerieNotaDebito;
        private BindingSource bs_SerieNotaEntrega;
        private BindingSource bs_MedioEfectivo;
        private BindingSource bs_MedioDivisa;
        private BindingSource bs_MedioElectronico;
        private BindingSource bs_MedioOtro;
        private BindingSource bs_MovVenta;
        private BindingSource bs_MovDevVenta;
        private BindingSource bs_MovSalida;

        private List<OOB.LibVenta.PosOffline.Deposito.Ficha> LDeposito;
        private List<OOB.LibVenta.PosOffline.Cobrador.Ficha> LCobrador;
        private List<OOB.LibVenta.PosOffline.Vendedor.Ficha> LVendedor;
        private List<OOB.LibVenta.PosOffline.Transporte.Ficha> LTransporte;
        private List<OOB.LibVenta.PosOffline.Serie.Ficha> LSerieFactura;
        private List<OOB.LibVenta.PosOffline.Serie.Ficha> LSerieNotaCredito;
        private List<OOB.LibVenta.PosOffline.Serie.Ficha> LSerieNotaDebito;
        private List<OOB.LibVenta.PosOffline.Serie.Ficha> LSerieNotaEntrega;
        private List<OOB.LibVenta.PosOffline.MedioCobro.Ficha> LMedioEfectivo;
        private List<OOB.LibVenta.PosOffline.MedioCobro.Ficha> LMedioDivisa;
        private List<OOB.LibVenta.PosOffline.MedioCobro.Ficha> LMedioElectronico;
        private List<OOB.LibVenta.PosOffline.MedioCobro.Ficha> LMedioOtro;
        private List<OOB.LibVenta.PosOffline.MovConceptoInv.Ficha> LMovVenta;
        private List<OOB.LibVenta.PosOffline.MovConceptoInv.Ficha> LMovDevVenta;
        private List<OOB.LibVenta.PosOffline.MovConceptoInv.Ficha> LMovSalida;
        private OOB.LibVenta.PosOffline.Configuracion.Actual.Ficha _cnfActual;


        public BindingSource _bs_Deposito { get {return bs_Deposito;} }
        public BindingSource _bs_Cobrador { get {return bs_Cobrador;} }
        public BindingSource _bs_Vendedor { get {return bs_Vendedor;} }
        public BindingSource _bs_Transporte { get {return bs_Transporte;} }
        public BindingSource _bs_SerieFactura { get {return bs_SerieFactura;} }
        public BindingSource _bs_SerieNotaCredito { get {return bs_SerieNotaCredito;} }
        public BindingSource _bs_SerieNotaDebito { get {return bs_SerieNotaDebito;} }
        public BindingSource _bs_SerieNotaEntrega { get {return bs_SerieNotaEntrega;} }
        public BindingSource _bs_MedioEfectivo { get {return bs_MedioEfectivo;} }
        public BindingSource _bs_MedioDivisa { get {return bs_MedioDivisa;} }
        public BindingSource _bs_MedioElectronico { get {return bs_MedioElectronico;} }
        public BindingSource _bs_MedioOtro { get {return bs_MedioOtro;} }
        public BindingSource _bs_MovVenta  { get {return bs_MovVenta ;} }
        public BindingSource _bs_MovDevVenta  { get {return bs_MovDevVenta ;} }
        public BindingSource _bs_MovSalida  { get {return bs_MovSalida ;} }
        public OOB.LibVenta.PosOffline.Configuracion.Actual.Ficha CnfActual { get { return _cnfActual; } }
        public Data CnfNueva { get; set;}


        public configurar()
        {
            CnfNueva = new Data();

            LDeposito = new List<OOB.LibVenta.PosOffline.Deposito.Ficha>();
            LVendedor = new List<OOB.LibVenta.PosOffline.Vendedor.Ficha>();
            LCobrador = new List<OOB.LibVenta.PosOffline.Cobrador.Ficha>();
            LTransporte = new List<OOB.LibVenta.PosOffline.Transporte.Ficha>();
            LSerieFactura = new List<OOB.LibVenta.PosOffline.Serie.Ficha>();
            LSerieNotaCredito = new List<OOB.LibVenta.PosOffline.Serie.Ficha>();
            LSerieNotaDebito = new List<OOB.LibVenta.PosOffline.Serie.Ficha>();
            LSerieNotaEntrega = new List<OOB.LibVenta.PosOffline.Serie.Ficha>();
            LMedioEfectivo = new List<OOB.LibVenta.PosOffline.MedioCobro.Ficha>();
            LMedioDivisa = new List<OOB.LibVenta.PosOffline.MedioCobro.Ficha>();
            LMedioElectronico = new List<OOB.LibVenta.PosOffline.MedioCobro.Ficha>();
            LMedioOtro = new List<OOB.LibVenta.PosOffline.MedioCobro.Ficha>();
            LMovVenta = new List<OOB.LibVenta.PosOffline.MovConceptoInv.Ficha>();
            LMovDevVenta = new List<OOB.LibVenta.PosOffline.MovConceptoInv.Ficha>();
            LMovSalida = new List<OOB.LibVenta.PosOffline.MovConceptoInv.Ficha>();

            bs_Deposito = new BindingSource();
            bs_Cobrador = new BindingSource();
            bs_Vendedor = new BindingSource();
            bs_Transporte = new BindingSource();
            bs_SerieFactura = new BindingSource();
            bs_SerieNotaCredito = new BindingSource();
            bs_SerieNotaDebito = new BindingSource();
            bs_SerieNotaEntrega = new BindingSource();
            bs_MedioEfectivo = new BindingSource();
            bs_MedioDivisa = new BindingSource();
            bs_MedioElectronico = new BindingSource();
            bs_MedioOtro = new BindingSource();
            bs_MovVenta = new BindingSource();
            bs_MovDevVenta = new BindingSource();
            bs_MovSalida = new BindingSource();

            bs_Deposito.DataSource = LDeposito;
            bs_Cobrador.DataSource = LCobrador;
            bs_Vendedor.DataSource = LVendedor;
            bs_Transporte.DataSource = LTransporte;
            bs_SerieFactura.DataSource = LSerieFactura;
            bs_SerieNotaCredito.DataSource = LSerieNotaCredito;
            bs_SerieNotaDebito.DataSource = LSerieNotaDebito;
            bs_SerieNotaEntrega.DataSource = LSerieNotaEntrega;
            bs_MedioEfectivo.DataSource = LMedioEfectivo;
            bs_MedioDivisa.DataSource = LMedioDivisa;
            bs_MedioElectronico.DataSource = LMedioElectronico;
            bs_MedioOtro.DataSource = LMedioOtro;
            bs_MovVenta.DataSource = LMovVenta;
            bs_MovDevVenta.DataSource = LMovDevVenta;
            bs_MovSalida.DataSource = LMovSalida;
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

            var r02 = Sistema.MyData2.Cobrador_Lista();
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

            var r05 = Sistema.MyData2.MedioCobro_Lista();
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
            LSerieNotaEntrega.Clear();
            LSerieNotaEntrega.AddRange(r06.Lista);

            var r07 = Sistema.MyData2.Configuracion_ActualCargar();
            if (r07.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r07.Mensaje);
                return rt;
            }
            _cnfActual = r07.Entidad;
            CnfNueva.setCnf(_cnfActual);

            var r08 = Sistema.MyData2.MovConceptoInv_Lista();
            if (r08.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r08.Mensaje);
                return rt;
            }
            LMovVenta.Clear();
            LMovVenta.AddRange(r08.Lista);
            LMovDevVenta.Clear();
            LMovDevVenta.AddRange(r08.Lista);
            LMovSalida.Clear();
            LMovSalida.AddRange(r08.Lista);

            rt = true;
            return rt;
        }


        public void Configura() 
        {
            if (CargarData())
            {
                var frm = new Configuracion.ConfigurarFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        public bool Guardar()
        {
            var rt = false;

            if (CnfNueva.aMedioDivisa == "") { return false; }
            if (CnfNueva.aMedioEfectivo == "") { return false; }
            if (CnfNueva.aMedioElectronico == "") { return false; }
            if (CnfNueva.aMedioOtro == "") { return false; }

            if (CnfNueva.aSerieFactura== "") { return false; }
            if (CnfNueva.aSerieNCredito== "") { return false; }
            if (CnfNueva.aSerieNDebito == "") { return false; }
            if (CnfNueva.aSerieNEntrega== "") { return false; }

            if (CnfNueva.aMovDevVenta == "") { return false; }
            if (CnfNueva.aMovSalida== "") { return false; }
            if (CnfNueva.aMovVenta== "") { return false; }

            if (CnfNueva.aCobrador == "") { return false; }
            if (CnfNueva.aTransporte== "") { return false; }
            if (CnfNueva.aVendedor == "") { return false; }

            if (CnfNueva.indClave == -1) { return false; }

            if (CnfActual.CodigoSucursal == "")
            {
                return false;
            }
            if (CnfNueva.IdEquipo == "")
            {
                return false;
            }
            if (CnfNueva.ActivarRepesaje)
            {
                if (CnfNueva.LimSupRepesaje < 0.0m)
                {
                    return false;
                }
                if (CnfNueva.LimInfRepesaje<0.0m)
                {
                    return false;
                }
            }

            var msg = MessageBox.Show("Guardar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var fichaCnf = new OOB.LibVenta.PosOffline.Configuracion.Guardar.Ficha()
                {
                    ActivarBusquedaPorDescripcion = CnfNueva.ActivarBusqPorDescripcion?"S":"N",
                    ActivarRepesaje = CnfNueva.ActivarRepesaje?"S":"N" ,
                    IdEquipo = CnfNueva.IdEquipo.PadLeft(2, '0'),
                    LimiteInferiorRepesaje = CnfNueva.LimInfRepesaje,
                    LimiteSuperiorRepesaje = CnfNueva.LimSupRepesaje,

                    AutoCobrador = CnfNueva.aCobrador ,
                    AutoTransporte = CnfNueva.aTransporte ,
                    AutoVendedor = CnfNueva.aVendedor ,

                    AutoMedioDivisa = CnfNueva.aMedioDivisa,
                    AutoMedioEfectivo = CnfNueva.aMedioEfectivo ,
                    AutoMedioElectronico = CnfNueva.aMedioElectronico ,
                    AutoMedioOtro = CnfNueva.aMedioOtro ,

                    ClavePos = CnfNueva.indClave + 1,

                    SerieFactura = CnfNueva.aSerieFactura ,
                    SerieNotaCredito = CnfNueva.aSerieNCredito ,
                    SerieNotaDebito = CnfNueva.aSerieNDebito ,
                    SerieNotaEntrega = CnfNueva.aSerieNEntrega ,

                    AutoMovConceptoDevVenta = CnfNueva.aMovDevVenta ,
                    AutoMovConceptoVenta = CnfNueva.aMovVenta ,
                    AutoMovConceptoSalida = CnfNueva.aMovSalida ,
                };
                var r01 = Sistema.MyData2.Configuracion_GuardarCambio(fichaCnf);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }
                Helpers.Msg.EditarOk();
                rt = true;
            }

            return rt;
        }

    }

}