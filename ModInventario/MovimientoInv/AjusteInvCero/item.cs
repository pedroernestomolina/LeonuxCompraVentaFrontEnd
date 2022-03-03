using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MovimientoInv.AjusteInvCero
{
    
    public  class item
    {

        private int _id;
        private OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Data _data;

        public int Id { get { return _id; } }
        public string AutoPrd { get { return _data.autoPrd; } }
        public string CodigoPrd { get { return _data.codigoPrd; } }
        public string NombrePrd { get { return _data.nombrePrd; } }
        public decimal Cantidad { get { return _data.exFisica; } }
        public string Empaque { get { return "UNIDAD ( 1 )"; } }


        public item(int id, OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Data data) 
        {
            _id = id;
            _data = data;
        }

    }

}