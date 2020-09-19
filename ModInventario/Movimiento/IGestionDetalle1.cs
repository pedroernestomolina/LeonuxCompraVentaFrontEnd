using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Movimiento
{
    
    public interface IGestionDetalle
    {

        System.Windows.Forms.BindingSource Souce { get; }

        void Limpiar();
        void AgregarItem(OOB.LibInventario.Producto.Data.Ficha ficha);


        string ItemsMovimiento { get; set; }
    }

}