using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra
{

    public interface IVenta
    {

        OOB.ResultadoAuto Venta_AgregarDocumento(OOB.LibVenta.Venta.Generar.Agregar ficha);

    }

}