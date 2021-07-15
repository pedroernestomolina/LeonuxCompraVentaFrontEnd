using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.ExportarData.Cliente
{
    
    public interface IExportar
    {

        void Inicializa();
        void setLista(List<OOB.LibVenta.PosOffline.Cliente.ExportarData.Ficha> list);
        void Inicia();

    }

}