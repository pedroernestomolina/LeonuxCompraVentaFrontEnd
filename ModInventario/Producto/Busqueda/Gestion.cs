using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Producto.Busqueda
{
    
    public class Gestion
    {


        private OOB.LibInventario.Producto.Filtro filtros;
        private OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda metodoBusqueda;
        private string cadenaBusq;
        private List<OOB.LibInventario.Producto.Data.Ficha> result;


        public OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda Metodo { get { return metodoBusqueda;} set { metodoBusqueda=value;} }
        public string CadenaBusqueda { get { return cadenaBusq; } set { cadenaBusq = value; } }
        public List<OOB.LibInventario.Producto.Data.Ficha> Resultado { get { return result; } }
        public bool IsOk { get; set; }


        public Gestion() 
        {
            filtros = new OOB.LibInventario.Producto.Filtro();
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
            filtros.Limpiar();
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
            filtros.cadena = CadenaBusqueda;
            filtros.MetodoBusqueda = metodoBusqueda;
            if (filtros.BusquedaOk)
                RealizarBusqueda();
            CadenaBusqueda = "";
            filtros.Limpiar();
        }

        private void RealizarBusqueda()
        {
            var r01 = Sistema.MyData.Producto_GetLista(filtros);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                IsOk = false;
                Helpers.Msg.Error(r01.Mensaje);
            }
            IsOk = true;
            result.Clear();
            result.AddRange(r01.Lista);
        }

        private void CargarFiltros(ModInventario.Buscar.Filtrar.data data)
        {
            filtros.autoProveedor = data.AutoProveedor;
            filtros.autoDepartamento = data.AutoDepartamento;
            filtros.autoGrupo = data.AutoGrupo;
            filtros.autoTasa = data.AutoTasa;
            filtros.autoMarca = data.AutoMarca;
            filtros.autoDeposito = data.AutoDeposito;
            if (data.IdOrigen != "")
            {
                filtros.origen = (OOB.LibInventario.Producto.Enumerados.EnumOrigen)int.Parse(data.IdOrigen);
            }
            if (data.IdCategoria != "")
            {
                filtros.categoria = (OOB.LibInventario.Producto.Enumerados.EnumCategoria)int.Parse(data.IdCategoria);
            }
            if (data.IdEstatus != "")
            {
                filtros.estatus = (OOB.LibInventario.Producto.Enumerados.EnumEstatus)int.Parse(data.IdEstatus);
            }
            if (data.IdAdmDivisa != "")
            {
                filtros.admPorDivisa = (OOB.LibInventario.Producto.Enumerados.EnumAdministradorPorDivisa)int.Parse(data.IdAdmDivisa);
            }
            if (data.IdPesado != "")
            {
                filtros.pesado = (OOB.LibInventario.Producto.Enumerados.EnumPesado)int.Parse(data.IdPesado);
            }
            if (data.IdCatalogo != "")
            {
                filtros.catalogo = OOB.LibInventario.Producto.Enumerados.EnumCatalogo.No ;
                if (data.IdCatalogo=="Si")
                    filtros.catalogo = OOB.LibInventario.Producto.Enumerados.EnumCatalogo.Si;
            }
            if (data.IdOferta != "")
            {
                filtros.oferta = (OOB.LibInventario.Producto.Enumerados.EnumOferta)int.Parse(data.IdOferta);
            }
            if (data.IdExistencia != "")
            {
                switch (data.IdExistencia) 
                {
                    case "0":
                        filtros.existencia = OOB.LibInventario.Producto.Filtro.Existencia.MayorQueCero;
                        break;
                    case "1":
                        filtros.existencia = OOB.LibInventario.Producto.Filtro.Existencia.IgualCero;
                        break;
                    case "2":
                        filtros.existencia = OOB.LibInventario.Producto.Filtro.Existencia.MenorQueCero;
                        break;
                }
            }
        }

        public void setFiltros(ModInventario.Buscar.Filtrar.data data)
        {
            CargarFiltros(data);
        }

    }

}