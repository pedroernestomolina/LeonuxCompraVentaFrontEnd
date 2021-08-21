using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros.SerieFiscal
{
    
    public class Gestion: IGestion
    {

        private GestionLista _gestionLista;
        private AgregarEditar _agregarEditar;


        public string MaestroTitulo { get { return "Maestro: SERIES FISCAL"; } }
        public Enumerados.Maestro GridVisualizarIs { get { return Enumerados.Maestro.SERIEFISCAL; } }


        public Gestion() 
        {
            _agregarEditar = new AgregarEditar();
        }


        public bool CargarData()
        {
            var rt = true;

            var filtro = new OOB.LibSistema.SerieFiscal.Lista.Filtro();
            var r01 = Sistema.MyData.SerieFiscal_GetLista(filtro);
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
                var r01 = Sistema.MyData.SerieFiscal_GetFicha_ById(_agregarEditar.AutoFichaNueva);
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
                var r01 = Sistema.MyData.SerieFiscal_GetFicha_ById(ItemActual.id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _gestionLista.ActualizarItem(r01.Entidad);
            }
        }

        public void CambiarEstatus(Maestros.Estatus.Gestion gestion, string idFicha)
        {
            var r00 = Sistema.MyData.Permiso_ControlSerieFiscal_ActivarInactivar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                gestion.setGestion(new Maestros.SerieFiscal.Estatus.Gestion());
                gestion.Inicializa();
                gestion.setFicha(idFicha);
                gestion.Inicia();
                if (gestion.CambioEstatusIsOk)
                {
                    var r01 = Sistema.MyData.SerieFiscal_GetFicha_ById (idFicha);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _gestionLista.ActualizarItem(r01.Entidad);
                }
            }
        }

    }

}