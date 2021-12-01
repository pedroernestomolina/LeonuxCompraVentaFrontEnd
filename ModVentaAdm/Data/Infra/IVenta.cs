using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Infra
{
    
    public interface IVenta
    {

        OOB.Resultado.FichaId  Venta_Temporal_Encabezado_Registrar(OOB.Venta.Temporal.Encabezado.Registrar.Ficha ficha);
        OOB.Resultado.Ficha Venta_Temporal_Encabezado_Editar(OOB.Venta.Temporal.Encabezado.Editar.Ficha ficha);
        OOB.Resultado.Ficha Venta_Temporal_Encabezado_Eliminar(int idEncabezado);
        OOB.Resultado.FichaId Venta_Temporal_Item_Registrar(OOB.Venta.Temporal.Item.Registrar.Ficha ficha);
        OOB.Resultado.Ficha Venta_Temporal_Item_Eliminar(OOB.Venta.Temporal.Item.Eliminar.Ficha ficha);
        OOB.Resultado.Ficha Venta_Temporal_Item_Limpiar(OOB.Venta.Temporal.Item.Limpiar.Ficha ficha);
        OOB.Resultado.FichaEntidad<OOB.Venta.Temporal.Item.Entidad.Ficha> Venta_Temporal_Item_GetFichaById(int idItem);
        OOB.Resultado.Ficha Venta_Temporal_Anular(OOB.Venta.Temporal.Anular.Ficha ficha);

    }

}