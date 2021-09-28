using DataProvSistema.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{

    public partial class DataProv : IData
    {

        public OOB.ResultadoEntidad<OOB.LibSistema.ReconversionMonetaria.Data.Ficha> ReconversionMonetaria_GetData()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.ReconversionMonetaria.Data.Ficha>();

            var r01 = MyData.ReconversionMonetaria_GetData();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            try
            {
                var nr = new OOB.LibSistema.ReconversionMonetaria.Data.Ficha()
                {
                    Producto = r01.Entidad.Producto.Select(s =>
                    {
                        var prd = new OOB.LibSistema.ReconversionMonetaria.Data.ItemPrd()
                        {
                            autoId = s.autoId,
                            nombre = s.nombre,
                            costoDivisa = s.costoDivisa,
                            costo = s.costo,
                            costoUnd = s.costoUnd,
                            costoProm = s.costoProm,
                            costoPromUnd = s.costoPromUnd,
                            costoPrv = s.costoPrv,
                            costoPrvUnd = s.costoPrvUnd,
                            precio1 = s.precio1,
                            precio2 = s.precio2,
                            precio3 = s.precio3,
                            precio4 = s.precio4,
                            precio5 = s.precio5,
                        };
                        return prd;
                    }).ToList(),
                    Proveedor = r01.Entidad.Proveedor.Select(s =>
                    {
                        var prv = new OOB.LibSistema.ReconversionMonetaria.Data.ItemProv()
                        {
                            autoId = s.autoId,
                            nombre = s.nombre,
                            anticipos = s.anticipos,
                            debitos = s.debitos,
                            creditos = s.creditos,
                            saldo = s.saldo,
                            disponible = s.disponible,
                        };
                        return prv;
                    }).ToList(),
                    SaldoPorPagar = r01.Entidad.SaldoPorPagar.Select(s =>
                    {
                        var cxp = new OOB.LibSistema.ReconversionMonetaria.Data.ItemSaldoPorPagar()
                        {
                            autoDoc = s.autoDoc,
                            docNumero = s.docNumero,
                            importe = s.importe,
                            acumulado = s.acumulado,
                            resta = s.resta,
                        };
                        return cxp;
                    }).ToList(),
                };
                rt.Entidad = nr;
            }
            catch (Exception e)
            {
                rt.Entidad = null;
                rt.Mensaje = e.Message;
                rt.Result = OOB.Enumerados.EnumResult.isError;
            }

            return rt;
        }

        public OOB.Resultado ReconversionMonetaria_Actualizar(OOB.LibSistema.ReconversionMonetaria.Actualizar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.ReconversionMonetaria.Actualizar.Ficha()
            {
                codUsuario = ficha.codUsuario,
                equipoEstacion = ficha.equipoEstacion,
                factorReconverion = ficha.factorReconverion,
                idUsuario = ficha.idUsuario,
                tasaDivisa = ficha.tasaDivisa,
                tasaDivisaPos = ficha.tasaDivisaPos,
                usuario = ficha.usuario,
                Producto = ficha.Producto.Select(s => 
                {
                    var prd = new DtoLibSistema.ReconversionMonetaria.Actualizar.ItemPrd()
                    {
                        autoId = s.autoId,
                        nombre = s.nombre,
                        costo = s.costo,
                        costoProm = s.costoProm,
                        costoPrv = s.costoPrv,
                        costoUnd = s.costoUnd,
                        costoPromUnd = s.costoPromUnd,
                        costoPrvUnd = s.costoPrvUnd,
                        precio1 = s.precio1,
                        precio2 = s.precio2,
                        precio3 = s.precio3,
                        precio4 = s.precio4,
                        precio5 = s.precio5,
                    };
                    return prd;
                }).ToList(),
                Proveedor= ficha.Proveedor.Select(s =>
                {
                    var prv = new DtoLibSistema.ReconversionMonetaria.Actualizar.ItemProv()
                    {
                        autoId = s.autoId,
                        nombre = s.nombre,
                        anticipos = s.anticipos,
                        debitos = s.debitos,
                        creditos = s.creditos,
                        saldo = s.saldo,
                        disponible = s.disponible,
                    };
                    return prv;
                }).ToList(),
                SaldoPorPagar = ficha.SaldoPorPagar.Select(s =>
                {
                    var cxp = new DtoLibSistema.ReconversionMonetaria.Actualizar.ItemSaldoPorPagar()
                    {
                        autoDoc = s.autoDoc,
                        docNumero = s.docNumero,
                        importe = s.importe,
                        acumulado = s.acumulado,
                        resta = s.resta,
                    };
                    return cxp;
                }).ToList(),
                HistoricoCosto = ficha.HistoricoCosto.Select(s =>
                {
                    var cost = new DtoLibSistema.ReconversionMonetaria.Actualizar.ItemHistCosto()
                    {
                        autoPrd = s.autoPrd,
                        costo = s.costo,
                        costoDivisa = s.costoDivisa,
                        documento = s.documento,
                        estacionEquipo = s.estacionEquipo,
                        nota = s.nota,
                        serie = s.serie,
                        tasaDivisa = s.tasaDivisa,
                        usuario = s.usuario,
                    };
                    return cost;
                }).ToList(),
                HistoricoPrecio= ficha.HistoricoPrecio.Select(s =>
                {
                    var prec = new DtoLibSistema.ReconversionMonetaria.Actualizar.ItemHistPrecio()
                    {
                        autoPrd = s.autoPrd,
                        estacionEquipo = s.estacionEquipo,
                        idPrecio = s.idPrecio,
                        nota = s.nota,
                        precio = s.precio,
                        usuario = s.usuario,
                    };
                    return prec;
                }).ToList(),
            };

            var r01 = MyData.ReconversionMonetaria_Actualizar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<int> ReconversionMonetaria_GetCount()
        {
            var rt = new OOB.ResultadoEntidad<int>();

            var r01 = MyData.ReconversionMonetaria_GetCount();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }

    }

}