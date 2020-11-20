using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public interface IGestionItem
    {

        event EventHandler ActualizarItemHnd; 


        System.Windows.Forms.BindingSource ItemSource { get; }
        int TItems { get; }
        decimal TotalMonto { get; }
        decimal MontoIva { get; }
        decimal MontoDivisa { get; }

        string Item_Producto { get; }
        decimal Item_Importe { get; }
        decimal Item_Impuesto { get; }
        decimal Item_Total { get; }
        decimal Item_Cantidad { get; }
        decimal Item_CantidadUnd { get; }
        decimal Item_CostoMoneda { get; }
        decimal Item_CostoMonedaUnd { get; }
        decimal Item_CostoDivisa { get; }
        decimal Item_CostoDivisaUnd { get; }
        string Item_EmpaqueCont { get; }
        string Item_CodRefPrv { get; }
        decimal Item_Dscto { get; }


        void LimpiarItems();
        void EliminarItem();
        void EditarItem();
        void AgregarItem(string autoPrd, string autoPrv, decimal factorDivisa);
        void Limpiar();

    }

}