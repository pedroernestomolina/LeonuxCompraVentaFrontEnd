using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovVenta.Venta.VentaAdministrativa
{

    public class Existencia
    {

        private bool _habilitarRupturaPorExistencia;


        public Existencia()
        {
            _habilitarRupturaPorExistencia = true;
            _cantUndDespachar = 1;
        }

        public Existencia(OOB.LibVenta.Inventario.Existencia.Ficha _ficha)
            : this()
        {
            autoDeposito = _ficha.autoDeposito;
            CodigoDeposito = _ficha.CodigoDeposito;
            DescripcionDeposito = _ficha.DescripcionDeposito;
            CantUndFisica = _ficha.CantUndFisica;
            CantUndReservada = _ficha.CantUndReservada;
            CantUndDisponible = _ficha.CantUndDisponible;
            Ubicacion = _ficha.Ubicacion;
        }


        public string autoDeposito { get; set; }
        public string CodigoDeposito { get; set; }
        public string DescripcionDeposito { get; set; }
        public decimal CantUndFisica { get; set; }
        public decimal CantUndReservada { get; set; }
        public decimal CantUndDisponible { get; set; }
        public string Ubicacion { get; set; }


        private decimal _cantUndDespachar;
        public decimal CantUndDespachar
        {
            get
            {
                return _cantUndDespachar;
            }
        }

        public bool VerificarExistenciaNegativa
        {
            get
            {
                return (CantUndDespachar > CantUndFisica);
            }
        }


        public void setCantUndDespachar(decimal cnt)
        {
            _cantUndDespachar = cnt;
        }

        public bool VerificarExistencia(decimal cnt)
        {
            if (_habilitarRupturaPorExistencia)
            {
                return (CantUndFisica >= cnt);
            }
            else
            {
                return true;
            }
        }

        public void setHabilitarRupturaPorExistencia(bool modo)
        {
            _habilitarRupturaPorExistencia = modo;
        }

    }

}