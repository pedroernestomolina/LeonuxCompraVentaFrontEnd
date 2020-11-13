using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public interface IGestionItem
    {

        System.Windows.Forms.BindingSource ItemSource { get; }
        int TItems { get; }
        decimal TotalMonto { get; }
        decimal MontoIva { get; }
        decimal MontoDivisa { get; }


        void LimpiarItems();
        void EliminarItem();
        void EditarItem();

    }

}