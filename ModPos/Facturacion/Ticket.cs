﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion
{

    public class Ticket
    {


        public class DatosNegocio
        {
            public string cirif { get; set; }
            public string razonsocial_1 { get; set; }
            public string razonsocial_2 { get; set; }
            public string razonsocial_3 { get; set; }
            public string direcionFiscal_1 { get; set; }
            public string direcionFiscal_2 { get; set; }
            public string direcionFiscal_3 { get; set; }
            public string direcionFiscal_4 { get; set; }
            public string telefono_1 { get; set; }
            public string telefono_2 { get; set; }


            public DatosNegocio()
            {
                Limpiar();
            }


            public void Limpiar() 
            {
                cirif = "";
                razonsocial_1 = "";
                razonsocial_2 = "";
                razonsocial_3 = "";
                direcionFiscal_1 = "";
                direcionFiscal_2 = "";
                direcionFiscal_3 = "";
                direcionFiscal_4 = "";
                telefono_1 = "";
                telefono_2 = "";
            }

            public void setEmpresa(OOB.LibVenta.PosOffline.Empresa.Ficha ficha)
            {
                Limpiar();

                cirif = ficha.CiRif;
                var n = ficha.Nombre.Trim();
                var l = n.Length;

                if (n.Length > 120)
                {
                    razonsocial_1 = n.Substring(0, 40);
                    razonsocial_2 = n.Substring(40, 40);
                    razonsocial_3 = n.Substring(80, 40);
                }
                if (n.Length > 80 && n.Length<=120) 
                {
                    razonsocial_1 = n.Substring(0,40);
                    razonsocial_2 = n.Substring(40,40);
                    razonsocial_3 = n.Substring(80, l);
                }
                if (n.Length>40 && n.Length<=80) 
                {
                    razonsocial_1 = n.Substring(0, 40);
                    razonsocial_2 = n.Substring(40, l);
                }
                if (n.Length > 0 && n.Length <=40)
                {
                    razonsocial_1 = n.Substring(0, l);
                }

                var nd = ficha.DireccionFiscal.Trim();
                var ld = nd.Length;
                if (nd.Length > 160)
                {
                    direcionFiscal_1 = nd.Substring(0, 40);
                    direcionFiscal_2 = nd.Substring(40, 40);
                    direcionFiscal_3 = nd.Substring(80, 40);
                    direcionFiscal_4 = nd.Substring(120, 40);
                }
                if (nd.Length > 120 && nd.Length <=160)
                {
                    direcionFiscal_1 = nd.Substring(0, 40);
                    direcionFiscal_2 = nd.Substring(40, 40);
                    direcionFiscal_3 = nd.Substring(80, 40);
                    direcionFiscal_4 = nd.Substring(120, ld);
                }
                if (nd.Length > 80 && nd.Length <= 120)
                {
                    direcionFiscal_1 = nd.Substring(0, 40);
                    direcionFiscal_2 = nd.Substring(40, 40);
                    direcionFiscal_3 = nd.Substring(80, ld);
                }
                if (nd.Length > 40 && nd.Length <=80)
                {
                    direcionFiscal_1 = nd.Substring(0, 40);
                    direcionFiscal_2 = nd.Substring(40, ld);
                }
                if (nd.Length > 0 && nd.Length <= 40)
                {
                    direcionFiscal_1 = nd.Substring(0, ld);
                }

                var tlf = ficha.Telefono.Trim();
                var ltlf = tlf.Length;
                if (ltlf > 80)
                {
                    telefono_1 = tlf.Substring(0, 40);
                    telefono_2 = tlf.Substring(40, 40);
                }
                if (ltlf> 40 && ltlf<=80)
                {
                    telefono_1 = tlf.Substring(0, 40);
                    telefono_2 = tlf.Substring(40, ltlf);
                }
                if (ltlf > 0 && ltlf <= 40)
                {
                    telefono_1 = tlf.Substring(0, ltlf);
                }
            }
        }

        public class DatosCliente
        {
            public string cirif { get; set; }
            public string nombre_1 { get; set; }
            public string nombre_2 { get; set; }
            public string dirFiscal_1 { get; set; }
            public string dirFiscal_2 { get; set; }
            public string telefono_1 { get; set; }
            public string condicionpago { get; set; }
            public string estacion { get; set; }
            public string usuario { get; set; }


            public DatosCliente()
            {
                Limpiar();
            }

            public void Limpiar() 
            {
                cirif = "";
                nombre_1 = "";
                nombre_2 = "";
                dirFiscal_1 = "";
                dirFiscal_2 = "";
                telefono_1 = "";
                condicionpago = "";
                usuario = "";
                estacion = "";
            }
        }

        public class DatosDocumento
        {

            public class Item
            {
                public decimal cantidad { get; set; }
                public decimal precio { get; set; }
                public bool isExento { get; set; }
                public bool isPesado { get; set; }
                public decimal importe { get; set; }
                public string descripcion { get; set; }


                public Item()
                {
                    cantidad = 1.0m;
                    precio = 0.0m;
                    isExento = false;
                    isPesado = false;
                    importe = 0.0m;
                    descripcion = "";
                }


                public string simporte { get { return "Bs " + importe.ToString("n2"); } }
                public string sdescripcion
                {
                    get
                    {
                        var t = descripcion.Trim();
                        if (t.Length >= 40)
                        {
                            t = t.Substring(0, 40);
                        }
                        if (isExento) { t = t + " (E)"; }
                        return t;
                    }
                }
                public string scantidadPrecio
                {
                    get
                    {
                        var t = "";
                        t = cantidad.ToString("n2") + " X " + precio.ToString("n2");
                        return t;
                    }
                }
            }

            public class MedioPago
            {
                public string descripcion { get; set; }
                public string monto { get; set; }
            }

            public string nombre { get; set; }
            public string aplicaA { get; set; }
            public string numero { get; set; }
            public string fecha { get; set; }
            public string hora { get; set; }
            public string subtotalNeto { get; set; }
            public string subtotal { get; set; }
            public string descuentoMonto { get; set; }
            public string descuentoPorct { get; set; }
            public string cargoMonto { get; set; }
            public string cargoPorct { get; set; }
            public bool HayDescuento { get; set; }
            public bool HayCargo { get; set; }
            public string total { get; set; }
            public string cambio { get; set; }
            public List<Item> Items { get; set; }
            public List<MedioPago> MediosPago { get; set; }


            public string descuento
            {
                get
                {
                    return "DESCUENTO " + descuentoPorct;
                }
            }

            public string cargo
            {
                get
                {
                    return "CARGO " + cargoPorct;
                }
            }


            public DatosDocumento()
            {
                Limpiar();
            }

            public void Limpiar() 
            {
                aplicaA = "";
                nombre = "";
                numero = "";
                fecha = "";
                hora = "";
                subtotal = "";
                total = "";
                cambio = "";
                descuentoMonto = "";
                descuentoPorct = "";
                cargoMonto = "";
                cargoPorct = "";
                HayDescuento = false;
                HayCargo = false;
                Items = new List<Item>();
                MediosPago = new List<MedioPago>();
            }
        }


        public DatosNegocio Negocio;
        public DatosCliente Cliente;
        public DatosDocumento Documento;
        private System.Drawing.Printing.PrintPageEventArgs eg;


        public Ticket()
        {
            Negocio = new DatosNegocio();
            Cliente = new DatosCliente();
            Documento = new DatosDocumento();
        }


        public void setControlador(System.Drawing.Printing.PrintPageEventArgs e) 
        {
            eg = e;
        }


        public void Imrpimir() 
        {

            var fr = new Font("Arial", 7, FontStyle.Regular);
            var fb = new Font("Arial", 8, FontStyle.Bold);


            var dn = this.Negocio;
            var df = this.Documento;
            var st = new List<String>();
            st.Add(dn.cirif);
            st.Add(dn.razonsocial_1);
            st.Add(dn.razonsocial_2);
            st.Add(dn.direcionFiscal_1);
            st.Add(dn.direcionFiscal_2);
            st.Add(dn.direcionFiscal_3);
            st.Add(dn.direcionFiscal_4);
            st.Add(dn.telefono_1);
            st.Add(dn.telefono_2);

            var dc = this.Cliente;
            var sc = new List<String>();

            if (df.aplicaA != "")
            {
                sc.Add("APLICA: " + df.aplicaA);
            }

            sc.Add("Datos Del Cliente:");
            sc.Add(dc.cirif);
            sc.Add(dc.nombre_1);
            sc.Add(dc.nombre_2);
            sc.Add(dc.dirFiscal_1);
            sc.Add(dc.dirFiscal_2);
            sc.Add(dc.telefono_1);
            sc.Add("CONDICION PAGO: " + dc.condicionpago);
            sc.Add("ESTACION: " + dc.estacion);
            sc.Add("USUARIO: " + dc.usuario);

            var l = 0;
            foreach (var s in st)
            {
                if (s.Trim() != "")
                {
                    eg.Graphics.DrawString(s, fr, Brushes.Black, centrar(s), l);
                    l += 10;
                }
            }
            l += 10;

            foreach (var s in sc)
            {
                if (s.Trim() != "")
                {
                    eg.Graphics.DrawString(s, fr, Brushes.Black, 0, l);
                    l += 10;
                }
            }

            l += 10;
            eg.Graphics.DrawString(df.nombre, fb, Brushes.Black, centrar(df.nombre), l);
            l += 10;
            eg.Graphics.DrawString(df.nombre+":", fr, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.numero, fr, Brushes.Black, dder(df.numero), l);
            l += 10;
            eg.Graphics.DrawString("FECHA: " + df.fecha, fr, Brushes.Black, 0, l);
            eg.Graphics.DrawString("HORA: " + df.hora, fr, Brushes.Black, dder("HORA: " + df.hora), l);
            l += 10;
            eg.Graphics.DrawString("-".PadRight(90, '-'), fr, Brushes.Black, 0, l);
            l += 10;

            foreach (var r in df.Items)
            {
                if (r.isPesado)
                {
                }
                else
                {
                    if (r.cantidad == 1.0m)
                    {
                        eg.Graphics.DrawString(r.sdescripcion, fr, Brushes.Black, 0, l);
                        eg.Graphics.DrawString(r.simporte, fr, Brushes.Black, dder(r.simporte), l);
                        l += 10;
                    }
                    else
                    {
                        eg.Graphics.DrawString(r.scantidadPrecio, fr, Brushes.Black, 0, l);
                        l += 10;
                        eg.Graphics.DrawString(r.sdescripcion, fr, Brushes.Black, 0, l);
                        eg.Graphics.DrawString(r.simporte, fr, Brushes.Black, dder(r.simporte), l);
                        l += 10;
                    }
                }
            }

            eg.Graphics.DrawString("-".PadRight(85, '-'), fr, Brushes.Black, 0, l);
            l += 10;
            eg.Graphics.DrawString("SUBTOTAL", fr, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.subtotalNeto, fr, Brushes.Black, dder(df.subtotalNeto), l);
            l += 10;
            eg.Graphics.DrawString("-".PadRight(90, '-'), fr, Brushes.Black, 0, l);
            l += 10;

            if (df.HayCargo || df.HayDescuento) 
            {
                if (df.HayDescuento)
                {
                    eg.Graphics.DrawString(df.descuento, fr, Brushes.Black, 0, l);
                    eg.Graphics.DrawString(df.descuentoMonto, fr, Brushes.Black, dder(df.descuentoMonto), l);
                    l += 10;
                    eg.Graphics.DrawString("-".PadRight(90, '-'), fr, Brushes.Black, 0, l);
                    l += 10;
                }
                if (df.HayCargo)
                {
                    eg.Graphics.DrawString(df.cargo, fr, Brushes.Black, 0, l);
                    eg.Graphics.DrawString(df.cargoMonto, fr, Brushes.Black, dder(df.cargoMonto), l);
                    l += 10;
                    eg.Graphics.DrawString("-".PadRight(90, '-'), fr, Brushes.Black, 0, l);
                    l += 10;
                }
                eg.Graphics.DrawString("SUBTOTAL", fr, Brushes.Black, 0, l);
                eg.Graphics.DrawString(df.subtotal, fr, Brushes.Black, dder(df.subtotal), l);
                l += 10;
                eg.Graphics.DrawString("-".PadRight(90, '-'), fr, Brushes.Black, 0, l);
                l += 10;
            }

            eg.Graphics.DrawString("TOTAL", fb, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.total, fr, Brushes.Black, dder(df.total), l);
            l += 15;

            foreach (var mp in df.MediosPago)
            {
                eg.Graphics.DrawString(mp.descripcion, fr, Brushes.Black, 0, l);
                eg.Graphics.DrawString(mp.monto, fr, Brushes.Black, dder(mp.monto), l);
                l += 10;
            }
            eg.Graphics.DrawString("CAMBIO", fr, Brushes.Black, 0, l);
            eg.Graphics.DrawString(df.cambio, fr, Brushes.Black, dder(df.cambio), l);
            l += 10;
        }

        private float centrar(string t)
        {
            float r = 0.0f;
            //r=(275 /51 - ((70 / 49) * t.Trim().Length))/2;
            float tl = (275.0f / 51.0f);
            r = ((50.0f - t.Trim().Length) / 2.0f) * tl;
            return r;
        }

        private float dder(string t)
        {
            float r = 0.0f;
            //r=(275 /51 - ((70 / 49) * t.Trim().Length))/2;
            float tl = (285.0f / 51.0f);
            r = ((51.0f - t.Length)) * tl;
            return r;
        }

    }

}