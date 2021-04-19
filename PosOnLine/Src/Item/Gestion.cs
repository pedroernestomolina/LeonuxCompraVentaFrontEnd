﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Item
{

    public class Gestion
    {

        public event EventHandler Hnd_Item_Cambio;


        private string _autoDeposito;
        private string _tarifaPrecio;
        private bool _validarExistencia;
        private bool _anularVentaIsOk;
        private decimal _tasaCambio;
        private OOB.Venta.Item.Entidad.Ficha _itemActual;
        private List<data> _litems;
        private BindingList<data> _blitems;
        private BindingSource _bsitems;
        private string _productoInf;
        private string _prdTasaIvaInf;
        private decimal _prdPrecioNetoInf;
        private decimal _prdIvaInf;
        private int _prdContenidoInf;
        private Multiplicar.Gestion _gestionMultiplicar;
        private Devolucion.Gestion _gestionDevolucion;
        private Pendiente.Gestion _gestionPendiente;
        private bool _dejarPendienteIsOk; 


        public int CantItem { get { return _blitems.Sum(s => s.cantItem); } }
        public decimal TotalPeso { get { return _blitems.Sum(s => s.totalPeso); } }
        public int CantRenglones { get { return _blitems.Sum(s => s.cantRenglones); } }
        public decimal Importe { get { return _blitems.Sum(s => s.MontoTotal()); } }
        public decimal ImporteDivisa { get { return _blitems.Sum(s => s.TotalItemDivisa); } }
        public BindingSource ItemSource { get { return _bsitems; } }
        public bool AnularVentaIsOk { get { return _anularVentaIsOk; } }
        public bool DejarCtaPendienteIsOk { get { return _dejarPendienteIsOk; } }
        public OOB.Venta.Item.Entidad.Ficha ItemActual { get { return _itemActual; } }
        public string Producto { get { return _productoInf; } }
        public string PrdTasaIva { get { return _prdTasaIvaInf; } }
        public decimal PrdPrecioNeto { get { return _prdPrecioNetoInf; } }
        public decimal PrdIva { get { return _prdIvaInf; } }
        public int PrdContenido { get { return _prdContenidoInf; } }
        public BindingList<data> Items { get { return _blitems; } }


        public Gestion()
        {
            _autoDeposito = "";
            _tarifaPrecio = "";
            _anularVentaIsOk = false;
            _dejarPendienteIsOk = false;
            _validarExistencia = true;
            _itemActual = null;
            _litems = new List<data>();
            _blitems = new BindingList<data>(_litems);
            _bsitems = new BindingSource();
            _bsitems.DataSource = _blitems;
            _bsitems.CurrentChanged += _bsitems_CurrentChanged;
        }


        private void _bsitems_CurrentChanged(object sender, EventArgs e)
        {
            _productoInf = "";
            _prdContenidoInf = 0;
            _prdIvaInf = 0.0m;
            _prdPrecioNetoInf = 0.0m;
            _prdTasaIvaInf = "";
            if (_bsitems.Current != null)
            {
                var it = (data)_bsitems.Current;
                _productoInf = it.Ficha.nombre;
                _prdContenidoInf = it.Ficha.empaqueContenido;
                _prdIvaInf = it.Iva();
                _prdPrecioNetoInf = it.Ficha.pneto;
                _prdTasaIvaInf = it.TasaIvaDescripcion;
            }
            var hnd = Hnd_Item_Cambio;
            if (hnd != null)
            {
                hnd(this, null);
            }
        }

        public void setDepositoAsignado(OOB.Deposito.Entidad.Ficha _depositoAsignado)
        {
            _autoDeposito = _depositoAsignado.id;
        }

        public void RegistraItem(string idPrd)
        {
            var r01 = Sistema.MyData.Producto_GetFichaById(idPrd);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            if (!r01.Entidad.IsPesado)
            {
                Registrar(r01.Entidad, 1);
            }
            else
            {
                var r1 = Sistema.MyBalanza.LeerPeso();
                if (!r1.IsOk) 
                {
                    Helpers.Msg.Error(r1.Mensaje);
                    return;
                }
                if (r1.Peso > 0) 
                {
                    Registrar(r01.Entidad, r1.Peso);
                }
            }
        }

        private void Registrar(OOB.Producto.Entidad.Ficha prd, decimal cant)
        {
            var cnt = 0.0m;
            var precioNeto = 0.0m;
            var precioFullDivisa = 0.0m;
            var empaqueCont = 0;
            var empaqueDesc = "";
            var decimales = "";
            switch (_tarifaPrecio)
            {
                case "1":
                    cnt = prd.contenido_1;
                    precioNeto = prd.pneto_1;
                    precioFullDivisa = prd.pdf_1;
                    empaqueCont = prd.contenido_1;
                    empaqueDesc = prd.empaque_1;
                    decimales = prd.decimales_1;
                    break;
                case "2":
                    cnt = prd.contenido_2;
                    precioNeto = prd.pneto_2;
                    precioFullDivisa = prd.pdf_2;
                    empaqueCont = prd.contenido_2;
                    empaqueDesc = prd.empaque_2;
                    decimales = prd.decimales_2;
                    break;
                case "3":
                    cnt = prd.contenido_3;
                    precioNeto = prd.pneto_3;
                    precioFullDivisa = prd.pdf_3;
                    empaqueCont = prd.contenido_3;
                    empaqueDesc = prd.empaque_3;
                    decimales = prd.decimales_3;
                    break;
                case "4":
                    cnt = prd.contenido_4;
                    precioNeto = prd.pneto_4;
                    precioFullDivisa = prd.pdf_4;
                    empaqueCont = prd.contenido_4;
                    empaqueDesc = prd.empaque_4;
                    decimales = prd.decimales_4;
                    break;
                case "5":
                    cnt = prd.contenido_5;
                    precioNeto = prd.pneto_5;
                    precioFullDivisa = prd.pdf_5;
                    empaqueCont = prd.contenido_5;
                    empaqueDesc = prd.empaque_5;
                    decimales = prd.decimales_5;
                    break;
            }

            if (cnt == 0.0m)
            {
                Helpers.Msg.Error("CONTENIDO DEL PRODUCTO NO DEFINIDO");
                return;
            }
            if (precioNeto == 0.0m)
            {
                Helpers.Msg.Error("PRECIO DEL PRODUCTO NO DEFINIDO");
                return;
            }

            cnt *= cant;
            var ficha = new OOB.Venta.Item.Registrar.Ficha()
            {
                validarExistencia = _validarExistencia,
                deposito = new OOB.Venta.Item.Registrar.FichaDeposito()
                {
                    autoDeposito = _autoDeposito,
                    autoPrd = prd.Auto,
                    cantBloq = cnt
                },
                item = new OOB.Venta.Item.Registrar.FichaItem()
                {
                    autoDepartamento = prd.AutoDepartamento,
                    autoGrupo = prd.AutoGrupo,
                    autoProducto = prd.Auto,
                    autoSubGrupo = prd.AutoSubGrupo,
                    autoTasa = prd.AutoTasaIva,
                    cantidad = cant,
                    categoria = prd.Categoria,
                    codigo = prd.CodigoPrd,
                    costoCompra = prd.Costo,
                    costoPromedio = prd.CostoPromedio,
                    costoPromedioUnd = prd.CostoPromedioUnidad,
                    costoUnd = prd.CostoUnidad,
                    decimales = decimales,
                    empaqueContenido = empaqueCont,
                    empaqueDescripcion = empaqueDesc,
                    estatusPesado = prd.EstatusPesado,
                    idOperador = Sistema.PosEnUso.id,
                    nombre = prd.NombrePrd,
                    pfullDivisa = precioFullDivisa,
                    pneto = precioNeto,
                    tarifaPrecio = _tarifaPrecio,
                    tasaIva = prd.TasaImpuesto,
                    tipoIva = "",
                    autoDeposito = _autoDeposito,
                },
            };
            var r01 = Sistema.MyData.Venta_Item_Registrar(ficha);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var r02 = Sistema.MyData.Venta_Item_GetById(r01.Id);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }

            _itemActual = r02.Entidad;
            _blitems.Insert(0, new data(r02.Entidad, _tasaCambio));
            _bsitems.Position = 0;
            Helpers.Sonido.SonidoOk();
        }

        public void setTarifaPrecio(string tarifa)
        {
            _tarifaPrecio = tarifa;
        }

        public void setValidarExistencia(bool validar)
        {
            _validarExistencia = validar;
        }

        public void setData(List<OOB.Venta.Item.Entidad.Ficha> list, decimal _tasaCambioActual)
        {
            setTasaCambio(_tasaCambioActual);
            _blitems.Clear();
            foreach (var it in list)
            {
                _blitems.Add(new data(it, _tasaCambioActual));
            }
        }

        public void AnularVenta()
        {
            _anularVentaIsOk = false;

            var litems = new List<OOB.Venta.Anular.FichaItem>();
            var litemsDeposito = new List<OOB.Venta.Anular.FichaDeposito>();
            foreach (var it in _litems)
            {
                var nit = new OOB.Venta.Anular.FichaItem()
                {
                    idOperador = it.Ficha.idOperador,
                    idItem = it.Ficha.id,
                };
                litems.Add(nit);

                var nitDep = new OOB.Venta.Anular.FichaDeposito()
                {
                    autoProducto = it.Ficha.autoProducto,
                    autoDeposito = it.Ficha.autoDeposito,
                    cantUndBloq = it.TotalUnd,
                };
                litemsDeposito.Add(nitDep);
            }

            var ficha = new OOB.Venta.Anular.Ficha()
            {
                items = litems,
                itemDeposito = litemsDeposito,
            };
            var r01 = Sistema.MyData.Venta_Anular(ficha);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _blitems.Clear();
            _bsitems.CurrencyManager.Refresh();
            _anularVentaIsOk = true;
        }

        public void Inicializar()
        {
            _anularVentaIsOk = false;
            _dejarPendienteIsOk = false;
            _itemActual = null;
            _productoInf = "";
            _prdContenidoInf = 0;
            _prdIvaInf = 0.0m;
            _prdPrecioNetoInf = 0.0m;
            _prdTasaIvaInf = "";
        }


        public void setTasaCambio(decimal _tasaCambioActual)
        {
            _tasaCambio = _tasaCambioActual;
        }

        public void Incrementar()
        {
            IncrementarItem(1);
        }

        private void IncrementarItem(decimal cnt)
        {
            if (ItemActual != null)
            {
                if (_bsitems.Current != null)
                {
                    var it = (data)_bsitems.Current;
                    if (it.Ficha.id == ItemActual.id)
                    {
                        if (!it.EsPesado)
                        {
                            var ficha = new OOB.Venta.Item.ActualizarCantidad.Aumentar.Ficha()
                            {
                                idOperador = it.Ficha.idOperador,
                                idItem = it.Ficha.id,
                                autoProducto = it.Ficha.autoProducto,
                                autoDeposito = it.Ficha.autoDeposito,
                                cantUndBloq = it.ContenidoEmp * cnt,
                                cantidad = cnt,
                                validarExistencia = Sistema.ConfiguracionActual.ValidarExistencia_Activa,
                            };
                            var r01 = Sistema.MyData.Venta_Item_ActualizarCantidad_Aumentar(ficha);
                            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                            {
                                Helpers.Msg.Error(r01.Mensaje);
                                return;
                            }
                            it.setAumentaCantiad(cnt);
                            Helpers.Sonido.SonidoOk();
                        }
                    }
                }
            }
        }

        private void ActualizarLista(List<OOB.Venta.Item.Entidad.Ficha> list)
        {
            _blitems.Clear();
            foreach (var it in list.OrderByDescending(o => o.id).ToList())
            {
                _blitems.Add(new data(it, _tasaCambio));
            }
        }

        public void Decrementar()
        {
            if (ItemActual != null)
            {
                if (_bsitems.Current != null)
                {
                    var it = (data)_bsitems.Current;
                    if (it.Ficha.id == ItemActual.id)
                    {
                        if (it.EsPesado) 
                        {
                            return;
                        }
                        if (it.Cantidad == 1)
                        {
                            var ficha = new OOB.Venta.Item.Eliminar.Ficha()
                            {
                                idOperador = it.Ficha.idOperador,
                                idItem = it.Ficha.id,
                                autoProducto = it.Ficha.autoProducto,
                                autoDeposito = it.Ficha.autoDeposito,
                                cantUndBloq = it.ContenidoEmp,
                            };
                            var r01 = Sistema.MyData.Venta_Item_Eliminar(ficha);
                            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                            {
                                Helpers.Msg.Error(r01.Mensaje);
                                return;
                            }
                            _blitems.Remove(it);
                            Helpers.Sonido.SonidoOk();
                        }
                        else
                        {
                            var ficha = new OOB.Venta.Item.ActualizarCantidad.Disminuir.Ficha()
                            {
                                idOperador = it.Ficha.idOperador,
                                idItem = it.Ficha.id,
                                autoProducto = it.Ficha.autoProducto,
                                autoDeposito = it.Ficha.autoDeposito,
                                cantUndBloq = it.ContenidoEmp,
                                cantidad = 1,
                            };
                            var r01 = Sistema.MyData.Venta_Item_ActualizarCantidad_Disminuir(ficha);
                            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                            {
                                Helpers.Msg.Error(r01.Mensaje);
                                return;
                            }
                            it.setDisminuyeCantidad(1);
                            Helpers.Sonido.SonidoOk();
                        }
                    }
                }
            }
        }

        public void setItemActualInicializar()
        {
            _itemActual = null;
        }

        public void setGestionMultiplicar(Src.Multiplicar.Gestion gestion)
        {
            _gestionMultiplicar = gestion;
        }

        public void setGestionDevolucion(Devolucion.Gestion gestion )
        {
            _gestionDevolucion= gestion;
        }

        public void DevolucionItem()
        {
            if (_blitems.Count>0)
            {
                _gestionDevolucion.Inicializa();
                _gestionDevolucion.setData(Items);
                _gestionDevolucion.Inicia();
                if (_gestionDevolucion.FichaCambioIsOk)
                {
                    var filtro = new OOB.Venta.Item.Lista.Filtro()
                    {
                        idOperador = Sistema.PosEnUso.id,
                    };
                    var r01 = Sistema.MyData.Venta_Item_GetLista(filtro);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    ActualizarLista(r01.ListaD);
                }
                setItemActualInicializar();
            }
        }

        public void Multiplicar()
        {
            if (ItemActual != null)
            {
                if (_bsitems.Current != null)
                {
                    var it = (data)_bsitems.Current;
                    if (it.Ficha.id == ItemActual.id)
                    {
                        if (it.EsPesado)
                        {
                            return;
                        }
                        _gestionMultiplicar.Inicializa();
                        _gestionMultiplicar.Inicia();
                        if (_gestionMultiplicar.ProcesarIsOk) 
                        {
                            IncrementarItem(_gestionMultiplicar.Cantidad);
                        }
                    }
                }
            }
        }

        public void DejarCtaPendiente(OOB.Cliente.Entidad.Ficha cliente)
        {
            _dejarPendienteIsOk = false;
            if (_gestionPendiente.DejarPendiente()) 
            {
                var agregar = new OOB.Pendiente.DejarCta.Ficha()
                {
                    cirifCliente = cliente.CiRif,
                    idCliente = cliente.Id,
                    idOperador = Sistema.PosEnUso.id,
                    monto = Importe,
                    montoDivisa = ImporteDivisa,
                    nombreCliente = cliente.Nombre,
                    renglones = CantRenglones,
                };
                agregar.items = _blitems.Select(s =>
                {
                    var nr = new OOB.Pendiente.DejarCta.FichaItem()
                    {
                        idItem = s.Ficha.id,
                    };
                    return nr;
                }).ToList();
                var r01 = Sistema.MyData.Pendiente_DejarCta(agregar);
                if (r01.Result ==  OOB.Resultado.Enumerados.EnumResult.isError )
                {
                    Helpers.Sonido.Error();
                    Helpers.Msg.Error(r01.Mensaje);
                }
                _blitems.Clear();
                _bsitems.CurrencyManager.Refresh();
                _dejarPendienteIsOk = true;
                Helpers.Msg.OK("PROCESO REALIZADO CON EXITO !!!");
            }
        }

        public void setGestionPendiente(Pendiente.Gestion gestion)
        {
            _gestionPendiente = gestion;
        }

        public void setDescuentoFinal(decimal p)
        {
            foreach (var it in _litems)
            {
                it.setDescuentoFinal(p);
            }
        }

        public void Limpiar()
        {
            Inicializar();
            _blitems.Clear();
            _bsitems.CurrencyManager.Refresh();
        }

    }

}