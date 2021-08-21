using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface ISerieFiscal
    {

        OOB.ResultadoLista<OOB.LibSistema.SerieFiscal.Entidad.Ficha> SerieFiscal_GetLista(OOB.LibSistema.SerieFiscal.Lista.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibSistema.SerieFiscal.Entidad.Ficha> SerieFiscal_GetFicha_ById(string id);
        OOB.ResultadoAuto SerieFiscal_AgregarFicha(OOB.LibSistema.SerieFiscal.Agregar.Ficha ficha);
        OOB.Resultado SerieFiscal_EditarFicha(OOB.LibSistema.SerieFiscal.Editar.Ficha ficha);
        OOB.Resultado SerieFiscal_ActivarFicha(OOB.LibSistema.SerieFiscal.ActivarInactivar.Ficha ficha);
        OOB.Resultado SerieFiscal_InactivarFicha(OOB.LibSistema.SerieFiscal.ActivarInactivar.Ficha ficha);

    }

}