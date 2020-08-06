﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOB.LibInventario.Producto.Data
{
    
    public class Identificacion
    {

        public string auto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string modelo { get; set; }
        public string referencia { get; set; }
        public int contenidoCompra { get; set; }
        public string empaqueCompra { get; set; }
        public Enumerados.EnumOrigen origen { get; set; }
        public Enumerados.EnumCategoria categoria { get; set; }
        public Enumerados.EnumEstatus estatus { get; set; }
        public Enumerados.EnumAdministradorPorDivisa AdmPorDivisa { get; set; }
        public string departamento { get; set; }
        public string codigoDepartamento { get; set; }
        public string grupo { get; set; }
        public string codigoGrupo { get; set; }
        public string marca { get; set; }
        public decimal tasaIva { get; set; }
        public string nombreTasaIva { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime? fechaBaja { get; set; }
        public DateTime? fechaUltActualizacion { get; set; }
        public string tipoABC { get; set; }
        public string comentarios { get; set; }
        public string advertencia { get; set; }
        public string presentacion { get; set; }


        public Identificacion()
        {
            auto = "";
            codigo = "";
            nombre = "";
            descripcion = "";
            modelo = "";
            referencia = "";
            contenidoCompra = 1;
            empaqueCompra = "";
            origen = Enumerados.EnumOrigen.SnDefinir;
            categoria = Enumerados.EnumCategoria.SnDefinir;
            estatus = Enumerados.EnumEstatus.SnDefinir;
            AdmPorDivisa = Enumerados.EnumAdministradorPorDivisa.SnDefinir;
            departamento = "";
            codigoDepartamento = "";
            grupo = "";
            codigoGrupo = "";
            marca = "";
            tasaIva = 0.0m;
            nombreTasaIva = "";
            fechaAlta = DateTime.Now.Date;
            fechaBaja = null;
            fechaUltActualizacion = null;
            tipoABC = "";
            comentarios = "";
            advertencia = "";
            presentacion = "";
        }


        public string Empaque 
        {
            get 
            { 
                var r="";
                r = empaqueCompra + "(" + contenidoCompra.ToString("n0") + ")";
                return r;
            } 
        }

        public string Impuesto 
        { 
            get 
            {
                var r = "EXENTO";
                if (tasaIva != 0.0m) 
                {
                    r = tasaIva.ToString("n2").PadLeft(5, '0') + "%," + nombreTasaIva;
                }
                return r;
            } 
        }
    }

}