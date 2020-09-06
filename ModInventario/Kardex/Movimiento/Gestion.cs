using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Kardex.Movimiento
{
    
    public class Gestion
    {


        private string autoPrd;
        private OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias dias;
        private OOB.LibInventario.Kardex.Movimiento.Resumen.Ficha ficha;
        private data compra;
        private data venta;
        private data inventario;


        public BindingSource Compra { get { return compra.Source; } }
        public BindingSource Venta{ get { return venta.Source; } }
        public BindingSource Inventario{ get { return inventario.Source; } }
        public string Entradas { get { return compra.CntInv.ToString(Decimales); } }
        public string Salidas { get { return venta.CntInv.ToString(Decimales); } }
        public string Producto { get { return ficha.codigoProducto + Environment.NewLine + ficha.nombreProducto; } }
        public string ExActual { get { return ficha.existenciaActual.ToString(Decimales); } }
        public string ExFecha { get { return ficha.existenciaFecha.ToString(Decimales); } }
        public string Fecha { get { return "Exist Al "+ficha.fecha; } }
        public string Decimales { get { return "n" + ficha.decimales; } }


        public Gestion()
        {
            compra = new data();
            venta= new data();
            inventario= new data();
            Limpiar();
        }


        public void Limpiar() 
        {
            dias = OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias.SinDefinir;
            compra.Limpiar();
            venta.Limpiar();
            inventario.Limpiar();
        }

        KardexFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new KardexFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return Cargar();
        }

        public void setFicha(string prd)
        {
            autoPrd = prd;
        }

        public void Procesar()
        {
            Cargar();
        }

        public bool Cargar() 
        {
            var rt = true;

            var filtro = new OOB.LibInventario.Kardex.Movimiento.Resumen.Filtro()
            {
                autoProducto = autoPrd,
                ultDias =  dias,
            };
            var r01 = Sistema.MyData.Producto_Kardex_Movimiento_Lista_Resumen(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            ficha = r01.Entidad;
            compra.setFicha(r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "COMPRAS").ToList());
            venta.setFicha(r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "VENTAS").ToList());
            inventario.setFicha(r01.Entidad.Data.Where(w => w.modulo.Trim().ToUpper() == "INVENTARIO").ToList());

            return rt;
        }

        public void setDias( OOB.LibInventario.Kardex.Enumerados.EnumMovUltDias xdias)
        {
            dias = xdias;
        }

    }

}