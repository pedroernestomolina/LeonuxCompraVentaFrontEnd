using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IDocumento
    {

        OOB.Resultado.FichaAuto Documento_Agregar_Factura(OOB.Documento.Agregar.Factura.Ficha ficha);

    }

}