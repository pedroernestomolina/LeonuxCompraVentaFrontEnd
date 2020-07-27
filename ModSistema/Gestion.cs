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

    }

}