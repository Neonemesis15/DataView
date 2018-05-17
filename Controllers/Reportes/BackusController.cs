using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datamercaderista.Models.Backus;
using System.Web.Script.Serialization;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Datamercaderista.Controllers.Reportes
{
    public class BackusController : Controller
    {
        //
        // GET: /Backus/

        public ActionResult Index()
        {
            Session["usuario"] = "Usuario Backus";
            Session["idcompania"] = "1637";
            ViewBag.idcompania = "1637";

            return View();
        }
        public JsonResult Obtener_ReportesPorPlanning(string codEquipo)
        {
            Datamercaderista.Models.Ecuador.M_LlenarCombo_Service service = new Datamercaderista.Models.Ecuador.M_LlenarCombo_Service();
            List<Datamercaderista.Models.Ecuador.M_combo> oListM_combo = service.GetComboItems(47, codEquipo);
            int index =1;
            var modelData = (from item in oListM_combo
                             select new
                             {
                                 Id = index++,
                                 Value = item.codigo.ToString(),
                                 Text = item.descripcion.ToString()
                             }
                           );
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Obtener_Empresas(string codCompania)
        {
            Datamercaderista.Models.Ecuador.M_LlenarCombo_Service service = new Datamercaderista.Models.Ecuador.M_LlenarCombo_Service();
            List<Datamercaderista.Models.Ecuador.M_combo> oListM_combo = service.GetComboItems(48, codCompania);
            var modelData = oListM_combo.Select(u => new SelectListItem()
            {
                Value = u.codigo.ToString(),
                Text = u.descripcion.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Obtener_ProductoPorPlanning(string codEquipo, string codReporte)
        {
            Datamercaderista.Models.Ecuador.M_LlenarCombo_Service service = new Datamercaderista.Models.Ecuador.M_LlenarCombo_Service();
            List<Datamercaderista.Models.Ecuador.M_combo> oListM_combo = service.GetComboItems(49, codEquipo, codReporte);
            var modelData = oListM_combo.Select(u => new SelectListItem()
            {
                Value = u.codigo.ToString(),
                Text = u.descripcion.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Obtener_CategoriaPorplanning(string codEquipo, string codReporte)
        {
            Datamercaderista.Models.Ecuador.M_LlenarCombo_Service service = new Datamercaderista.Models.Ecuador.M_LlenarCombo_Service();
            List<Datamercaderista.Models.Ecuador.M_combo> oListM_combo = service.GetComboItems(50, codEquipo, codReporte);
            var modelData = oListM_combo.Select(u => new SelectListItem()
            {
                Value = u.codigo.ToString(),
                Text = u.descripcion.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Obtener_SubCategoriaPorplanning(string codEquipo, string codReporte)
        {
            Datamercaderista.Models.Ecuador.M_LlenarCombo_Service service = new Datamercaderista.Models.Ecuador.M_LlenarCombo_Service();
            List<Datamercaderista.Models.Ecuador.M_combo> oListM_combo = service.GetComboItems(51, codEquipo, codReporte);
            var modelData = oListM_combo.Select(u => new SelectListItem()
            {
                Value = u.codigo.ToString(),
                Text = u.descripcion.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Obtener_MarcaPorPlanning(string codEquipo, string codReporte)
        {
            Datamercaderista.Models.Ecuador.M_LlenarCombo_Service service = new Datamercaderista.Models.Ecuador.M_LlenarCombo_Service();
            List<Datamercaderista.Models.Ecuador.M_combo> oListM_combo = service.GetComboItems(52, codEquipo, codReporte);
            var modelData = oListM_combo.Select(u => new SelectListItem()
            {
                Value = u.codigo.ToString(),
                Text = u.descripcion.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Obtener_PerfilesPorCliente(string codCompania)
        {
            Datamercaderista.Models.Ecuador.M_LlenarCombo_Service service = new Datamercaderista.Models.Ecuador.M_LlenarCombo_Service();
            List<Datamercaderista.Models.Ecuador.M_combo> oListM_combo = service.GetComboItems(53, codCompania);
            var modelData = oListM_combo.Select(u => new SelectListItem()
            {
                Value = u.codigo.ToString(),
                Text = u.descripcion.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Obtener_UsuariosPorPlanning(string codCompania, string codEquipo)
        {
            Datamercaderista.Models.Ecuador.M_LlenarCombo_Service service = new Datamercaderista.Models.Ecuador.M_LlenarCombo_Service();
            List<Datamercaderista.Models.Ecuador.M_combo> oListM_combo = service.GetComboItems(54, codCompania, codEquipo);
            var modelData = oListM_combo.Select(u => new SelectListItem()
            {
                Value = u.codigo.ToString(),
                Text = u.descripcion.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //Reportes
        public ActionResult Precios()
        {
            return View();
        }
        public ActionResult STOCK_OUT()
        {
            return View();
        }
        public ActionResult Stock()
        {
            return View();
        }
        public ActionResult Visibilidad()
        {
            return View();
        }
        public ActionResult Participacion()
        {
            return View();
        }
        public ActionResult Actividades()
        {
            return View();
        }
        public ActionResult Vigencia()
        {
            return View();
        }
        public ActionResult CodigoPDV()
        {
            return View();
        }
        public ActionResult Multimedia()
        {
            return View();
        }
        public ActionResult Ventas()
        {
            return View();
        }
        public ActionResult Comentarios()
        {
            return View();
        }
        public ActionResult InicioFinDia()
        {
            return View();
        }
        public ActionResult Ubicacion()
        {
            return View();
        }
        public ActionResult Visita()
        {
            return View();
        }
        public ActionResult Motivo()
        {
            return View();
        }
        public ActionResult Fotografico()
        {
            return View();
        }

        static M_ReporteParametro oReporteParametroConsolidado;
        public ActionResult ConsolidadoPrecio()
        {
            Session["codEquipo"] = Request.QueryString["codEquipo"];

            M_ReportesBackus_Services service = new M_ReportesBackus_Services();

            oReporteParametroConsolidado = new M_ReporteParametro();
            oReporteParametroConsolidado.CodCanal = Request.QueryString["codCanal"];
            oReporteParametroConsolidado.CodEquipo = Request.QueryString["codEquipo"];
            oReporteParametroConsolidado.CodReporte = Convert.ToInt32(Request.QueryString["codReporte"]);
            oReporteParametroConsolidado.CodAnio = Request.QueryString["codAnio"];
            oReporteParametroConsolidado.CodMes = Request.QueryString["codMes"];
            oReporteParametroConsolidado.FecIni = Request.QueryString["fecIni"];
            oReporteParametroConsolidado.FecFin = Request.QueryString["fecFin"];
            oReporteParametroConsolidado.CodOficina = Convert.ToInt32(Request.QueryString["codOficina"]);
            oReporteParametroConsolidado.CodDepartamento = Request.QueryString["codDepartamento"];
            oReporteParametroConsolidado.CodProvincia = Request.QueryString["codProvincia"];
            oReporteParametroConsolidado.CodCono = Convert.ToInt32(Request.QueryString["codSector"]);
            oReporteParametroConsolidado.CodDistrito = Request.QueryString["codDistrito"];
            oReporteParametroConsolidado.CodCadena = Convert.ToInt32(Request.QueryString["codCadena"]);
            oReporteParametroConsolidado.CodPdv = Request.QueryString["codPDV"];
            oReporteParametroConsolidado.CodEmpresa = Convert.ToInt32(Request.QueryString["codEmpresa"]);
            oReporteParametroConsolidado.CodCategoria = Request.QueryString["codCategoria"];
            oReporteParametroConsolidado.CodSubCategoria = Request.QueryString["codSubCategoria"];
            oReporteParametroConsolidado.CodMarca = Convert.ToInt32(Request.QueryString["codMarca"]);
            oReporteParametroConsolidado.CodProducto = Request.QueryString["codProducto"];
            oReporteParametroConsolidado.CodPerfil = Request.QueryString["codPerfil"];
            oReporteParametroConsolidado.CodUsuario = Convert.ToInt32(Request.QueryString["codUsuario"]);
            oReporteParametroConsolidado.CodEstado = Request.QueryString["codEstado"];

            List<Backus_Consolidado_Cabecera> ols = service.ObtenerCabecerasConsolidadoPrecio(oReporteParametroConsolidado);

            if (ols == null)
                ols = new List<Backus_Consolidado_Cabecera>();

            var model = new Modelo_Backus
            {
                oLs = ols
            };

            ViewBag.campania = Session["codEquipo"].ToString();

            return View(model);
        }
        public ActionResult ConsolidadoPresencia()
        {
            Session["codEquipo"] = Request.QueryString["codEquipo"];

            M_ReportesBackus_Services service = new M_ReportesBackus_Services();

            oReporteParametroConsolidado = new M_ReporteParametro();
            oReporteParametroConsolidado.CodCanal = Request.QueryString["codCanal"];
            oReporteParametroConsolidado.CodEquipo = Request.QueryString["codEquipo"];
            oReporteParametroConsolidado.CodReporte = Convert.ToInt32(Request.QueryString["codReporte"]);
            oReporteParametroConsolidado.CodAnio = Request.QueryString["codAnio"];
            oReporteParametroConsolidado.CodMes = Request.QueryString["codMes"];
            oReporteParametroConsolidado.FecIni = Request.QueryString["fecIni"];
            oReporteParametroConsolidado.FecFin = Request.QueryString["fecFin"];
            oReporteParametroConsolidado.CodOficina = Convert.ToInt32(Request.QueryString["codOficina"]);
            oReporteParametroConsolidado.CodDepartamento = Request.QueryString["codDepartamento"];
            oReporteParametroConsolidado.CodProvincia = Request.QueryString["codProvincia"];
            oReporteParametroConsolidado.CodCono = Convert.ToInt32(Request.QueryString["codSector"]);
            oReporteParametroConsolidado.CodDistrito = Request.QueryString["codDistrito"];
            oReporteParametroConsolidado.CodCadena = Convert.ToInt32(Request.QueryString["codCadena"]);
            oReporteParametroConsolidado.CodPdv = Request.QueryString["codPDV"];
            oReporteParametroConsolidado.CodEmpresa = Convert.ToInt32(Request.QueryString["codEmpresa"]);
            oReporteParametroConsolidado.CodCategoria = Request.QueryString["codCategoria"];
            oReporteParametroConsolidado.CodSubCategoria = Request.QueryString["codSubCategoria"];
            oReporteParametroConsolidado.CodMarca = Convert.ToInt32(Request.QueryString["codMarca"]);
            oReporteParametroConsolidado.CodProducto = Request.QueryString["codProducto"];
            oReporteParametroConsolidado.CodPerfil = Request.QueryString["codPerfil"];
            oReporteParametroConsolidado.CodUsuario = Convert.ToInt32(Request.QueryString["codUsuario"]);
            oReporteParametroConsolidado.CodEstado = Request.QueryString["codEstado"];

            List<Backus_Consolidado_Cabecera> ols = service.ObtenerCabecerasConsolidadoPresencia(oReporteParametroConsolidado);

            if (ols == null)
                ols = new List<Backus_Consolidado_Cabecera>();

            var model = new Modelo_Backus
            {
                oLs = ols
            };

            ViewBag.campania = Session["codEquipo"].ToString();

            return View(model);
        }
        public ActionResult GetDmBackusReportePrecio(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReportePrecio(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteQuiebre(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = Convert.ToString(codEstado);

            var model = service.GetDmBackusReporteQuiebre(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteStock(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteStock(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteVisibilidad(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteVisibilidad(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteParticipacion(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteParticipacion(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteActividades(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteActividad(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteVigencia(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteVigencia(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteCodigoPDV(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteCodigoPDV(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteMultimedia(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteMultimedia(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteVentas(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteVenta(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteComentarios(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteComentario(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteInicioFinDia(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteInicioFinDia(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteUbicacion(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteUbicacion(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteVisita(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteVisita(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteMotivo(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteMotivo(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteFotografico(string codCanal, string codEquipo, string codReporte, string codAnio, string codMes, string codPeriodo, string fecIni, string fecFin, string codOficina, string codDepartamento, string codProvincia, string codSector, string codDistrito, string codCadena, string codPDV, string codEmpresa, string codCategoria, string codSubCategoria, string codMarca, string codProducto, string codPerfil, string codUsuario, string codEstado)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            DmBackusReporteParametro_Request request = new DmBackusReporteParametro_Request();
            request.oReporteParametro = new M_ReporteParametro();
            request.oReporteParametro.CodCanal = codCanal;
            request.oReporteParametro.CodEquipo = codEquipo; //"2013498765453";
            request.oReporteParametro.CodReporte = Convert.ToInt32(codReporte);
            request.oReporteParametro.CodAnio = codAnio;
            request.oReporteParametro.CodMes = codMes;
            request.oReporteParametro.FecIni = fecIni;
            request.oReporteParametro.FecFin = fecFin;
            request.oReporteParametro.CodOficina = Convert.ToInt32(codOficina);
            request.oReporteParametro.CodDepartamento = codDepartamento;
            request.oReporteParametro.CodProvincia = codProvincia;
            request.oReporteParametro.CodCono = Convert.ToInt32(codSector);
            request.oReporteParametro.CodDistrito = codDistrito;
            request.oReporteParametro.CodCadena = Convert.ToInt32(codCadena);
            request.oReporteParametro.CodPdv = codPDV;
            request.oReporteParametro.CodEmpresa = Convert.ToInt32(codEmpresa);
            request.oReporteParametro.CodCategoria = codCategoria;
            request.oReporteParametro.CodSubCategoria = codSubCategoria;
            request.oReporteParametro.CodMarca = Convert.ToInt32(codMarca);
            request.oReporteParametro.CodProducto = codProducto;
            request.oReporteParametro.CodPerfil = codPerfil;
            request.oReporteParametro.CodUsuario = Convert.ToInt32(codUsuario);
            request.oReporteParametro.CodEstado = codEstado;

            var model = service.GetDmBackusReporteFotografico(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        public ActionResult GetDmBackusReporteDetalleFoto(string codEquipo, string codPDV)
        {
            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            GetDmBackusDetalleFoto_Request request = new GetDmBackusDetalleFoto_Request();

            request.id_Planning = codEquipo;
            request.ClientPDV_Code = codPDV;


            var model = service.GetDmBackusDetalleFoto(request);

            var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            var result = new ContentResult
            {
                //Content = serializer.Serialize(modelList),
                Content = serializer.Serialize(model),
                ContentType = "application/json"
            };
            return result;
        }
        //Validacion

        public JsonResult ValidarInvalidarReportePrecio(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReportePrecio;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteQuiebre(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteQuiebre;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteStock(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteStock;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteVisibilidad(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteVisibilidad;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteParticipacion(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteParticipacion;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteActividades(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteActividad;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteVigencia(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteVigencia;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteCodigoPDV(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteCodPDV;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteMultimedia(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteMultimedia;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteVentas(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteVentas;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteComentarios(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteComentario;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteInicioFinDia(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteInicioFinDia;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteUbicacion(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteUbicacion;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteVisita(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteVisita;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteMotivo(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteMotivo;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        public JsonResult ValidarInvalidarReporteFotografico(string DataItems, string Validado)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(DataItems);

            string List_IdRegDet = String.Empty;

            foreach (var item in Items)
            {
                List_IdRegDet += item["IdRegDet"] + ",";
            }

            ValidarInvalidarReporteDmBackus_Request request = new ValidarInvalidarReporteDmBackus_Request();
            request.ValidarInvalidarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusValidarInvalidarReporte();
            request.ValidarInvalidarReporte_req.Estado = Convert.ToBoolean(Validado);
            request.ValidarInvalidarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ValidarInvalidarReporte_req.List_IdRepDet = List_IdRegDet;
            request.ValidarInvalidarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteFotografico;


            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ValidarInvalidarReporteDmBackus(request);

            return Json(model);
        }
        //Fin De validación

        //Actualizacion
        public JsonResult GuardarReporteBackusPrecios(string DataItems)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Item = jss.Deserialize<dynamic>(DataItems);

            int IdRegDet = Item[0]["IdRegDet"];
            bool Validado = Item[0]["Validado"];

            string Campos = Convert.ToString(Item[0]["PrecioCosto"]);
            Campos += "," + Convert.ToString(Item[0]["PrecioReventa"]);
            Campos += "," + Convert.ToString(Item[0]["PrecioPublico"]);
            Campos += "," + Convert.ToString(Item[0]["PrecioOferta"]);

            ActualizarReporteDmBackus_Request request =new ActualizarReporteDmBackus_Request();
            request.ActualizarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusActualizarReporte();
            request.ActualizarReporte_req.Estado = Validado;
            request.ActualizarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ActualizarReporte_req.IdRepDet = IdRegDet;
            request.ActualizarReporte_req.Campos = Campos;
            request.ActualizarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReportePrecio;

            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ActualizarReporteDmBackus(request);

            return Json(model);            
        }
        public JsonResult GuardarReporteBackusQuiebre(string DataItems)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Item = jss.Deserialize<dynamic>(DataItems);

            int IdRegDet = Item[0]["IdRegDet"];
            bool Validado = Item[0]["Validado"];

            string Campos = Convert.ToString(Item[0]["Comentario"]);

            ActualizarReporteDmBackus_Request request = new ActualizarReporteDmBackus_Request();
            request.ActualizarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusActualizarReporte();
            request.ActualizarReporte_req.Estado = Validado;
            request.ActualizarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ActualizarReporte_req.IdRepDet = IdRegDet;
            request.ActualizarReporte_req.Campos = Campos;
            request.ActualizarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteQuiebre;

            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ActualizarReporteDmBackus(request);

            return Json(model);     
        }
        public JsonResult GuardarReporteBackusStock(string DataItems)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Item = jss.Deserialize<dynamic>(DataItems);

            int IdRegDet = Item[0]["IdRegDet"];
            bool Validado = Item[0]["Validado"];

            string Campos = Convert.ToString(Item[0]["CantidadUno"]);
            Campos += "," + Convert.ToString(Item[0]["CantidadDos"]);

            ActualizarReporteDmBackus_Request request = new ActualizarReporteDmBackus_Request();
            request.ActualizarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusActualizarReporte();
            request.ActualizarReporte_req.Estado = Validado;
            request.ActualizarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ActualizarReporte_req.IdRepDet = IdRegDet;
            request.ActualizarReporte_req.Campos = Campos;
            request.ActualizarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteStock;

            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ActualizarReporteDmBackus(request);

            return Json(model);     
        }
        public JsonResult GuardarReporteBackusVisibilidad(string DataItems)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Item = jss.Deserialize<dynamic>(DataItems);

            int IdRegDet = Item[0]["IdRegDet"];
            bool Validado = Item[0]["Validado"];

            string Campos = Convert.ToString(Item[0]["Comentario"]);

            ActualizarReporteDmBackus_Request request = new ActualizarReporteDmBackus_Request();
            request.ActualizarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusActualizarReporte();
            request.ActualizarReporte_req.Estado = Validado;
            request.ActualizarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ActualizarReporte_req.IdRepDet = IdRegDet;
            request.ActualizarReporte_req.Campos = Campos;
            request.ActualizarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteVisibilidad;

            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ActualizarReporteDmBackus(request);

            return Json(model);     
        }
        public JsonResult GuardarReporteBackusParticipacion(string DataItems)
        {

            return Json(true);
        }
        public JsonResult GuardarReporteBackusActividades(string DataItems)
        {
            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Item = jss.Deserialize<dynamic>(DataItems);

            int IdRegDet = Item[0]["IdRegDet"];
            bool Validado = Item[0]["Validado"];

            string Campos = Convert.ToString(Item[0]["PrecioCosto"]);
            Campos += "," + Convert.ToString(Item[0]["PrecioReventa"]);
            Campos += "," + Convert.ToString(Item[0]["PrecioPublico"]);
            Campos += "," + Convert.ToString(Item[0]["PrecioOferta"]);

            ActualizarReporteDmBackus_Request request = new ActualizarReporteDmBackus_Request();
            request.ActualizarReporte_req = new Lucky.Entity.Common.Servicio.DM_Backus.E_DmBackusActualizarReporte();
            request.ActualizarReporte_req.Estado = Validado;
            request.ActualizarReporte_req.nombreUsuario = Session["usuario"].ToString();
            request.ActualizarReporte_req.IdRepDet = IdRegDet;
            request.ActualizarReporte_req.Campos = Campos;
            request.ActualizarReporte_req.Reporte = Lucky.Entity.Common.Servicio.DM_Backus.Reporte.ReporteActividad;

            M_ReportesBackus_Services service = new M_ReportesBackus_Services();
            var model = service.ActualizarReporteDmBackus(request);

            return Json(model);     
        }
        public JsonResult GuardarReporteBackusVigencia(string DataItems)
        {

            return Json(true);
        }
        public JsonResult GuardarReporteBackusCodigoPDV(string DataItems)
        {

            return Json(true);
        }
        public JsonResult GuardarReporteBackusMultimedia(string DataItems)
        {

            return Json(true);
        }
        public JsonResult GuardarReporteBackusVentas(string DataItems)
        {

            return Json(true);
        }
        public JsonResult GuardarReporteBackusComentarios(string DataItems)
        {

            return Json(true);
        }
        public JsonResult GuardarReporteBackusInicioFinDia(string DataItems)
        {

            return Json(true);
        }
        public JsonResult GuardarReporteBackusUbicacion(string DataItems)
        {

            return Json(true);
        }
        public JsonResult GuardarReporteBackusVisita(string DataItems)
        {

            return Json(true);
        }
        public JsonResult GuardarReporteBackusMotivo(string DataItems)
        {

            return Json(true);
        }
        //---Fin Actualizacion

        //Exportacion
        public JsonResult ExportToExcelDmBackusReportePrecio(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Precio");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("Empresa", typeof(string));
            tb_reporte.Columns.Add("Categoria", typeof(string));
            tb_reporte.Columns.Add("SubCategoria", typeof(string));
            tb_reporte.Columns.Add("Marca", typeof(string));
            tb_reporte.Columns.Add("SkuProducto", typeof(string));
            tb_reporte.Columns.Add("Producto", typeof(string));
            tb_reporte.Columns.Add("PrecioCosto", typeof(decimal));
            tb_reporte.Columns.Add("PrecioReventa", typeof(decimal));
            tb_reporte.Columns.Add("PrecioPublico", typeof(decimal));
            tb_reporte.Columns.Add("PrecioOferta", typeof(decimal));
            tb_reporte.Columns.Add("CodTipo", typeof(string));
            tb_reporte.Columns.Add("Tipo", typeof(string));
            tb_reporte.Columns.Add("FecIni", typeof(string));
            tb_reporte.Columns.Add("FecFin", typeof(string));
            tb_reporte.Columns.Add("CodMecanica", typeof(string));
            tb_reporte.Columns.Add("Mecanica", typeof(string));
            tb_reporte.Columns.Add("UrlFoto", typeof(string));
            tb_reporte.Columns.Add("Comentario", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["Empresa"],
                    item["Categoria"],
                    item["SubCategoria"],
                    item["Marca"],
                    item["SkuProducto"],
                    item["Producto"],
                    item["PrecioCosto"],
                    item["PrecioReventa"],
                    item["PrecioPublico"],
                    item["PrecioOferta"],
                    item["CodTipo"],
                    item["Tipo"],
                    item["FecIni"],
                    item["FecFin"],
                    item["CodMecanica"],
                    item["Mecanica"],
                    item["UrlFoto"],
                    item["Comentario"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteQuiebre(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Quiebre");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("Empresa", typeof(string));
            tb_reporte.Columns.Add("Categoria", typeof(string));
            tb_reporte.Columns.Add("SubCategoria", typeof(string));
            tb_reporte.Columns.Add("Marca", typeof(string));
            tb_reporte.Columns.Add("SkuProducto", typeof(string));
            tb_reporte.Columns.Add("Producto", typeof(string));
            tb_reporte.Columns.Add("CodTipo", typeof(string));
            tb_reporte.Columns.Add("Tipo", typeof(string));
            tb_reporte.Columns.Add("CodTipo2", typeof(string));
            tb_reporte.Columns.Add("Tipo2", typeof(string));
            tb_reporte.Columns.Add("CodTipo3", typeof(string));
            tb_reporte.Columns.Add("Tipo3", typeof(string));
            tb_reporte.Columns.Add("FecIni", typeof(string));
            tb_reporte.Columns.Add("FecFin", typeof(string));
            tb_reporte.Columns.Add("UrlFoto", typeof(string));
            tb_reporte.Columns.Add("Comentario", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["Empresa"],
                    item["Categoria"],
                    item["SubCategoria"],
                    item["Marca"],
                    item["SkuProducto"],
                    item["Producto"],
                    item["CodTipo"],
                    item["Tipo"],
                    item["CodTipo2"],
                    item["CodTipo2"],
                    item["CodTipo3"],
                    item["CodTipo3"],
                    item["FecIni"],
                    item["FecFin"],
                    item["UrlFoto"],
                    item["Comentario"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteStock(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Stock");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("Empresa", typeof(string));
            tb_reporte.Columns.Add("Categoria", typeof(string));
            tb_reporte.Columns.Add("SubCategoria", typeof(string));
            tb_reporte.Columns.Add("Marca", typeof(string));
            tb_reporte.Columns.Add("SkuProducto", typeof(string));
            tb_reporte.Columns.Add("Producto", typeof(string));
            tb_reporte.Columns.Add("FechaConteo", typeof(string));
            tb_reporte.Columns.Add("CantidadUno", typeof(int));
            tb_reporte.Columns.Add("CantidadDos", typeof(int));
            tb_reporte.Columns.Add("CodTipo", typeof(string));
            tb_reporte.Columns.Add("Tipo", typeof(string));
            tb_reporte.Columns.Add("UrlFoto", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["Empresa"],
                    item["Categoria"],
                    item["SubCategoria"],
                    item["Marca"],
                    item["SkuProducto"],
                    item["Producto"],
                    item["FechaConteo"],
                    item["CantidadUno"],
                    item["CantidadDos"],
                    item["CodTipo"],
                    item["Tipo"],
                    item["UrlFoto"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteVisibilidad(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Visibilidad");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("Empresa", typeof(string));
            tb_reporte.Columns.Add("Categoria", typeof(string));
            tb_reporte.Columns.Add("SubCategoria", typeof(string));
            tb_reporte.Columns.Add("Marca", typeof(string));
            tb_reporte.Columns.Add("ElementoCantidad", typeof(string));
            tb_reporte.Columns.Add("CodTipo", typeof(string));
            tb_reporte.Columns.Add("Tipo", typeof(string));
            tb_reporte.Columns.Add("FecIni", typeof(string));
            tb_reporte.Columns.Add("FecFin", typeof(string));
            tb_reporte.Columns.Add("codTipoVisibilidad", typeof(string));
            tb_reporte.Columns.Add("Visibilidad", typeof(string));
            tb_reporte.Columns.Add("CodElemento", typeof(string));
            tb_reporte.Columns.Add("Elemento", typeof(string));
            tb_reporte.Columns.Add("UrlFoto", typeof(string));
            tb_reporte.Columns.Add("Comentario", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["Empresa"],
                    item["Categoria"],
                    item["SubCategoria"],
                    item["Marca"],
                    item["ElementoCantidad"],
                    item["CodTipo"],
                    item["Tipo"],
                    item["FecIni"],
                    item["FecFin"],
                    item["codTipoVisibilidad"],
                    item["Visibilidad"],
                    item["CodElemento"],
                    item["Elemento"],
                    item["UrlFoto"],
                    item["Comentario"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteParticipacion(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Participacion");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("Empresa", typeof(string));
            tb_reporte.Columns.Add("Categoria", typeof(string));
            tb_reporte.Columns.Add("SubCategoria", typeof(string));
            tb_reporte.Columns.Add("Marca", typeof(string));
            tb_reporte.Columns.Add("CodParticipacion", typeof(string));
            tb_reporte.Columns.Add("Participacion", typeof(string));
            tb_reporte.Columns.Add("CantidadUno", typeof(int));
            tb_reporte.Columns.Add("CantidadDos", typeof(int));
            tb_reporte.Columns.Add("CodTipo", typeof(string));
            tb_reporte.Columns.Add("Tipo", typeof(string));
            tb_reporte.Columns.Add("UrlFoto", typeof(string));
            tb_reporte.Columns.Add("TotalUno", typeof(int));
            tb_reporte.Columns.Add("TotalDos", typeof(int));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["Empresa"],
                    item["Categoria"],
                    item["SubCategoria"],
                    item["Marca"],
                    item["CodParticipacion"],
                    item["Participacion"],
                    item["CantidadUno"],
                    item["CantidadDos"],
                    item["CodTipo"],
                    item["Tipo"],
                    item["UrlFoto"],
                    item["TotalUno"],
                    item["TotalDos"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteActividad(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Actividad");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("Empresa", typeof(string));
            tb_reporte.Columns.Add("Categoria", typeof(string));
            tb_reporte.Columns.Add("SubCategoria", typeof(string));
            tb_reporte.Columns.Add("Marca", typeof(string));
            tb_reporte.Columns.Add("CodProducto", typeof(string));
            tb_reporte.Columns.Add("Producto", typeof(string));
            tb_reporte.Columns.Add("CodObjetivo", typeof(string));
            tb_reporte.Columns.Add("Objetivo", typeof(string));
            tb_reporte.Columns.Add("CodActividad", typeof(string));
            tb_reporte.Columns.Add("Actividad", typeof(string));
            tb_reporte.Columns.Add("OtraActividad", typeof(string));
            tb_reporte.Columns.Add("Mecanica", typeof(string));
            tb_reporte.Columns.Add("FecIni", typeof(string));
            tb_reporte.Columns.Add("FecFin", typeof(string));
            tb_reporte.Columns.Add("CodElemento", typeof(string));
            tb_reporte.Columns.Add("Elemento", typeof(string));
            tb_reporte.Columns.Add("PrecioCosto", typeof(string));
            tb_reporte.Columns.Add("PrecioReventa", typeof(string));
            tb_reporte.Columns.Add("PrecioPublico", typeof(string));
            tb_reporte.Columns.Add("PrecioOferta", typeof(string));
            tb_reporte.Columns.Add("UrlFotoUno", typeof(string));
            tb_reporte.Columns.Add("UrlFotoDos", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["Empresa"],
                    item["Categoria"],
                    item["SubCategoria"],
                    item["Marca"],
                    item["CodProducto"],
                    item["Producto"],
                    item["CodObjetivo"],
                    item["Objetivo"],
                    item["CodActividad"],
                    item["Actividad"],
                    item["OtraActividad"],
                    item["Mecanica"],
                    item["FecIni"],
                    item["FecFin"],
                    item["CodElemento"],
                    item["Elemento"],
                    item["PrecioCosto"],
                    item["PrecioReventa"],
                    item["PrecioPublico"],
                    item["PrecioOferta"],
                    item["UrlFotoUno"],
                    item["UrlFotoDos"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteVigencia(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Vigencia");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("Empresa", typeof(string));
            tb_reporte.Columns.Add("Categoria", typeof(string));
            tb_reporte.Columns.Add("SubCategoria", typeof(string));
            tb_reporte.Columns.Add("Marca", typeof(string));
            tb_reporte.Columns.Add("CodProducto", typeof(string));
            tb_reporte.Columns.Add("Producto", typeof(string));
            tb_reporte.Columns.Add("Cantidad", typeof(int));
            tb_reporte.Columns.Add("Fecha", typeof(string));
            tb_reporte.Columns.Add("UrlFoto", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["Empresa"],
                    item["Categoria"],
                    item["SubCategoria"],
                    item["Marca"],
                    item["CodProducto"],
                    item["Producto"],
                    item["Cantidad"],
                    item["Fecha"],
                    item["UrlFoto"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteCodigoPDV(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_CodigoPDV");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("CodDistribuidora", typeof(string));
            tb_reporte.Columns.Add("Distribuidora", typeof(string));
            tb_reporte.Columns.Add("CodPDV", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["CodDistribuidora"],
                    item["Distribuidora"],
                    item["CodPDV"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteVenta(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Visibilidad");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("Empresa", typeof(string));
            tb_reporte.Columns.Add("Categoria", typeof(string));
            tb_reporte.Columns.Add("SubCategoria", typeof(string));
            tb_reporte.Columns.Add("Marca", typeof(string));
            tb_reporte.Columns.Add("CodProducto", typeof(string));
            tb_reporte.Columns.Add("Producto", typeof(string));
            tb_reporte.Columns.Add("Cantidad", typeof(string));
            tb_reporte.Columns.Add("CodTipo", typeof(string));
            tb_reporte.Columns.Add("Tipo", typeof(string));
            tb_reporte.Columns.Add("UrlFoto", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["Empresa"],
                    item["Categoria"],
                    item["SubCategoria"],
                    item["Marca"],
                    item["CodProducto"],
                    item["Producto"],
                    item["Cantidad"],
                    item["CodTipo"],
                    item["Tipo"],
                    item["UrlFoto"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteMultimedia(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Multimedia");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("Empresa", typeof(string));
            tb_reporte.Columns.Add("CodTipoMultimedia", typeof(string));
            tb_reporte.Columns.Add("TipoMultimedia", typeof(string));
            tb_reporte.Columns.Add("Categoria", typeof(string));
            tb_reporte.Columns.Add("SubCategoria", typeof(string));
            tb_reporte.Columns.Add("Marca", typeof(string));
            tb_reporte.Columns.Add("UrlFoto", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["Empresa"],
                    item["CodTipoMultimedia"],
                    item["TipoMultimedia"],
                    item["Categoria"],
                    item["SubCategoria"],
                    item["Marca"],
                    item["UrlFoto"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteComentario(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Comentario");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("Comentario", typeof(string));
            tb_reporte.Columns.Add("UrlFoto", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["Comentario"],
                    item["UrlFoto"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteInicioFinDia(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_InicioFinDia");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("FecIni", typeof(string));
            tb_reporte.Columns.Add("LatitudIni", typeof(string));
            tb_reporte.Columns.Add("LongitudIni", typeof(string));
            tb_reporte.Columns.Add("FechaCelIni", typeof(string));
            tb_reporte.Columns.Add("FechaBdIni", typeof(string));
            tb_reporte.Columns.Add("FecFin", typeof(string));
            tb_reporte.Columns.Add("Latitud", typeof(string));
            tb_reporte.Columns.Add("Longitud", typeof(string));
            tb_reporte.Columns.Add("FechaCelFin", typeof(string));
            tb_reporte.Columns.Add("FechaBdFin", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["FecIni"],
                    item["LatitudIni"],
                    item["LongitudIni"],
                    item["FechaCelIni"],
                    item["FechaBdIni"],
                    item["FecFin"],
                    item["Latitud"],
                    item["Longitud"],
                    item["FechaCelFin"],
                    item["FechaBdFin"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteUbicacion(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Ubicacion");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("CodPDV", typeof(string));
            tb_reporte.Columns.Add("NombrePDV", typeof(string));
            tb_reporte.Columns.Add("Latitud", typeof(string));
            tb_reporte.Columns.Add("Longitud", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["CodPDV"],
                    item["NombrePDV"],
                    item["Latitud"],
                    item["Longitud"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteVisita(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Visita");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("Canal", typeof(string));
            tb_reporte.Columns.Add("Oficina", typeof(string));
            tb_reporte.Columns.Add("Cono", typeof(string));
            tb_reporte.Columns.Add("Departamento", typeof(string));
            tb_reporte.Columns.Add("Provincia", typeof(string));
            tb_reporte.Columns.Add("Distrito", typeof(string));
            tb_reporte.Columns.Add("Cadena", typeof(string));
            tb_reporte.Columns.Add("CodPDV", typeof(string));
            tb_reporte.Columns.Add("NombrePDV", typeof(string));
            tb_reporte.Columns.Add("FecCel", typeof(string));
            tb_reporte.Columns.Add("FecBd", typeof(string));
            tb_reporte.Columns.Add("Perfil", typeof(string));
            tb_reporte.Columns.Add("CodUsuario", typeof(string));
            tb_reporte.Columns.Add("Usuario", typeof(string));
            tb_reporte.Columns.Add("Latitud", typeof(string));
            tb_reporte.Columns.Add("Longitud", typeof(string));
            tb_reporte.Columns.Add("DateBy", typeof(string));
            tb_reporte.Columns.Add("FecModi", typeof(string));
            tb_reporte.Columns.Add("CodUsuarioModi", typeof(string));
            tb_reporte.Columns.Add("UsuarioModi", typeof(string));
            tb_reporte.Columns.Add("CodPeriodo", typeof(string));
            tb_reporte.Columns.Add("Periodo", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["Canal"],
                    item["Oficina"],
                    item["Cono"],
                    item["Departamento"],
                    item["Provincia"],
                    item["Distrito"],
                    item["Cadena"],
                    item["CodPDV"],
                    item["NombrePDV"],
                    item["FecCel"],
                    item["FecBd"],
                    item["Perfil"],
                    item["CodUsuario"],
                    item["Usuario"],
                    item["Latitud"],
                    item["Longitud"],
                    item["DateBy"],
                    item["FecModi"],
                    item["CodUsuarioModi"],
                    item["UsuarioModi"],
                    item["CodPeriodo"],
                    item["Periodo"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteMotivo(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Visibilidad");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("Empresa", typeof(string));
            tb_reporte.Columns.Add("Categoria", typeof(string));
            tb_reporte.Columns.Add("SubCategoria", typeof(string));
            tb_reporte.Columns.Add("Marca", typeof(string));
            tb_reporte.Columns.Add("ElementoCantidad", typeof(string));
            tb_reporte.Columns.Add("CodTipo", typeof(string));
            tb_reporte.Columns.Add("Tipo", typeof(string));
            tb_reporte.Columns.Add("FecIni", typeof(string));
            tb_reporte.Columns.Add("FecFin", typeof(string));
            tb_reporte.Columns.Add("codTipoVisibilidad", typeof(string));
            tb_reporte.Columns.Add("Visibilidad", typeof(string));
            tb_reporte.Columns.Add("CodElemento", typeof(string));
            tb_reporte.Columns.Add("Elemento", typeof(string));
            tb_reporte.Columns.Add("UrlFoto", typeof(string));
            tb_reporte.Columns.Add("Comentario", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["Empresa"],
                    item["Categoria"],
                    item["SubCategoria"],
                    item["Marca"],
                    item["ElementoCantidad"],
                    item["CodTipo"],
                    item["Tipo"],
                    item["FecIni"],
                    item["FecFin"],
                    item["codTipoVisibilidad"],
                    item["Visibilidad"],
                    item["CodElemento"],
                    item["Elemento"],
                    item["UrlFoto"],
                    item["Comentario"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcelDmBackusReporteFotografico(string model, string data, string title)
        {

            DataTable tb_reporte = new DataTable("Reporte_Visibilidad");

            tb_reporte.Columns.Add("IdRegDet", typeof(int));
            tb_reporte.Columns.Add("TipoReporte", typeof(string));
            tb_reporte.Columns.Add("CodPDV", typeof(string));
            tb_reporte.Columns.Add("NombrePDV", typeof(string));
            tb_reporte.Columns.Add("FecIni", typeof(string));
            tb_reporte.Columns.Add("FecFin", typeof(string));
            tb_reporte.Columns.Add("UrlFoto", typeof(string));
            tb_reporte.Columns.Add("Comentario", typeof(string));
            tb_reporte.Columns.Add("Validado", typeof(bool));

            var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            dynamic Items = jss.Deserialize<dynamic>(data);

            foreach (var item in Items)
            {
                tb_reporte.Rows.Add(
                    item["IdRegDet"],
                    item["TipoReporte"],
                    item["CodPDV"],
                    item["NombrePDV"],
                    item["FecIni"],
                    item["FecFin"],
                    item["UrlFoto"],
                    item["Comentario"],
                    item["Validado"]
                    );
            }

            DataSet ds = new DataSet();
            //DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            //ds.Tables.Add(dt);
            ds.Tables.Add(tb_reporte);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        //fin Exportacion


        //Consultas consolidado
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConsolidadoBackusResumenPrecios()
        {
            DataTable oDt;

            M_ReportesBackus_Services services = new M_ReportesBackus_Services();

            oDt = services.ObtenerResumenConsolidadoPrecio(oReporteParametroConsolidado);

            if (oDt == null)
                oDt = new DataTable();
            else if (oDt.Rows.Count <= 0)
                oDt = new DataTable();
            var result = new ContentResult
            {
                Content = Util.DataTableToJson(oDt),
                ContentType = "application/json"
            };
            return result;
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConsolidadoBackusDetallePrecios()
        {
            DataTable oDt;

            M_ReportesBackus_Services services = new M_ReportesBackus_Services();
            oDt = services.ObtenerDetalleConsolidadoPrecio(oReporteParametroConsolidado);

            //var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            if (oDt == null)
                oDt = new DataTable();
            else if (oDt.Rows.Count <= 0)
                oDt = new DataTable();
            var result = new ContentResult
            {
                Content = Util.DataTableToJson(oDt),
                ContentType = "application/json"
            };

            return result;
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult ConsolidadoUpdatePrecio(string Datos)
        {

            return Json(true);
        }

        public JsonResult ExportToExcelConsolidadoPrecio(string model, string data, string title)
        {
            //-- crea dataset
            DataSet oDs = new DataSet();
            M_ReportesBackus_Services services = new M_ReportesBackus_Services();

            //-- objeto cabecera
            List<Backus_Consolidado_Cabecera> oLs;
            oLs = services.ObtenerCabecerasConsolidadoPrecio(oReporteParametroConsolidado);

            //-- objeto resumen
            DataTable oDt_Resumen = services.ObtenerResumenConsolidadoPrecio(oReporteParametroConsolidado);
            oDt_Resumen.TableName = "Resumen";

            //-- objeto detalle
            DataTable oDt_Detalle = Util.ConvertJSONToDataTable(data);
            oDt_Detalle.TableName = "Detalle";

            //-- inserta la tabla resumen y detalle a dataset
            oDs.Tables.Add(oDt_Resumen);
            oDs.Tables.Add(oDt_Detalle);

            //-- instancia objeto excel a session
            Session[title] = ExportaConsolidado_Resumen(oDs, oLs);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConsolidadoBackusResumenPresencia()
        {
            DataTable oDt;

            M_ReportesBackus_Services services = new M_ReportesBackus_Services();
            oDt = services.ObtenerResumenConsolidadoPresencia(oReporteParametroConsolidado);
            if (oDt == null)
                oDt = new DataTable();
            else if (oDt.Rows.Count <= 0)
                oDt = new DataTable();
            var result = new ContentResult
            {
                Content = Util.DataTableToJson(oDt),
                ContentType = "application/json"
            };

            return result;
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ConsolidadoBackusDetallePresencia()
        {
            DataTable oDt;

            M_ReportesBackus_Services services = new M_ReportesBackus_Services();
            oDt = services.ObtenerDetalleConsolidadoPresencia(oReporteParametroConsolidado);

            //var serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            if (oDt == null)
                oDt = new DataTable();
            else if (oDt.Rows.Count <= 0)
                oDt = new DataTable();
            var result = new ContentResult
            {
                Content = Util.DataTableToJson(oDt),
                ContentType = "application/json"
            };

            return result;
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult ConsolidadoUpdatePresencia(string Datos)
        {

            return Json(true);
        }

        public JsonResult ExportToExcelConsolidadoPresencia(string model, string data, string title)
        {
            //-- crea dataset
            DataSet oDs = new DataSet();
            M_ReportesBackus_Services services = new M_ReportesBackus_Services();

            //-- objeto cabecera
            List<Backus_Consolidado_Cabecera> oLs;
            oLs = services.ObtenerCabecerasConsolidadoPresencia(oReporteParametroConsolidado);

            //-- objeto resumen
            DataTable oDt_Resumen = services.ObtenerResumenConsolidadoPresencia(oReporteParametroConsolidado);
            oDt_Resumen.TableName = "Resumen";

            //-- objeto detalle
            DataTable oDt_Detalle = Util.ConvertJSONToDataTable(data);
            oDt_Detalle.TableName = "Detalle";

            //-- inserta la tabla resumen y detalle a dataset
            oDs.Tables.Add(oDt_Resumen);
            oDs.Tables.Add(oDt_Detalle);

            //-- instancia objeto excel a session
            Session[title] = ExportaConsolidado_Resumen(oDs, oLs);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        //fin consultas consolidado


        //otros

        public static byte[] ExportaConsolidado_Resumen(DataSet vDs, List<Backus_Consolidado_Cabecera> vLs)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                //-- instancia tablas
                DataTable oDt_Resumen = vDs.Tables["Resumen"];
                DataTable oDt_Detalle = vDs.Tables["Detalle"];

                //-- cantidad de registros por tablas
                int iResumen = oDt_Resumen.Rows.Count;
                int iDetalle = oDt_Detalle.Rows.Count;
                int iContadorResumen = 1;
                int iContadorDetalle = 1;
                int iFilas = 0;
                int iUbicacion = 0;

                //-- crea hoja excel
                ExcelWorksheet oWs = pck.Workbook.Worksheets.Add("Consolidado");

                foreach (Backus_Consolidado_Cabecera oAu in vLs)
                {
                    //-- inserta cabecera de resumen
                    if (oAu.cab_cabecera.Length > 3 && oAu.cab_cabecera.Substring(0, 3) == "id_")
                    {
                        oWs.Cells[1, iContadorResumen].Value = oAu.cab_descripcion;
                        iContadorResumen += 1;
                    }
                    else if (oAu.cab_cabecera == "Resumen" || ((oAu.cab_cabecera.Length > 3) && (oAu.cab_cabecera.Substring(0, 4) == "val_")))
                    {
                        if (oAu.cab_cabecera == "Resumen")
                        {
                            oWs.Cells[1, iContadorResumen].Value = "...";
                            iUbicacion = iContadorResumen - 1;
                        }
                    }
                    else
                    {
                        oWs.Cells[1, iContadorResumen].Value = oAu.cab_descripcion;
                        iContadorResumen += 1;
                    }

                    //-- inserta cabecera de detalle
                    if (oAu.cab_cabecera.Length > 3 && oAu.cab_cabecera.Substring(0, 3) == "id_")
                    {
                        oWs.Cells[iResumen + 3, iContadorDetalle].Value = oAu.cab_descripcion;
                        iContadorDetalle += 1;
                    }
                    else if (oAu.cab_cabecera == "Resumen" || ((oAu.cab_cabecera.Length > 3) && (oAu.cab_cabecera.Substring(0, 4) == "val_"))) { }
                    else
                    {
                        oWs.Cells[iResumen + 3, iContadorDetalle].Value = oAu.cab_cabecera;
                        iContadorDetalle += 1;
                    }
                }

                //-- imprime tabla "Resumen"
                oWs.Cells[2, iUbicacion].LoadFromDataTable(oDt_Resumen, false);

                //-- reinicia el contador de columnas
                iContadorDetalle = 1;
                iFilas = iResumen + 4;

                //-- imprime tabla "Detalle"
                foreach (DataRow oRow in oDt_Detalle.Rows)
                {
                    foreach (DataColumn oColumna in oDt_Detalle.Columns)
                    {
                        if ((oColumna.ColumnName == "vao_i") || ((oColumna.ColumnName.Length > 3) && (oColumna.ColumnName.Substring(0, 3) == "id_"))) { }
                        else
                        {
                            oWs.Cells[iFilas, iContadorDetalle].Value = oRow[oColumna].ToString();
                            iContadorDetalle += 1;
                        }
                    }

                    iContadorDetalle = 1;
                    iFilas += 1;
                }

                //oWSheet.Range["A1"].Select();
                //oThisAddInApp.ActiveSheet.ListObjects.Add(XlListObjectSourceType.xlSrcRange, oWSheet.Range["$A$1:$O" + iRow], Type.Missing, XlYesNoGuess.xlYes).Name = "Tabla3";
                //oThisAddInApp.ActiveSheet.ListObjects("Tabla3").TableStyle = "TableStyleMedium2";
                //oWSheet.Columns["A:P"].EntireColumn.AutoFit();
                //oWSheet.Range["A1"].Select();

                return pck.GetAsByteArray();
            }
        }
    }
}
