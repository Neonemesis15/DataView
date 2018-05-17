using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models.Backus
{
    //Creado por:outs, el 19/05/2014
    public class DmBackusReporteParametro_Request
    {
        [JsonProperty("a")]
        public M_ReporteParametro oReporteParametro { get; set; }
    }
    public class M_ReporteParametro
    {
        [JsonProperty("a")]
        public string CodEquipo { get; set; }
        [JsonProperty("b")]
        public string CodCanal { get; set; }
        [JsonProperty("c")]
        public int CodOficina { get; set; }
        [JsonProperty("d")]
        public int CodCono { get; set; }
        [JsonProperty("e")]
        public string CodDepartamento { get; set; }
        [JsonProperty("f")]
        public string CodProvincia { get; set; }
        [JsonProperty("g")]
        public string CodDistrito { get; set; }
        [JsonProperty("h")]
        public string CodAnio { get; set; }
        [JsonProperty("i")]
        public string CodMes { get; set; }
        [JsonProperty("j")]
        public int CodPeriodo { get; set; }
        [JsonProperty("k")]
        public string FecIni { get; set; }
        [JsonProperty("l")]
        public string FecFin { get; set; }
        [JsonProperty("m")]
        public int CodCadena { get; set; }
        [JsonProperty("n")]
        public string CodPdv { get; set; }
        [JsonProperty("o")]
        public int CodEmpresa { get; set; }
        [JsonProperty("p")]
        public string CodCategoria { get; set; }
        [JsonProperty("q")]
        public string CodSubCategoria { get; set; }
        [JsonProperty("r")]
        public int CodMarca { get; set; }
        [JsonProperty("s")]
        public string CodProducto { get; set; }
        [JsonProperty("t")]
        public string CodPerfil { get; set; }
        [JsonProperty("u")]
        public int CodUsuario { get; set; }
        [JsonProperty("v")]
        public int CodReporte { get; set; }
        [JsonProperty("w")]
        public string CodEstado { get; set; }
    }

    //Creado por:outs, el 19/05/2014
    public class GetDmBackusReportePrecio_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReportePrecio> oListM_DmBackusReportePrecio { get; set; }
    }
    public class M_DmBackusReportePrecio
    {
        [JsonProperty("a")]
        public string Empresa { get; set; }
        [JsonProperty("b")]
        public string Categoria { get; set; }
        [JsonProperty("c")]
        public string SubCategoria { get; set; }
        [JsonProperty("d")]
        public string Marca { get; set; }
        [JsonProperty("e")]
        public string SkuProducto { get; set; }
        [JsonProperty("f")]
        public string Producto { get; set; }
        [JsonProperty("g")]
        public string PrecioCosto { get; set; }
        [JsonProperty("h")]
        public string PrecioReventa { get; set; }
        [JsonProperty("i")]
        public string PrecioPublico { get; set; }
        [JsonProperty("j")]
        public string PrecioOferta { get; set; }
        [JsonProperty("k")]
        public string CodTipo { get; set; }
        [JsonProperty("l")]
        public string Tipo { get; set; }
        [JsonProperty("m")]
        public string FecIni { get; set; }
        [JsonProperty("n")]
        public string FecFin { get; set; }
        [JsonProperty("o")]
        public string CodMecanica { get; set; }
        [JsonProperty("p")]
        public string Mecanica { get; set; }
        [JsonProperty("q")]
        public string UrlFoto { get; set; }
        [JsonProperty("r")]
        public string Comentario { get; set; }
        [JsonProperty("s")]
        public bool Validado { get; set; }
        [JsonProperty("t")]
        public int IdRegDet { get; set; }
    }
    //Creado por:outs, el 20/05/2014
    public class GetDmBackusReporteQuiebre_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteQuiebre> oListM_DmBackusReporteQuiebre { get; set; }
    }

    public class M_DmBackusReporteQuiebre
    {

        /// <summary>
        /// Atributos omitidos se Add  15/08/2014 CH
        /// </summary>
        [JsonProperty("s")]
        public string Cod_PDV { get; set; }
        [JsonProperty("t")]
        public string pdv_Name { get; set; }
        //Fin Atributos omitidos se Add  15/08/2014 CH

        [JsonProperty("a")]
        public string Empresa { get; set; }
        [JsonProperty("b")]
        public string Categoria { get; set; }
        [JsonProperty("c")]
        public string SubCategoria { get; set; }
        [JsonProperty("d")]
        public string Marca { get; set; }
        [JsonProperty("e")]
        public string SkuProducto { get; set; }
        [JsonProperty("f")]
        public string Producto { get; set; }
        [JsonProperty("g")]
        public string CodTipo { get; set; }
        [JsonProperty("h")]
        public string Tipo { get; set; }
        [JsonProperty("i")]
        public string UrlFoto { get; set; }
        [JsonProperty("j")]
        public string CodTipo2 { get; set; }
        [JsonProperty("k")]
        public string Tipo2 { get; set; }
        [JsonProperty("l")]
        public string CodTipo3 { get; set; }
        [JsonProperty("m")]
        public string Tipo3 { get; set; }
        [JsonProperty("n")]
        public string FecIni { get; set; }
        [JsonProperty("o")]
        public string FecFin { get; set; }
        [JsonProperty("p")]
        public string Comentario { get; set; }
        /// <summary>
        /// Atributos omitidos se Add  15/08/2014 CH
        /// </summary>
        [JsonProperty("u")]
        public string Fec_reg_Cel { get; set; }
        [JsonProperty("v")]
        public string CreateBy { get; set; }
        [JsonProperty("w")]
        public string DateBy { get; set; }
        [JsonProperty("x")]
        public string ModiBy { get; set; }
        [JsonProperty("y")]
        public string DateModiBy { get; set; }
        //FinAtributos omitidos se Add  15/08/2014 CH
        [JsonProperty("q")]
        public bool Validado { get; set; }
        [JsonProperty("r")]
        public int IdRegDet { get; set; }
    }
    //Creado por:outs, el 20/05/2014
    public class GetDmBackusReporteStock_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteStock> oListM_DmBackusReporteStock { get; set; }
    }

    public class M_DmBackusReporteStock
    {
        [JsonProperty("a")]
        public string Empresa { get; set; }
        [JsonProperty("b")]
        public string Categoria { get; set; }
        [JsonProperty("c")]
        public string SubCategoria { get; set; }
        [JsonProperty("d")]
        public string Marca { get; set; }
        [JsonProperty("e")]
        public string FechaConteo { get; set; }
        [JsonProperty("f")]
        public string SkuProducto { get; set; }
        [JsonProperty("g")]
        public string Producto { get; set; }
        [JsonProperty("h")]
        public int CantidadUno { get; set; }
        [JsonProperty("i")]
        public int CantidadDos { get; set; }
        [JsonProperty("j")]
        public string CodTipo { get; set; }
        [JsonProperty("k")]
        public string Tipo { get; set; }
        [JsonProperty("l")]
        public string UrlFoto { get; set; }
        [JsonProperty("m")]
        public bool Validado { get; set; }
        [JsonProperty("n")]
        public int IdRegDet { get; set; }
    }
    //Creado por:outs, el 20/05/2014
    public class GetDmBackusReporteVisibilidad_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteVisibilidad> oListM_DmBackusReporteVisibilidad { get; set; }
    }

    public class M_DmBackusReporteVisibilidad
    {
        [JsonProperty("a")]
        public string Empresa { get; set; }
        [JsonProperty("b")]
        public string codTipoVisibilidad { get; set; }
        [JsonProperty("c")]
        public string Visibilidad { get; set; }
        [JsonProperty("d")]
        public string CodElemento { get; set; }
        [JsonProperty("e")]
        public string Elemento { get; set; }
        [JsonProperty("f")]
        public int ElementoCantidad { get; set; }
        [JsonProperty("g")]
        public string CodTipo { get; set; }
        [JsonProperty("h")]
        public string Tipo { get; set; }
        [JsonProperty("i")]
        public string Categoria { get; set; }
        [JsonProperty("j")]
        public string SubCategoria { get; set; }
        [JsonProperty("k")]
        public string Marca { get; set; }
        [JsonProperty("l")]
        public string FecIni { get; set; }
        [JsonProperty("m")]
        public string FecFin { get; set; }
        [JsonProperty("n")]
        public bool Validado { get; set; }
        [JsonProperty("o")]
        public string UrlFoto { get; set; }
        [JsonProperty("p")]
        public string Comentario { get; set; }
        [JsonProperty("r")]
        public int IdRegDet { get; set; }
    }
    //Creado por:outs, el 20/05/2014
    public class GetDmBackusReporteParticipacion_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteParticipacion> oListM_DmBackusReporteParticipacion { get; set; }
    }

    public class M_DmBackusReporteParticipacion
    {
        [JsonProperty("a")]
        public string Empresa { get; set; }
        [JsonProperty("b")]
        public string Categoria { get; set; }
        [JsonProperty("c")]
        public string SubCategoria { get; set; }
        [JsonProperty("d")]
        public string Marca { get; set; }
        [JsonProperty("e")]
        public string CodParticipacion { get; set; }
        [JsonProperty("f")]
        public string Participacion { get; set; }
        [JsonProperty("g")]
        public int CantidadUno { get; set; }
        [JsonProperty("h")]
        public int CantidadDos { get; set; }
        [JsonProperty("i")]
        public string CodTipo { get; set; }
        [JsonProperty("j")]
        public string Tipo { get; set; }
        [JsonProperty("k")]
        public string UrlFoto { get; set; }
        [JsonProperty("l")]
        public int TotalUno { get; set; }
        [JsonProperty("m")]
        public int TotalDos { get; set; }
        [JsonProperty("n")]
        public bool Validado { get; set; }
        [JsonProperty("o")]
        public int IdRegDet { get; set; }
    }
    //Creado por:outs, el 20/05/2014
    public class GetDmBackusReporteActividad_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteActividad> oListM_DmBackusReporteActividad { get; set; }
    }

    public class M_DmBackusReporteActividad
    {
        [JsonProperty("a")]
        public string Empresa { get; set; }
        [JsonProperty("b")]
        public string Categoria { get; set; }
        [JsonProperty("c")]
        public string SubCategoria { get; set; }
        [JsonProperty("d")]
        public string Marca { get; set; }
        [JsonProperty("e")]
        public string CodProducto { get; set; }
        [JsonProperty("f")]
        public string Producto { get; set; }
        [JsonProperty("g")]
        public string CodObjetivo { get; set; }
        [JsonProperty("h")]
        public string Objetivo { get; set; }
        [JsonProperty("i")]
        public string CodActividad { get; set; }
        [JsonProperty("j")]
        public string Actividad { get; set; }
        [JsonProperty("k")]
        public string OtraActividad { get; set; }
        [JsonProperty("l")]
        public string Mecanica { get; set; }
        [JsonProperty("m")]
        public string FecIni { get; set; }
        [JsonProperty("n")]
        public string FecFin { get; set; }
        [JsonProperty("o")]
        public string CodElemento { get; set; }
        [JsonProperty("p")]
        public string Elemento { get; set; }
        [JsonProperty("q")]
        public string PrecioCosto { get; set; }
        [JsonProperty("r")]
        public string PrecioReventa { get; set; }
        [JsonProperty("s")]
        public string PrecioPublico { get; set; }
        [JsonProperty("t")]
        public string PrecioOferta { get; set; }
        [JsonProperty("u")]
        public string UrlFotoUno { get; set; }
        [JsonProperty("v")]
        public string UrlFotoDos { get; set; }
        [JsonProperty("w")]
        public string Validado { get; set; }
        [JsonProperty("y")]
        public int IdRegDet { get; set; }
    }
    //Creado por:outs, el 20/05/2014
    public class GetDmBackusReporteVigencia_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteVigencia> oListM_DmBackusReporteVigencia { get; set; }
    }

    public class M_DmBackusReporteVigencia
    {
        [JsonProperty("a")]
        public string Empresa { get; set; }
        [JsonProperty("b")]
        public string Categoria { get; set; }
        [JsonProperty("c")]
        public string SubCategoria { get; set; }
        [JsonProperty("d")]
        public string Marca { get; set; }
        [JsonProperty("e")]
        public string CodProducto { get; set; }
        [JsonProperty("f")]
        public string Producto { get; set; }
        [JsonProperty("g")]
        public int Cantidad { get; set; }
        [JsonProperty("h")]
        public string Fecha { get; set; }
        [JsonProperty("i")]
        public string UrlFoto { get; set; }
        [JsonProperty("j")]
        public bool Validado { get; set; }
        [JsonProperty("k")]
        public int IdRegDet { get; set; }
    }
    //Creado por:outs, el 20/05/2014
    public class GetDmBackusReporteCodigoPDV_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteCodigoPDV> oListM_DmBackusReporteCodigoPDV { get; set; }
    }

    public class M_DmBackusReporteCodigoPDV
    {
        [JsonProperty("a")]
        public int CodDistribuidora { get; set; }
        [JsonProperty("b")]
        public string Distribuidora { get; set; }
        [JsonProperty("c")]
        public string CodPDV { get; set; }
        [JsonProperty("d")]
        public bool Validado { get; set; }
        [JsonProperty("e")]
        public int IdRegDet { get; set; }
    }
    //Creado por:outs, el 20/05/2014
    public class GetDmBackusReporteVenta_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteVenta> oListM_DmBackusReporteVenta { get; set; }
    }

    public class M_DmBackusReporteVenta
    {
        [JsonProperty("a")]
        public string Empresa { get; set; }
        [JsonProperty("b")]
        public string Categoria { get; set; }
        [JsonProperty("c")]
        public string SubCategoria { get; set; }
        [JsonProperty("d")]
        public string Marca { get; set; }
        [JsonProperty("e")]
        public string CodProducto { get; set; }
        [JsonProperty("f")]
        public string Producto { get; set; }
        [JsonProperty("g")]
        public int Cantidad { get; set; }
        [JsonProperty("h")]
        public string CodTipo { get; set; }
        [JsonProperty("i")]
        public string Tipo { get; set; }
        [JsonProperty("j")]
        public string UrlFoto { get; set; }
        [JsonProperty("k")]
        public bool Validado { get; set; }
        [JsonProperty("l")]
        public int IdRegDet { get; set; }
    }
    //Creado por:outs, el 20/05/2014
    public class GetDmBackusReporteMultimedia_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteMultimedia> oListM_DmBackusReporteMultimedia { get; set; }
    }

    public class M_DmBackusReporteMultimedia
    {
        [JsonProperty("a")]
        public string Empresa { get; set; }
        [JsonProperty("b")]
        public string CodTipoMultimedia { get; set; }
        [JsonProperty("c")]
        public string TipoMultimedia { get; set; }
        [JsonProperty("d")]
        public string Categoria { get; set; }
        [JsonProperty("e")]
        public string SubCategoria { get; set; }
        [JsonProperty("f")]
        public string Marca { get; set; }
        [JsonProperty("g")]
        public string UrlFoto { get; set; }
        [JsonProperty("h")]
        public bool Validado { get; set; }
        [JsonProperty("i")]
        public int IdRegDet { get; set; }
    }
    //Creado por:outs, el 20/05/2014
    public class GetDmBaclusReporteComentario_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteComentario> oListM_DmBackusReporteComentario { get; set; }
    }

    public class M_DmBackusReporteComentario
    {
        [JsonProperty("a")]
        public string Comentario { get; set; }
        [JsonProperty("b")]
        public string UrlFoto { get; set; }
        [JsonProperty("c")]
        public bool Validado { get; set; }
        [JsonProperty("d")]
        public int IdRegDet { get; set; }
    }

    //Creado por:outs, el 20/05/2014
    public class GetDmBackusReporteInicioFinDia_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteInicioFinDia> oListM_DmBackusReporteInicioFinDia { get; set; }
    }

    public class M_DmBackusReporteInicioFinDia
    {
        [JsonProperty("a")]
        public string FecIni { get; set; }
        [JsonProperty("b")]
        public string LatitudIni { get; set; }
        [JsonProperty("c")]
        public string LongitudIni { get; set; }
        [JsonProperty("d")]
        public string FechaCelIni { get; set; }
        [JsonProperty("e")]
        public string FechaBdIni { get; set; }
        [JsonProperty("f")]
        public string FecFin { get; set; }
        [JsonProperty("g")]
        public string Latitud { get; set; }
        [JsonProperty("h")]
        public string Longitud { get; set; }
        [JsonProperty("i")]
        public string FechaCelFin { get; set; }
        [JsonProperty("j")]
        public string FechaBdFin { get; set; }
        [JsonProperty("k")]
        public string Validado { get; set; }
        [JsonProperty("l")]
        public int IdRegDet { get; set; }
        [JsonProperty("m")]
        public int CodGestor { get; set; }
        [JsonProperty("n")]
        public string Gestor { get; set; }
    }
    //Creado por:outs, el 20/05/2014
    public class GetDmBackusReporteUbicacion_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteUbicacion> oListM_DmBackusReporteUbicacion { get; set; }
    }

    public class M_DmBackusReporteUbicacion
    {
        [JsonProperty("a")]
        public string Latitud { get; set; }
        [JsonProperty("b")]
        public string Longitud { get; set; }
        [JsonProperty("c")]
        public bool Validado { get; set; }
        [JsonProperty("d")]
        public int IdRegDet { get; set; }
        [JsonProperty("e")]
        public string CodPDV { get; set; }
        [JsonProperty("f")]
        public string NombrePDV { get; set; }
    }
    //Creado por:outs, el 20/05/2014
    public class GetDmBackusReporteVisita_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteVisita> oListM_DmBackusReporteVisita { get; set; }
    }

    public class M_DmBackusReporteVisita
    {
        [JsonProperty("a")]
        public string Canal { get; set; }
        [JsonProperty("b")]
        public string Oficina { get; set; }
        [JsonProperty("c")]
        public string Cono { get; set; }
        [JsonProperty("d")]
        public string Departamento { get; set; }
        [JsonProperty("e")]
        public string Provincia { get; set; }
        [JsonProperty("f")]
        public string Distrito { get; set; }
        [JsonProperty("g")]
        public string Cadena { get; set; }
        [JsonProperty("h")]
        public string CodPDV { get; set; }
        [JsonProperty("i")]
        public string NombrePDV { get; set; }
        [JsonProperty("j")]
        public string FecCel { get; set; }
        [JsonProperty("k")]
        public string FecBd { get; set; }
        [JsonProperty("l")]
        public string Perfil { get; set; }
        [JsonProperty("m")]
        public string CodUsuario { get; set; }
        [JsonProperty("n")]
        public string Usuario { get; set; }
        [JsonProperty("o")]
        public string Latitud { get; set; }
        [JsonProperty("p")]
        public string Longitud { get; set; }
        [JsonProperty("q")]
        public string DateBy { get; set; }
        [JsonProperty("r")]
        public string FecModi { get; set; }
        [JsonProperty("s")]
        public string CodUsuarioModi { get; set; }
        [JsonProperty("t")]
        public string UsuarioModi { get; set; }
        [JsonProperty("u")]
        public int CodPeriodo { get; set; }
        [JsonProperty("v")]
        public string Periodo { get; set; }
        [JsonProperty("w")]
        public bool Validado { get; set; }
        [JsonProperty("y")]
        public int IdRegDet { get; set; }
    }

    //Creado por:outs, el 20/05/2014
    public class GetDmBackusReporteMotivo_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteMotivo> oListM_DmBackusReporteMotivo { get; set; }
    }

    public class M_DmBackusReporteMotivo
    {
        [JsonProperty("a")]
        public string CodMotivo { get; set; }
        [JsonProperty("b")]
        public string Motivo { get; set; }
        [JsonProperty("c")]
        public string UrlFoto { get; set; }
        [JsonProperty("d")]
        public bool Validado { get; set; }
        [JsonProperty("e")]
        public int IdRegDet { get; set; }
    }

    //Creado por:outs, el 30/05/2014
    public class GetDmBackusReporteFotografico_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusReporteFotografico> oListM_DmBackusReporteFotografico { get; set; }
    }

    public class M_DmBackusReporteFotografico
    {
        [JsonProperty("a")]
        public int IdRegDet { get; set; }
        [JsonProperty("b")]
        public int idPerson { get; set; }
        [JsonProperty("c")]
        public string Persona { get; set; }
        [JsonProperty("d")]
        public string id_Planning { get; set; }
        [JsonProperty("e")]
        public string Empresa { get; set; }
        [JsonProperty("f")]
        public string id_Tipo_Reporte { get; set; }
        [JsonProperty("g")]
        public string TipoReporte { get; set; }
        [JsonProperty("h")]
        public string Categoria { get; set; }
        [JsonProperty("i")]
        public string SubCategoria { get; set; }
        [JsonProperty("j")]
        public int id_brand { get; set; }
        [JsonProperty("k")]
        public string Marca { get; set; }
        [JsonProperty("l")]
        public string SkuProducto { get; set; }
        [JsonProperty("m")]
        public string Producto { get; set; }
        [JsonProperty("n")]
        public string Fec_Reg_Cel { get; set; }
        [JsonProperty("o")]
        public string NomFoto { get; set; }
        [JsonProperty("p")]
        public string Comentario { get; set; }
        [JsonProperty("q")]
        public string Latitud { get; set; }
        [JsonProperty("r")]
        public string Longitud { get; set; }
        [JsonProperty("s")]
        public string CodPDV { get; set; }
        [JsonProperty("t")]
        public string NombrePDV { get; set; }
        [JsonProperty("u")]
        public string FecIni { get; set; }
        [JsonProperty("v")]
        public string FecFin { get; set; }
        [JsonProperty("w")]
        public bool Validado { get; set; }
    }
    //Creado por:outs, el 30/05/2014

    public class GetDmBackusDetalleFoto_Request
    {
        [JsonProperty("a")]
        public string id_Planning { get; set; }
        [JsonProperty("b")]
        public string ClientPDV_Code { get; set; }
    }
    public class GetDmBackusDetalleFoto_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_DmBackusDetalleFoto> oListM_DmBackusDetalleFoto { get; set; }
    }

    public class M_DmBackusDetalleFoto
    {
        [JsonProperty("a")]
        public int Id { get; set; }
        [JsonProperty("b")]
        public string Nombre_Foto { get; set; }
    }

    //Validacion

    //Creado por:outs, el 29/05/2014
    public class ValidarInvalidarReporteDmBackus_Request
    {
        [JsonProperty("a")]
        public Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte ValidarInvalidarReporte_req { get; set; }
    }

    public class ValidarInvalidarReporteDmBackus_Response : BaseResponse
    {
        [JsonProperty("a")]
        public string ValidarInvalidarReporte { get; set; }
    }

    //Fin de validación


    //actualización

    //Consolidados
    public class Modelo_Backus
    {
        [JsonProperty("a")]
        public List<Backus_Consolidado_Cabecera> oLs { get; set; }
    }

    public class Backus_Consolidado_Cabecera
    {
        [JsonProperty("a")]
        public int cab_id { get; set; }

        [JsonProperty("b")]
        public string cab_cabecera { get; set; }

        [JsonProperty("c")]
        public string cab_descripcion { get; set; }
    }
    //fin consolidados
    public class ActualizarReporteDmBackus_Request
    {
        [JsonProperty("a")]
        public Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusActualizarReporte ActualizarReporte_req { get; set; }
    }
    public class ActualizarReporteDmBackus_Response : BaseResponse
    {
        [JsonProperty("a")]
        public string msjActualizarReporteDmBackus { get; set; }
    }

    //fin de actualización
    public class M_ReportesBackus_Services
    {
        //Services method
        public List<M_DmBackusReportePrecio> GetDmBackusReportePrecio(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReportePrecio(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReportePrecio_Response response = HelperJson.Deserialize<GetDmBackusReportePrecio_Response>(responseJSON);

            return response.oListM_DmBackusReportePrecio;
        }
        //Services method
        public List<M_DmBackusReporteQuiebre> GetDmBackusReporteQuiebre(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteQuiebre(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteQuiebre_Response response = HelperJson.Deserialize<GetDmBackusReporteQuiebre_Response>(responseJSON);

            return response.oListM_DmBackusReporteQuiebre;
        }

        //Services method
        public List<M_DmBackusReporteStock> GetDmBackusReporteStock(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteStock(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteStock_Response response = HelperJson.Deserialize<GetDmBackusReporteStock_Response>(responseJSON);

            return response.oListM_DmBackusReporteStock;
        }

        //Services method
        public List<M_DmBackusReporteVisibilidad> GetDmBackusReporteVisibilidad(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteVisibilidad(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteVisibilidad_Response response = HelperJson.Deserialize<GetDmBackusReporteVisibilidad_Response>(responseJSON);

            return response.oListM_DmBackusReporteVisibilidad;
        }

        //Services method
        public List<M_DmBackusReporteParticipacion> GetDmBackusReporteParticipacion(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteParticipacion(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteParticipacion_Response response = HelperJson.Deserialize<GetDmBackusReporteParticipacion_Response>(responseJSON);

            return response.oListM_DmBackusReporteParticipacion;
        }

        //Services method
        public List<M_DmBackusReporteActividad> GetDmBackusReporteActividad(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteActividad(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteActividad_Response response = HelperJson.Deserialize<GetDmBackusReporteActividad_Response>(responseJSON);

            return response.oListM_DmBackusReporteActividad;
        }
        //Services method
        public List<M_DmBackusReporteVigencia> GetDmBackusReporteVigencia(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteVigencia(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteVigencia_Response response = HelperJson.Deserialize<GetDmBackusReporteVigencia_Response>(responseJSON);

            return response.oListM_DmBackusReporteVigencia;
        }

        //Services method
        public List<M_DmBackusReporteCodigoPDV> GetDmBackusReporteCodigoPDV(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteCodigoPDV(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteCodigoPDV_Response response = HelperJson.Deserialize<GetDmBackusReporteCodigoPDV_Response>(responseJSON);

            return response.oListM_DmBackusReporteCodigoPDV;
        }

        //Services method
        public List<M_DmBackusReporteVenta> GetDmBackusReporteVenta(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteVenta(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteVenta_Response response = HelperJson.Deserialize<GetDmBackusReporteVenta_Response>(responseJSON);

            return response.oListM_DmBackusReporteVenta;
        }
        //Services method
        public List<M_DmBackusReporteMultimedia> GetDmBackusReporteMultimedia(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteMultimedia(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteMultimedia_Response response = HelperJson.Deserialize<GetDmBackusReporteMultimedia_Response>(responseJSON);

            return response.oListM_DmBackusReporteMultimedia;
        }
        //Services method
        public List<M_DmBackusReporteComentario> GetDmBackusReporteComentario(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteComentario(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBaclusReporteComentario_Response response = HelperJson.Deserialize<GetDmBaclusReporteComentario_Response>(responseJSON);

            return response.oListM_DmBackusReporteComentario;
        }
        //Services method
        public List<M_DmBackusReporteInicioFinDia> GetDmBackusReporteInicioFinDia(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteInicioFinDia(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteInicioFinDia_Response response = HelperJson.Deserialize<GetDmBackusReporteInicioFinDia_Response>(responseJSON);

            return response.oListM_DmBackusReporteInicioFinDia;
        }

        //Services method
        public List<M_DmBackusReporteUbicacion> GetDmBackusReporteUbicacion(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteUbicacion(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteUbicacion_Response response = HelperJson.Deserialize<GetDmBackusReporteUbicacion_Response>(responseJSON);

            return response.oListM_DmBackusReporteUbicacion;
        }

        //Services method
        public List<M_DmBackusReporteVisita> GetDmBackusReporteVisita(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteVisita(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteVisita_Response response = HelperJson.Deserialize<GetDmBackusReporteVisita_Response>(responseJSON);

            return response.oListM_DmBackusReporteVisita;
        }
        //Services method
        public List<M_DmBackusReporteMotivo> GetDmBackusReporteMotivo(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteMotivo(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteMotivo_Response response = HelperJson.Deserialize<GetDmBackusReporteMotivo_Response>(responseJSON);

            return response.oListM_DmBackusReporteMotivo;
        }

        //Services method
        public List<M_DmBackusReporteFotografico> GetDmBackusReporteFotografico(DmBackusReporteParametro_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<DmBackusReporteParametro_Request>(request);

            string responseJSON = client.GetDmBackusReporteFotografico(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusReporteFotografico_Response response = HelperJson.Deserialize<GetDmBackusReporteFotografico_Response>(responseJSON);

            return response.oListM_DmBackusReporteFotografico;
        }
        //Services method
        public List<M_DmBackusDetalleFoto> GetDmBackusDetalleFoto(GetDmBackusDetalleFoto_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<GetDmBackusDetalleFoto_Request>(request);

            string responseJSON = client.GetDmBackusDetalleFoto(requestJSON);
            client.Close();//liberamos la conexion

            GetDmBackusDetalleFoto_Response response = HelperJson.Deserialize<GetDmBackusDetalleFoto_Response>(responseJSON);

            return response.oListM_DmBackusDetalleFoto;
        }
        //Validacion 

        //Services method
        public string ValidarInvalidarReporteDmBackus(ValidarInvalidarReporteDmBackus_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<ValidarInvalidarReporteDmBackus_Request>(request);

            string responseJSON = client.ValidarInvalidarReporteDmBackus(requestJSON);
            client.Close();//liberamos la conexion

            ValidarInvalidarReporteDmBackus_Response response = HelperJson.Deserialize<ValidarInvalidarReporteDmBackus_Response>(responseJSON);

            return response.ValidarInvalidarReporte;
        }


        //Fin de Validación

        //actualización 


        //Services method
        public string ActualizarReporteDmBackus(ActualizarReporteDmBackus_Request request)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string requestJSON = HelperJson.Serialize<ActualizarReporteDmBackus_Request>(request);

            string responseJSON = client.ActualizarReporteDmBackus(requestJSON);
            client.Close();//liberamos la conexion

            ActualizarReporteDmBackus_Response response = HelperJson.Deserialize<ActualizarReporteDmBackus_Response>(responseJSON);

            return response.msjActualizarReporteDmBackus;
        }


        //fin actualización

        //consolidados
        public List<Backus_Consolidado_Cabecera> ObtenerCabecerasConsolidadoPrecio(M_ReporteParametro oE_ReporteParametro)
        {
            try
            {
                Lucky.Data.Conexion oCoon = new Lucky.Data.Conexion();
                System.Data.SqlClient.SqlDataReader oRe = oCoon.ejecutarDataReader("UP_GEN_DM_ConsolidadoBackusReportePrecio_cabecera"
                  , oE_ReporteParametro.CodCanal
                  , oE_ReporteParametro.CodEquipo
                  , oE_ReporteParametro.CodAnio
                  , oE_ReporteParametro.CodMes
                  , oE_ReporteParametro.FecIni
                  , oE_ReporteParametro.FecFin
                  , oE_ReporteParametro.CodOficina
                  , oE_ReporteParametro.CodDepartamento
                  , oE_ReporteParametro.CodProvincia
                  , oE_ReporteParametro.CodCono
                  , oE_ReporteParametro.CodDistrito
                  , oE_ReporteParametro.CodCadena
                  , oE_ReporteParametro.CodPdv
                  , oE_ReporteParametro.CodEmpresa
                  , oE_ReporteParametro.CodCategoria
                  , oE_ReporteParametro.CodSubCategoria
                  , oE_ReporteParametro.CodMarca
                  , oE_ReporteParametro.CodProducto
                  , oE_ReporteParametro.CodPerfil
                  , oE_ReporteParametro.CodUsuario
                  , oE_ReporteParametro.CodEstado
                    );

                List<Backus_Consolidado_Cabecera> oLs = new List<Backus_Consolidado_Cabecera>();


                while (oRe.Read())
                {
                    Backus_Consolidado_Cabecera oOj = new Backus_Consolidado_Cabecera();
                    oOj.cab_id = (int)oRe.GetValue(oRe.GetOrdinal("tmp_id"));
                    oOj.cab_cabecera = oRe.GetValue(oRe.GetOrdinal("tmp_cabecera")).ToString();
                    oOj.cab_descripcion = oRe.GetValue(oRe.GetOrdinal("tmp_descripcion")).ToString();
                    oLs.Add(oOj);
                }
                oRe.Close();

                if (oLs.Count > 0) { return oLs; } else { return null; }
            }
            catch (Exception) { return null; }
        }
        public System.Data.DataTable ObtenerResumenConsolidadoPrecio(M_ReporteParametro oE_ReporteParametro)
        {
            try
            {
                Lucky.Data.Conexion oCoon = new Lucky.Data.Conexion();
                System.Data.DataTable dt = oCoon.ejecutarDataTable("UP_GEN_DM_ConsolidadoBackusReportePrecio_resumen"
                  , oE_ReporteParametro.CodCanal
                  , oE_ReporteParametro.CodEquipo
                  , oE_ReporteParametro.CodAnio
                  , oE_ReporteParametro.CodMes
                  , oE_ReporteParametro.FecIni
                  , oE_ReporteParametro.FecFin
                  , oE_ReporteParametro.CodOficina
                  , oE_ReporteParametro.CodDepartamento
                  , oE_ReporteParametro.CodProvincia
                  , oE_ReporteParametro.CodCono
                  , oE_ReporteParametro.CodDistrito
                  , oE_ReporteParametro.CodCadena
                  , oE_ReporteParametro.CodPdv
                  , oE_ReporteParametro.CodEmpresa
                  , oE_ReporteParametro.CodCategoria
                  , oE_ReporteParametro.CodSubCategoria
                  , oE_ReporteParametro.CodMarca
                  , oE_ReporteParametro.CodProducto
                  , oE_ReporteParametro.CodPerfil
                  , oE_ReporteParametro.CodUsuario
                  , oE_ReporteParametro.CodEstado
                    );


                if (dt.Rows.Count > 0) { return dt; } else { return null; }
            }
            catch (Exception) { return null; }
        }
        public System.Data.DataTable ObtenerDetalleConsolidadoPrecio(M_ReporteParametro oE_ReporteParametro)
        {
            try
            {
                Lucky.Data.Conexion oCoon = new Lucky.Data.Conexion();
                System.Data.DataTable dt = oCoon.ejecutarDataTable("UP_GEN_DM_ConsolidadoBackusReportePrecio_detalle"
                  , oE_ReporteParametro.CodCanal
                  , oE_ReporteParametro.CodEquipo
                  , oE_ReporteParametro.CodAnio
                  , oE_ReporteParametro.CodMes
                  , oE_ReporteParametro.FecIni
                  , oE_ReporteParametro.FecFin
                  , oE_ReporteParametro.CodOficina
                  , oE_ReporteParametro.CodDepartamento
                  , oE_ReporteParametro.CodProvincia
                  , oE_ReporteParametro.CodCono
                  , oE_ReporteParametro.CodDistrito
                  , oE_ReporteParametro.CodCadena
                  , oE_ReporteParametro.CodPdv
                  , oE_ReporteParametro.CodEmpresa
                  , oE_ReporteParametro.CodCategoria
                  , oE_ReporteParametro.CodSubCategoria
                  , oE_ReporteParametro.CodMarca
                  , oE_ReporteParametro.CodProducto
                  , oE_ReporteParametro.CodPerfil
                  , oE_ReporteParametro.CodUsuario
                  , oE_ReporteParametro.CodEstado
                    );


                if (dt.Rows.Count > 0) { return dt; } else { return null; }
            }
            catch (Exception) { return null; }
        }

        public List<Backus_Consolidado_Cabecera> ObtenerCabecerasConsolidadoPresencia(M_ReporteParametro oE_ReporteParametro)
        {
            try
            {
                Lucky.Data.Conexion oCoon = new Lucky.Data.Conexion();
                System.Data.SqlClient.SqlDataReader oRe = oCoon.ejecutarDataReader("UP_GEN_DM_ConsolidadoBackusReportePresencia_cabecera"
                  , oE_ReporteParametro.CodCanal
                  , oE_ReporteParametro.CodEquipo
                  , oE_ReporteParametro.CodAnio
                  , oE_ReporteParametro.CodMes
                  , oE_ReporteParametro.FecIni
                  , oE_ReporteParametro.FecFin
                  , oE_ReporteParametro.CodOficina
                  , oE_ReporteParametro.CodDepartamento
                  , oE_ReporteParametro.CodProvincia
                  , oE_ReporteParametro.CodCono
                  , oE_ReporteParametro.CodDistrito
                  , oE_ReporteParametro.CodCadena
                  , oE_ReporteParametro.CodPdv
                  , oE_ReporteParametro.CodEmpresa
                  , oE_ReporteParametro.CodCategoria
                  , oE_ReporteParametro.CodSubCategoria
                  , oE_ReporteParametro.CodMarca
                  , oE_ReporteParametro.CodProducto
                  , oE_ReporteParametro.CodPerfil
                  , oE_ReporteParametro.CodUsuario
                  , oE_ReporteParametro.CodEstado
                    );

                List<Backus_Consolidado_Cabecera> oLs = new List<Backus_Consolidado_Cabecera>();


                while (oRe.Read())
                {
                    Backus_Consolidado_Cabecera oOj = new Backus_Consolidado_Cabecera();
                    oOj.cab_id = (int)oRe.GetValue(oRe.GetOrdinal("tmp_id"));
                    oOj.cab_cabecera = oRe.GetValue(oRe.GetOrdinal("tmp_cabecera")).ToString();
                    oOj.cab_descripcion = oRe.GetValue(oRe.GetOrdinal("tmp_descripcion")).ToString();
                    oLs.Add(oOj);
                }
                oRe.Close();

                if (oLs.Count > 0) { return oLs; } else { return null; }
            }
            catch (Exception) { return null; }
        }
        public System.Data.DataTable ObtenerResumenConsolidadoPresencia(M_ReporteParametro oE_ReporteParametro)
        {
            try
            {
                Lucky.Data.Conexion oCoon = new Lucky.Data.Conexion();
                System.Data.DataTable dt = oCoon.ejecutarDataTable("UP_GEN_DM_ConsolidadoBackusReportePresencia_resumen"
                  , oE_ReporteParametro.CodCanal
                  , oE_ReporteParametro.CodEquipo
                  , oE_ReporteParametro.CodAnio
                  , oE_ReporteParametro.CodMes
                  , oE_ReporteParametro.FecIni
                  , oE_ReporteParametro.FecFin
                  , oE_ReporteParametro.CodOficina
                  , oE_ReporteParametro.CodDepartamento
                  , oE_ReporteParametro.CodProvincia
                  , oE_ReporteParametro.CodCono
                  , oE_ReporteParametro.CodDistrito
                  , oE_ReporteParametro.CodCadena
                  , oE_ReporteParametro.CodPdv
                  , oE_ReporteParametro.CodEmpresa
                  , oE_ReporteParametro.CodCategoria
                  , oE_ReporteParametro.CodSubCategoria
                  , oE_ReporteParametro.CodMarca
                  , oE_ReporteParametro.CodProducto
                  , oE_ReporteParametro.CodPerfil
                  , oE_ReporteParametro.CodUsuario
                  , oE_ReporteParametro.CodEstado
                    );

                if (dt.Rows.Count > 0) { return dt; } else { return null; }
            }
            catch (Exception) { return null; }
        }
        public System.Data.DataTable ObtenerDetalleConsolidadoPresencia(M_ReporteParametro oE_ReporteParametro)
        {
            try
            {
                Lucky.Data.Conexion oCoon = new Lucky.Data.Conexion();
                System.Data.DataTable dt = oCoon.ejecutarDataTable("UP_GEN_DM_ConsolidadoBackusReportePresencia_detalle"
                  , oE_ReporteParametro.CodCanal
                  , oE_ReporteParametro.CodEquipo
                  , oE_ReporteParametro.CodAnio
                  , oE_ReporteParametro.CodMes
                  , oE_ReporteParametro.FecIni
                  , oE_ReporteParametro.FecFin
                  , oE_ReporteParametro.CodOficina
                  , oE_ReporteParametro.CodDepartamento
                  , oE_ReporteParametro.CodProvincia
                  , oE_ReporteParametro.CodCono
                  , oE_ReporteParametro.CodDistrito
                  , oE_ReporteParametro.CodCadena
                  , oE_ReporteParametro.CodPdv
                  , oE_ReporteParametro.CodEmpresa
                  , oE_ReporteParametro.CodCategoria
                  , oE_ReporteParametro.CodSubCategoria
                  , oE_ReporteParametro.CodMarca
                  , oE_ReporteParametro.CodProducto
                  , oE_ReporteParametro.CodPerfil
                  , oE_ReporteParametro.CodUsuario
                  , oE_ReporteParametro.CodEstado
                    );

                if (dt.Rows.Count > 0) { return dt; } else { return null; }
            }
            catch (Exception) { return null; }
        }
        //fin consolidado
    }
}