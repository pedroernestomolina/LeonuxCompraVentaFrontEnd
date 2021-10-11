using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Operador.Cierre
{
    
    public class cierre
    {

        private decimal _divisaPromedio; 
        private OOB.LibVenta.PosOffline.Operador.Movimiento.Ficha _movimientos;
        public decimal EntradaPorEfectivo { get; set; }
        public decimal EntradaPorTarjeta { get; set; }
        public decimal EntradaPorOtro { get; set; }
        public int EntradaPorCntDivisa { get; set; }
        public decimal EntradaPorCredito 
        {
            get 
            {
                return _movimientos.montoDocCredito;
            }
        }

        public decimal EntradaPorDivisa
        {
            get
            {
                return (EntradaPorCntDivisa * _divisaPromedio);
            }
        }

        public OOB.LibVenta.PosOffline.Operador.Movimiento.Ficha Movimientos 
        {
            get 
            {
                return _movimientos;
            }
        }

        public decimal MontoVenta 
        {
            get 
            {
                var rt = 0.0m;
                rt = _movimientos.montoFactura - _movimientos.montoNCredito;
                return rt;
            }
        }

        public decimal MontoEfectivo
        {
            get 
            {
                var rt = 0.0m;
                rt = ( _movimientos.montoDocContado - (_movimientos.montoDivisa+ _movimientos.montoElectronico+ _movimientos.montoOtros))  ;
                return rt;
            }
        }

        public decimal MontoDocContado 
        {
            get
            {
                var rt = 0.0m;
                rt = (_movimientos.montoDocContado - _movimientos.montoNCredito);
                return rt;
            }
        }

        public decimal CntDocContado
        {
            get
            {
                var rt = 0.0m;
                rt = (_movimientos.cntDocContado + _movimientos.cntNCredito );
                return rt;
            }
        }

        public decimal MontoDesgloze
        {
            get
            {
                var rt = 0.0m;
                rt = (MontoEfectivo +_movimientos.montoDivisa + _movimientos.montoElectronico + _movimientos.montoOtros + _movimientos.montoDocCredito) - _movimientos.montoNCredito ;  
                return rt;
            }
        }

        public decimal Diferencia 
        {
            get 
            {
                var rt = 0.0m;
                //rt = (EntradaPorEfectivo + EntradaPorDivisa + EntradaPorTarjeta + EntradaPorOtro) - MontoDesgloze ;
                rt = TotalEntrada - MontoDesgloze;
                return rt;
            }
        }

        public decimal SubTotal 
        {
            get
            {
                var rt = 0.0m;
                //rt = _movimientos.montoFactura - _movimientos.montoDocCredito;
                rt = _movimientos.montoFactura ;
                return rt;
            }
        }

        public decimal Total
        {
            get
            {
                var rt = 0.0m;
                rt = (SubTotal - _movimientos.montoNCredito);
                return rt;
            }
        }

        public decimal TotalEntrada
        {
            get
            {
                var rt = 0.0m;
                rt = (EntradaPorEfectivo + EntradaPorDivisa + EntradaPorTarjeta + EntradaPorOtro+ EntradaPorCredito) ;
                return rt;
            }
        }


        public cierre() 
        {
            Inicializa();
        }

        public void setMovimientos(OOB.LibVenta.PosOffline.Operador.Movimiento.Ficha mov, decimal factorCambio)
        {
            _movimientos = mov;
            _divisaPromedio = 0.0m;
            if (mov.cntDivisa > 0)
            {
                _divisaPromedio = mov.montoDivisa / mov.cntDivisa;
            }
            else
            {
                _divisaPromedio = factorCambio;
            }
        }


        public void Inicializa()
        {
            _movimientos = null;
            _divisaPromedio = 0.0m;
            EntradaPorEfectivo = 0.0m;
            EntradaPorOtro = 0.0m;
            EntradaPorTarjeta = 0.0m;
            EntradaPorCntDivisa = 0;
        }

    }

}