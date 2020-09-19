using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Busqueda
{
    
    public class Gestion
    {


        private OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda metodoBusqueda;
        private string cadenaBusq;
        private List<OOB.LibInventario.Producto.Data.Ficha> result;


        public OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda Metodo { get { return metodoBusqueda;} set { metodoBusqueda=value;} }
        public string CadenaBusqueda { get { return cadenaBusq; } set { cadenaBusq = value; } }
        public List<OOB.LibInventario.Producto.Data.Ficha> Resultado { get { return result; } }
        public bool IsOk { get; set; }


        public Gestion() 
        {
            metodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.SnDefinir;
            cadenaBusq = "";
            result = new List<OOB.LibInventario.Producto.Data.Ficha>();
        }


        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
            }
        }

        private void Limpiar()
        {
            cadenaBusq = ""; 
            metodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.SnDefinir;
            result.Clear();
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_PreferenciaBusqueda();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            switch (r01.Entidad)
            {
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorCodigo:
                    metodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Codigo;
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorNombre:
                    metodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Nombre;
                    break;
                case OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda.PorReferencia:
                    metodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Referencia;
                    break;
            }

            return rt;
        }

        public void Buscar()
        {
            IsOk = false;
            if (CadenaBusqueda.Trim() != "" && CadenaBusqueda.Trim()!="*")
            {
                RealizarBusqueda();
            }
            CadenaBusqueda = "";
        }

        private void RealizarBusqueda()
        {
            var filtro = new OOB.LibInventario.Producto.Filtro();
            filtro.cadena = CadenaBusqueda;
            filtro.MetodoBusqueda = metodoBusqueda;

            var r01 = Sistema.MyData.Producto_GetLista(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                IsOk = false;
                Helpers.Msg.Error(r01.Mensaje);
            }
            IsOk = true;
            result.Clear();
            result.AddRange(r01.Lista);
        }

    }

}