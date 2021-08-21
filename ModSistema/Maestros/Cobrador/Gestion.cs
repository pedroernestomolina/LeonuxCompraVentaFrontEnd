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
        private AgregarEditar _agregarEditar;


        public string MaestroTitulo { get { return "Maestro: COBRADOR"; } }
        public Enumerados.Maestro GridVisualizarIs { get { return Enumerados.Maestro.COBRADOR; } }


        public Gestion() 
        {
            _agregarEditar = new AgregarEditar();
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
            _agregarEditar.setGestion(new Agregar.Gestion());
            _agregarEditar.Inicializa();
            _agregarEditar.Inicia();
            if (_agregarEditar.ProcesarIsOk) 
            {
                var r01 = Sistema.MyData.Cobrador_GetFicha_ById(_agregarEditar.AutoFichaNueva);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _gestionLista.AgregarItem(r01.Entidad);
            }
        }

        public void EditarFicha(dataLista ItemActual)
        {
            _agregarEditar.setGestion(new Editar.Gestion());
            _agregarEditar.Inicializa();
            _agregarEditar.setFichaEditar(ItemActual.id);
            _agregarEditar.Inicia();
            if (_agregarEditar.ProcesarIsOk)
            {
                var r01 = Sistema.MyData.Cobrador_GetFicha_ById(ItemActual.id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _gestionLista.ActualizarItem(r01.Entidad);
            }
        }

        public void CambiarEstatus(Estatus.Gestion gestion, string idFicha)
        {
            Helpers.Msg.Alerta("FUNCION NO IMPLEMENTADA");
            return;
        }

    }

}