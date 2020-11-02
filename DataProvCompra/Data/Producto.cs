using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoLista<OOB.LibCompra.Producto.Data.Ficha> Producto_GetLista(OOB.LibCompra.Producto.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Producto.Data.Ficha>();

            var filtroDto = new DtoLibCompra.Producto.Lista.Filtro()
            {
                autoDepartamento = filtro.autoDepartamento,
                autoGrupo = filtro.autoGrupo,
                autoMarca = filtro.autoMarca,
                autoProveedor = filtro.autoProveedor,
                cadena = filtro.cadena,
                MetodoBusqueda = (DtoLibCompra.Producto.Enumerados.EnumMetodoBusqueda)filtro.MetodoBusqueda,
            };
            var r01 = MyData.Producto_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Producto.Data.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Producto.Data.Ficha();
                        var id = new OOB.LibCompra.Producto.Data.Identificacion()
                        {
                            auto = s.autoPrd,
                            codigo = s.codigoPrd,
                            descripcion = s.descripcionPrd,
                            empaqueCompra = s.empaqueCompraPrd,
                            contenidoCompra = s.contenidoEmpaquePrd,
                            departamento = s.nombreDepartamento,
                            grupo = s.nombreGrupo,
                            marca = s.nombreMarca,
                            referencia = s.referenciaPrd,
                            modelo = s.modeloPrd,
                            tasaIva = s.tasaIvaPrd,
                            nombreTasaIva = s.tasaIvaDescripcion,
                            estatus =  (OOB.LibCompra.Producto.Enumerados.EnumEstatus) s.estatusPrd,
                            origen = s.origenPrd,
                            categoria = s.categoriaPrd,
                            AdmPorDivisa = (OOB.LibCompra.Producto.Enumerados.EnumAdministradorPorDivisa) s.admPorDivisa,
                        };
                        nr.identidad = id;
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}