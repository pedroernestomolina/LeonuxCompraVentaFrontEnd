using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros.Cobrador
{

    public class Gestion : IGestion
    {

        private GestionLista _gestionLista;


        public string MaestroTitulo { get { return "Maestro: COBRADOR"; } }


        public Gestion()
        {
        }


        public bool CargarData()
        {
            var rt = true;

            var filtro = new OOB.LibSistema.Cobrador.Lista.Filtro();
            var r01 = Sistema.MyData.Cobrador_GetLista(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _gestionLista.setLista(r01.Lista);

            return rt;
        }

        public void Inicializa()
        {
        }

        public void setLista(GestionLista gestion)
        {
            this._gestionLista = gestion;
        }

        public void AgregarFicha()
        {
        }

        public void EditarFicha(dataLista ItemActual)
        {
        }

    }

}