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
        private Producto.Existencia.Ver.Gestion _gestionPrdExistencia;
        private Producto.Precio.Historico.Gestion _gestionHistoricoPrecio;
        private Producto.Precio.Ver.Gestion _gestionPrdPrecios;
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
            _gestionPrdExistencia = new Producto.Existencia.Ver.Gestion();
            _gestionPrdPrecios = new Producto.Precio.Ver.Gestion();
            _gestionHistoricoPrecio = new Producto.Precio.Historico.Gestion();
            _gestionEditarPrecio = new Producto.Precio.Editar.Gestion(new Producto.Precio.Editar.ModoSucursal.Gestion());
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
            RealizarBusqueda();
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

    }

}