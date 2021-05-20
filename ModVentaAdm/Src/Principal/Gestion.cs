using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Principal
{
    
    public class Gestion
    {


        private Administrador.Gestion _gestionAdm;


        public string BD_Ruta { get { return Sistema.Instancia; } }
        public string BD_Nombre { get { return Sistema.BaseDatos; } }
        public string Version { get { return "Ver. " + Application.ProductVersion; } }
        public string Host { get { return Sistema.Instancia + "/" + Sistema.BaseDatos; } }
        public string Usuario { get { return Sistema.Usuario.codigo + Environment.NewLine + Sistema.Usuario.nombre; } }



        public Gestion()
        {
            _gestionAdm = new Administrador.Gestion();
        }


        public void Inicializa()
        {
        }

        PrincipalFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                frm = new PrincipalFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            return rt;
        }


        public void AdministradorDoc()
        {
            _gestionAdm.setGestion(new Administrador.Documentos.Gestion());
            _gestionAdm.Inicializa();
            _gestionAdm.Inicia();
        }

    }

}