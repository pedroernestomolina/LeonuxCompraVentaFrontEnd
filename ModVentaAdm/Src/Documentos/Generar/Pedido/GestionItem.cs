using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Documentos.Generar.Pedido
{
    
    public class GestionItem: AgregarEditarItem.IGestion
    {

        private int _idItemAgregado;


        public int IdItemAgregado { get { return _idItemAgregado; } }


        public bool AgregarItem(AgregarEditarItem.data data, int idTempVenta)
        {
            _idItemAgregado = -1;
            var prd = data.Producto;
            var ficha = new OOB.Venta.Temporal.Item.Registrar.Ficha()
            {
                validarExistencia = data.GetRupturaPorExistencia,
                itemEncabezado = new OOB.Venta.Temporal.Item.Registrar.ItemEncabezado()
                {
                    id = idTempVenta,
                    monto = data.GetImporteFull,
                    montoDivisa = data.GetImporteDivisaFull,
                    renglones = 1,
                },
                itemDetalle = new OOB.Venta.Temporal.Item.Registrar.ItemDetalle()
                {
                    autoDepartamento = prd.AutoDepartamento,
                    autoGrupo = prd.AutoGrupo,
                    autoProducto = prd.Auto,
                    autoSubGrupo = prd.AutoSubGrupo,
                    autoTasaIva = prd.AutoTasaIva,
                    cantidad = data.GetCantidad,
                    categroiaProducto = prd.Categoria,
                    codigoProducto = prd.CodigoPrd,
                    costo = prd.Costo,
                    costoPromd = prd.CostoProm,
                    costoPromdUnd = prd.CostoPromUnd,
                    costoUnd = prd.CostoUnd,
                    decimalesProducto = data.GetDecimales,
                    dsctoPorct = data.GetDsctoPorct,
                    empaqueCont = data.GetEmpqCont,
                    empaqueDesc = data.GetEmpqDesc,
                    estatusPesadoProducto = prd.EstatusPesado,
                    estatusReservaMerc = "1",
                    idVenta = idTempVenta,
                    nombreProducto = prd.NombrePrd,
                    notas = data.GetNotas,
                    precioNeto = data.GetPrecioNeto,
                    precioNetoDivisa = data.GetPrecioNetoDivisa,
                    tarifaPrecio = data.GetIdPrecio,
                    tasaIva = prd.TasaImpuesto,
                    tipoIva = prd.TipoIva,
                },
                itemActDeposito = new OOB.Venta.Temporal.Item.Registrar.ItemActDeposito()
                {
                    autoDeposito = data.GetIdDeposito,
                    autoProducto = prd.Auto,
                    cntActualizar = data.GetCantidadUnd,
                    prdDescripcion = prd.NombrePrd,
                },
            };
            var r01 = Sistema.MyData.Venta_Temporal_Item_Registrar(ficha);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _idItemAgregado = r01.Id;

            return true;
        }

    }

}