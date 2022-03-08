using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MaestrosInv.Departamento.Agregar
{
    
    public class Gestion: IAgregarEditar
    {

        public bool ProcesarIsOk { get { throw new NotImplementedException(); } }
        public bool AbandonarIsOk { get { throw new NotImplementedException(); } }
        public string Codigo { get { return ""; } }
        public string Nombre { get { return ""; } }


        public Gestion() 
        {
        }


        public void Inicializa()
        {
        }

        AgregarEditarFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new AgregarEditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }


        public void Procesar()
        {
        }

        public void Abandonar()
        {
        }

        public void setCodigo(string p)
        {
        }

        public void setNombre(string p)
        {
        }

    }

}