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
        public OOB.ResultadoId Operador_Abrir(OOB.LibVenta.PosOffline.Operador.Abrir.Ficha ficha)
        {
            var rt = new OOB.ResultadoId();

            var agregarDTO = new DtoLibPosOffLine.Operador.Abrir.Ficha()
            {
                IdJornada = ficha.IdJornada,
                AutoUsuario = ficha.AutoUsuario,
                CodigoUsuario = ficha.CodigoUsuario,
                Usuario = ficha.Usuario,
                Fecha = ficha.Fecha.ToShortDateString(),
                Hora = ficha.Hora,
                Estatus = ficha.Estatus,
            };
            var r01 = MyData.Operador_Abrir (agregarDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Id = r01.Id;

            return rt;
        }

        public OOB.Resultado Operador_Cerrar(OOB.LibVenta.PosOffline.Operador.Cerrar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var agregarDTO = new DtoLibPosOffLine.Operador.Cerrar.Ficha()
            {
                IdOperador=ficha.IdOperador,
                Fecha = ficha.Fecha.ToShortDateString(),
                Hora = ficha.Hora,
                Estatus = ficha.Estatus,
            };
            var r01 = MyData.Operador_Cerrar(agregarDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<int> Operador_Activo()
        {
            var rt = new OOB.ResultadoEntidad<int>();

            var r01 = MyData.Operador_Activa();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.Entidad = r01.Entidad;
            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Operador.Cargar.Ficha> Operador_Cargar(int idOperador)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Operador.Cargar.Ficha>();

            var r01 = MyData.Operador_Cargar (idOperador);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var c = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Operador.Cargar.Ficha()
            {
                Id = c.Id,
                IdJornada = c.IdJornada,
                AutoUsuario = c.AutoUsuario,
                CodigoUsuario = c.CodigoUsuario,
                Usuario = c.Usuario,
                Estatus = (OOB.LibVenta.PosOffline.Operador.Enumerado.EnumEstatus)c.Estatus,
                FechaApertura = c.FechaApertura,
                FechaCierre = c.FechaCierre,
                HoraApertura = c.HoraApertura,
                HoraCierre = c.HoraCierre,
            };
            rt.Entidad = nr;

            return rt;
        }
    }

}
