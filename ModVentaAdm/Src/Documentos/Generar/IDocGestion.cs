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
        bool AbandonarDocIsOk { get; }
        IDatosDocumento HabilitarDatosDoc { get; }
        decimal TasaDivisa { get; }


        void Inicializa();
        bool CargarData();
        void AbandonarDoc();

    }

}