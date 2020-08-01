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

        public OOB.ResultadoLista<OOB.LibInventario.Producto.Data.Ficha> Producto_GetLista(OOB.LibInventario.Producto.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Data.Ficha>();

            var filtroDto = new DtoLibInventario.Producto.Filtro()
            {
                admPorDivisa = (DtoLibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)filtro.admPorDivisa,
                autoDepartamento = filtro.autoDepartamento,
                autoDeposito = filtro.autoDeposito,
                autoGrupo = filtro.autoGrupo,
                autoMarca = filtro.autoMarca,
                autoProveedor = filtro.autoProveedor,
                autoTasa = filtro.autoTasa,
                cadena = filtro.cadena,
                categoria = (DtoLibInventario.Producto.Enumerados.EnumCategoria)filtro.categoria,
                estatus = (DtoLibInventario.Producto.Enumerados.EnumEstatus)filtro.estatus,
                MetodoBusqueda = (DtoLibInventario.Producto.Enumerados.EnumMetodoBusqueda)filtro.MetodoBusqueda,
                oferta = (DtoLibInventario.Producto.Enumerados.EnumOferta)filtro.oferta,
                origen = (DtoLibInventario.Producto.Enumerados.EnumOrigen)filtro.origen,
                pesado = (DtoLibInventario.Producto.Enumerados.EnumPesado)filtro.pesado,
            };
            var r01 = MyData.Producto_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Data.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibInventario.Producto.Data.Ficha();
                        var id = nr.identidad;
                        id.auto = s.auto;
                        id.codigo = s.codigo;
                        id.nombre = s.nombre;
                        id.descripcion = s.descripcion;
                        id.empaqueCompra =s.empaque;
                        id.contenidoCompra =s.contenido;
                        id.departamento=s.departamento;
                        id.grupo = s.grupo;
                        id.marca = s.marca;
                        id.referencia= s.referencia;
                        id.modelo = s.modelo;
                        id.tasaIva =s.tasaIva;
                        id.nombreTasaIva = s.tasaIvaDescripcion;
                        id.estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus) s.estatus;
                        id.origen = (OOB.LibInventario.Producto.Enumerados.EnumOrigen)s.origen;
                        id.categoria = (OOB.LibInventario.Producto.Enumerados.EnumCategoria) s.categoria;
                        id.AdmPorDivisa = (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa) s.admPorDivisa;
                        id.fechaAlta=s.fechaAlta;
                        nr.costo.fechaUltCambio = s.fechaUltCambioCosto;
                        nr.extra.esPesado= (OOB.LibInventario.Producto.Enumerados.EnumPesado) s.esPesado;
                        
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Producto.Origen.Ficha> Producto_Origen_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Origen.Ficha>();

            var r01 = MyData.Producto_Origen_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Origen.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.Origen.Ficha ()
                        {
                             Id=s.Id,
                             Descripcion=s.Descripcion,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Producto.Categoria.Ficha> Producto_Categoria_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Categoria.Ficha>();

            var r01 = MyData.Producto_Categoria_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Categoria.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.Categoria.Ficha()
                        {
                            Id = s.Id,
                            Descripcion = s.Descripcion,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}