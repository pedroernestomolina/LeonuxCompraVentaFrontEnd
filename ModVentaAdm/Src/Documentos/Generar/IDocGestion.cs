using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Src.Documentos.Generar
{
    
    public interface IDocGestion
    {

        string TipoDocumento { get; }
        IDatosDocumento HabilitarDatosDoc { get; }
        decimal TasaDivisa { get; }
        AgregarEditarItem.IGestion ItemGestion { get; }
        OOB.Sistema.TipoDocumento.Entidad.Ficha SistTipoDocumento { get; }
        int CantDocPend { get; }


        void Inicializa();
        bool CargarData();

    }

}