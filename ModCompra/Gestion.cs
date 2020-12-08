using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra
{
    
    public class Gestion
    {


        private Administrador.Gestion _gestionAdmDoc ;


        public string Version
        {
            get
            {
                return "Ver. " + Application.ProductVersion;
            }
        }
        public string Host
        {
            get
            {
                return Sistema._Instancia + "/" + Sistema._BaseDatos;
            }
        }
        public string Usuario
        {
            get
            {
                var rt = "";
                rt = Sistema.UsuarioP.codigoUsu +
                    Environment.NewLine + Sistema.UsuarioP.nombreUsu +
                    Environment.NewLine + Sistema.UsuarioP.nombreGru;
                return rt;
            }
        }


        public Gestion()
        {
            _gestionAdmDoc = new Administrador.Gestion();
        }


        Form1 frm = null;
        public void Inicia()
        {
            if (frm == null)
            {
                frm = new Form1();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }

        public void RegistrarFacturaCompra()
        {
            frm.setVisibilidadOff();

            var gestionEntrada = new Documento.Cargar.Controlador.Gestion();
            gestionEntrada.setGestion(new Documento.Cargar.Factura.GestionFac());
            gestionEntrada.Inicia();

            frm.setVisibilidadOn();
        }

        public void AdministradorDoc()
        {
            var r00 = Sistema.MyData.Permiso_AdmDoc(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionAdmDoc.setGestion(new Administrador.Documentos.Gestion());
                _gestionAdmDoc.Inicia();
            }
            //Helpers.VisualizarDocumento.Visualizar("0000000036");
        }

    }

}