﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Buscar
{

    public class Gestion
    {

        private Filtrar.Gestion _gestionFiltro;
        private GestionLista _gestionLista;
        private Producto.Precio.Editar.Gestion _gestionEditarPrecio;
        private Producto.Deposito.Listar.Gestion _gestionPrdExistencia;
        private Producto.Precio.Historico.Gestion _gestionHistoricoPrecio;
        private Producto.Precio.Ver.Gestion _gestionPrdPrecios;
        private Producto.Costo.Historico.Gestion _gestionHistoricoCosto;
        private Producto.Costo.Ver.Gestion _gestionPrdCosto;
        private Producto.Costo.Editar.Gestion _gestionEditarCosto;
        private Producto.QR.Gestion _gestionQR;
        private Producto.Deposito.Asignar.Gestion _gestionDeposito;
        private Producto.AgregarEditar.Gestion _gestionEditarFicha;
        private Producto.AgregarEditar.Gestion _gestionAgregarFicha;
        private Producto.Estatus.Gestion _gestionEstatus;
        private Kardex.Movimiento.Gestion _gestionKardex;
        private OOB.LibInventario.Producto.Filtro _filtros;


        public OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda MetodoBusqueda { get; set; }
        public string Cadena { get; set; }
        public object Source { get { return _gestionLista.Source; } }
        public int Items { get { return _gestionLista.Items; } }
        public OOB.LibInventario.Producto.Data.Ficha Item { get { return _gestionLista.Item; } }
        public bool HayItemSeleccionado { get; set; }


        public Gestion()
        {
            _filtros = new OOB.LibInventario.Producto.Filtro();
            _gestionFiltro = new Filtrar.Gestion();
            _gestionLista = new GestionLista();
            _gestionLista.CambioItemActual+=_gestionLista_CambioItemActual;
            _gestionPrdExistencia = new Producto.Deposito.Listar.Gestion();
            _gestionPrdPrecios = new Producto.Precio.Ver.Gestion();
            _gestionHistoricoPrecio = new Producto.Precio.Historico.Gestion();
            _gestionEditarPrecio = new Producto.Precio.Editar.Gestion(new Producto.Precio.Editar.ModoSucursal.Gestion());
            _gestionHistoricoCosto= new Producto.Costo.Historico.Gestion();
            _gestionPrdCosto = new Producto.Costo.Ver.Gestion();
            _gestionEditarCosto = new Producto.Costo.Editar.Gestion();
            _gestionQR = new Producto.QR.Gestion();
            _gestionDeposito = new Producto.Deposito.Asignar.Gestion();
            _gestionEditarFicha = new Producto.AgregarEditar.Gestion(new Producto.AgregarEditar.Editar.Gestion());
            _gestionAgregarFicha = new Producto.AgregarEditar.Gestion(new Producto.AgregarEditar.Agregar.Gestion());
            _gestionEstatus = new Producto.Estatus.Gestion();
            _gestionKardex = new Kardex.Movimiento.Gestion();
            LimpiarEntradas();
        }

        private void _gestionLista_CambioItemActual(object sender, EventArgs e)
        {
            frm.ActualizarItem();
        }

        private void LimpiarEntradas()
        {
            Cadena = "";
            MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Codigo;
        }

        BusquedaFrm frm;
        public void Inicia() 
        {
            LimpiarEntradas();
            if (CargarData()) 
            {
                HayItemSeleccionado = false;
                _gestionLista.Limpiar();
                if (frm == null) 
                {
                    frm = new BusquedaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_PreferenciaBusqueda();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            switch (r01.Entidad) 
            {
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorCodigo:
                    MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Codigo;
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorNombre:
                    MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Nombre;
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorReferencia:
                    MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Referencia;
                    break;
            }

            return rt;
        }

        public void RealizarBusqueda()
        {
            if (_gestionFiltro.IsFiltrarOk || this.Cadena.Trim() != "") 
            {
                _filtros.cadena = this.Cadena;
                _filtros.MetodoBusqueda = this.MetodoBusqueda;
                CargarFiltros();

                var r01 = Sistema.MyData.Producto_GetLista(_filtros);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                _gestionLista.setLista(r01.Lista);
                _filtros.Limpiar();
                _gestionFiltro.Limpiar();

                frm.ActualizarItem();
                Cadena = "";
            }
        }

        public void FiltrarBusqueda()
        {
            _gestionFiltro.Inicia();
            if (_gestionFiltro.ActivarBusqueda) 
            {
                RealizarBusqueda();
            }
        }

        private void CargarFiltros()
        {
            _filtros.autoDepartamento = _gestionFiltro.AutoDepartamento;
            _filtros.autoGrupo = _gestionFiltro.AutoGrupo;
            _filtros.autoTasa = _gestionFiltro.AutoTasa;
            _filtros.autoMarca = _gestionFiltro.AutoMarca;
            _filtros.autoDeposito = _gestionFiltro.AutoDeposito;
            if (_gestionFiltro.IdOrigen != "")
            {
                _filtros.origen = (OOB.LibInventario.Producto.Enumerados.EnumOrigen)int.Parse(_gestionFiltro.IdOrigen);
            }
            if (_gestionFiltro.IdCategoria != "")
            {
                _filtros.categoria = (OOB.LibInventario.Producto.Enumerados.EnumCategoria)int.Parse(_gestionFiltro.IdCategoria);
            }
            if (_gestionFiltro.IdEstatus != "")
            {
                _filtros.estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus)int.Parse(_gestionFiltro.IdEstatus);
            }
            if (_gestionFiltro.IdAdmDivisa != "")
            {
                _filtros.admPorDivisa = (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)int.Parse(_gestionFiltro.IdAdmDivisa);
            }
            if (_gestionFiltro.IdPesado != "")
            {
                _filtros.pesado = (OOB.LibInventario.Producto.Enumerados.EnumPesado)int.Parse(_gestionFiltro.IdPesado);
            }
            if (_gestionFiltro.IdOferta != "")
            {
                _filtros.oferta = (OOB.LibInventario.Producto.Enumerados.EnumOferta)int.Parse(_gestionFiltro.IdOferta);
            }
        }

        public void SeleccionarItem()
        {
            HayItemSeleccionado = _gestionLista.SeleccionarItem() != null ? true : false;
        }

        public void VerExistencia()
        {
            if (Item != null)
            {
                _gestionPrdExistencia.setFicha(Item.identidad.auto);
                _gestionPrdExistencia.Inicia();
            }
        }

        public void VerPrecios()
        {
            if (Item != null)
            {
                _gestionPrdPrecios.setFicha(Item.identidad.auto);
                _gestionPrdPrecios.Inicia();
            }
        }

        public void Limpiar()
        {
            _gestionLista.Limpiar();
            frm.ActualizarItem();
        }

        public void EditarPrecio()
        {
            if (Item != null)
            {
                if (Item.identidad.estatus != OOB.LibInventario.Producto.Enumerados.EnumEstatus.Inactivo)
                {
                    _gestionEditarPrecio.setFicha(Item.identidad.auto);
                    _gestionEditarPrecio.Inicia();
                }
                else
                    Helpers.Msg.Error("Producto En Estado Inactivo, Verifique Por Favor !!!");
            }
        }

        public void HistoricoPrecio()
        {
            if (Item != null)
            {
                _gestionHistoricoPrecio.setFicha(Item.identidad.auto);
                _gestionHistoricoPrecio.Inicia();
            }
        }

        internal void HistoricoCosto()
        {
            if (Item != null)
            {
                _gestionHistoricoCosto.setFicha(Item.identidad.auto);
                _gestionHistoricoCosto.Inicia();
            }
        }

        public void VerCosto()
        {
            if (Item != null)
            {
                _gestionPrdCosto.setFicha(Item.identidad.auto);
                _gestionPrdCosto.Inicia();
            }
        }

        public void EditarCosto()
        {
            if (Item != null)
            {
                if (Item.identidad.estatus != OOB.LibInventario.Producto.Enumerados.EnumEstatus.Inactivo)
                {
                    _gestionEditarCosto.setFicha(Item.identidad.auto);
                    _gestionEditarCosto.Inicia();
                }
                else
                    Helpers.Msg.Error("Producto En Estado Inactivo, Verifique Por Favor !!!");
            }
        }

        public void GenerarQR()
        {
            if (Item != null)
            {
                _gestionQR.setFicha(Item.identidad.auto);
                _gestionQR.Inicia();
            }
        }

        public void AsignarDeposito()
        {
            if (Item != null)
            {
                _gestionDeposito.setFicha(Item.identidad.auto);
                _gestionDeposito.Inicia();
            }
        }

        public void MovKardex()
        {
            if (Item != null)
            {
                _gestionKardex.setFicha(Item.identidad.auto);
                _gestionKardex.Inicia();
            }
        }

        public void EditarFicha()
        {
            if (Item != null)
            {
                if (Item.identidad.estatus == OOB.LibInventario.Producto.Enumerados.EnumEstatus.Inactivo)
                {
                    Helpers.Msg.Error("Producto En Estado Inactivo, Verifique Por Favor !!!");
                    return;
                }

                _gestionEditarFicha.setFicha(Item.identidad.auto);
                _gestionEditarFicha.Inicia();
                if (_gestionEditarFicha.IsAgregarEditarOk)
                {
                    var filtros = new OOB.LibInventario.Producto.Filtro();
                    filtros.autoProducto = Item.identidad.auto;
                    var r01 = Sistema.MyData.Producto_GetLista(filtros);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    if (r01.Lista !=null) 
                    {
                        if (r01.Lista.Count > 0) 
                        {
                            _gestionLista.Reemplazar(r01.Lista);
                        }
                    }
                }
            }
        }

        public void AgregarFicha()
        {
            _gestionAgregarFicha.Inicia();
            if (_gestionAgregarFicha.IsAgregarEditarOk) 
            {
                var filtros = new OOB.LibInventario.Producto.Filtro();
                filtros.autoProducto = _gestionAgregarFicha.AutoProductoAgregado ;
                var r01 = Sistema.MyData.Producto_GetLista(filtros);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                if (r01.Lista != null)
                {
                    if (r01.Lista.Count > 0)
                    {
                        _gestionLista.Agregar(r01.Lista);
                    }
                }
            }
        }

        public void CambioEstatus()
        {
            if (Item != null)
            {
                _gestionEstatus.setFicha(Item.identidad.auto);
                _gestionEstatus.Inicia();

                if (_gestionEstatus.IsCambioOk)
                {
                    var filtros = new OOB.LibInventario.Producto.Filtro();
                    filtros.autoProducto = Item.identidad.auto;
                    var r01 = Sistema.MyData.Producto_GetLista(filtros);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    if (r01.Lista != null)
                    {
                        if (r01.Lista.Count > 0)
                        {
                            _gestionLista.Reemplazar(r01.Lista);
                        }
                    }
                }

            }
        }

    }

}