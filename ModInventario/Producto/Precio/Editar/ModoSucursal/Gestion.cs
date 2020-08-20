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
            precio_1.setData(1, _costoUnd, _tasaIva, r01.Entidad.utilidad1, _p1, modoUtilidad, r01.Entidad.etiqueta1, "0000000001", _modoDivisa, tasaCambioActual);
            precio_2.setData(1, _costoUnd, _tasaIva, r01.Entidad.utilidad2, _p2, modoUtilidad, r01.Entidad.etiqueta2, "0000000001", _modoDivisa, tasaCambioActual);
            precio_3.setData(1, _costoUnd, _tasaIva, r01.Entidad.utilidad3, _p3, modoUtilidad, r01.Entidad.etiqueta3, "0000000001", _modoDivisa, tasaCambioActual);
            precio_4.setData(1, _costoUnd, _tasaIva, r01.Entidad.utilidad4, _p4, modoUtilidad, r01.Entidad.etiqueta4, "0000000001", _modoDivisa, tasaCambioActual);
            precio_5.setData(1, _costoUnd, _tasaIva, r01.Entidad.utilidad5, _p5, modoUtilidad, r01.Entidad.etiqueta5, "0000000001", _modoDivisa, tasaCambioActual);

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
        }

        public void Procesar()
        {
            var msg = "Procesar Cambios ?";
            var rt = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

    }

}