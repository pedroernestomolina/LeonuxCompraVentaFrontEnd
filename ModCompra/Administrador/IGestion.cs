using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Administrador
{
    
    public interface IGestion
    {

        enumerados.EnumTipoAdministrador TipoAdministrador { get; }
        string Titulo { get; }
        BindingSource Source { get; }
        string Items { get; }
        DateTime? Filtro_Desde { get; set; }
        DateTime? Filtro_Hasta { get; set; }
        string Filtro_TipoDoc { get; set; }
        string Filtro_Sucursal { get; set; }
        BindingSource SucursalSource { get; }


        void Inicia();
        void Buscar();
        void AnularItem();
        void LimpiarFiltros();
        void LimpiarData();
        void VisualizarDocumento();
        void Imprimir();

    }

}