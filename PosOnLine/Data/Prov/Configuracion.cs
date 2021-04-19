using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Prov
{
    
    public partial class DataPrv: IData
    {

        public OOB.Resultado.FichaEntidad<OOB.Configuracion.Entidad.Ficha> Configuracion_Pos_GetFicha()
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Configuracion.Entidad.Ficha>();

            var r01 = MyData.Configuracion_Pos_GetFicha();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            var nr = new OOB.Configuracion.Entidad.Ficha()
            {
                idClaveUsar = ent.idClaveUsar,
                idCobrador = ent.idCobrador,
                idConceptoDevVenta = ent.idConceptoDevVenta,
                idConceptoSalida = ent.idConceptoSalida,
                idConceptoVenta = ent.idConceptoVenta,
                idDeposito = ent.idDeposito,
                idMedioPagoDivisa = ent.idMedioPagoDivisa,
                idMedioPagoEfectivo = ent.idMedioPagoEfectivo,
                idMedioPagoElectronico = ent.idMedioPagoElectronico,
                idMedioPagoOtros = ent.idMedioPagoOtros,
                idPrecioManejar = ent.idPrecioManejar,
                idSucursal = ent.idSucursal,
                idTransporte = ent.idTransporte,
                idVendedor = ent.idVendedor,
                validarExistencia = ent.validarExistencia,
                idTipoDocumentoVenta=ent.idTipoDocVenta,
                idTipoDocumentoDevVenta=ent.idTipoDocDevVenta,
                idTipoDocumentoNotaEntrega=ent.idTipoDocNotaEntrega,
                idSerieFactura=ent.idFacturaSerie,
                idSerieNotaCredito=ent.idNotaCreditoSerie,
                idSerieNotaEntrega=ent.idNotaEntregaSerie,
            };
            result.Entidad = nr;

            return result;
        }

        public OOB.Resultado.FichaEntidad<decimal> Configuracion_FactorDivisa()
        {
            var result = new OOB.Resultado.FichaEntidad<decimal>();

            var r01 = MyData.Configuracion_FactorDivisa();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Entidad = r01.Entidad;

            return result;
        }

    }

}