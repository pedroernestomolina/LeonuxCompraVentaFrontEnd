using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento.Ajuste.Entrada
{
    
    public class Gestion
    {

        private decimal tasaCambio;
        private decimal contenido;
        private Movimiento.enumerados.enumTipoEmpaque tipoEmpaque;
        private Movimiento.enumerados.enumTipoMovimientoAjuste tipoMovimiento;
        private decimal importe;
        private decimal importeMonedaLocal;
        private string idDeposito;


        public bool ProcesarOk { get; set; }
        public OOB.LibInventario.Producto.Data.Ficha Prd { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }

        public string Producto { get { return Prd.Producto; } }
        public string ProductoEmpCompra { get { return Prd.Empaque; } }
        public string ProductoAdmDivisa { get { return Prd.Divisa; } }
        public string ProductoTasaIva { get { return Prd.Impuesto; } }
        public string ProductoFechaUltAct { get { return Prd.FechaUltimaActualizacion; } }
        public bool ProductoEsDivisa { get { return Prd.identidad.AdmPorDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si ? true : false; } }
        public string TasaCambio { get { return String.Format("{0:n2}", tasaCambio); } }
        public string CntUnd { get { return string.Format("{0:n"+Decimales+"}", (Cantidad * contenido)); } }
        public string CostoUnd { get { return string.Format("{0:n2}", (Costo / contenido)); } }
        public Movimiento.enumerados.enumTipoEmpaque  TipoEmpaqueSeleccionado { get { return tipoEmpaque; } }
        public Movimiento.enumerados.enumTipoMovimientoAjuste TipoMovimientoSeleccionado { get { return tipoMovimiento; } }
        public decimal CntExistenciaDeposito 
        {
            get 
            {
                var vt = 0.0m;
                vt = Prd.existencia.depositos.First(w => w.autoId == idDeposito).exFisica;
                return vt;
            }
        }
        public string Decimales { get { return Prd.Decimales; } }
        public string ExistenciaDeposito { get { return CntExistenciaDeposito.ToString("n" + Decimales); } }


        public decimal TotalUnd { get { return (Cantidad * contenido); } }
        public decimal Importe 
        { 
            get 
            {
                importe = (Cantidad * Costo);
                importeMonedaLocal = importe;
                if (ProductoEsDivisa)
                    importeMonedaLocal = (importe * tasaCambio);
                return importe; 
            }
        }
        public decimal ImporteMonedaLocal { get { return importeMonedaLocal; } }


        public Gestion()
        {
            idDeposito = "";
            ProcesarOk = false;
            Cantidad = 0.0m;
            Costo = 0.0m;
            contenido = 1;
            importe = 0.0m;
            tipoEmpaque = enumerados.enumTipoEmpaque.PorEmpaqueCompra ;
            tipoMovimiento = enumerados.enumTipoMovimientoAjuste.SinDefinir;
        }


        EntradaFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                contenido = Prd.identidad.contenidoCompra;
                Costo = (Prd.costo.costoUnd * contenido);
                if (Prd.identidad.AdmPorDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si)
                {
                    Costo = (Prd.costo.costoDivisaUnd * contenido);
                }

                if (frm == null)
                {
                    frm = new EntradaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            return rt;
        }

        private void Limpiar()
        {
            ProcesarOk = false;
            Cantidad = 0.0m;
            Costo = 0.0m;
            contenido = 1;
            tipoEmpaque = enumerados.enumTipoEmpaque.PorEmpaqueCompra ;
            tipoMovimiento = enumerados.enumTipoMovimientoAjuste.SinDefinir;
        }

        public void Procesar()
        {
            if (Prd.costo.Edad > 30)
            {
                Helpers.Msg.Error("Costo Edad No Permitido, Verifique Por Favor");
                return;
            }
            if (importe == 0.0m) 
            {
                Helpers.Msg.Error("Monto Importe Movimiento Incorrecto, Verifique Por Favor");
                return;
            }
            if (tipoMovimiento == enumerados.enumTipoMovimientoAjuste.SinDefinir) 
            {
                Helpers.Msg.Error("Debes Indicar El Tipo De Ajuste A Realizar, Verifique Por Favor");
                return;
            }
            if (tipoMovimiento == enumerados.enumTipoMovimientoAjuste.PorSalida) 
            {
                if (TotalUnd > Prd.existencia.depositos.First(w => w.autoId == idDeposito).exFisica)
                {
                    Helpers.Msg.Error("No Hay La Disponibilidad Para Este Producto" + Environment.NewLine + "Verifique Por Favor...");
                    return;
                }
            }

            var msg = MessageBox.Show("Guardar Cambios ?","*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2 );
            if (msg == DialogResult.Yes) 
            {
                ProcesarOk = true;
            }
        }

        public void setFicha(OOB.LibInventario.Producto.Data.Ficha ficha, string idDeposito)
        {
            Prd = ficha;
            this.idDeposito = idDeposito;
        }

        public void setEmpaque(int p)
        {
            contenido = Prd.identidad.contenidoCompra;
            tipoEmpaque = enumerados.enumTipoEmpaque.PorEmpaqueCompra;
            Costo = (Prd.costo.costoUnd * contenido);
            if (Prd.identidad.AdmPorDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si)
            {
                Costo = (Prd.costo.costoDivisaUnd * contenido);
            }

            if (p == 1)
            {
                contenido = 1;
                tipoEmpaque = enumerados.enumTipoEmpaque.PorUnidad;
                Costo = (Prd.costo.costoUnd);
                if (Prd.identidad.AdmPorDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si)
                {
                    Costo = (Prd.costo.costoDivisaUnd);
                }
            }
        }

        public void Editar(item it,string idDeposito)
        {
            Limpiar();
            if (CargarData())
            {
                this.idDeposito = idDeposito;
                Prd = it.FichaPrd;
                Costo = it.Costo;
                Cantidad = it.Cantidad;
                contenido = Prd.identidad.contenidoCompra;
                tipoEmpaque = it.TipoEmpaqueSeleccionado ;
                tipoMovimiento = it.TipoMovimiento;

                if (frm == null)
                {
                    frm = new EntradaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void setTasaCambio(decimal tasaCambio)
        {
            this.tasaCambio=tasaCambio;
        }

        public void setMovimiento(Movimiento.enumerados.enumTipoMovimientoAjuste tipoMov)
        {
            this.tipoMovimiento = tipoMov;
        }

    }

}