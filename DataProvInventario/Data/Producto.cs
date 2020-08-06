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
                        id.fechaAlta=s.fechaAlta.Value;
                        id.fechaUltActualizacion = s.fechaUltActualizacion;
                        nr.costo.fechaUltCambio = s.fechaUltCambioCosto;
                        nr.extra.esPesado= (OOB.LibInventario.Producto.Enumerados.EnumPesado) s.esPesado;
                        nr.precio.estatusOferta = (OOB.LibInventario.Producto.Enumerados.EnumOferta) s.enOferta;
                        
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

        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Existencia> Producto_GetExistencia(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Existencia>();

            var r01 = MyData.Producto_GetExistencia(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibInventario.Producto.Data.Existencia();
            var e = r01.Entidad;
            if (e != null)
            {
                nr.decimales = e.decimales;
                nr.empaque = e.empaqueCompra;
                nr.empaqueContenido = e.empaqueCompraCont;

                var list = new List<OOB.LibInventario.Producto.Data.Deposito>();
                if (e.depositos != null)
                {
                    if (e.depositos.Count > 0)
                    {
                        list = e.depositos.Select(s =>
                        {
                            return new OOB.LibInventario.Producto.Data.Deposito()
                            {
                                codigo = s.codigo,
                                exDisponible = s.exDisponible,
                                exFisica = s.exFisica,
                                exReserva = s.exReserva,
                                nombre = s.nombre,
                            };
                        }).ToList();
                    }
                }
                nr.depositos = list;
            }
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Producto.Estatus.Ficha> Producto_Estatus_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Estatus.Ficha>();

            var r01 = MyData.Producto_Estatus_Lista ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Estatus.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.Estatus.Ficha()
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

        public OOB.ResultadoLista<OOB.LibInventario.Producto.AdmDivisa.Ficha> Producto_AdmDivisa_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.AdmDivisa.Ficha>();

            var r01 = MyData.Producto_AdmDivisa_Lista ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.AdmDivisa.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.AdmDivisa.Ficha()
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

        public OOB.ResultadoLista<OOB.LibInventario.Producto.Pesado.Ficha> Producto_Pesado_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Pesado.Ficha>();

            var r01 = MyData.Producto_Pesado_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Pesado.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.Pesado.Ficha()
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

        public OOB.ResultadoLista<OOB.LibInventario.Producto.Oferta.Ficha> Producto_Oferta_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Oferta.Ficha>();

            var r01 = MyData.Producto_Oferta_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Oferta.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.Oferta.Ficha()
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

        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Precio> Producto_GetPrecio(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Precio>();

            var r01 = MyData.Producto_GetPrecio (autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibInventario.Producto.Data.Precio();
            var e = r01.Entidad;
            if (e != null)
            {
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
                nr.empaque1 = e.empaque1;
                nr.empaque2 = e.empaque2;
                nr.empaque3 = e.empaque3;
                nr.empaque4 = e.empaque4;
                nr.empaque5 = e.empaque5;
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

                nr.estatusOferta = (OOB.LibInventario.Producto.Enumerados.EnumOferta) e.estatusOferta;
                nr.inicioOferta = e.inicioOferta;
                nr.finOferta = e.finOferta;
                nr.ofertaActiva = (OOB.LibInventario.Producto.Enumerados.EnumOferta) e.ofertaActiva;
                nr.precioOferta = e.precioOferta;
                nr.precioSugerido = e.precioSugerido;
            }
            rt.Entidad = nr;

            return rt;
        }

    }

}