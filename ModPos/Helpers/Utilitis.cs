using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace ModPos.Helpers
{
    
    public class Utilitis
    {

        static public string _Instancia { get; set; }
        static public string _BaseDatos { get; set; }
        static public string _DataLocal { get; set; }


        static public void Calculadora()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"calc.exe";
            p.Start();
            //p.WaitForExit();
        }

        static public OOB.Resultado CargarXml()
        {
            var result = new OOB.Resultado();

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
                                            _Instancia = sv.InnerText.Trim();
                                        }
                                        if (sv.LocalName.Trim().ToUpper() == "CATALOGO")
                                        {
                                            _BaseDatos = sv.InnerText.Trim();
                                        }
                                    }
                                }
                                if (nv.LocalName.ToUpper().Trim() == "DATALOCAL") 
                                {
                                    _DataLocal = nv.InnerText.Trim();
                                }

                                if (nv.LocalName.ToUpper().Trim()=="IMPRESORATICKET")
                                {
                                    foreach (XmlNode mi in nv.ChildNodes)
                                    {
                                        if (mi.LocalName.Trim().ToUpper() == "TAMANOROLLO")
                                        {
                                            if (mi.InnerText.Trim().ToUpper() == "G")
                                            {
                                                Sistema.ImpresoraTicket = Sistema.EnumModoRolloTicket.Grande;
                                            }                                            
                                            if (mi.InnerText.Trim().ToUpper() == "P")
                                            {
                                                Sistema.ImpresoraTicket = Sistema.EnumModoRolloTicket.Pequeno;
                                            }
                                        }
                                    }

                                }

                                if (nv.LocalName.ToUpper().Trim() == "NUEVOCONOMONETARIO")
                                {
                                    Sistema.NuevoConoMonetario= decimal.Parse(nv.InnerText.Trim());
                                }
                                if (nv.LocalName.ToUpper().Trim() == "NUEVOCONOMONETARIOFECHAFINUSO")
                                {
                                    Sistema.NuevoConoMonetarioFechaFinUso = DateTime.Parse(nv.InnerText.Trim());
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Result =  OOB.Enumerados.EnumResult.isError;
                result.Mensaje = e.Message;
            }

            return result;
        }

    }

}
