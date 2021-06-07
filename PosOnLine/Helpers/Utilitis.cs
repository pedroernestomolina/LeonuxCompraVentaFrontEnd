using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace PosOnLine.Helpers
{
    
    public class Utilitis
    {
        static public string _DataLocal { get; set; }


        static public void Calculadora()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"calc.exe";
            p.Start();
            //p.WaitForExit();
        }

        static public OOB.Resultado.Ficha CargarXml()
        {
            var result = new OOB.Resultado.Ficha();

            try
            {
                var doc = new XmlDocument();
                doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\Conf.XML");

                if (doc.HasChildNodes)
                {
                    foreach (XmlNode nd in doc)
                    {
                        if (nd.LocalName.ToUpper().Trim() == "CONFIGURACION")
                        {
                            foreach (XmlNode nv in nd.ChildNodes)
                            {
                                if (nv.LocalName.ToUpper().Trim() == "SERVIDOR")
                                {
                                    foreach (XmlNode sv in nv.ChildNodes)
                                    {
                                        if (sv.LocalName.Trim().ToUpper() == "INSTANCIA")
                                        {
                                            Sistema.Instancia = sv.InnerText.Trim();
                                        }
                                        if (sv.LocalName.Trim().ToUpper() == "CATALOGO")
                                        {
                                            Sistema.BaseDatos = sv.InnerText.Trim();
                                        }
                                    }
                                }
                                if (nv.LocalName.ToUpper().Trim() == "IDEQUIPO")
                                {
                                    Sistema.IdEquipo= nv.InnerText.Trim();
                                }

                                if (nv.LocalName.ToUpper().Trim() == "DATALOCAL") 
                                {
                                    _DataLocal = nv.InnerText.Trim();
                                }

                                if (nv.LocalName.ToUpper().Trim() == "SERIEFACTURA")
                                {
                                    Sistema.SerieFactura = nv.InnerText.Trim().ToUpper();
                                }
                                if (nv.LocalName.ToUpper().Trim() == "SERIENCREDITO")
                                {
                                    Sistema.SerieNCredito = nv.InnerText.Trim().ToUpper();
                                }
                                if (nv.LocalName.ToUpper().Trim() == "SERIENENTREGA")
                                {
                                    Sistema.SerieNEntrega = nv.InnerText.Trim().ToUpper();
                                }

                                if (nv.LocalName.ToUpper().Trim() == "MODOIMPRESIONFACTURA")
                                {
                                    switch (nv.InnerText.Trim().ToUpper())
                                    {
                                        case "G":
                                            Sistema.ImprimirFactura = new Helpers.Imprimir.Grafico.Documento();
                                            break;
                                        case "F":
                                            break;
                                        case "T80":
                                            Sistema.ImprimirFactura = new Helpers.Imprimir.Tickera80.Documento();
                                            break;
                                        case "T58":
                                            Sistema.ImprimirFactura = new Helpers.Imprimir.Tickera58.Documento();
                                            break;
                                    }
                                }

                                if (nv.LocalName.ToUpper().Trim() == "MODOIMPRESIONNENTREGA")
                                {
                                    switch (nv.InnerText.Trim().ToUpper())
                                    {
                                        case "G":
                                            Sistema.ImprimirNotaEntrega = new Helpers.Imprimir.Grafico.Documento();
                                            break;
                                        case "F":
                                            break;
                                        case "T80":
                                            Sistema.ImprimirNotaEntrega = new Helpers.Imprimir.Tickera80.Documento();
                                            break;
                                        case "T58":
                                            Sistema.ImprimirNotaEntrega = new Helpers.Imprimir.Tickera58.Documento();
                                            break;
                                    }
                                }

                                if (nv.LocalName.ToUpper().Trim() == "MODOIMPRESIONNCREDITO")
                                {
                                    switch (nv.InnerText.Trim().ToUpper())
                                    {
                                        case "G":
                                            Sistema.ImprimirNotaCredito = new Helpers.Imprimir.Grafico.Documento();
                                            break;
                                        case "F":
                                            break;
                                        case "T80":
                                            Sistema.ImprimirNotaCredito = new Helpers.Imprimir.Tickera80.Documento();
                                            break;
                                        case "T58":
                                            Sistema.ImprimirNotaCredito = new Helpers.Imprimir.Tickera58.Documento();
                                            break;
                                    }
                                }

                                if (nv.LocalName.ToUpper().Trim() == "MODOIMPRESIONCUADRECAJA")
                                {
                                    switch (nv.InnerText.Trim().ToUpper())
                                    {
                                        case "G":
                                            Sistema.ImprimirCuadreCaja= new Helpers.Imprimir.Grafico.CuadreDoc();
                                            break;
                                        case "F":
                                            break;
                                        case "T80":
                                            Sistema.ImprimirCuadreCaja = new Helpers.Imprimir.Tickera80.CuadreDoc();
                                            break;
                                        case "T58":
                                            Sistema.ImprimirCuadreCaja = new Helpers.Imprimir.Tickera58.CuadreDoc();
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Result =  OOB.Resultado.Enumerados.EnumResult.isError;
                result.Mensaje = e.Message;
            }

            return result;
        }

    }

}
