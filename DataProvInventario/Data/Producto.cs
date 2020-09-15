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
                autoProducto=filtro.autoProducto,
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
                existencia = (DtoLibInventario.Producto.Filtro.Existencia )filtro.existencia,
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

                        var fechaV = "";
                        if (s.fechaUltCambioCosto.HasValue) 
                        {
                            fechaV = s.fechaUltCambioCosto.Value.ToShortDateString();
                        }

                        nr.costo.fechaUltCambio = fechaV;
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
                             Id=s.Id.ToString(),
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
                            Id = s.Id.ToString(),
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
                                autoId= s.autoId,
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

        public OOB.ResultadoLista<OOB.LibInventario.Producto.Estatus.Lista.Ficha> Producto_Estatus_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.Estatus.Lista.Ficha>();

            var r01 = MyData.Producto_Estatus_Lista ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.Estatus.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.Estatus.Lista.Ficha()
                        {
                            Id = s.Id.ToString(),
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
                            Id = s.Id.ToString(),
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
                nr.codigo=e.codigo;
                nr.nombre=e.nombre;
                nr.descripcion=e.descripcion;
                nr.nombreTasaIva=e.nombreTasaIva;
                nr.tasaIva = e.tasaIva;
                nr.estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus) e.estatus;

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

                nr.admDivisa = (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)e.admDivisa;
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

        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Costo> Producto_GetCosto(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Costo>();

            var r01 = MyData.Producto_GetCosto(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibInventario.Producto.Data.Costo();
            var e = r01.Entidad;
            if (e != null)
            {
                nr.codigo = e.codigo;
                nr.nombre = e.nombre;
                nr.descripcion = e.descripcion;
                nr.nombreTasaIva = e.nombreTasaIva;
                nr.tasaIva = e.tasaIva;
                nr.empaqueCompra = e.empaqueCompra;
                nr.contEmpaqueCompra = e.contEmpaqueCompra;
                nr.estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus)e.estatus;
                nr.admDivisa = (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)e.admDivisa;

                nr.costoDivisaUnd= e.costoDivisa/e.contEmpaqueCompra ;
                nr.costoImportacionUnd = e.costoImportacionUnd;
                nr.costoPromedioUnd =e.costoPromedioUnd;
                nr.costoProveedorUnd = e.costoProveedorUnd;
                nr.costoUnd = e.costoUnd;
                nr.costoVarioUnd = e.costoVarioUnd;
                var fechaV="";
                if (e.fechaUltCambio.HasValue) { fechaV = e.fechaUltCambio.Value.ToShortDateString(); }
                nr.fechaUltCambio = fechaV;
            }
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Depositos.Lista.Ficha> Producto_GetDepositos(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Depositos.Lista.Ficha>();

            var r01 = MyData.Producto_GetDepositos(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibInventario.Producto.Depositos.Lista.Ficha();
            var e = r01.Entidad;
            if (e != null)
            {
                nr.autoPrd=e.autoPrd;
                nr.codigoPrd=e.codigoPrd;
                nr.descripcionPrd=e.descripcionPrd;
                nr.nombrePrd=e.nombrePrd;
                nr.referenciaPrd=e.referenciaPrd;

                var list = new List<OOB.LibInventario.Producto.Depositos.Lista.Deposito>();
                if (e.depositos != null)
                {
                    if (e.depositos.Count > 0)
                    {
                        list = e.depositos.Select(s =>
                        {
                            return new OOB.LibInventario.Producto.Depositos.Lista.Deposito()
                            {
                                auto = s.autoDeposito,
                                codigo = s.codigoDeposito,
                                nombre = s.nombreDeposito,
                            };
                        }).ToList();
                    }
                }
                nr.depositos = list;
            }
            rt.Entidad = nr;

            return rt;
        }

        public OOB.Resultado Producto_AsignarDepositos(OOB.LibInventario.Producto.Depositos.Asignar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var listDTO = new List<DtoLibInventario.Producto.Depositos.Asignar.Deposito>();
            foreach (var it in ficha.depositos) 
            {
                var nr = new DtoLibInventario.Producto.Depositos.Asignar.Deposito()
                {
                    autoDeposito = it.autoDeposito,
                    averia = it.averia,
                    disponible = it.disponible,
                    fechaUltConteo = it.fechaUltConteo,
                    fisica = it.fisica,
                    nivel_minimo = it.nivel_minimo,
                    nivel_optimo = it.nivel_optimo,
                    pto_pedido = it.pto_pedido,
                    reservada = it.reservada,
                    resultadoUltConteo = it.resultadoUltConteo,
                    ubicacion_1 = it.ubicacion_1,
                    ubicacion_2 = it.ubicacion_2,
                    ubicacion_3 = it.ubicacion_3,
                    ubicacion_4 = it.ubicacion_4,
                };
                listDTO.Add(nr);
            }

            var fichaDTO = new DtoLibInventario.Producto.Depositos.Asignar.Ficha() 
            {
                 autoProducto= ficha.autoProducto,
                 depositos=listDTO,
            };
            var r01 = MyData.Producto_AsignarDepositos(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Producto.ClasificacionAbc.Ficha> Producto_Clasificacion_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Producto.ClasificacionAbc.Ficha>();

            var r01 = MyData.Producto_Clasificacion_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Producto.ClasificacionAbc.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Producto.ClasificacionAbc.Ficha()
                        {
                            Id = s.Id.ToString(),
                            Descripcion = s.Descripcion,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Editar.Obtener.Ficha> Producto_Editar_GetFicha(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Editar.Obtener.Ficha>();

            var r01 = MyData.Producto_Editar_GetFicha(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibInventario.Producto.Editar.Obtener.Ficha();
            var e = r01.Entidad;
            if (e != null)
            {
                nr.auto=e.auto;
                nr.autoDepartamento = e.autoDepartamento;
                nr.autoGrupo = e.autoGrupo;
                nr.autoMarca = e.autoMarca;
                nr.autoEmpCompra = e.autoEmpCompra;
                nr.autoTasaImpuesto = e.autoTasaImpuesto;

                nr.codigo = e.codigo;
                nr.nombre = e.nombre;
                nr.descripcion = e.descripcion;
                nr.modelo = e.modelo;
                nr.referencia = e.referencia;
                nr.contenidoCompra = e.contenidoCompra;

                nr.imagen = e.imagen;
                nr.esPesado = (OOB.LibInventario.Producto.Enumerados.EnumPesado) e.esPesado;
                nr.plu = e.plu;
                nr.diasEmpaque = e.diasEmpaque;

                nr.origen= (OOB.LibInventario.Producto.Enumerados.EnumOrigen) e.origen;
                nr.categoria= (OOB.LibInventario.Producto.Enumerados.EnumCategoria) e.categoria;
                nr.AdmPorDivisa= (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)  e.AdmPorDivisa;
                nr.Clasificacion= (OOB.LibInventario.Producto.Enumerados.EnumClasificacionABC) e.Clasificacion;
            }
            rt.Entidad = nr;

            return rt;
        }

        public OOB.Resultado Producto_Editar_Actualizar(OOB.LibInventario.Producto.Editar.Actualizar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Producto.Editar.Actualizar.Ficha()
            {
                auto = ficha.auto,
                abc = ficha.abc,
                autoDepartamento = ficha.autoDepartamento,
                autoEmpCompra = ficha.autoEmpCompra,
                autoGrupo = ficha.autoGrupo,
                autoMarca = ficha.autoMarca,
                autoTasaImpuesto = ficha.autoTasaImpuesto,
                categoria = ficha.categoria,
                codigo = ficha.codigo,
                contenidoCompra = ficha.contenidoCompra,
                descripcion = ficha.descripcion,
                estatusDivisa = ficha.estatusDivisa,
                modelo = ficha.modelo,
                nombre = ficha.nombre,
                origen = ficha.origen,
                referencia = ficha.referencia,
                imagen = ficha.imagen,
                diasEmpaque = ficha.diasEmpaque,
                esPesado = ficha.esPesado,
                plu = ficha.plu,
            };
            var r01 = MyData.Producto_Editar_Actualizar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoAuto Producto_Nuevo_Agregar(OOB.LibInventario.Producto.Agregar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibInventario.Producto.Agregar.Ficha()
            {
                abc = ficha.abc,
                autoDepartamento = ficha.autoDepartamento,
                autoEmpCompra = ficha.autoEmpCompra,
                autoGrupo = ficha.autoGrupo,
                autoMarca = ficha.autoMarca,
                autoTasaImpuesto = ficha.autoTasaImpuesto,
                categoria = ficha.categoria,
                codigo = ficha.codigo,
                contenidoCompra = ficha.contenidoCompra,
                descripcion = ficha.descripcion,
                estatusDivisa = ficha.estatusDivisa,
                modelo = ficha.modelo,
                nombre = ficha.nombre,
                origen = ficha.origen,
                referencia = ficha.referencia,
                estatus = ficha.estatus,
                tasa = ficha.tasa,
                imagen=ficha.imagen,
                diasEmpaque = ficha.diasEmpaque,
                esPesado = ficha.esPesado,
                plu = ficha.plu,
            };
            var r01 = MyData.Producto_Nuevo_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Depositos.Ver.Ficha> Producto_GetDeposito(OOB.LibInventario.Producto.Depositos.Ver.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Depositos.Ver.Ficha>();

            var filtroDTO = new DtoLibInventario.Producto.Depositos.Ver.Filtro()
            {
                autoDeposito = filtro.autoDeposito,
                autoProducto = filtro.autoProducto,
            };
            var r01 = MyData.Producto_GetDeposito(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s= r01.Entidad;
            var nr = new OOB.LibInventario.Producto.Depositos.Ver.Ficha()
            {
                autoDeposito = s.autoDeposito,
                autoProducto = s.autoProducto,
                averia = s.averia,
                codigoDeposito = s.codigoDeposito,
                codigoProducto = s.codigoProducto,
                contenidoCompra = s.contenidoCompra,
                disponible = s.disponible,
                empaqueCompra = s.empaqueCompra,
                fechaUltConteo = s.fechaUltConteo.HasValue ? s.fechaUltConteo.Value.ToShortDateString(): "",
                fisica = s.fisica,
                nivelMinimo = (int)s.nivelMinimo,
                nivelOptimo = (int)s.nivelOptimo,
                nombreDeposito = s.nombreDeposito,
                nombreProducto = s.nombreProducto,
                ptoPedido = (int)s.ptoPedido,
                referenciaProducto = s.referenciaProducto,
                reservada = s.reservada,
                resultadoUltConteo = s.resultadoUltConteo,
                ubicacion_1 = s.ubicacion_1,
                ubicacion_2 = s.ubicacion_2,
                ubicacion_3 = s.ubicacion_3,
                ubicacion_4 = s.ubicacion_4,
            };
            rt.Entidad=nr;

            return rt;
        }

        public OOB.Resultado Producto_EditarDeposito(OOB.LibInventario.Producto.Depositos.Editar.Ficha ficha)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Depositos.Editar.Ficha>();

            var fichaDTO = new DtoLibInventario.Producto.Depositos.Editar.Ficha()
            {
                autoDeposito = ficha.autoDeposito,
                autoProducto = ficha.autoProducto,
                nivelMinimo = ficha.nivelMinimo,
                nivelOptimo = ficha.nivelOptimo,
                ptoPedido = ficha.ptoPedido,
                ubicacion_1 = ficha.ubicacion_1,
                ubicacion_2 = ficha.ubicacion_2,
                ubicacion_3 = ficha.ubicacion_3,
                ubicacion_4 = ficha.ubicacion_4,
            };
            var r01 = MyData.Producto_DepositoEditar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Producto_CambiarEstatusA_Activo(string auto)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Producto_CambiarEstatusA_Activo(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Producto_CambiarEstatusA_Inactivo(string auto)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Producto_CambiarEstatusA_Inactivo(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Producto_CambiarEstatusA_Suspendido(string auto)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Producto_CambiarEstatusA_Suspendido(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Estatus.Actual.Ficha> Producto_Estatus_GetFicha(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Estatus.Actual.Ficha>();

            var r01 = MyData.Producto_Estatus_GetFicha(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s= r01.Entidad;
            var nr = new OOB.LibInventario.Producto.Estatus.Actual.Ficha()
            {
                autoProducto = s.autoProducto,
                codigoProducto = s.codigoProducto,
                estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus)s.estatus,
                nombreProducto = s.nombreProducto,
                referenciaProducto = s.referenciaProducto,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Imagen> Producto_GetImagen(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Imagen >();

            var r01 = MyData.Producto_GetImagen(autoPrd);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Producto.Data.Imagen()
            {
                codigo = s.codigo,
                descripcion = s.descripcion,
                imagen = s.imagen,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}