using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Movimiento.Traslado.EntreSucursalesPorExistenciaPorDebajoNivelMinimo
{

    public class Item
    {

        public OOB.LibInventario.Movimiento.Traslado.Consultar.ProductoPorDebajoNivelMinimo ficha { get; set; }

        public string CodigoPrd { get { return ficha.codigoProducto; } }
        public string NombrePrd { get { return ficha.nombreProducto; } }
        public decimal Cantidad { get { return ficha.cntUndReponer; } }
        public string Empaque { get { return "Unidad"; } }
        public decimal Costo { get { return ficha.costoFinalUnd; } }
        public decimal Importe { get { return ficha.cntUndReponer*ficha.costoFinalUnd ; } }

    }

}