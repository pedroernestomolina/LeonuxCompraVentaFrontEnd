using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema
{

    public class Gestion
    {


        private SucursalGrupo.Gestion _gestionSucGrupo;
        private Sucursal.Gestion _gestionSuc;
        private Deposito.Gestion _gestionDep;
        private Precio.Gestion _gestionPrecio;
        private UsuarioGrupo.Gestion _gestionUsuarioGrupo;
        private Usuario.Gestion _gestionUsuario;
        private SucursalDeposito.Gestion _gestionSucDep;
        private Servicio.Gestion _gestionServicio;


        public string Host 
        {
            get 
            {
                return "Base Dato: "+Sistema.Host; 
            }
        }

        public string Version 
        {
            get 
            {
                return "Ver. " + Application.ProductVersion; 
            }
        }


        public Gestion()
        {
            _gestionSucGrupo = new SucursalGrupo.Gestion();
            _gestionSuc = new Sucursal.Gestion();
            _gestionDep = new Deposito.Gestion();
            _gestionPrecio = new Precio.Gestion();
            _gestionUsuarioGrupo = new UsuarioGrupo.Gestion();
            _gestionUsuario = new Usuario.Gestion();
            _gestionSucDep = new SucursalDeposito.Gestion();
            _gestionServicio = new Servicio.Gestion();
        }


        public void Inicia() 
        {
            var frm = new Form1();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void MaestroSucursalGrupo()
        {
            _gestionSucGrupo.Inicia();
        }

        public void MaestroSucursales()
        {
            _gestionSuc.Inicia();
        }


        public  void MaestroDepositos()
        {
            _gestionDep.Inicia();
        }

        public void EtiquetarPrecios()
        {
            _gestionPrecio.Inicia();
        }

        public void AsignarDepositoPrincipalASucursal()
        {
            _gestionSucDep.Inicia();
        }

        public void MaestroUsuariosGrupo()
        {
            _gestionUsuarioGrupo.Inicia();
        }

        public void MaestroUsuarios()
        {
            _gestionUsuario.Inicia();
        }

        public void InicializarBD()
        {
            _gestionServicio.Inicia();
        }

    }

}