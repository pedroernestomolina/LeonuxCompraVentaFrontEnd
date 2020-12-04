using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Precio.Editar
{

    public class data
    {

        public enum enumModo { Financiero = 1, Lineal };
        public enum enumModoRedondeo { SinRedondeo = 1, Unidad, Decena };
        public enum enumPreferenciaPrecio { Neto = 1, Full };


        private enumModo modoCalculoUtilidad;
        private enumModoRedondeo modoRedondeo;
        private enumPreferenciaPrecio preferenciaPrecio;
        private decimal costoUnd;
        private decimal tasaIva;
        private decimal tasaCambioActual;
        private bool isDivisa;

        public string autoEmpaque { get; set; }
        public int contenido { get; set; }
        public string etiqueta { get; set; }
        public decimal utilidadVigente { get; set; }

        public decimal Costo
        {
            get
            {
                var rt = 0.0m;
                rt = costoUnd;
                return rt;
            }
        }

        public decimal CostoFull
        {
            get
            {
                var rt = 0.0m;
                rt = Costo + (Costo * tasaIva / 100);
                return rt;
            }
        }


        private decimal _utilidad;
        public decimal utilidad
        {
            get
            {
                return Math.Round(_utilidad, 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                _utilidad = value;
                CalculaNeto();
                CalculaFull();
            }
        }

        private void CalculaNeto()
        {
            if (modoCalculoUtilidad == enumModo.Lineal)
            {
                _neto = ((Costo * (_utilidad / 100)) + Costo);
            }
            if (modoCalculoUtilidad == enumModo.Financiero)
            {
                _neto = Costo;
                if (_utilidad >= 0 && _utilidad < 100)
                {
                    _neto = (Costo / ((100 - _utilidad) / 100));
                }
            }

            if (_neto < Costo)
            {
                _neto = 0.0m;
            }
        }

        private decimal _neto;
        public decimal neto
        {
            get
            {
                return Math.Round(_neto, 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                if (isDivisa)
                {
                    _neto = value;
                }
                else
                {
                    if (preferenciaPrecio == enumPreferenciaPrecio.Neto)
                    {
                        switch (modoRedondeo)
                        {
                            case enumModoRedondeo.SinRedondeo:
                                _neto = value;
                                break;
                            case enumModoRedondeo.Unidad:
                                _neto = Helpers.MetodosExtension.RoundUnidad((int)value);
                                break;
                            case enumModoRedondeo.Decena:
                                _neto = Helpers.MetodosExtension.RoundDecena((int)value);
                                break;
                        }
                    }
                    else
                        _neto = value;
                }
                CalculaFull();
                CalculaUtilidad();
            }
        }

        private void CalculaUtilidad()
        {
            if (modoCalculoUtilidad == enumModo.Lineal)
            {
                _utilidad = 0.0m;
                if (_neto > Costo)
                {
                    _utilidad = (((_neto / Costo) - 1) * 100);
                }
            }
            if (modoCalculoUtilidad == enumModo.Financiero)
            {
                _utilidad = 0.0m;
                if (_neto > Costo)
                {
                    _utilidad = ((1 - (Costo / _neto)) * 100);
                }
            }
        }

        private void CalculaFull()
        {
            _full = ((_neto * tasaIva / 100) + _neto);
        }

        private decimal _full;
        public decimal full
        {
            get
            {
                return Math.Round(_full, 2, MidpointRounding.AwayFromZero);
            }
            set
            {
                if (isDivisa)
                {
                    _full = value;
                }
                else
                {
                    if (preferenciaPrecio == enumPreferenciaPrecio.Full)
                    {
                        switch (modoRedondeo)
                        {
                            case enumModoRedondeo.SinRedondeo:
                                _full = value;
                                break;
                            case enumModoRedondeo.Unidad:
                                _full = Helpers.MetodosExtension.RoundUnidad((int)value);
                                break;
                            case enumModoRedondeo.Decena:
                                _full = Helpers.MetodosExtension.RoundDecena((int)value);
                                break;
                        }
                    }
                    else
                        _full= value;
                }
                _neto = (_full / ((tasaIva / 100) + 1));
                CalculaUtilidad();
            }
        }

        public decimal costo2
        {
            get
            {
                var rt = 0.0m;
                if (isDivisa)
                {
                    rt = Costo * tasaCambioActual;
                }
                else
                {
                    rt = Costo / tasaCambioActual;
                }
                return rt;
            }
        }

        public decimal neto2
        {
            get
            {
                var rt = 0.0m;
                if (isDivisa)
                {
                    rt = neto * tasaCambioActual;
                }
                else
                {
                    rt = neto / tasaCambioActual;
                }
                return rt;
            }
        }
        public decimal full2
        {
            get
            {
                var rt = 0.0m;
                if (isDivisa)
                {
                    rt = full * tasaCambioActual;
                }
                else
                {
                    rt = full / tasaCambioActual;
                }
                return rt;
            }
        }

        public decimal PrecioNeto_BsF
        {
            get
            {
                var rt = 0.0m;
                if (isDivisa)
                {
                    rt = neto * tasaCambioActual;
                }
                else
                {
                    rt = neto;
                }

                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }

        public decimal PrecioNeto_Divisa
        {
            get
            {
                var rt = 0.0m;
                if (isDivisa)
                {
                    rt = neto;
                }
                else
                {
                    rt = neto / tasaCambioActual;
                }

                return rt;
            }
        }

        public decimal PrecioFull_Divisa
        {
            get
            {
                var rt = 0.0m;
                rt = PrecioNeto_Divisa + (PrecioNeto_Divisa * tasaIva / 100);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }


        public void setCalculoUtilidad(enumModo modo)
        {
            modoCalculoUtilidad = modo;
        }

        public void setData(int cont, decimal costo, decimal iva, decimal ut, decimal precio, enumModo enumModo, string etq, string autoEmp, bool modoDivisa, decimal tasaCambio, enumModoRedondeo redondeo, enumPreferenciaPrecio prefPrec)
        {
            autoEmpaque = autoEmp;
            etiqueta = etq;
            contenido = cont;
            costoUnd = costo;
            tasaIva = iva;
            modoCalculoUtilidad = enumModo;
            tasaCambioActual = tasaCambio;
            isDivisa = modoDivisa;
            utilidadVigente = ut;
            modoRedondeo = redondeo;
            preferenciaPrecio = prefPrec;

            _utilidad = ut;
            if (ut == 0.0m)
                return;

            if (modoDivisa)
            {
                _full = precio;
                if (Costo==0.0m)
                    _neto= _full/ ((tasaIva /100)+1);
                else
                    CalculaNeto();
                CalculaFull();
            }
            else
            {
                _neto = precio;
                CalculaFull();
                if (Costo!=0.0m)
                    CalculaNeto();
            }
        }

        public void sw()
        {
            costoUnd = costo2;
            neto = neto2;
            CalculaUtilidad();
            CalculaFull();
            isDivisa = !isDivisa;
        }

        public void Limpiar() 
        {
            _utilidad = 0.0m;
            _neto = 0.0m;
            _full = 0.0m;
            autoEmpaque = "";
            etiqueta = "";
            contenido = 1;
            costoUnd = 0.0m;
            tasaIva = 0.0m;
            modoCalculoUtilidad = enumModo.Lineal;
            tasaCambioActual = 0.0m;
            isDivisa = false;
            utilidadVigente = 0.0m;
            modoRedondeo = enumModoRedondeo.SinRedondeo;
            preferenciaPrecio = enumPreferenciaPrecio.Neto;
        }

    }

}