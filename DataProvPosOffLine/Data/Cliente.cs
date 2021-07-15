using DataProvPosOffLine.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.Data
{
    
    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Cliente.Ficha> Cliente(int id)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Cliente.Ficha>();

            var r01 = MyData.Cliente(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var c = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Cliente.Ficha()
            {
                Id = c.Id,
                CiRif = c.CiRif,
                NombreRazonSocial = c.NombreRazaonSocial,
                DirFiscal = c.DirFiscal,
                Telefono = c.Telefono,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Cliente.Ficha> Cliente_BuscarPorCiRif(string ciRif)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Cliente.Ficha>();

            var r01 = MyData.Cliente_BuscarPorCiRif(ciRif);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.LibVenta.PosOffline.Cliente.Ficha();
            if (r01.Entidad != null) 
            {
                var c = r01.Entidad;
                nr.Id = c.Id;
                nr.CiRif = c.CiRif;
                nr.NombreRazonSocial = c.NombreRazaonSocial;
                nr.DirFiscal = c.DirFiscal;
                nr.Telefono = c.Telefono;
            }
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoId Cliente_Agregar(OOB.LibVenta.PosOffline.Cliente.Agregar ficha)
        {
            var rt = new OOB.ResultadoId();

            var agregarDTO = new DtoLibPosOffLine.Cliente.Agregar() 
            {
                 CiRif=ficha.CiRif,
                 NombreRazaonSocial=ficha.NombreRazaonSocial,
                 DirFiscal=ficha.DirFiscal,
                 Telefono=ficha.Telefono,
            };
            var r01 = MyData.Cliente_Agregar(agregarDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Id = r01.Id;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibVenta.PosOffline.Cliente.Ficha> Cliente_Lista(string filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibVenta.PosOffline.Cliente.Ficha>();

            var r01 = MyData.Cliente_Lista(filtro);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibVenta.PosOffline.Cliente.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.PosOffline.Cliente.Ficha()
                        {
                            Id = s.Id,
                            CiRif = s.CiRif,
                            NombreRazonSocial = s.NombreRazaonSocial,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibVenta.PosOffline.Cliente.ExportarData.Ficha> Cliente_ExportarData(OOB.LibVenta.PosOffline.Cliente.ExportarData.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibVenta.PosOffline.Cliente.ExportarData.Ficha>();

            var filtroDTO= new DtoLibPosOffLine.Cliente.ExportarData.Filtro ();
            var r01 = MyData.Cliente_ExportarData(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibVenta.PosOffline.Cliente.ExportarData.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.PosOffline.Cliente.ExportarData.Ficha()
                        {
                            CiRif = s.CiRif,
                            NombreRazonSocial = s.NombreRazonSocial,
                            DirFiscal = s.DirFiscal,
                            Telefono = s.Telefono,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}