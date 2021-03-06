﻿using ModVentaAdm.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Prov
{
    
    public partial class DataPrv : IData
    {

        public OOB.Resultado.FichaEntidad<OOB.Sistema.Empresa.Entidad.Ficha> Sistema_Empresa_GetFicha()
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Sistema.Empresa.Entidad.Ficha>();

            var r01 = MyData.Sistema_Empresa_GetFicha();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            var s = r01.Entidad;
            result.Entidad = new OOB.Sistema.Empresa.Entidad.Ficha()
            {
                CiRif = s.CiRif,
                Direccion = s.Direccion,
                Nombre = s.Nombre,
                Telefono = s.Telefono,
            };

            return result;
        }

        public OOB.Resultado.Lista<OOB.Sistema.Vendedor.Entidad.Ficha> Sistema_Vendedor_GetLista()
        {
            var result = new OOB.Resultado.Lista<OOB.Sistema.Vendedor.Entidad.Ficha>();

            var filtroDTO = new DtoLibPos.Vendedor.Lista.Filtro();
            var r01 = MyData.Vendedor_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Sistema.Vendedor.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Sistema.Vendedor.Entidad.Ficha()
                        {
                            id = s.id,
                            codigo = s.codigo,
                            nombre = s.nombre,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

        public OOB.Resultado.Lista<OOB.Sistema.Cobrador.Entidad.Ficha> Sistema_Cobrador_GetLista()
        {
            var result = new OOB.Resultado.Lista<OOB.Sistema.Cobrador.Entidad.Ficha>();

            var filtroDTO = new DtoLibPos.Cobrador.Lista.Filtro();
            var r01 = MyData.Cobrador_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Sistema.Cobrador.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Sistema.Cobrador.Entidad.Ficha()
                        {
                            id = s.id,
                            codigo = s.codigo,
                            nombre = s.nombre,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

        public OOB.Resultado.Lista<OOB.Sistema.Estado.Entidad.Ficha> Sistema_Estado_GetLista()
        {
            var result = new OOB.Resultado.Lista<OOB.Sistema.Estado.Entidad.Ficha>();

            var r01 = MyData.Sistema_Estado_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Sistema.Estado.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Sistema.Estado.Entidad.Ficha()
                        {
                            auto = s.auto,
                            nombre = s.nombre,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

    }

}