using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.ControlAcceso
{
    
    public class Gestion
    {


        private Cliente.Gestion _clienteGestion;
        private Proveedor.Gestion _proveedorGestion;
        private Inventario.Gestion _inventarioGestion;
        private Compra.Gestion _compraGestion;
        private Venta.Gestion _ventaGestion;
        private Sist.Gestion _sistGestion;
        private bool _isAbandonarOk;
        private bool _isActualizarOk;
        private string _codGrupo;
        private string _desGrupo;


        public bool ActualizarIsOk { get { return _isActualizarOk; } }
        public bool AbandonarIsOk { get { return _isAbandonarOk; } }
        public BindingSource ClienteSource { get { return _clienteGestion.Source; } }
        public BindingSource ProveedorSource { get { return _proveedorGestion.Source; } }
        public BindingSource InventarioSource { get { return _inventarioGestion.Source; } }
        public BindingSource CompraSource { get { return _compraGestion.Source; } }
        public BindingSource VentaSource { get { return _ventaGestion.Source; } }
        public BindingSource SistemaSource { get { return _sistGestion.Source; } }
        public string Grupo { get { return _desGrupo; } }


        public Gestion() 
        {
            _codGrupo = "";
            _desGrupo = "";
            _isAbandonarOk = false;
            _isActualizarOk = false;
            _clienteGestion = new Cliente.Gestion();
            _proveedorGestion = new Proveedor.Gestion();
            _inventarioGestion = new Inventario.Gestion();
            _compraGestion = new Compra.Gestion();
            _ventaGestion = new Venta.Gestion();
            _sistGestion = new Sist.Gestion();
        }


        ControlAccesoFrm frm;
        public void Inicia() 
        {
            if (CargarData())
            {
                if (frm==null)
                {
                    frm = new ControlAccesoFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        public void Inicializa()
        {
            _codGrupo = "";
            _desGrupo = "";
            _isAbandonarOk = false;
            _isActualizarOk = false;
            _clienteGestion.Inicializa();
            _proveedorGestion.Inicializa();
            _inventarioGestion.Inicializa();
            _compraGestion.Inicializa();
            _ventaGestion.Inicializa();
            _sistGestion.Inicializa();
        }

        public void setLista(List<OOB.LibSistema.ControlAcceso.Data.Ficha> list)
        {
            _clienteGestion.setLista(list.Where(s=>s.fCodigo.Substring(0,2)=="01").ToList());
            _proveedorGestion.setLista(list.Where(s => s.fCodigo.Substring(0, 2) == "02").ToList());
            _inventarioGestion.setLista(list.Where(s => s.fCodigo.Substring(0, 2) == "03").ToList());
            _compraGestion.setLista(list.Where(s => s.fCodigo.Substring(0, 2) == "07").ToList());
            _ventaGestion.setLista(list.Where(s => s.fCodigo.Substring(0, 2) == "08").ToList());
            _sistGestion.setLista(list.Where(s => s.fCodigo.Substring(0, 2) == "12").ToList());
        }

        public void ActualizarData()
        {
            var lCliente = _clienteGestion.ListaAcceso();
            var lProv = _proveedorGestion.ListaAcceso();
            var lInv = _inventarioGestion.ListaAcceso();
            var lCompra = _compraGestion.ListaAcceso();
            var lVenta= _ventaGestion.ListaAcceso();
            var lSist= _sistGestion.ListaAcceso();

            var msg = "Guardar Cambios ?";
            var m = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (m== DialogResult.Yes)
            {
                var ficha= new OOB.LibSistema.ControlAcceso.Actualizar.Ficha();
                foreach(var it in lCliente)
                {
                    var nr = new OOB.LibSistema.ControlAcceso.Actualizar.ItemAcceso()
                    {
                        codFuncion = it.codFuncion,
                        codGrupo = _codGrupo,
                        estatus = it.estatus ? "1" : "0",
                        seguridad = it.seguridad
                    };
                    ficha.ItemsAcceso.Add(nr);
                };
                foreach (var it in lProv)
                {
                    var nr = new OOB.LibSistema.ControlAcceso.Actualizar.ItemAcceso()
                    {
                        codFuncion = it.codFuncion,
                        codGrupo = _codGrupo,
                        estatus = it.estatus ? "1" : "0",
                        seguridad = it.seguridad
                    };
                    ficha.ItemsAcceso.Add(nr);
                };
                foreach (var it in lInv)
                {
                    var nr = new OOB.LibSistema.ControlAcceso.Actualizar.ItemAcceso()
                    {
                        codFuncion = it.codFuncion,
                        codGrupo = _codGrupo,
                        estatus = it.estatus ? "1" : "0",
                        seguridad = it.seguridad
                    };
                    ficha.ItemsAcceso.Add(nr);
                };
                foreach (var it in lCompra)
                {
                    var nr = new OOB.LibSistema.ControlAcceso.Actualizar.ItemAcceso()
                    {
                        codFuncion = it.codFuncion,
                        codGrupo = _codGrupo,
                        estatus = it.estatus ? "1" : "0",
                        seguridad = it.seguridad
                    };
                    ficha.ItemsAcceso.Add(nr);
                };
                foreach (var it in lVenta)
                {
                    var nr = new OOB.LibSistema.ControlAcceso.Actualizar.ItemAcceso()
                    {
                        codFuncion = it.codFuncion,
                        codGrupo = _codGrupo,
                        estatus = it.estatus ? "1" : "0",
                        seguridad = it.seguridad
                    };
                    ficha.ItemsAcceso.Add(nr);
                };
                foreach (var it in lSist)
                {
                    var nr = new OOB.LibSistema.ControlAcceso.Actualizar.ItemAcceso()
                    {
                        codFuncion = it.codFuncion,
                        codGrupo = _codGrupo,
                        estatus = it.estatus ? "1" : "0",
                        seguridad = it.seguridad
                    };
                    ficha.ItemsAcceso.Add(nr);
                };
                var r01 = Sistema.MyData.ControlAcceso_Actualizar(ficha);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _isActualizarOk = true;
            }
        }

        public void AbandonarCambios()
        {
            var msg = "ABANDONAR CAMBIOS EFECTUADOS ?";
            var m = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (m== DialogResult.Yes)
            {
                _isAbandonarOk = true;
            }
        }

        public void setGrupo(string id, string desc)
        {
            _codGrupo = id;
            _desGrupo = desc;
        }
    }

}