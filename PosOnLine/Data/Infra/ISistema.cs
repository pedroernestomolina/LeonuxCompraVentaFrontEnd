using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface ISistema
    {

        OOB.Resultado.FichaEntidad<OOB.Sistema.Transporte.Entidad.Ficha> Sistema_Transporte_GetFichaById(string id);

        OOB.Resultado.FichaEntidad<OOB.Sistema.TipoDocumento.Entidad.Ficha> Sistema_TipoDocumento_GetFichaById(string id);

        OOB.Resultado.FichaEntidad<OOB.Sistema.SerieFiscal.Entidad.Ficha> Sistema_Serie_GetFichaById(string id);

        OOB.Resultado.Lista<OOB.Sistema.TasaFiscal.Entidad.Ficha> Sistema_Fiscal_GetTasas(OOB.Sistema.TasaFiscal.Listar.Filtro filtro);

        OOB.Resultado.FichaEntidad<OOB.Sistema.Cobrador.Entidad.Ficha> Sistema_Cobrador_GetFichaById(string id);

        OOB.Resultado.FichaEntidad<OOB.Sistema.MedioPago.Entidad.Ficha> Sistema_MedioPago_GetFichaById(string id);

    }

}