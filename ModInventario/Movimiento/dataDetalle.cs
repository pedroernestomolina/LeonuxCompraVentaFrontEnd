﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Movimiento
{
    
    public class dataDetalle
    {

        private List<item> lstItems;


        public List<item> ListaItems { get { return lstItems; } }
        public decimal MontoMovimiento { get { return ListaItems.Sum(s => s.ImporteMonedaLocal *s.Signo); } }


        public dataDetalle()
        {
            lstItems = new List<item>();
        }


        public void Limpiar()
        {
            lstItems.Clear();
        }

        public void Agregar(OOB.LibInventario.Producto.Data.Ficha ficha, decimal cnt, decimal costo, enumerados.enumTipoEmpaque emp,
            decimal tasaCambio, decimal importe, decimal importeMonedaLocal, enumerados.enumTipoMovimientoAjuste tipoMov, bool disponible=true, bool exDepCero=false)
        {
            lstItems.Add(new item(ficha,cnt,costo, emp, tasaCambio, importe, importeMonedaLocal,tipoMov, disponible, exDepCero));
        }
        public void Remover(item it)
        {
            lstItems.Remove(it);
        }

        public void EliminarItemsNoDisponible()
        {
            foreach (var rg in lstItems.Where(w=> !w.Disponible).ToList()) 
            {
                Remover(rg);
            }
        }

        public void EliminarItemsExistenciaDepositoCero()
        {
            foreach (var rg in lstItems.Where(w => w.ExistenciaDepositoEnCero).ToList())
            {
                Remover(rg);
            }
        }

        public bool VerificaItemRegistrado(string autoPrd)
        {
            var it = lstItems.FirstOrDefault(f => f.FichaPrd.AutoId == autoPrd);
            return it != null;
        }

    }

}