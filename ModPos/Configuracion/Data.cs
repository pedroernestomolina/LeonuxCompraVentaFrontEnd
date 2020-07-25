using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Configuracion
{
    
    public class Data
    {

        public bool ActivarRepesaje { get; set; }
        public bool ActivarBusqPorDescripcion { get; set; }
        public decimal LimSupRepesaje { get; set; }
        public decimal LimInfRepesaje { get; set; }
        public string IdEquipo { get; set; }

        public string aMedioEfectivo {get;set;}
        public string aMedioDivisa  {get;set;}
        public string aMedioElectronico {get;set;}
        public string aMedioOtro {get;set;}

        public string aSerieFactura {get;set;}
        public string aSerieNCredito  {get;set;}
        public string aSerieNDebito  {get;set;}
        public string aSerieNEntrega  {get;set;}

        public string aTransporte  {get;set;}
        public string aCobrador  {get;set;}
        public string aVendedor  {get;set;}

        public string aMovVenta  {get;set;}
        public string aMovDevVenta  {get;set;}
        public string aMovSalida { get; set; }

        public int indClave {get;set;}


        public Data()
        {
            Limpiar();
        }

        private void Limpiar()
        {
            LimSupRepesaje = 0.0m;
            LimInfRepesaje = 0.0m;
            ActivarRepesaje = false;
            ActivarBusqPorDescripcion = false;
            IdEquipo = "";

            aMedioDivisa = "";
            aMedioEfectivo = "";
            aMedioElectronico = "";
            aMedioOtro = "";

            aSerieFactura = "";
            aSerieNCredito = "";
            aSerieNDebito = "";
            aSerieNEntrega = "";

            aMovVenta = "";
            aMovDevVenta = "";
            aMovSalida = "";

            aCobrador = "";
            aTransporte = "";
            aVendedor = "";

            indClave = -1;
        }


        public void setCnf(OOB.LibVenta.PosOffline.Configuracion.Actual.Ficha ficha) 
        {
            LimInfRepesaje = ficha.LimiteInferiorRepesaje;
            LimSupRepesaje = ficha.LimiteSuperiorRepesaje;
            ActivarRepesaje = ficha.ActivarRepesaje;
            ActivarBusqPorDescripcion = ficha.ActivarBusquedaPorDescripcion;
            IdEquipo = ficha.EquipoNumero;

            aMedioEfectivo = ficha.AutoMedioEfectivo;
            aMedioDivisa = ficha.AutoMedioDivisa;
            aMedioElectronico = ficha.AutoMedioElectronico;
            aMedioOtro = ficha.AutoMedioOtro;

            aSerieFactura = ficha.SerieFactura;
            aSerieNCredito = ficha.SerieNotaCredito;
            aSerieNDebito = ficha.SerieNotaDebito;
            aSerieNEntrega = ficha.SerieNotaEntrega;

            aMovVenta = ficha.AutoMovConceptoVenta;
            aMovDevVenta = ficha.AutoMovConceptoDevVenta;
            aMovSalida = ficha.AutoMovConceptoSalida;

            aCobrador=ficha.AutoCobrador;
            aTransporte = ficha.AutoTransporte;
            aVendedor = ficha.AutoVendedor;

            indClave = ficha.ClavePos;
        }

    }

}