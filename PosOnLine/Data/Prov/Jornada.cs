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

        public OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha> Jornada_EnUso_GetByIdEquipo(string idEquipo)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha>();

            var r01 = MyData.Jornada_EnUso_GetByIdEquipo(idEquipo);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent=r01.Entidad;
            var nr = new OOB.Pos.EnUso.Ficha()
            {
                codUsuario = ent.codUsuario,
                fechaApertura = ent.fechaApertura,
                horaApertura = ent.horaApertura,
                id = ent.id,
                idUsuario = ent.idUsuario,
                nomUsuario = ent.nomUsuario,
                idAutoArqueoCierre=ent.idArqueoCierre,
                idResumen=ent.idResumen,
            };
            result.Entidad=nr;

            return result;
        }

        public OOB.Resultado.FichaId Jornada_Abrir(OOB.Pos.Abrir.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaId();

            var fichaDTO = new DtoLibPos.Pos.Abrir.Ficha()
            {
                idEquipo = ficha.idEquipo,
                codSucursal=ficha.codSucursal,
                operadorAbrir = new DtoLibPos.Pos.Abrir.Operador()
                {
                    estatus = ficha.operadorAbrir.estatus,
                    idEquipo = ficha.operadorAbrir.idEquipo,
                    idUsuario = ficha.operadorAbrir.idUsuario,
                },
                arqueoAbrir = new DtoLibPos.Pos.Abrir.Arqueo()
                {
                    cheque = ficha.arqueoAbrir.cheque,
                    cierreFtp = ficha.arqueoAbrir.cierreFtp,
                    cntDivisaUsuario = ficha.arqueoAbrir.cntDivisaUsuario,
                    cntDivisia = ficha.arqueoAbrir.cntDivisia,
                    cntDoc = ficha.arqueoAbrir.cntDoc,
                    cntDocFac = ficha.arqueoAbrir.cntDocFac,
                    cntDocNCr = ficha.arqueoAbrir.cntDocNCr,
                    cobranza = ficha.arqueoAbrir.cobranza,
                    codUsuario = ficha.arqueoAbrir.codUsuario,
                    credito = ficha.arqueoAbrir.credito,
                    debito = ficha.arqueoAbrir.debito,
                    devolucion = ficha.arqueoAbrir.devolucion,
                    diferencia = ficha.arqueoAbrir.diferencia,
                    efectivo = ficha.arqueoAbrir.efectivo,
                    firma = ficha.arqueoAbrir.firma,
                    idUsuario = ficha.arqueoAbrir.idUsuario,
                    mbanco1 = ficha.arqueoAbrir.mbanco1,
                    mbanco2 = ficha.arqueoAbrir.mbanco2,
                    mbanco3 = ficha.arqueoAbrir.mbanco3,
                    mbanco4 = ficha.arqueoAbrir.mbanco4,
                    mcheque = ficha.arqueoAbrir.mcheque,
                    mefectivo = ficha.arqueoAbrir.mefectivo,
                    mfirma = ficha.arqueoAbrir.mfirma,
                    mgastos = ficha.arqueoAbrir.mgastos,
                    montoFac = ficha.arqueoAbrir.montoFac,
                    montoNCr = ficha.arqueoAbrir.montoNCr,
                    motros = ficha.arqueoAbrir.motros,
                    mretenciones = ficha.arqueoAbrir.mretenciones,
                    mretiro = ficha.arqueoAbrir.mretiro,
                    msubtotal = ficha.arqueoAbrir.msubtotal,
                    mtarjeta = ficha.arqueoAbrir.mtarjeta,
                    mticket = ficha.arqueoAbrir.mticket,
                    mtotal = ficha.arqueoAbrir.mtotal,
                    mtrans = ficha.arqueoAbrir.mtrans,
                    nombreUsuario = ficha.arqueoAbrir.nombreUsuario,
                    otros = ficha.arqueoAbrir.otros,
                    retiro = ficha.arqueoAbrir.retiro,
                    subTotal = ficha.arqueoAbrir.subTotal,
                    ticket = ficha.arqueoAbrir.ticket,
                    total = ficha.arqueoAbrir.total,
                },
                resumenAbrir = new DtoLibPos.Pos.Abrir.Resumen()
                {
                    cntDevolucion = ficha.resumenAbrir.cntDevolucion,
                    cntDivisa = ficha.resumenAbrir.cntDivisa,
                    cntDoc = ficha.resumenAbrir.cntDoc,
                    cntDocContado = ficha.resumenAbrir.cntDocContado,
                    cntDocCredito = ficha.resumenAbrir.cntDocCredito,
                    cntEfectivo = ficha.resumenAbrir.cntEfectivo,
                    cntElectronico = ficha.resumenAbrir.cntElectronico,
                    cntFac = ficha.resumenAbrir.cntFac,
                    cntNCr = ficha.resumenAbrir.cntNCr,
                    cntotros = ficha.resumenAbrir.cntotros,
                    mContado = ficha.resumenAbrir.mContado,
                    mCredito = ficha.resumenAbrir.mCredito,
                    mDevolucion = ficha.resumenAbrir.mDevolucion,
                    mDivisa = ficha.resumenAbrir.mDivisa,
                    mEfectivo = ficha.resumenAbrir.mEfectivo,
                    mElectronico = ficha.resumenAbrir.mElectronico,
                    mFac = ficha.resumenAbrir.mFac,
                    mNCr = ficha.resumenAbrir.mNCr,
                    mOtros = ficha.resumenAbrir.mOtros,
                }
            };
            var r01 = MyData.Jornada_Abrir(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError) 
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            result.Id = r01.Id;

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha> Jornada_EnUso_GetById(int id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha>();

            var r01 = MyData.Jornada_EnUso_GetById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            var nr = new OOB.Pos.EnUso.Ficha()
            {
                codUsuario = ent.codUsuario,
                fechaApertura = ent.fechaApertura,
                horaApertura = ent.horaApertura,
                id = ent.id,
                idUsuario = ent.idUsuario,
                nomUsuario = ent.nomUsuario,
            };
            result.Entidad = nr;

            return result;
        }

    }

}