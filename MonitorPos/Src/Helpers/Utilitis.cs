﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace MonitorPos.Src.Helpers
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

                                if (nv.LocalName.ToUpper().Trim() == "MONITORCIERRERESUMEN")
                                {
                                    foreach (XmlNode mi in nv.ChildNodes)
                                    {
                                        if (mi.LocalName.Trim().ToUpper() == "ACTIVAR")
                                        {
                                            if (mi.InnerText.Trim().ToUpper()=="SI")
                                                Sistema.ActivarMonitorCierreResumen = true;
                                        }
                                        if (mi.LocalName.Trim().ToUpper() == "TIEMPO")
                                        {
                                            Sistema.TiempoMonitorCierreResumen = int.Parse(mi.InnerText.Trim());
                                        }
                                        if (mi.LocalName.Trim().ToUpper() == "IDEQUIPO")
                                        {
                                            Sistema.IdEquipo = mi.InnerText.Trim();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                result.Mensaje = e.Message;
            }

            return result;
        }

    }

}