using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IDocumento
    {

        OOB.ResultadoAuto Compra_DocumentoAgregarFactura(OOB.LibCompra.Documento.Cargar.Factura.Ficha docFac);
        OOB.ResultadoEntidad<OOB.LibCompra.Documento.Visualizar.Ficha> Compra_DocumentoVisualizar(string auto);
        OOB.ResultadoLista<OOB.LibCompra.Documento.Lista.Ficha> Compra_DocumentoGetLista(OOB.LibCompra.Documento.Lista.Filtro filtro);
        OOB.Resultado Compra_DocumentoAnularFactura(OOB.LibCompra.Documento.Anular.Factura.Ficha ficha);

    }

}