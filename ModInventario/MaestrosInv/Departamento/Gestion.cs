using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MaestrosInv.Departamento
{
    
    public class Gestion: IMaestroTipo
    {

        private bool _eliminarIsOk;
        private List<data> _list;
        private ISeguridadAccesoSistema _gSeguridad;
        private IAgregarEditar _gAgregar;
        private IAgregarEditar _gEditar;
        private data _itemAgregarEditar;


        public string Titulo { get { return "MAESTRO: DEPARTAMENTOS"; } }
        public bool AgregarIsOk { get { return _gAgregar.IsOk; } }
        public bool EditarIsOk { get { return _gEditar.IsOk; } }
        public bool EliminarIsOk { get { return _eliminarIsOk; } }
        public List<data> ListData { get { return _list; } }
        public data ItemAgregarEditar { get { return _itemAgregarEditar; } }


        public Gestion (ISeguridadAccesoSistema seguridad, IAgregarEditar agregar, IAgregarEditar editar) 
        {
            _gSeguridad = seguridad;
            _gAgregar = agregar;
            _gEditar = editar;

            _itemAgregarEditar = null;
            _eliminarIsOk = false;
            _list = new List<data>();
        }


        public bool CargarData()
        {
            var r01 = Sistema.MyData.Departamento_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _list.Clear();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
            {
                _list.Add(new data(rg.auto, rg.codigo, rg.nombre));
            }

            return true;
        }

        public void AgregarItem()
        {
            var r00 = Sistema.MyData.Permiso_CrearDepartamento(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_gSeguridad.Verificar(r00.Entidad))
            {
                _gAgregar.Inicializa();
                _gAgregar.Inicia();
                if (_gAgregar.IsOk)
                {
                    var r01 = Sistema.MyData.Departamento_GetFicha(_gAgregar.ItemAgregarId);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _itemAgregarEditar = new data(r01.Entidad.auto, r01.Entidad.codigo, r01.Entidad.nombre);
                }
            }
        }

        public void EditarItem(data ItemActual)
        {
            var r00 = Sistema.MyData.Permiso_ModificarDepartamento(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_gSeguridad.Verificar(r00.Entidad))
            {
                var idEditar = ItemActual.auto;
                _gEditar.Inicializa();
                _gEditar.setItemEditar(idEditar);
                _gEditar.Inicia();
                if (_gEditar.IsOk)
                {
                    var r01 = Sistema.MyData.Departamento_GetFicha(idEditar);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _itemAgregarEditar = new data(r01.Entidad.auto, r01.Entidad.codigo, r01.Entidad.nombre);
                }
            }
        }

        public void EliminarItem(data ItemActual)
        {
            _eliminarIsOk = false;
            var r00 = Sistema.MyData.Permiso_EliminarDepartamento(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_gSeguridad.Verificar(r00.Entidad))
            {
                var msg = MessageBox.Show("Eliminar Item Actual ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var r01 = Sistema.MyData.Departamento_Eliminar(ItemActual.auto);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _eliminarIsOk = true;
                    Helpers.Msg.EliminarOk();
                }
            }
        }

        public void Inicializa()
        {
            _itemAgregarEditar = null;
            _eliminarIsOk = false;
            _list.Clear();
        }

    }

}