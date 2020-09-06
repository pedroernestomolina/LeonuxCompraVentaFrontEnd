using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Tool.AjusteNivelMinimoMaximoProducto
{
    
    public class Gestion
    {

        private GestionLista _gestionLista;
        private BindingSource bs_Deposito;
        private List<OOB.LibInventario.Deposito.Ficha> lDeposito;
        private OOB.LibInventario.Deposito.Ficha _deposito;
        private string _autoDeposito;


        public bool IsLimpiarOk { get; set; }
        public bool IsBuscarHabilitado { get; set; }
        public bool ProcesoIsOk { get; set; }
        public bool SalirIsOk { get; set; } 
        public BindingSource _bsDeposito { get { return bs_Deposito; } }
        public BindingSource Lista { get { return _gestionLista.Source; } }
        public string AutoDeposito 
        {
            get { return _autoDeposito ; }
            set { _autoDeposito = value; }
        }
        public string Deposito 
        { 
            get 
            {
                var d = "";
                if (_deposito.auto != "") 
                {
                    d += "(" + _deposito.codigo + ") " + _deposito.nombre;
                    d += Environment.NewLine + "Asignado A Sucursal: " + "(" + _deposito.codigoSucursal + ") " + _deposito.nombreSucursal;
                }
                return d;
            } 
        }


        public Gestion()
        {
            _gestionLista = new GestionLista();
            lDeposito = new List<OOB.LibInventario.Deposito.Ficha>();
            bs_Deposito = new BindingSource();
            bs_Deposito.DataSource = lDeposito;
            _deposito = new OOB.LibInventario.Deposito.Ficha();
        }


        public void Inicia() 
        {
            IsLimpiarOk = false;
            IsBuscarHabilitado = true;
            ProcesoIsOk = false;
            SalirIsOk = false;
            if (CargarData()) 
            {
                var frm = new AjusteNivelFrm();
                frm.setControlador(this);
                frm.Show();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Deposito_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            lDeposito.Clear();
            lDeposito.AddRange(r01.Lista);

            return rt;
        }

        public void Buscar()
        {
            if (AutoDeposito == "") 
            {
                return;
            }

            var filtro= new OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Filtro();
            filtro.autoDeposito=AutoDeposito;
            var r01 = Sistema.MyData.Tools_AjusteNivelMinimoMaximo_GetLista(filtro);
            if (r01.Result== OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gestionLista.setLista(r01.Lista);

            var r02 = Sistema.MyData.Deposito_GetFicha(AutoDeposito);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }
            _deposito = r02.Entidad;
            IsBuscarHabilitado = false;
        }

        public void Limpiar()
        {
            IsLimpiarOk = false;
            var msg = MessageBox.Show("Limpiar Busqueda Actual ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                IsLimpiarOk = true;
                IsBuscarHabilitado = true;
                ProcesoIsOk = false;
                SalirIsOk = false;
                _autoDeposito = "";
                _deposito.Limpiar();
                _gestionLista.Limpiar();
            }
        }

        public void AjustarMinimoMaximo()
        {
            _gestionLista.AjustarMinimoMaximo();
        }

        public void Procesar()
        {
            ProcesoIsOk = false;

            if (_deposito.auto == "") 
            {
                return;
            }
            if (_gestionLista.Lista.Count == 0) 
            {
                return;
            }

            var msg = MessageBox.Show("Guardar Cambios Realizados ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                var list = new List<OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Ajustar.Ficha>();
                foreach (var it in _gestionLista.Lista.ToList()) 
                {
                    var nr = new OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Ajustar.Ficha()
                    {
                        autoDeposito = _deposito.auto,
                        autoProducto = it.Ficha.autoProducto,
                        nivelMinimo = it.Minimo,
                        nivelOptimo = it.Maximo,
                    };
                    list.Add(nr);
                }

                var r01 = Sistema.MyData.Tools_AjusteNivelMinimoMaximo_Ajustar(list);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                Helpers.Msg.OK("Proceso Realizado Exitosamente  Ok........");
                SalirIsOk = true;
                ProcesoIsOk = true;
                Salir();
            }
        }

        public void Salir()
        {
            if (!ProcesoIsOk)
            {
                SalirIsOk = false;
                var msg = MessageBox.Show("Abandonar Todos Los Cambios Efectuados ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    SalirIsOk = true;
                }
            }
        }

    }

}