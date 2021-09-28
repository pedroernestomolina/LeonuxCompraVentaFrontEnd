using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorPos.Src.Principal
{

    public class Monitor
    {

        static public void ResumenDia(string idEquipo)
        {
            var xr1 = Sistema.MyData.Operador_Activa();
            if (xr1.Result == DtoLib.Enumerados.EnumResult.isError)
                return;

            var xfiltro = new DtoLibPosOffLine.Monitor.ResumenDia.Filtro() { equipo = idEquipo, idOperador = xr1.Entidad };
            var xr2= Sistema.MyData.Monitor_Resumen_Dia(xfiltro);
        }

        static public void Resumen() 
        {
            var r00 = Sistema.MyData.Monitor_ListaResumen();
            if (r00.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                return;
            }
            r00.Lista.Add(new DtoLibPosOffLine.Monitor.ListaResumen.Ficha());
            foreach (DtoLibPosOffLine.Monitor.ListaResumen.Ficha rCierre in r00.Lista)
            {
                var xcierre = rCierre.cierreGenerar;
                var filtro = new DtoLibPosOffLine.Monitor.GenerarResumen.Filtro()
                {
                    cierre = xcierre,
                };
                var r01 = Sistema.MyData.Monitor_GenerarResumen(filtro);
                if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
                {
                    return;
                }

                var list = r01.Lista.Select(s =>
                {
                    var rg = new DtoLibPosOffLine.Monitor.SubirResumen.Detalle()
                    {
                        autoProducto = s.autoProducto,
                        cnt = s.cnt,
                    };
                    return rg;
                }).ToList();
                var ficha = new DtoLibPosOffLine.Monitor.SubirResumen.Ficha()
                {
                    codSucursal = "08",
                    cierre = xcierre,
                    Lista = list,
                };
                var r02 = Sistema.MyData.Monitor_SubirResumen(ficha);
                if (r02.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    return;
                }

                if (xcierre != "") 
                {
                    var cierre = new DtoLibPosOffLine.Monitor.InsertarCierre.Ficha()
                    {
                        cierre = xcierre,
                        estatus = "T",
                    };
                    var r03 = Sistema.MyData.Monitor_InsertarCierre(cierre);
                    if (r03.Result == DtoLib.Enumerados.EnumResult.isError)
                    {
                        return;
                    }
                }
            }
        }

    }

}