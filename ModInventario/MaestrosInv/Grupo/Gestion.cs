using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MaestrosInv.Grupo
{
    
    public class Gestion: IMaestroTipo
    {

        public Gestion(ISeguridadAccesoSistema seguridad, IAgregarEditar agregar, IAgregarEditar editar) 
        {
        }


        public void Inicializa()
        {
        }


        public string Titulo
        {
            get { throw new NotImplementedException(); }
        }

        public bool AgregarIsOk
        {
            get { throw new NotImplementedException(); }
        }

        public bool EditarIsOk
        {
            get { throw new NotImplementedException(); }
        }

        public bool EliminarIsOK
        {
            get { throw new NotImplementedException(); }
        }


        public List<data> ListaData
        {
            get { throw new NotImplementedException(); }
        }

        public bool CargarData()
        {
            throw new NotImplementedException();
        }


        public void AgregarItem()
        {
            throw new NotImplementedException();
        }

        public void EditarItem(string id)
        {
            throw new NotImplementedException();
        }

        public void EliminarItem(string id)
        {
            throw new NotImplementedException();
        }

        public data ItemAgregarEditar
        {
            get { throw new NotImplementedException(); }
        }
    }

}