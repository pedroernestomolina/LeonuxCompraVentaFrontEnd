using DataProvInventario.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{
    
    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<OOB.LibInventario.Usuario.Ficha> Usuario_Principal()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Usuario.Ficha>();

            var r01 = MyData.Usuario_Principal();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Usuario.Ficha()
            {
                autoUsu = s.autoUsu,
                codigoUsu = s.codigoUsu,
                nombreUsu = s.nombreUsu,
                apellidoUsu = s.apellidoUsu,
                isActivo = s.isActivo,
                autoGru = s.autoGru,
                NombreGru = s.nombreGru,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}