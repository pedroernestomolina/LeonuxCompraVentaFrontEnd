using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion.Pago
{

    public class Pago
    {

        public List<PagoDetalle> _detalle { get; set; }
        private decimal _subtotalMonto;
        private decimal _tasaCambio;
        private decimal _dsctoPorct;
        private bool _isCredito;


        public decimal MontoRecibido
        {
            get
            {
                var x = 0.0m;
                x = _detalle.Sum(s => s.Monto);
                return x;
            }
        }

        public decimal MontoCambioDar_MonedaNacional
        {
            get
            {
                var x = 0.0m;
                if (!_isCredito) 
                {
                    x = MontoRecibido - MontoPagar;
                }
                return x;
            }
        }

        public decimal MontoCambioDar_Divisa
        {
            get
            {
                var x = 0.0m;
                if (!_isCredito)
                {
                    if (_tasaCambio > 0)
                    {
                        x = MontoCambioDar_MonedaNacional / _tasaCambio;
                    }
                }
                return x;
            }
        }

        public decimal MontoResta_MonedaNacional
        {
            get
            {
                var x = 0.0m;
                x = MontoPagar - MontoRecibido;
                x = Math.Round(x, 2, MidpointRounding.AwayFromZero);
                return x;
            }
        }

        public decimal MontoResta_Divisa
        {
            get
            {
                var x = 0.0m;
                if (_tasaCambio > 0)
                {
                    x = MontoResta_MonedaNacional / _tasaCambio;
                }
                return x;
            }
        }

        public decimal MontoDivisa
        {
            get
            {
                var x = 0.0m;
                x = _detalle.Where(w => w.Modo == Enumerados.ModoPago.Divisa).Sum(s => s.Monto);
                return x;
            }
        }

        public decimal SubTotalMontoPagar
        {
            get
            {
                return decimal.Round(_subtotalMonto,2, MidpointRounding.AwayFromZero) ;
            }
        }

        public decimal MontoPagar
        {
            get
            {
                var x = 0.0m;
                x = _subtotalMonto-Descuento;
                return x;
            }
        }

        public decimal MontoPagarDivisa
        {
            get
            {
                var x = 0.0m;
                if (_tasaCambio > 0)
                {
                    x =MontoPagar / _tasaCambio;
                }
                return x;
            }
        }

        public decimal TasaCambio
        {
            get
            {
                var x = 0.0m;
                x = _tasaCambio;
                return x;
            }
        }

        public decimal Descuento
        {
            get
            {
                var x = 0.0m;
                x = _subtotalMonto * _dsctoPorct/100;
                return decimal.Round(x,2,MidpointRounding.AwayFromZero);
            }
        }

        public decimal DescuentoPorct
        {
            get
            {
                return _dsctoPorct;
            }
        }

        public bool IsCredito
        {
            get
            {
                return _isCredito;
            }
        }


        public Pago()
        {
            _isCredito = false;
            _subtotalMonto = 0.0m;
            _tasaCambio = 0.0m;
            _dsctoPorct = 0.0m;
            _detalle = new List<PagoDetalle>();
        }


        public void setMontoPagar(decimal monto)
        {
            _subtotalMonto = monto;
        }

        public void setTasaCambio(decimal tasa)
        {
            _tasaCambio = tasa;
        }

        public void AddEfectivo(decimal monto)
        {
            var it = _detalle.FirstOrDefault(f => f.Modo == Enumerados.ModoPago.Efectivo);
            if (it == null)
            {
                it = new PagoDetalle()
                {
                    Modo = Enumerados.ModoPago.Efectivo,
                    Tasa = 1,
                    Cantidad = 1,
                    Monto = monto,
                    Lote = "",
                    Referencia = "",
                    TarjetaNro = "",
                    Importe = MontoResta_MonedaNacional,
                    MontoRecibido=monto,
                };
                _detalle.Add(it);
            }
            else
            {
                it.Monto = 0;
                it.Importe = MontoResta_MonedaNacional;
                it.Monto = monto;
                it.MontoRecibido = monto;
            }
        }

        public void AddDivisa(decimal monto)
        {
            var it = _detalle.FirstOrDefault(f => f.Modo == Enumerados.ModoPago.Divisa);
            if (it == null)
            {
                it = new PagoDetalle()
                {
                    Modo = Enumerados.ModoPago.Divisa,
                    Tasa = _tasaCambio,
                    Cantidad = monto,
                    Monto = monto * _tasaCambio,
                    Lote = "",
                    Referencia = "",
                    TarjetaNro = "",
                    Importe = MontoResta_MonedaNacional,
                    MontoRecibido=monto,
                };
                _detalle.Add(it);
            }
            else
            {
                it.Monto = 0;
                it.Importe = MontoResta_MonedaNacional;
                it.Monto = monto;
                it.Monto = monto * _tasaCambio;
                it.MontoRecibido = monto;
            }
        }

        public void AddElectronico(decimal monto, int id)
        {
            var it = _detalle.FirstOrDefault(f => f.Modo == Enumerados.ModoPago.Electronico && f.Id == id);
            if (it == null)
            {
                it = new PagoDetalle()
                {
                    Id = id,
                    Modo = Enumerados.ModoPago.Electronico,
                    Tasa = 1,
                    Cantidad = 1,
                    Monto = monto,
                    Lote = "",
                    Referencia = "",
                    TarjetaNro = "",
                    Importe = MontoResta_MonedaNacional,
                    MontoRecibido=monto,
                };
                _detalle.Add(it);
            }
            else
            {
                it.Monto = 0;
                it.Importe = MontoResta_MonedaNacional;
                it.Monto = monto;
                it.Lote = "";
                it.Referencia = "";
                it.TarjetaNro = "";
                it.MontoRecibido = monto;
            }
        }

        public void Limpiar()
        {
            _isCredito = false;
            _dsctoPorct = 0.0m;
            _detalle.Clear();
        }

        public void setDescuento(decimal porct)
        {
            _dsctoPorct= porct;
        }

        public bool Procesar() 
        {
            var rt = false;

            if (MontoRecibido >= MontoPagar) 
            {
                var msg = MessageBox.Show("Procesar Pago ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    return true;
                }
            }

            return rt;
        }

        public bool  setDocumentoCredito() 
        {
            var msg = MessageBox.Show("Dejar Factura A Crédito ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.No)
            {
                return false;
            }
            _detalle.Clear();
            _isCredito = true;

            return true;
        }

        public bool ProcesarCredito()
        {
            var rt = false;

            var msg = MessageBox.Show("Procesar Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                return true;
            }
            _isCredito = false;

            return rt;
        }

        public void DarDescuento() 
        {
            var dsctFrm = new DescuentoFrm();
            dsctFrm.ShowDialog();
            if (dsctFrm.DsctoIsOk) 
            {
                _dsctoPorct = dsctFrm.DsctoPorcentaje;
            }
        }

    }

}