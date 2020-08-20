using DataProvInventario.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{

    public partial class DataProv : IData
    {

        public OOB.ResultadoEntidad<OOB.LibInventario.Precio.Historico.Ficha> HistoricoPrecio_GetLista(OOB.LibInventario.Precio.Historico.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Precio.Historico.Ficha>();

            var filtroDTO = new DtoLibInventario.Precio.Historico.Filtro()
            {
                autoProducto = filtro.autoProducto,
            };
            var r01 = MyData.HistoricoPrecio_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Precio.Historico.Data>();
            if (r01.Entidad.data != null)
            {
                if (r01.Entidad.data.Count > 0)
                {
                    list = r01.Entidad.data.Select(s =>
                    {
                        return new OOB.LibInventario.Precio.Historico.Data()
                        {
                            estacion = s.estacion,
                            etqPrecio = s.etqPrecio,
                            fecha = s.fecha,
                            hora = s.hora,
                            idPrecio = s.idPrecio,
                            nota = s.nota,
                            precio = s.precio,
                            usuario = s.usuario
                        };
                    }).ToList();
                }
            }
            rt.Entidad = new OOB.LibInventario.Precio.Historico.Ficha()
            {
                codigo = r01.Entidad.codigo,
                descripcion = r01.Entidad.descripcion,
                data = list,
            };

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Precio.PrecioCosto.Ficha> PrecioCosto_GetFicha(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Precio.PrecioCosto.Ficha >();

            var r01 = MyData.PrecioCosto_GetFicha(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibInventario.Precio.PrecioCosto.Ficha();
            var e = r01.Entidad;
            if (e != null)
            {
                nr.codigo = e.codigo;
                nr.nombre = e.nombre;
                nr.descripcion = e.descripcion;
                nr.nombreTasaIva = e.nombreTasaIva;
                nr.tasaIva = e.tasaIva;

                nr.etiqueta1 = e.etiqueta1;
                nr.etiqueta2 = e.etiqueta2;
                nr.etiqueta3 = e.etiqueta3;
                nr.etiqueta4 = e.etiqueta4;
                nr.etiqueta5 = e.etiqueta5;
                nr.contenido1 = e.contenido1;
                nr.contenido2 = e.contenido2;
                nr.contenido3 = e.contenido3;
                nr.contenido4 = e.contenido4;
                nr.contenido5 = e.contenido5;
                nr.autoEmp1 = e.autoEmp1;
                nr.autoEmp2 = e.autoEmp2;
                nr.autoEmp3 = e.autoEmp3;
                nr.autoEmp4 = e.autoEmp4;
                nr.autoEmp5 = e.autoEmp5;
                nr.precioNeto1 = e.precioNeto1;
                nr.precioNeto2 = e.precioNeto2;
                nr.precioNeto3 = e.precioNeto3;
                nr.precioNeto4 = e.precioNeto4;
                nr.precioNeto5 = e.precioNeto5;
                nr.precioFullDivisa1 = e.precioFullDivisa1;
                nr.precioFullDivisa2 = e.precioFullDivisa2;
                nr.precioFullDivisa3 = e.precioFullDivisa3;
                nr.precioFullDivisa4 = e.precioFullDivisa4;
                nr.precioFullDivisa5 = e.precioFullDivisa5;
                nr.utilidad1 = e.utilidad1;
                nr.utilidad2 = e.utilidad2;
                nr.utilidad3 = e.utilidad3;
                nr.utilidad4 = e.utilidad4;
                nr.utilidad5 = e.utilidad5;

                nr.admDivisa = OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.No ;
                if (e.admDivisa=="1")
                {
                    nr.admDivisa= OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si;
                }
                nr.fechaUltimaActCosto = e.fechaUltActualizacion;
                nr.contempCompra=e.contempCompra;
                nr.empCompra=e.empCompra;
                nr.costoUnd=e.costoUnd;
                nr.costoUndDivisa=e.costoDivisa/e.contempCompra;
            }
            rt.Entidad = nr;

            return rt;
        }

    }

}