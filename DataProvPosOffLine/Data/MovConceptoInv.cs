﻿using DataProvPosOffLine.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoLista<OOB.LibVenta.PosOffline.MovConceptoInv.Ficha> MovConceptoInv_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibVenta.PosOffline.MovConceptoInv.Ficha>();

            var r01 = MyData.MovConceptoInv_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibVenta.PosOffline.MovConceptoInv.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.PosOffline.MovConceptoInv.Ficha()
                        {
                            Auto = s.Auto,
                            Codigo = s.Codigo,
                            Nombre = s.Nombre,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}