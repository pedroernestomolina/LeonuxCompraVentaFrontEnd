﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Helpers.Imprimir
{

    public class Documento
    {

         static public Helpers.Imprimir.data CargarDataDocumento(string idDoc)
        {
            var xr1 = Sistema.MyData.Documento_GetById(idDoc);
            if (xr1.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(xr1.Mensaje);
                return null;
            }

            var xdata = new Helpers.Imprimir.data();
            xdata.negocio = new Helpers.Imprimir.data.Negocio()
            {
                Nombre = Sistema.DatosEmpresa.Nombre,
                CiRif = Sistema.DatosEmpresa.CiRif,
                Direccion = Sistema.DatosEmpresa.Direccion,
                Telefonos = Sistema.DatosEmpresa.Telefono,
            };
            var docNombre = "";
            switch (xr1.Entidad.Tipo.Trim().ToUpper())
            {
                case "01":
                    docNombre = "FACTURA";
                    break;
                case "02":
                    docNombre = "NOTA DE DEBITO";
                    break;
                case "03":
                    docNombre = "NOTA DE CREDITO";
                    break;
                case "04":
                    docNombre = "NOTA DE ENTREGA";
                    break;
            }
            xdata.encabezado = new Helpers.Imprimir.data.Encabezado()
            {
                CiRifCli = xr1.Entidad.CiRif,
                DireccionCli = xr1.Entidad.DirFiscal,
                DocumentoCondicionPago = xr1.Entidad.CondicionPago,
                DocumentoControl = xr1.Entidad.Control,
                DocumentoDiasCredito = xr1.Entidad.Dias,
                DocumentoFecha = xr1.Entidad.Fecha,
                DocumentoFechaVencimiento = xr1.Entidad.FechaVencimiento,
                DocumentoNombre = docNombre,
                DocumentoNro = xr1.Entidad.DocumentoNro,
                DocumentoSerie = xr1.Entidad.Serie,
                DocumentoAplica = xr1.Entidad.Aplica,
                NombreCli = xr1.Entidad.RazonSocial,
                FactorCambio = xr1.Entidad.FactorCambio,
                SubTotal = xr1.Entidad.SubTotalNeto,
                Descuento = xr1.Entidad.Descuento,
                Total = xr1.Entidad.Total,
                TotalDivisa = xr1.Entidad.MontoDivisa,
            };
            xdata.item = new List<Helpers.Imprimir.data.Item>();
            foreach (var rg in xr1.Entidad.items)
            {
                var nr = new Helpers.Imprimir.data.Item()
                {
                    NombrePrd = rg.Nombre,
                    CodigoPrd = rg.Codigo,
                    Cantidad = rg.Cantidad,
                    Contenido = rg.ContenidoEmpaque,
                    DepositoCodigo = rg.CodigoDeposito,
                    DepositoDesc = rg.Deposito,
                    Empaque = rg.Empaque,
                    Importe = rg.TotalNeto,
                    ImporteDivisa = rg.TotalNeto,
                    Precio = rg.PrecioItem,
                    PrecioDivisa = rg.PrecioItem,
                    TotalUnd = rg.CantidadUnd,
                };
                xdata.item.Add(nr);
            }
            return xdata;
        }

    }

}