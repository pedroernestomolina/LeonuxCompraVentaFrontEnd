﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Principal
{
    
    public class Gestion
    {


        private Administrador.Gestion _gestionAdm;
        private Reportes.Gestion _gestionRep;
        private Maestros.Gestion _gestionMaestro;
        private Cliente.Administrador.Gestion _gestionAdmCliente;
        private ReportesCliente.Gestion _gestionRepCli;


        public string BD_Ruta { get { return Sistema.Instancia; } }
        public string BD_Nombre { get { return Sistema.BaseDatos; } }
        public string Version { get { return "Ver. " + Application.ProductVersion; } }
        public string Host { get { return Sistema.Instancia + "/" + Sistema.BaseDatos; } }
        public string Usuario { get { return Sistema.Usuario.codigo + Environment.NewLine + Sistema.Usuario.nombre; } }


        public Gestion()
        {
            _gestionAdm = new Administrador.Gestion();
            _gestionRep = new Reportes.Gestion();
            _gestionMaestro = new Maestros.Gestion();
            _gestionAdmCliente = new Cliente.Administrador.Gestion();
            _gestionRepCli = new ReportesCliente.Gestion();
        }


        public void Inicializa()
        {
        }

        PrincipalFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                frm = new PrincipalFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Sistema_Empresa_GetFicha();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            Sistema.DatosEmpresa = r01.Entidad;

            return rt;
        }


        public void AdministradorDoc()
        {
            _gestionAdm.setGestion(new Administrador.Documentos.Gestion());
            _gestionAdm.Inicializa();
            _gestionAdm.Inicia();
        }

        public void Reporte_GeneralDocumentos()
        {
            Reporte(new Reportes.Modo.GeneralDocumento.Gestion());
        }

        public void Reporte_GeneralPorDepartamento()
        {
            Reporte(new Reportes.Modo.GeneralPorDepartamento.Gestion());
        }

        public void Reporte_GeneralPorGrupo()
        {
            Reporte(new Reportes.Modo.GeneralPorGrupo.Gestion());
        }

        private void Reporte(Reportes.IGestion gestion)
        {
            var r00 = Sistema.MyData.Permiso_Reportes(Sistema.Usuario.idGrupo);
            if (r00.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionRep.setGestion(gestion);
                _gestionRep.Inicializa();
                _gestionRep.Inicia();
            }
        }

        public void MaestroGrupo()
        {
            var r00 = Sistema.MyData.Permiso_ClienteGrupo(Sistema.Usuario.idGrupo);
            if (r00.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionMaestro.setGestion(new Maestros.Grupo.Gestion());
                _gestionMaestro.Inicializa();
                _gestionMaestro.Inicia();
            }
        }

        public void MaestroZona()
        {
            var r00 = Sistema.MyData.Permiso_ClienteZona(Sistema.Usuario.idGrupo);
            if (r00.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionMaestro.setGestion(new Maestros.Zona.Gestion());
                _gestionMaestro.Inicializa();
                _gestionMaestro.Inicia();
            }
        }

        public void MaestroClientes()
        {
            var r00 = Sistema.MyData.Permiso_Cliente (Sistema.Usuario.idGrupo);
            if (r00.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionAdmCliente.Inicializa();
                _gestionAdmCliente.Inicia();
            }
        }

        public void Reporte_Resumen()
        {
            Reporte(new Reportes.Modo.Resumen.Gestion());
        }

        public void Reporte_GeneralPorProducto()
        {
            Reporte(new Reportes.Modo.GeneralPorProducto.Gestion());
        }

        public void Reporte_GeneralDocumentoDetalle()
        {
            Reporte(new Reportes.Modo.GeneralDocumentoDetalle.Gestion());
        }

        public void Reporte_Consolidado()
        {
            Reporte(new Reportes.Modo.Consolidado.Gestion());
        }

        public void Reporte_Cliente_Maestro()
        {
            ReporteCliente(new ReportesCliente.Modo.Maestro.Gestion());
        }

        private void ReporteCliente(ReportesCliente.IGestion gestion)
        {
            var r00 = Sistema.MyData.Permiso_Cliente_Reportes(Sistema.Usuario.idGrupo);
            if (r00.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionRepCli.setGestion(gestion);
                _gestionRepCli.Inicializa();
                _gestionRepCli.Inicia();
            }
        }

    }

}