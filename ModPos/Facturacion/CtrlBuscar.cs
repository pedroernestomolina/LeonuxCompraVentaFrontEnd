﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion
{

    public class CtrlBuscar
    {


        public OOB.LibVenta.PosOffline.Producto.Ficha Producto { get; set; }
        public decimal Peso { get; set; }
        public decimal Precio { get; set; }
        private FormatoPreEmpaque _formato;
        private CtrlLista _listaPrd;


        public CtrlBuscar(CtrlLista listaPrd)
        {
            _listaPrd = listaPrd;
            Producto = new OOB.LibVenta.PosOffline.Producto.Ficha();
            _formato = new FormatoPreEmpaque();
            Peso = 0.0m;
            Precio = 0.0m;
        }


        private bool BusquedaPorCodigo(string codigo)
        {
            var rt = false;

            
            var r01 = Sistema.MyData2.Producto_BuscarPorCodigoBarraPlu(codigo);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return rt;
            }

            if (r01.Entidad != "")
            {
                var r02 = Sistema.MyData2.Producto(r01.Entidad);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return rt;
                }

                Producto = r02.Entidad;
                return true;
            }

            return rt;
        }

        private ResultadoPreEmpaque VerificaPreEmpaque(string codigo)
        {
            var rt = new ResultadoPreEmpaque();

            if (_formato == null)
            {
                return rt;
            };
            if (codigo.Length != _formato.Largo)
            {
                return rt;
            };
            var cb = codigo.Substring(0, _formato.LargoCabecera);
            if (cb != _formato.IdCabecera)
            {
                return rt;
            };

            var cod = codigo.Substring(_formato.LargoCabecera, _formato.LargoItemCod);
            var peso = 0.0m;
            var precio = 0.0m;
            if (_formato.IsModoPeso)
            {
                var ind = _formato.LargoCabecera + _formato.LargoItemCod;
                var xs = codigo.Substring(ind, _formato.LargoPeso);
                peso = decimal.Parse(xs) / 1000;
            }
            else
            {
                var ind = _formato.LargoCabecera + _formato.LargoItemCod;
                var xs = codigo.Substring(ind, _formato.LargoPrecio);
                precio = decimal.Parse(xs);
            }
            rt.IsPreEmpaque = true;
            rt.ItemCodigo = cod;
            rt.Peso = peso;
            rt.Precio = precio;

            return rt;
        }

        public bool ActivarBusqueda(string buscar, bool activarBusquedaPorDescripcion = true)
        {
            var rt = false;
            Producto = null;
            Peso = 0.0m;
            Precio = 0.0m;

            var codBuscar = buscar;
            var vr = VerificaPreEmpaque(buscar);
            if (vr.IsPreEmpaque)
            {
                codBuscar = vr.ItemCodigo;
                Peso = vr.Peso;
            }

            var result = BusquedaPorCodigo(codBuscar);
            if (result)
            {
                rt = true;
            }
            else
            {
                if (activarBusquedaPorDescripcion)
                {
                    _listaPrd.ListaFiltrada(buscar);
                    if (_listaPrd.IsProductoSelected )
                    {
                        var r01 = Sistema.MyData2.Producto(_listaPrd.ProductoSelected.Auto);
                        if (r01.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r01.Mensaje);
                            return false;
                        }
                        Producto = r01.Entidad;
                        return true;
                    }
                }
            }

            return rt;
        }

        public void setFormatoPreEmpaque(FormatoPreEmpaque formato)
        {
            _formato = formato;
        }
    
    }

}