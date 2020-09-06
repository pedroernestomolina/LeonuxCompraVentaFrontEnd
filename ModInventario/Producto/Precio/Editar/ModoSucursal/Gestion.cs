using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.Editar.ModoSucursal
{

    public class Gestion: IGestion
    {

        private string autoPrd;
        private string producto;
        private string costoUnit;
        private string admDivisa;
        private string tasaIva;
        private data.enumModo modoUtilidad;
        private decimal tasaCambioActual;
        private string fechaUltActCosto;
        private bool isModoActualDivisa;
        private decimal costoUnd;
        private decimal costoUndDivisa;
        private bool _isCerrarHabilitado;
        private OOB.LibInventario.Precio.PrecioCosto.Ficha fichaPrecioCosto; 

        private List<OOB.LibInventario.EmpaqueMedida.Ficha> empaque1;
        private List<OOB.LibInventario.EmpaqueMedida.Ficha> empaque2;
        private List<OOB.LibInventario.EmpaqueMedida.Ficha> empaque3;
        private List<OOB.LibInventario.EmpaqueMedida.Ficha> empaque4;
        private List<OOB.LibInventario.EmpaqueMedida.Ficha> empaque5;
        private BindingSource sourceEmpaque1;
        private BindingSource sourceEmpaque2;
        private BindingSource sourceEmpaque3;
        private BindingSource sourceEmpaque4;
        private BindingSource sourceEmpaque5;
        private data precio_1;
        private data precio_2;
        private data precio_3;
        private data precio_4;
        private data precio_5;


        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque1 { get { return empaque1; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque2 { get { return empaque2; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque3 { get { return empaque3; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque4 { get { return empaque4; } }
        public List<OOB.LibInventario.EmpaqueMedida.Ficha> Empaque5 { get { return empaque5; } }
        public BindingSource SourceEmpaque1 { get { return sourceEmpaque1; } }
        public BindingSource SourceEmpaque2 { get { return sourceEmpaque2; } }
        public BindingSource SourceEmpaque3 { get { return sourceEmpaque3; } }
        public BindingSource SourceEmpaque4 { get { return sourceEmpaque4; } }
        public BindingSource SourceEmpaque5 { get { return sourceEmpaque5; } }

        public bool IsCerrarHabilitado { get { return _isCerrarHabilitado; } }
        public data Precio_1 { get { return precio_1; } }
        public data Precio_2 { get { return precio_2; } }
        public data Precio_3 { get { return precio_3; } }
        public data Precio_4 { get { return precio_4; } }
        public data Precio_5 { get { return precio_5; } }

        public string Producto
        {
            get { return producto; }
        }

        public string CostoUnitario
        {
            get { return costoUnit; }
        }

        public string AdmDivisa
        {
            get { return admDivisa; }
        }

        public string TasaIva
        {
            get { return tasaIva; }
        }

        public string TasaCambioActual
        {
            get { return tasaCambioActual.ToString("n2"); }
        }

        public string MetodoCalculoUtilidad
        {
            get { return modoUtilidad.ToString(); }
        }

        public string FechaUltActCosto
        {
            get { return fechaUltActCosto; }
        }

        public bool Habilitar_ContenidoEmpaque
        {
            get { return false; }
        }

        public bool Habilitar_Empaque
        {
            get { return false; }
        }


        public Gestion()
        {
            _isCerrarHabilitado = true;
            empaque1 = new List<OOB.LibInventario.EmpaqueMedida.Ficha>();
            empaque2 = new List<OOB.LibInventario.EmpaqueMedida.Ficha>();
            empaque3 = new List<OOB.LibInventario.EmpaqueMedida.Ficha>();
            empaque4 = new List<OOB.LibInventario.EmpaqueMedida.Ficha>();
            empaque5 = new List<OOB.LibInventario.EmpaqueMedida.Ficha>();
            sourceEmpaque1 = new BindingSource();
            sourceEmpaque2 = new BindingSource();
            sourceEmpaque3 = new BindingSource();
            sourceEmpaque4 = new BindingSource();
            sourceEmpaque5 = new BindingSource();
            sourceEmpaque1.DataSource = empaque1;
            sourceEmpaque2.DataSource = empaque2;
            sourceEmpaque3.DataSource = empaque3;
            sourceEmpaque4.DataSource = empaque4;
            sourceEmpaque5.DataSource = empaque5;

            precio_1 = new data();
            precio_2 = new data();
            precio_3 = new data();
            precio_4 = new data();
            precio_5 = new data();
        }


        public bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.PrecioCosto_GetFicha(autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            fichaPrecioCosto = r01.Entidad;

            var r02 = Sistema.MyData.EmpaqueMedida_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            var r03 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }

            var r04 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }

            var r05 = Sistema.MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }

            var r06 = Sistema.MyData.Configuracion_PreferenciaRegistroPrecio();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }

            //PREFERENCIA PRECIO
            var preferenciaPrecio = data.enumPreferenciaPrecio.Neto;
            if (r06.Entidad == OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Full) 
            {
                preferenciaPrecio = data.enumPreferenciaPrecio.Full;
            }

            //REDONDEO
            var redondeo = data.enumModoRedondeo.SinRedondeo;
            switch (r05.Entidad)
            {
                case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Unidad:
                    redondeo= data.enumModoRedondeo.Unidad;
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Decena:
                    redondeo= data.enumModoRedondeo.Decena;
                    break;
            }

            //TASA CAMBIO ACTUAL
            tasaCambioActual = r03.Entidad;

            //UTILIDAD METODO
            modoUtilidad = data.enumModo.Lineal;
            if (r04.Entidad == OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Financiero) 
            {
                modoUtilidad = data.enumModo.Financiero;
            }

            //FICHA PRODUCTO
            producto = r01.Entidad.codigo + Environment.NewLine + r01.Entidad.descripcion;
            admDivisa = r01.Entidad.admDivisa.ToString();
            tasaIva = "EXENTO";
            fechaUltActCosto = r01.Entidad.fechaUltimaActCosto;
            costoUnd = r01.Entidad.costoUnd;
            costoUndDivisa = r01.Entidad.costoUndDivisa;

            if (r01.Entidad.tasaIva > 0)
            {
                tasaIva = r01.Entidad.tasaIva.ToString("n2").Trim().PadLeft(5, '0') + "%";
            }

            var _modoDivisa = false;
            var _costoUnd = r01.Entidad.costoUnd;
            var _p1 = r01.Entidad.precioNeto1;
            var _p2=r01.Entidad.precioNeto2;
            var _p3=r01.Entidad.precioNeto3;
            var _p4=r01.Entidad.precioNeto4;
            var _p5=r01.Entidad.precioNeto5;
            costoUnit = r01.Entidad.costoUnd.ToString("N2");
            if (r01.Entidad.admDivisa == OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa.Si)
            {
                isModoActualDivisa = true;
                _p1 = r01.Entidad.precioFullDivisa1;
                _p2 = r01.Entidad.precioFullDivisa2;
                _p3 = r01.Entidad.precioFullDivisa3;
                _p4 = r01.Entidad.precioFullDivisa4;
                _p5 = r01.Entidad.precioFullDivisa5;
                _modoDivisa = true;
                _costoUnd = r01.Entidad.costoUndDivisa;
                costoUnit = r01.Entidad.costoUndDivisa.ToString("N2");
            }
            var _tasaIva = r01.Entidad.tasaIva;
            precio_1.setData(1, _costoUnd, _tasaIva, r01.Entidad.utilidad1, _p1, modoUtilidad, r01.Entidad.etiqueta1, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio);
            precio_2.setData(1, _costoUnd, _tasaIva, r01.Entidad.utilidad2, _p2, modoUtilidad, r01.Entidad.etiqueta2, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio);
            precio_3.setData(1, _costoUnd, _tasaIva, r01.Entidad.utilidad3, _p3, modoUtilidad, r01.Entidad.etiqueta3, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio);
            precio_4.setData(1, _costoUnd, _tasaIva, r01.Entidad.utilidad4, _p4, modoUtilidad, r01.Entidad.etiqueta4, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio);
            precio_5.setData(1, _costoUnd, _tasaIva, r01.Entidad.utilidad5, _p5, modoUtilidad, r01.Entidad.etiqueta5, "0000000001", _modoDivisa, tasaCambioActual, redondeo, preferenciaPrecio);

            //empaques
            empaque1.Clear();
            empaque1.AddRange(r02.Lista);
            sourceEmpaque1.CurrencyManager.Refresh();

            empaque2.Clear();
            empaque2.AddRange(r02.Lista);
            sourceEmpaque2.CurrencyManager.Refresh();

            empaque3.Clear();
            empaque3.AddRange(r02.Lista);
            sourceEmpaque3.CurrencyManager.Refresh();

            empaque4.Clear();
            empaque4.AddRange(r02.Lista);
            sourceEmpaque4.CurrencyManager.Refresh();

            empaque5.Clear();
            empaque5.AddRange(r02.Lista);
            sourceEmpaque5.CurrencyManager.Refresh();

            return rt;
        }

        public void setFicha(string autoprd)
        {
            autoPrd = autoprd;
        }

        public void ModoPrecioSw()
        {
            var msg = "Cambiar a Modo BCV (BsF) ?";
            if (!isModoActualDivisa) 
            {
                msg = "Cambiar a Modo DIVISA ($) ?";
            }
            var rt = MessageBox.Show(msg,"*** ALERTA ***",  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rt == DialogResult.Yes)
            {
                isModoActualDivisa = !isModoActualDivisa;
                precio_1.sw();
                precio_2.sw();
                precio_3.sw();
                precio_4.sw();
                precio_5.sw();
            }
            costoUnit=costoUnd.ToString("n2");
            if (isModoActualDivisa)
            { 
                costoUnit=costoUndDivisa.ToString("n2");
            };
        }

        public void Procesar()
        {
            var msg = "Procesar Cambios ?";
            var rt = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rt == DialogResult.Yes)
            {
                _isCerrarHabilitado = Guardar();
            }
            else 
            {
                _isCerrarHabilitado = false;
            }
        }

        private bool Guardar()
        {
            var rt = true;
            var ficha = new OOB.LibInventario.Precio.Editar.Ficha()
            {
                autoProducto = autoPrd,
                autoUsuario = Sistema.UsuarioP.auto,
                codigoUsuario = Sistema.UsuarioP.codigo,
                estacion = Environment.MachineName,
                nombreUsuario = Sistema.UsuarioP.nombre,
            };

            var p1 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = precio_1.autoEmpaque,
                contenido = precio_1.contenido,
                precio_divisa_Neto = precio_1.PrecioFull_Divisa,
                precioNeto = precio_1.PrecioNeto_BsF,
                utilidad = precio_1.utilidad,
            };
            ficha.precio_1= p1;
            var h1 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = precio_1.PrecioNeto_BsF,
                precio_id = "1",
            };

            var p2 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = precio_2.autoEmpaque,
                contenido = precio_2.contenido,
                precio_divisa_Neto = precio_2.PrecioFull_Divisa,
                precioNeto = precio_2.PrecioNeto_BsF,
                utilidad = precio_2.utilidad,
            };
            ficha.precio_2 = p2;
            var h2 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = precio_2.PrecioNeto_BsF,
                precio_id = "2",
            };

            var p3 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = precio_3.autoEmpaque,
                contenido = precio_3.contenido,
                precio_divisa_Neto = precio_3.PrecioFull_Divisa,
                precioNeto = precio_3.PrecioNeto_BsF,
                utilidad = precio_3.utilidad,
            };
            ficha.precio_3 = p3;
            var h3 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = precio_3.PrecioNeto_BsF,
                precio_id = "3",
            };

            var p4 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = precio_4.autoEmpaque,
                contenido = precio_4.contenido,
                precio_divisa_Neto = precio_4.PrecioFull_Divisa,
                precioNeto = precio_4.PrecioNeto_BsF,
                utilidad = precio_4.utilidad,
            };
            ficha.precio_4 = p4;
            var h4 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = precio_4.PrecioNeto_BsF,
                precio_id = "4",
            };

            var p5 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            {
                autoEmp = precio_5.autoEmpaque,
                contenido = precio_5.contenido,
                precio_divisa_Neto = precio_5.PrecioFull_Divisa,
                precioNeto = precio_5.PrecioNeto_BsF,
                utilidad = precio_5.utilidad,
            };
            ficha.precio_5 = p5;
            var h5 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            {
                nota = "",
                precio = precio_5.PrecioNeto_BsF,
                precio_id = "PTO",
            };

            var historia = new List<OOB.LibInventario.Precio.Editar.FichaHistorica>();
            if (VerificaCambio(precio_1,1)) { historia.Add(h1); }
            if (VerificaCambio(precio_2,2)) { historia.Add(h2); }
            if (VerificaCambio(precio_3,3)) { historia.Add(h3); }
            if (VerificaCambio(precio_4,4)) { historia.Add(h4); }
            if (VerificaCambio(precio_5,5)) { historia.Add(h5); }
            ficha.historia = historia;

            var r01 = Sistema.MyData.PrecioProducto_Actualizar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            return rt;
        }

        private bool VerificaCambio(data precio, int p)
        {
            var rt = false;

            if (p == 1) 
            {
                if (precio.autoEmpaque != fichaPrecioCosto.autoEmp1) { return true; }
                if (precio.contenido != fichaPrecioCosto.contenido1) { return true; }
                if (precio.PrecioNeto_BsF != fichaPrecioCosto.precioNeto1) { return true; }
                if (precio.utilidad != fichaPrecioCosto.utilidad1) { return true; }
            }
            if (p == 2)
            {
                if (precio.autoEmpaque != fichaPrecioCosto.autoEmp2) { return true; }
                if (precio.contenido != fichaPrecioCosto.contenido2) { return true; }
                if (precio.PrecioNeto_BsF != fichaPrecioCosto.precioNeto2) { return true; }
                if (precio.utilidad != fichaPrecioCosto.utilidad2) { return true; }
            }
            if (p == 3)
            {
                if (precio.autoEmpaque != fichaPrecioCosto.autoEmp3) { return true; }
                if (precio.contenido != fichaPrecioCosto.contenido3) { return true; }
                if (precio.PrecioNeto_BsF != fichaPrecioCosto.precioNeto3) { return true; }
                if (precio.utilidad != fichaPrecioCosto.utilidad3) { return true; }
            }
            if (p == 4)
            {
                if (precio.autoEmpaque != fichaPrecioCosto.autoEmp4) { return true; }
                if (precio.contenido != fichaPrecioCosto.contenido4) { return true; }
                if (precio.PrecioNeto_BsF != fichaPrecioCosto.precioNeto4) { return true; }
                if (precio.utilidad != fichaPrecioCosto.utilidad4) { return true; }
            }
            if (p == 5)
            {
                if (precio.autoEmpaque != fichaPrecioCosto.autoEmp5) { return true; }
                if (precio.contenido != fichaPrecioCosto.contenido5) { return true; }
                if (precio.PrecioNeto_BsF != fichaPrecioCosto.precioNeto5) { return true; }
                if (precio.utilidad != fichaPrecioCosto.utilidad5) { return true; }
            }

            return rt;
        }

        public void InicializarIsCerrarHabilitado()
        {
            _isCerrarHabilitado = true;
        }

        public void Limpiar()
        {
            precio_1.Limpiar();
            precio_2.Limpiar();
            precio_3.Limpiar();
            precio_4.Limpiar();
            precio_5.Limpiar();

            producto="";
            costoUnit="";
            admDivisa="";
            tasaIva="";

        //private data.enumModo modoUtilidad;
        //private decimal tasaCambioActual;
        //private string fechaUltActCosto;
        //private bool isModoActualDivisa;
        //private decimal costoUnd;
        //private decimal costoUndDivisa;
        //private bool _isCerrarHabilitado;
        //private OOB.LibInventario.Precio.PrecioCosto.Ficha fichaPrecioCosto; 

        }

    }

}