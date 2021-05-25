using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Administrador
{
    
    public interface IGestionListaDetalle
    {

        BindingSource ItemsSource { get; }
        string ItemsEncontrados { get; }


        void AnularItem();
        void LimpiarData();
        //void setGestionAnular(Anular.Gestion _gestionAnular);
        void VisualizarDocumento();
        void Imprimir();
        void CorrectorDocumento();
        void setLista(List<OOB.Documento.Lista.Ficha> list);

    }

}