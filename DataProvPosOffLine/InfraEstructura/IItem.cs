using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{
    
    public interface IItem
    {

        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Item.Ficha> Item(int id);
        OOB.ResultadoId Item_Agregar(OOB.LibVenta.PosOffline.Item.Agregar ficha);
        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Item.Ficha> Item_Cargar();
        OOB.Resultado Item_Limpiar();
        OOB.Resultado Item_Actualizar(OOB.LibVenta.PosOffline.Item.Actualizar ficha);
        OOB.Resultado Item_Eliminar(int id);

    }

}