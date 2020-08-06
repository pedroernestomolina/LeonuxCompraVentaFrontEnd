using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Existencia.Ver
{

    public class data
    {

        private OOB.LibInventario.Producto.Data.Deposito _deposito; 
        private int _empContenido;

        public string CodigoDep { get { return _deposito.codigo; } }
        public string NombreDep { get { return _deposito.nombre; } }
        public decimal ExFisica 
        {
            get 
            {
                var ex = 0.0m;
                ex = _deposito.exFisica / _empContenido;
                return ex;
            }
        }
        public decimal ExReserva
        {
            get
            {
                var ex = 0.0m;
                ex = _deposito.exReserva / _empContenido;
                return ex;
            }
        }
        public decimal ExDisponible
        {
            get
            {
                var ex = 0.0m;
                ex = _deposito.exDisponible / _empContenido;
                return ex;
            }
        }


        public data(OOB.LibInventario.Producto.Data.Deposito dep)
        {
            _deposito = dep;
            _empContenido = 1;
        }

        public void setContenido(int cnt) 
        {
            _empContenido = cnt;
        }

    }

}