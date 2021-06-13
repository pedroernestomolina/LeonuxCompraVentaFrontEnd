using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Infra
{
    
    public interface ICliente
    {

        OOB.Resultado.FichaEntidad<OOB.Maestro.Cliente.Entidad.Ficha> Cliente_GetFicha(string autoCliente);
        OOB.Resultado.Lista<OOB.Maestro.Cliente.Entidad.Ficha> Cliente_GetLista(OOB.Maestro.Cliente.Lista.Filtro filtro);
        OOB.Resultado.Lista<OOB.Maestro.Cliente.Documento.Ficha> Cliente_Documentos_GetLista(OOB.Maestro.Cliente.Documento.Filtro filtro);
        OOB.Resultado.Lista<OOB.Maestro.Cliente.Articulos.Ficha> Cliente_ArticulosVenta_GetLista(OOB.Maestro.Cliente.Articulos.Filtro filtro);

    }

}