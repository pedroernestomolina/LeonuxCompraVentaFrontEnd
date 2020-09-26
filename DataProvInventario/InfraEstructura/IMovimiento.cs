using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IMovimiento
    {

        OOB.ResultadoLista<OOB.LibInventario.Movimiento.Traslado.Consultar.ProductoPorDebajoNivelMinimo> Producto_Movimiento_Traslado_Consultar_ProductosPorDebajoNivelMinimo(OOB.LibInventario.Movimiento.Traslado.Consultar.Filtro filtro);
        OOB.ResultadoAuto  Producto_Movimiento_Traslado_Insertar(OOB.LibInventario.Movimiento.Traslado.Insertar.Ficha ficha);
        OOB.ResultadoEntidad<OOB.LibInventario.Movimiento.Ver.Ficha> Producto_Movimiento_GetFicha(string autoDoc);
        OOB.ResultadoAuto Producto_Movimiento_Cargo_Insertar(OOB.LibInventario.Movimiento.Cargo.Insertar.Ficha ficha);
        OOB.ResultadoAuto Producto_Movimiento_DesCargo_Insertar(OOB.LibInventario.Movimiento.DesCargo.Insertar.Ficha ficha);
        OOB.ResultadoAuto Producto_Movimiento_Ajuste_Insertar(OOB.LibInventario.Movimiento.Ajuste.Insertar.Ficha ficha);

    }

}