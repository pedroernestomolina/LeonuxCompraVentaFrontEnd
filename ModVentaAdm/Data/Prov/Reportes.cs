using ModVentaAdm.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Prov
{

    public partial class DataPrv : IData
    {

        public OOB.Resultado.Lista<OOB.Reportes.GeneralDocumento.Ficha> Reportes_GeneralDocumento(OOB.Reportes.GeneralDocumento.Filtro filtro)
        {
            var rt = new OOB.Resultado.Lista<OOB.Reportes.GeneralDocumento.Ficha>();

            var filtroDTO = new DtoLibPos.Reportes.VentaAdministrativa.GeneralDocumento.Filtro()
            {
                codSucursal = filtro.idSucursal,
                desde = filtro.desde,
                hasta = filtro.hasta,
                tipoDocFactura = filtro.tipoDocFactura,
                tipoDocNtDebito = filtro.tipoDocNtDebito,
                tipoDocNtCredito = filtro.tipoDocNtCredito,
                tipoDocNtEntrega = filtro.tipoDocNtEntrega,
            };
            var r01 = MyData.ReportesAdm_GeneralDocumento(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var list= new List<OOB.Reportes.GeneralDocumento.Ficha>();
            if (r01.Lista != null) 
            {
                if (r01.Lista.Count > 0) 
                {
                    list = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Reportes.GeneralDocumento.Ficha()
                        {
                            clienteCiRif = s.clienteCiRif,
                            clienteNombre = s.clienteNombre,
                            control = s.control,
                            documento = s.documento,
                            estatusDoc = s.estatusDoc,
                            factorDoc = s.factorDoc,
                            fecha = s.fecha,
                            montoCargo = s.montoCargo,
                            montoDscto = s.montoDscto,
                            nombreDoc = s.nombreDoc,
                            renglones = s.renglones,
                            serie = s.serie,
                            signoDoc = s.signoDoc,
                            tipoDoc = s.tipoDoc,
                            total = s.total,
                            totalDivisa = s.totalDivisa,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.ListaD=list;

            return rt;
        }

    }

}