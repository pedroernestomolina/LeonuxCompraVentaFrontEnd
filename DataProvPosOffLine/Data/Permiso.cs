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

        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Permiso.Pos.Ficha> IPermiso.Permiso_ManejoPos()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Permiso.Pos.Ficha>();

            var r01 = MyData.Permiso_ManejoPos();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var ent = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Permiso.Pos.Ficha();
            nr.Devolucion = new OOB.LibVenta.PosOffline.Permiso.Pos.Permiso(ent.Devolucion.Codigo, ent.Devolucion.Descripcion, ent.Devolucion.RequiereClave);
            nr.AnularVenta = new OOB.LibVenta.PosOffline.Permiso.Pos.Permiso(ent.AnularVenta.Codigo, ent.AnularVenta.Descripcion, ent.AnularVenta.RequiereClave);
            nr.Sumar = new OOB.LibVenta.PosOffline.Permiso.Pos.Permiso(ent.Sumar.Codigo, ent.Sumar.Descripcion, ent.Sumar.RequiereClave);
            nr.Multiplicar= new OOB.LibVenta.PosOffline.Permiso.Pos.Permiso(ent.Multiplicar.Codigo, ent.Multiplicar.Descripcion, ent.Multiplicar.RequiereClave);
            nr.Restar= new OOB.LibVenta.PosOffline.Permiso.Pos.Permiso(ent.Restar.Codigo, ent.Restar.Descripcion, ent.Restar.RequiereClave);
            nr.DejarCtaPendiente = new OOB.LibVenta.PosOffline.Permiso.Pos.Permiso(ent.DejarCtaPendiente.Codigo, ent.DejarCtaPendiente.Descripcion, ent.DejarCtaPendiente.RequiereClave);
            nr.AnularCtaPendiente = new OOB.LibVenta.PosOffline.Permiso.Pos.Permiso(ent.AnularCtaPendiente.Codigo, ent.AnularCtaPendiente.Descripcion, ent.AnularCtaPendiente.RequiereClave);
            nr.DarDesctoGlobal= new OOB.LibVenta.PosOffline.Permiso.Pos.Permiso(ent.DarDesctoGlobal.Codigo, ent.DarDesctoGlobal.Descripcion, ent.DarDesctoGlobal.RequiereClave);
            nr.CtaCredito = new OOB.LibVenta.PosOffline.Permiso.Pos.Permiso(ent.CtaCredito.Codigo, ent.CtaCredito.Descripcion, ent.CtaCredito.RequiereClave);
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Permiso.AdmDocumento.Ficha> Permiso_AdmDocumento()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Permiso.AdmDocumento.Ficha>();

            var r01 = MyData.Permiso_AdmDocumento();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var ent = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Permiso.AdmDocumento.Ficha();
            nr.Anular = new OOB.LibVenta.PosOffline.Permiso.permiso (ent.Anular.Codigo, ent.Anular.Descripcion, ent.Anular.RequiereClave);
            nr.ReImprimir = new OOB.LibVenta.PosOffline.Permiso.permiso(ent.ReImprimir.Codigo, ent.ReImprimir.Descripcion, ent.ReImprimir.RequiereClave);
            nr.NotaCredito = new OOB.LibVenta.PosOffline.Permiso.permiso(ent.NotaCredito.Codigo, ent.NotaCredito.Descripcion, ent.NotaCredito.RequiereClave);
            rt.Entidad = nr;

            return rt;
        }

    }

}