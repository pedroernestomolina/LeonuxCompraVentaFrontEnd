﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Consultor
{

    public class data
    {

        private OOB.Producto.Entidad.Ficha _ficha;
        private Precio _precio;
        private Existencia _existencia;


        public string CodigoPrd { get { return _ficha.CodigoPrd; } }
        public string CodigoPlu { get { return _ficha.CodigoPLU; } }
        public string CodigoBarra { get; set; }
        public string NombrePrd { get { return _ficha.NombrePrd; } }
        public string Departamento { get { return _ficha.NombreDepartamento; } }
        public string Grupo { get { return _ficha.NombreGrupo; } }
        public string Marca { get { return _ficha.Marca; } }
        public string Modelo { get { return _ficha.Modelo; } }
        public string Pasillo { get { return _ficha.Pasillo; } }
        public decimal Tasa { get { return _ficha.TasaImpuesto; } }
        public string Referencia { get { return _ficha.Referencia; } }
        public Precio Precio { get { return _precio; } }
        public Existencia Existencia { get { return _existencia; } }


        public bool IsInactivo { get; set; } 
        public string TasaIvaDescripcion 
        {
            get 
            {
                var rt = "EXENTO";
                if (Tasa > 0) 
                {
                    rt = Tasa.ToString("n2") + "%";
                }
                return rt ;
            }
        }


        public data() 
        {
            _precio = new Precio();
            _existencia = new Existencia();
        }

        public void setData(OOB.Producto.Entidad.Ficha fichaPrd, string _tarifaPrecio, OOB.Producto.Existencia.Entidad.Ficha fichaEx)
        {
            _ficha = fichaPrd;
            _precio.Limpiar();
            _existencia.Limpiar();

            switch (_tarifaPrecio)
            {
                case "1":
                    _precio.setData(_ficha.pneto_1 , _ficha.TasaImpuesto, _ficha.contenido_1, _ficha.empaque_1, _ficha.pdf_1);
                    _existencia.setData(fichaEx, _ficha.contenido_1);
                    break;
                case "2":
                    _precio.setData(_ficha.pneto_2, _ficha.TasaImpuesto, _ficha.contenido_2, _ficha.empaque_2, _ficha.pdf_2);
                    break;
                case "3":
                    _precio.setData(_ficha.pneto_3, _ficha.TasaImpuesto, _ficha.contenido_3, _ficha.empaque_3, _ficha.pdf_3);
                    break;
                case "4":
                    _precio.setData(_ficha.pneto_4, _ficha.TasaImpuesto, _ficha.contenido_4, _ficha.empaque_4, _ficha.pdf_4);
                    break;
                case "5":
                    _precio.setData(_ficha.pneto_5, _ficha.TasaImpuesto, _ficha.contenido_5, _ficha.empaque_5, _ficha.pdf_5);
                    break;
            }
        }

    }

}