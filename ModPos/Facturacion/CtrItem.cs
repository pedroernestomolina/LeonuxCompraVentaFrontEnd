using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion
{

    public class CtrItem
    {

        public class ProductoActual
        {
            public string Nombre { get; set; }
            public string TasaIva { get; set; }
            public decimal Iva { get; set; }
            public decimal PrecioNeto { get; set; }
            public decimal PrecioFulll { get; set; }
            public int Contenido { get; set; }


            public ProductoActual()
            {
                Limpiar();
            }

            public void setProducto(Item prd)
            {
                Nombre = prd.NombrePrd;
                PrecioNeto = prd.PrecioNeto;
                TasaIva = prd.TasaIvaDesc;
                Iva = prd.Iva;
                PrecioFulll = prd.PrecioFull;
            }

            public void Limpiar()
            {
                Nombre = "";
                TasaIva = "Ex";
                Iva = 0.0m;
                PrecioNeto = 0.0m;
                PrecioFulll = 0.0m;
                Contenido = 1;
            }

        }


        private List<Item> _items;
        private BindingList<Item> _bItems;
        private BindingSource _bs;
        private ProductoActual _prdActual;
        private bool _activarRepesaje;
        private decimal _limiteRepesajeInf;
        private decimal _limiteRepesajeSup;
        private decimal _montoDivisa;
        private decimal _dsctoGlobal;
        private decimal _cargoGlobal;


        public List<Item> Items
        {
            get
            {
                return _items;
            }
        }

        public BindingSource Source
        {
            get
            {
                return _bs;
            }
        }

        public ProductoActual PrdActual
        {
            get
            {
                return _prdActual;
            }
        }

        public decimal SubTotalNeto
        {
            get
            {
                var rt = 0.0m;
                rt = _items.Sum(s => s.TotalNeto);
                return rt;
            }
        }

        public decimal SubTotal
        {
            get
            {
                var rt = 0.0m;
                rt = _items.Sum(s => s.Total);
                return rt;
            }
        }

        public int CantItem
        {
            get
            {
                var rt = 0;
                rt = _items.Sum(s => s.CantItem);
                return rt;
            }
        }

        public int Renglones
        {
            get
            {
                return _items.Count();
            }
        }

        public decimal TotalPeso
        {
            get
            {
                var rt = 0.0m;
                rt = _items.Sum(s => s.TotalPeso);
                return rt;
            }
        }

        public decimal TotalDivisa
        {
            get
            {
                var rt = 0.0m;
                if (_montoDivisa > 0)
                {
                    rt = SubTotal / _montoDivisa;
                }
                return rt;
            }
        }

        public decimal FactorCambio
        {
            get
            {
                return _montoDivisa;
            }
        }

        public decimal DsctoGlobal
        {
            get
            {
                return _dsctoGlobal;
            }
        }

        public decimal CargoGlobal
        {
            get
            {
                return _cargoGlobal;
            }
        }

        public decimal MontoExento
        {
            get
            {
                var rt = 0.0m;
                rt = _items.Sum(s => s.MontoExento);
                return rt;
            }
        }

        public decimal MontoBase
        {
            get
            {
                var rt = 0.0m;
                rt = _items.Sum(s => s.MontoBase);
                return rt;
            }
        }

        public decimal MontoImpuesto
        {
            get
            {
                var rt = 0.0m;
                rt = _items.Sum(s => s.MontoImpuesto);
                return rt;
            }
        }

        public decimal MontoTotal
        {
            get
            {
                var rt = 0.0m;
                rt = MontoExento + MontoBase + MontoImpuesto;
                return rt;
            }
        }

        public decimal MontoDivisa
        {
            get
            {
                var rt = 0.0m;
                if (FactorCambio > 0)
                {
                    rt = MontoTotal / FactorCambio;
                }
                return rt;
            }
        }

        public decimal MontoDescuentoNeto
        {
            get
            {
                var rt = 0.0m;
                rt = _items.Sum(s => s.MontoDsctoNeto);
                return rt;
            }
        }

        public decimal MontoDescuento
        {
            get
            {
                var rt = 0.0m;
                rt = _items.Sum(s => s.MontoDscto);
                return rt;
            }
        }

        public decimal MontoVentaNeto
        {
            get
            {
                var rt = 0.0m;
                rt = MontoBase + MontoExento;
                return rt;
            }
        }

        public decimal MontoCostoVenta
        {
            get
            {
                var rt = 0.0m;
                rt = _items.Sum(s => s.CostoVenta);
                return rt;
            }
        }

        public decimal UtilidadNetaMonto
        {
            get
            {
                var rt = 0.0m;
                rt = MontoVentaNeto - MontoCostoVenta;
                return rt;
            }
        }

        public decimal UtilidadNetaPorct
        {
            get
            {
                var rt = 100.0m;
                if (MontoCostoVenta > 0)
                {
                    rt = (1 - (MontoCostoVenta / MontoVentaNeto)) * 100;
                }
                return rt;
            }
        }

        public CtrItem()
        {
            _items = new List<Item>();
            _bItems = new BindingList<Item>(_items);
            _bs = new BindingSource();
            _bs.CurrentChanged += _bs_CurrentChanged;
            _bs.DataSource = _bItems;
            _prdActual = new ProductoActual();
        }

        private void _bs_CurrentChanged(object sender, EventArgs e)
        {
            if (_bs.Current != null)
            {
                var item = (Item)_bs.Current;
                _prdActual.setProducto(item);
            }
        }

        public void RegistraItem(OOB.LibVenta.PosOffline.Producto.Ficha _prd, decimal peso)
        {
            if (!_prd.IsActivo)
            {
                Helpers.Msg.Error("PRODUCTO EN ESTADO INACTIVO, VERIFIQUE POR FAVOR... !!");
                return;
            }
            if (_prd.Precio_1.PrecioNeto <= 0.0m)
            {
                Helpers.Msg.Error("PRODUCTO NO POSEE PRECIO DE VENTA, VERIFIQUE POR FAVOR... !!");
                return;
            }

            if (_prd.IsPreEmpaque)
            {
                if (peso > 0)
                {
                    RegistraItemPreEmpaque(_prd, peso);
                }
            }
            else
            {
                if (peso == 0.0m)
                {
                    if (_prd.IsPesado)
                    {
                        RegistraItemPesado(_prd);
                    }
                    else
                    {
                        RegistraItemBarra(_prd);
                    }
                }
            }
        }

        private void RegistraItemBarra(OOB.LibVenta.PosOffline.Producto.Ficha _prd)
        {
            var nr = new Item()
            {
                AutoId = _prd.Auto,
                NombrePrd = _prd.NombrePrd,
                Cantidad = 1,
                PrecioNeto = _prd.Precio_1.PrecioNeto,
                TasaIva = _prd.TasaImpuesto,
                EsPesado = _prd.IsPesado,
                TipoIva = _prd.TipoIva,
                CostoUnd = _prd.CostoUnidad,
                CostoPromUnd = _prd.CostoPromedioUnidad,
                AutoDepartamento = _prd.AutoDepartamento,
                AutoGrupo = _prd.AutoGrupo,
                AutoSubGrupo = _prd.AutoSubGrupo,
                AutoTasa = _prd.AutoTasa,
                Categoria = _prd.Categoria,
                CodigoPrd = _prd.CodigoPrd,
                Decimales = _prd.Precio_1.Decimales,
                EmpaqueCodigo = "",
                EmpaqueDescripcion = _prd.Precio_1.DescEmpVenta,
                EmpaqueContenido = _prd.Precio_1.ContEmpVenta,
                DiasEmpaqueGarantia = _prd.DiasEmpaqueGarantia,
                TarifaPrecio = _prd.Precio_1.Id,
                PrecioSugerido = _prd.PrecioSugerido,
            };
            Insertar(nr);
        }

        private void RegistraItemPesado(OOB.LibVenta.PosOffline.Producto.Ficha _prd)
        {
            var r01 = Sistema.MyBalanza.LeerPeso();
            if (r01.IsOk == false)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            if (r01.Peso > 0)
            {
                var nr = new Item()
                {
                    AutoId = _prd.Auto,
                    NombrePrd = _prd.NombrePrd,
                    Cantidad = r01.Peso,
                    PrecioNeto = _prd.Precio_1.PrecioNeto,
                    TasaIva = _prd.TasaImpuesto,
                    EsPesado = _prd.IsPesado,
                    TipoIva = _prd.TipoIva,
                    CostoUnd = _prd.CostoUnidad,
                    CostoPromUnd = _prd.CostoPromedioUnidad,
                    AutoDepartamento = _prd.AutoDepartamento,
                    AutoGrupo = _prd.AutoGrupo,
                    AutoSubGrupo = _prd.AutoSubGrupo,
                    AutoTasa = _prd.AutoTasa,
                    Categoria = _prd.Categoria,
                    CodigoPrd = _prd.CodigoPrd,
                    Decimales = _prd.Precio_1.Decimales,
                    EmpaqueCodigo = "",
                    EmpaqueDescripcion = _prd.Precio_1.DescEmpVenta,
                    EmpaqueContenido = _prd.Precio_1.ContEmpVenta,
                    DiasEmpaqueGarantia = _prd.DiasEmpaqueGarantia,
                    TarifaPrecio = _prd.Precio_1.Id,
                    PrecioSugerido = _prd.PrecioSugerido,
                };
                Insertar(nr);
            }
        }

        private void RegistraItemPreEmpaque(OOB.LibVenta.PosOffline.Producto.Ficha _prd, decimal peso)
        {
            if (_activarRepesaje)
            {
                var r01 = Sistema.MyBalanza.LeerPeso();
                if (r01.IsOk == false)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                if (r01.Peso > 0)
                {
                    var difPorArriba = r01.Peso - peso;
                    if (difPorArriba > 0 && difPorArriba > _limiteRepesajeSup)
                    {
                        Helpers.Msg.Error("REPESAJE NO CONCUERDA CON EL PESO DE LA ETIQUETA");
                        return;
                    }
                    var difPorAbajo = r01.Peso - peso;
                    if (difPorAbajo < 0 && Math.Abs(difPorAbajo) > _limiteRepesajeInf)
                    {
                        Helpers.Msg.Error("REPESAJE NO CONCUERDA CON EL PESO DE LA ETIQUETA");
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            var nr = new Item()
            {
                AutoId = _prd.Auto,
                NombrePrd = _prd.NombrePrd,
                Cantidad = peso,
                PrecioNeto = _prd.Precio_1.PrecioNeto,
                TasaIva = _prd.TasaImpuesto,
                EsPesado = _prd.IsPesado,
                TipoIva = _prd.TipoIva,
                CostoUnd = _prd.CostoUnidad,
                CostoPromUnd = _prd.CostoPromedioUnidad,
                AutoDepartamento = _prd.AutoDepartamento,
                AutoGrupo = _prd.AutoGrupo,
                AutoSubGrupo = _prd.AutoSubGrupo,
                AutoTasa = _prd.AutoTasa,
                Categoria = _prd.Categoria,
                CodigoPrd = _prd.CodigoPrd,
                Decimales = _prd.Precio_1.Decimales,
                EmpaqueCodigo = "",
                EmpaqueDescripcion = _prd.Precio_1.DescEmpVenta,
                EmpaqueContenido = _prd.Precio_1.ContEmpVenta,
                DiasEmpaqueGarantia = _prd.DiasEmpaqueGarantia,
                TarifaPrecio = _prd.Precio_1.Id,
                PrecioSugerido = _prd.PrecioSugerido,
            };
            Insertar(nr);
        }

        private void Insertar(Item item)
        {
            var agregar = new OOB.LibVenta.PosOffline.Item.Agregar()
            {
                AutoPrd = item.AutoId,
                NombrePrd = item.NombrePrd,
                Cantidad = item.Cantidad,
                TasaImpuesto = item.TasaIva,
                PrecioNeto = item.PrecioNeto,
                EsPesado = item.EsPesado,
                TipoIva = item.TipoIva,
                CostoCompraUnd = item.CostoUnd,
                CostoPromedioUnd = item.CostoPromUnd,
                AutoDepartamento = item.AutoDepartamento,
                AutoGrupo = item.AutoGrupo,
                AutoSubGrupo = item.AutoSubGrupo,
                AutoTasaIva = item.AutoTasa,
                Categoria = item.Categoria,
                CodigoPrd = item.CodigoPrd,
                Decimales = item.Decimales,
                EmpCodigo = item.EmpaqueCodigo,
                EmpDescripcion = item.EmpaqueDescripcion,
                EmpContenido = item.EmpaqueContenido,
                DiasEmpaqueGarantia = item.DiasEmpaqueGarantia,
                Tarifa = item.TarifaPrecio,
                PrecioSugerido = item.PrecioSugerido,
            };
            var r01 = Sistema.MyData2.Item_Agregar(agregar);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            item.Id = r01.Id;
            _bItems.Insert(0, item);
            _bs.MoveFirst();
        }

        public void IncrementarItem(Item it, int cnt)
        {
            if (it != null)
            {
                if (cnt > 0)
                {
                    var act = new OOB.LibVenta.PosOffline.Item.Actualizar()
                    {
                        Id = it.Id,
                        Cantidad = (it.Cantidad + cnt),
                    };
                    var r01 = Sistema.MyData2.Item_Actualizar(act);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    it.Cantidad += cnt;
                }
            }
        }

        public void Restar(Item it)
        {
            var eliminar = false;

            if (!it.EsPesado)
            {
                if (it.Cantidad > 1)
                {
                    var act = new OOB.LibVenta.PosOffline.Item.Actualizar()
                    {
                        Id = it.Id,
                        Cantidad = it.Cantidad - 1,
                    };
                    var r01 = Sistema.MyData2.Item_Actualizar(act);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    it.Cantidad -= 1;
                }
                else
                {
                    eliminar = true;
                }
            }
            else
            {
                eliminar = true;
            }

            if (eliminar)
            {
                var r01 = Sistema.MyData2.Item_Eliminar(it.Id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _bs.Remove(it);
            }
        }

        public void Limpiar()
        {
            _dsctoGlobal = 0.0m;
            _prdActual.Limpiar();
            _bItems.Clear();
        }

        public void setRepesaje(bool activar, decimal limiteInf, decimal limiteSup)
        {
            _activarRepesaje = activar;
            _limiteRepesajeInf = limiteInf;
            _limiteRepesajeSup = limiteSup;
        }

        public void setMontoDivisa(decimal monto)
        {
            _montoDivisa = monto;
        }

        public void Multiplicar(Item it)
        {
            var frm = new MultiplicarFrm();
            frm.ShowDialog();
            IncrementarItem(it, frm.Cantidad);
        }

        public void CargarLista(List<OOB.LibVenta.PosOffline.Item.Ficha> lst)
        {
            foreach (var it in lst.OrderByDescending(o => o.Id))
            {
                var nr = new Item(it);
                _bItems.Add(nr);
            }
        }

        public void setDescuentoGlobal(decimal dct)
        {
            _dsctoGlobal = dct;
            foreach (var r in _items)
            {
                r.setDescuentoGlobal(dct);
            }
        }

        public void setCargoGlobal(decimal cargo)
        {
            _cargoGlobal = cargo;
            foreach (var r in _items)
            {
                r.setCargoGlobal(cargo);
            }
        }

        public decimal MontoBaseX(string tipoIva)
        {
            var rt = 0.0m;
            rt = _items.Where(w => w.TipoIva == tipoIva).Sum(s => s.MontoBase);
            return rt;
        }

        public decimal MontoIvaX(string tipoIva)
        {
            var rt = 0.0m;
            rt = _items.Where(w => w.TipoIva == tipoIva).Sum(s => s.MontoImpuesto);
            return rt;
        }

        public bool DejarCtaEnPendiente(Cliente.Ficha ficha)
        {
            var rt = false;

            var msg = MessageBox.Show("Dejar Cuenta En Pendiente ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var agregar = new OOB.LibVenta.PosOffline.Pendiente.DejarEnPendiente.Agregar()
                {
                    IdCliente = ficha.Id,
                    Monto = SubTotal,
                    Renglones = Renglones,
                };
                agregar.Items = _items.Select(s =>
                {
                    var nr = new OOB.LibVenta.PosOffline.Pendiente.DejarEnPendiente.AgregarItem()
                    {
                        IdItem = s.Id,
                    };
                    return nr;
                }).ToList();

                var r01 = Sistema.MyData2.Pendiente_DejarCtaEnPendiente(agregar);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }

                return true;
            }

            return rt;
        }

        public void ActivarDevolucion()
        {

            var frm = new Devolucion.DevolucionFrm(this);
            frm.ShowDialog();
        }

        public bool EliminarItem(int id)
        {
            var rt = false;

            var it = _bItems.FirstOrDefault(f => f.Id == id);
            if (it != null)
            {
                var r01 = Sistema.MyData2.Item_Eliminar(it.Id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return rt;
                }
                _bItems.Remove(it);
                rt = true;
            }

            return rt;
        }

        public bool Restar(int id)
        {
            var rt = false;

            var it = _bItems.First(f => f.Id == id);
            if (it != null)
            {
                var act = new OOB.LibVenta.PosOffline.Item.Actualizar()
                {
                    Id = it.Id,
                    Cantidad = it.Cantidad - 1,
                };
                var r01 = Sistema.MyData2.Item_Actualizar(act);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }
                rt = true;
            }

            return rt;
        }

        public bool AnularVenta()
        {
            var rt = false;

            var msg = MessageBox.Show("Anular Venta ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var r01 = Sistema.MyData2.Item_Limpiar();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return rt;
                }

                _dsctoGlobal = 0.0m;
                _prdActual.Limpiar();
                _bItems.Clear();
                rt = true;
            }

            return rt;
        }

    }

}