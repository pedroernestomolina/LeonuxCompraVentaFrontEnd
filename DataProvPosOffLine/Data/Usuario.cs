using DataProvPosOffLine.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Usuario.Ficha> Usuario_Cargar(OOB.LibVenta.PosOffline.Usuario.BuscarCargar ficha)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Usuario.Ficha>();

            var buscarCargarDto = new DtoLibPosOffLine.Usuario.Cargar()
            {
                Codigo = ficha.Codigo,
                PassWord = ficha.PassWord,
            };
            var r01 = MyData.Usuario_Cargar(buscarCargarDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var u=r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Usuario.Ficha()
            {
                Auto = u.UsuarioAuto,
                AutoGrupo = u.GrupoAuto,
                Codigo = u.UsuarioCodigo,
                CodigoGrupo = "",
                Descripcion = u.UsuarioDescripcion,
                DescripcionGrupo = u.GrupoDescripcion,
                IsActivo = true,
                IsInvitado=false,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}
