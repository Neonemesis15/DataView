using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Lucky.Data;
using Datamercaderista.Models;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lucky.Entity.Common.Servicio;
using System.Configuration;
using System.Data.SqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

using Newtonsoft;
using Newtonsoft.Json;

using Lucky.Business;
using Lucky.Business.Common;
using Lucky.Business.Common.Servicio;

using System.Text;
using System.Text.RegularExpressions;
using Datamercaderista.ServicioGestionOperativa;
using System.Web.Script.Serialization;

namespace Datamercaderista.Controllers
{
    public class HomeController : Controller
    {
        public static Datamercaderista.Models.M_Usuario_Data user;

        public ActionResult Index()
        {
            //Session["usuario"] = "uchikarafk";
            //Session["idcompania"] = "1572";
            //Session["canaluser"] = "1002";
            //ViewBag.idcompania = "1572";
            //ViewBag.canal = "1002";


            /*
             * Datos de pruebas para Unacem 
            Session["usuario"] = "jvegalh";
            Session["idcompania"] = "1560";
            Session["canaluser"] = "1241";
            ViewBag.idcompania = "1560";
            ViewBag.canal = "1241";
            */

            //Session["usuario"] = "uaavvdc";
            //Session["idcompania"] = "1572";
            //Session["canaluser"] = "1025";
            //ViewBag.idcompania = "1572";
            //ViewBag.canal = "1025";

            /*
            Session["usuario"] = "dmercaderista";
            Session["idcompania"] = "1561";
            Session["canaluser"] = "2008";
            ViewBag.idcompania = "1561";
            ViewBag.canal = "2008";
            */

            //Session["usuario"] = "dmercaderista";
            //Session["idcompania"] = "1561";
            //Session["canaluser"] = "1000";
            //ViewBag.idcompania = "1561";
            //ViewBag.canal = "1000";

            //Session["usuario"] = "dmercaderista";
            //Session["idcompania"] = "1561";

            //Session["canaluser"] = "1000";
            //ViewBag.idcompania = "1561";
            //ViewBag.canal = "1000";

            Session["usuario"] = "dmercaderista";
            Session["idcompania"] = "1561";

            Session["canaluser"] = "1241";
            ViewBag.idcompania = "1561";
            ViewBag.canal = "1241";


            //Session["usuario"] = "colgate ecuador";
            //Session["idcompania"] = "1670";
            //Session["canaluser"] = "1241";
            //ViewBag.idcompania = "1670";
            //ViewBag.canal = "1241";

            try
            {
                string usuario = Session["usuario"].ToString();
                ViewBag.idcompania = Session["idcompania"].ToString();
                ViewBag.canal = Session["canaluser"].ToString();
                if (usuario == "" || usuario == null)
                {
                    this.Session.Abandon();
                    System.Web.HttpContext.Current.Response.Redirect("http://www.xplora.com.pe/login.aspx");
                    //System.Web.HttpContext.Current.Response.Redirect("http://localhost:61260/login.aspx");
                }
            }
            catch
            {
                this.Session.Abandon();
                System.Web.HttpContext.Current.Response.Redirect("http://www.xplora.com.pe/login.aspx");
                //System.Web.HttpContext.Current.Response.Redirect("http://localhost:61260/login.aspx");
            }
            return View();
        }

        public void Login()
        {
            string url = "";
            try
            {
                M_Usuario_Data_Service OM_Usuario_Service = new M_Usuario_Data_Service();
                string nombreUsuario = Request.QueryString["data"];
                if (nombreUsuario == null)
                {
                    this.Session.Abandon();
                    url = "http://www.xplora.com.pe/login.aspx";
                    //url = "http://localhost:61260/login.aspx";

                }
                nombreUsuario = Lucky.CFG.Util.Encriptacion.QueryStringDecode(nombreUsuario, "usr");
                user = OM_Usuario_Service.Obtener_Usuario_Data(nombreUsuario);


                if (user.nombreUsuario == "" || user.nombreUsuario == null)
                {
                    this.Session.Abandon();
                    url = "http://www.xplora.com.pe/login.aspx";
                    //url = "http://localhost:61260/login.aspx";

                }
                else
                {
                    string idcompania = user.codigoCliente;
                    string Personid = user.codigoUsuario;
                    string Perfilid = user.codigoPerfil;
                    string Nombre_Compania = user.nombreCliente;
                    string nombreCompleto = user.nombreCompleto;
                    string EmailUser = user.emailUsuario;
                    string canalUsuario = user.canalUsuario;

                    //ViewBag.nombreCompleto = nombreCompleto;
                    Session["nombreCompleto"] = nombreCompleto;
                    Session["idcompania"] = idcompania;
                    Session["personid"] = Personid;
                    Session["usuario"] = nombreUsuario;
                    Session["emailuser"] = EmailUser;
                    Session["canaluser"] = canalUsuario;


                    url = "http://www.xplora.com.pe:9093";
                    //url = "http://localhost:61260";

                }
            }
            catch
            {
                url = "http://www.xplora.com.pe/login.aspx";
                //url = "http://localhost:55830/login.aspx";
            }

            System.Web.HttpContext.Current.Response.Redirect(url);
            //return View();
        }

        public ActionResult Bienvenido()
        {
            return View();
        }

        public ActionResult Prueba()
        {

            return View();
        }

        public ActionResult Logout()
        {
            this.Session.Abandon();
            Session.Remove("idcompania");
            Session.Remove("Nombre_client");
            Response.Redirect("http://www.xplora.com.pe/login.aspx", false);

            return View();
        }

        public void Download(string img)
        {
            //var imagenArray = img.ToString();
            string[] imagen = img.Split('/');
            string patch = "C:/Paginas Lucky/Pages/Modulos/Operativo/Reports/FotoAndroid/" + imagen[imagen.Length - 1];
            //string patch = "/Archivos/" + img;

            System.IO.FileInfo toDownload = new System.IO.FileInfo(patch);
            if (toDownload.Exists)
            {
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + toDownload.Name);
                System.Web.HttpContext.Current.Response.AddHeader("Content-Length", toDownload.Length.ToString());
                System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                System.Web.HttpContext.Current.Response.WriteFile(patch);
                System.Web.HttpContext.Current.Response.End();
            }
        }

        //lista campania por canal por compania
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Listar_Menu(string idcompania, string node, string canal)
        {
            M_Menu oM_Campana = new M_Menu();
            M_Menu_Service oM_Menu_Service = new M_Menu_Service();

            if (node == "root") node = "0";
            //string a = id;
            var modelList = oM_Menu_Service.obtenerMenu(idcompania, node, canal);

            return Json(modelList, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Listar_Menu2(string idcompania, string node, string canal,string modulo)
        {
            M_Menu oM_Campana = new M_Menu();
            M_Menu_Service oM_Menu_Service = new M_Menu_Service();

            if (node == "root")
                node = "0";
            //string a = id;
            var modelList = oM_Menu_Service.obtenerMenu(idcompania, node, canal, modulo);

            return Json(modelList, JsonRequestBehavior.AllowGet);
        }

        //lista Canal por Compañia y Perfil
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListarCanal()
        {
            string idcompania = Session["idcompania"].ToString();
            M_Canal_Service oM_Canal_Service = new M_Canal_Service();

            var modelData = new List<SelectListItem>();

            var modelList = oM_Canal_Service.obtenerCanal(idcompania);

            foreach (var lista in modelList)
            {
                modelData.Add(new SelectListItem() { Text = lista.Namechannel, Value = lista.Codchanel });
            }
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //lista campania por canal por compania
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListarCampaniaxCanal_Compania(string idcanal, string idcompania)
        {

            M_Campana_Service oM_Campana_Service = new M_Campana_Service();
            var modelList = oM_Campana_Service.consulta(idcanal, idcompania);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Planning_Name,
                Value = u.Id_planning.ToString(),

            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        //Listar Node Commercial Type por canal
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListarNodeComTypes(string idcanal)
        {
            M_NodeComercial_Service oM_NodeComercial_Service = new M_NodeComercial_Service();
            var modelList = oM_NodeComercial_Service.Listar_NodeTypePorCanal(idcanal);
            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.NodeComTypename,
                Value = u.idNodeComType.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        //Listar Distribuidor por codCompania
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListarDistribuidorasPorCampania(string codCampania)
        {
            M_Distribuidor_Service oM_Distribuidor_Service = new M_Distribuidor_Service();
            var modelList = oM_Distribuidor_Service.ListarDistribuidorasPorCampania(codCampania);
            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.distribuidor,
                Value = u.id_dist.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //
        //lista mercaderistas por compania
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Listar_Generadores_Por_CodCampania_CodSupervisor(string CodCampania)
        {
            M_Mercaderista oM_Mercaderista = new M_Mercaderista();
            M_Mercaderista_Service oM_Mercaderista_Service = new M_Mercaderista_Service();
            string idS = "-1";
            var modelList = oM_Mercaderista_Service.consulta(CodCampania, idS);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Person_NameComplet,
                Value = u.Person_id.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //lista mercaderistas por compania y codSupervisor
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Listar_Generadores_Por_CodCampania_por_CodSupervisor(string CodCampania, string codSuper)
        {
            M_Mercaderista oM_Mercaderista = new M_Mercaderista();
            M_Mercaderista_Service oM_Mercaderista_Service = new M_Mercaderista_Service();
            var modelList = oM_Mercaderista_Service.consulta(CodCampania, codSuper);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Person_NameComplet,
                Value = u.Person_id.ToString(),

            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //lista oficina por compania
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Listar_Oficina_Por_Compania(string CodCompania)
        {
            M_Oficina oM_Oficina = new M_Oficina();
            M_Oficina_Service oM_Oficina_Service = new M_Oficina_Service();

            var modelList = oM_Oficina_Service.consulta(CodCompania);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Name_Oficina,
                Value = u.Cod_Oficina.ToString(),

            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //lista Malla por Canal y Compañia
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Listar_Malla(string CodCanal, string CodCompania, string CodOficina)
        {
            M_Malla_Request request = new M_Malla_Request();
            M_Malla_Service oM_Malla_Service = new M_Malla_Service();
            request.Cod_Channel = CodCanal;
            request.Cod_Compania = CodCompania;
            request.Cod_Oficina = CodOficina;
            var modelList = oM_Malla_Service.Consultar_Malla(request);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Name_Malla,
                Value = u.Cod_Malla.ToString(),

            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //lista Zona por Campaña
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Listar_NodeComercial_Por_CodCampania_CodCiudad(string CodCampania)
        {
            M_NodeComercial oM_NodeComercial = new M_NodeComercial();
            M_NodeComercial_Service oM_NodeComercial_Service = new M_NodeComercial_Service();

            var modelList = oM_NodeComercial_Service.Listar_NodeComercial_Por_CodCampania_CodCiudad(CodCampania);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.commercialNodeName,
                Value = u.id_NodeCommercial.ToString(),

            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //lista Mercado por Campania y Persona(Generador)
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Listar_NodeComercial_Por_CodCampania_CodPerson(string CodCampania, string CodPerson)
        {
            M_NodeComercial oM_NodeComercial = new M_NodeComercial();
            M_NodeComercial_Service oM_NodeComercial_Service = new M_NodeComercial_Service();

            var modelList = oM_NodeComercial_Service.Listar_NodoCommercial_Por_CodCampania_CodPerson(CodCampania, CodPerson);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.commercialNodeName,
                Value = u.id_NodeCommercial.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //lista PDV por Campaña Oficina y NodeComercial
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Listar_PuntoDeVenta_Por_CodCampania_CodOficina_CodCadena(string CodCampania, string CodOficina, string CodZona)
        {
            M_PuntoDeVenta oM_PuntoDeVenta = new M_PuntoDeVenta();
            M_PuntoDeVenta_Service oM_PuntoDeVenta_Service = new M_PuntoDeVenta_Service();

            var modelList = oM_PuntoDeVenta_Service.consulta(CodCampania, CodOficina, CodZona);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Pdv_Name,
                Value = u.ClientPDV_Code.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListarSubCategoria_Por_CodCategoria(string id_ProductCategory)
        {
            M_SubCategoria oM_Categoria = new M_SubCategoria();
            M_SubCategoria_Service oM_Categoria_Service = new M_SubCategoria_Service();

            var modelList = oM_Categoria_Service.consulta(id_ProductCategory);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Nombre_SubCategoria,
                Value = u.Cod_SubCategoria.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }


        //lista Cateogria por Campaña
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Listar_Categoria_Por_CodCampania(string CodCampania)
        {
            M_Categoria oM_Categoria = new M_Categoria();
            M_Categoria_Service oM_Categoria_Service = new M_Categoria_Service();

            var modelList = oM_Categoria_Service.consulta(CodCampania);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Product_Category,
                Value = u.Id_ProductCategory.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }

        //lista Cateogria por Campaña
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Listar_Categoria_Sancela(string Company_id, string Status)
        {
            M_Categoria oM_Categoria = new M_Categoria();
            M_Categoria_Service oM_Categoria_Service = new M_Categoria_Service();

            var modelList = oM_Categoria_Service.Listar_Categoria_por_Compania_Status(Company_id, Status);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Product_Category,
                Value = u.Id_ProductCategory.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Listar_Categoria_Por_CodCampania_Fotografico(string CodCampania)
        {
            M_Categoria oM_Categoria = new M_Categoria();
            M_Categoria_Service oM_Categoria_Service = new M_Categoria_Service();

            var modelList = oM_Categoria_Service.Listar_Categoria_porCampania(CodCampania);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Product_Category,
                Value = u.Id_ProductCategory.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }

        //lista Marca por Campaña
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Listar_Marca_Por_CodCategoria(string CodCategoria)
        {
            M_Marca oM_Marca = new M_Marca();
            M_Marca_Service oM_Marca_Service = new M_Marca_Service();

            var modelList = oM_Marca_Service.consulta(CodCategoria);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Name_Brand,
                Value = u.Id_Brand.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }

        //FILTRO - lista oficinas por codpais por codcliente por codcampania
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult listarOficinasPorCodPais_CodCliente_CodCampania(string codcampania)
        {
            M_Oficina_Service oM_Oficina_Service = new M_Oficina_Service();
            string idcompania = Session["idcompania"].ToString();
            M_Oficina_Request oM_Oficina_Request = new M_Oficina_Request();
            oM_Oficina_Request.codPais = "589";
            oM_Oficina_Request.codCliente = idcompania;
            oM_Oficina_Request.codCampania = codcampania;

            //M_Oficina ListaOficina = new M_Oficina();
            //ListaOficina.Cod_Oficina = 0;
            //ListaOficina.Name_Oficina = "-- Todos --";
            var modelLista = oM_Oficina_Service.consultarOficinas_Por_CodPais_CodCliente_CodCampania(oM_Oficina_Request);
            //modelLista.Add(ListaOficina);

            if (modelLista == null) return Json("");
            var modelData = modelLista.Select(o => new SelectListItem
            {
                Value = o.Cod_Oficina.ToString(),
                Text = o.Name_Oficina,
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //FILTRO-lista departamentos por codCliente por codCampania por codPais
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListarDepartamentos(string idoficina, string codCampania)
        {
            M_Departamento_Service oM_Departamento_Service = new M_Departamento_Service();
            M_Departamento_Request oM_Departamento_Request = new M_Departamento_Request();
            string idcompania = Session["idcompania"].ToString();
            oM_Departamento_Request.CodCliente = idcompania;
            oM_Departamento_Request.CodCampania = codCampania;
            oM_Departamento_Request.codPais = "589";
            oM_Departamento_Request.codOficina = idoficina;

            var modelLista = oM_Departamento_Service.listarDepartamentos_Por_CodCliente_Por_CodCampania_Por_CodPais_CodOficina(oM_Departamento_Request);
            if (modelLista == null) return Json("");
            var modelData = modelLista.Select(u => new SelectListItem()
            {
                Text = u.NombreDepartamento,
                Value = u.CodDepartamento.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //FILTRO-lista departamentos por codCampania  
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListarDepartamentosxCampania(string idcampania)
        {
            M_Departamento_Service oM_Departamento_Service = new M_Departamento_Service();

            var modelLista = oM_Departamento_Service.getDepartamentoxCampania(idcampania);
            if (modelLista == null) return Json("");
            var modelData = modelLista.Select(u => new SelectListItem()
            {
                Text = u.NombreDepartamento,
                Value = u.CodDepartamento.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //FILTRO-listar provincias por codCampania por codPais por codDepartamento
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListarProvincias(string codCampania, string codOficina, string codDpto)
        {
            M_Provincia_Service oM_Provincia_Service = new M_Provincia_Service();
            M_Provincia_Request oM_Provincia_Request = new M_Provincia_Request();
            oM_Provincia_Request.CodCampania = codCampania;
            oM_Provincia_Request.codPais = "589";
            oM_Provincia_Request.codDepartamento = codDpto;
            oM_Provincia_Request.codOficina = codOficina;
            var modelLista = oM_Provincia_Service.listarProvincias_Por_Campania_Por_CodPais_Por_CodOficina_Por_codDepartamento(oM_Provincia_Request);
            if (modelLista == null) return Json("");
            var modelData = modelLista.Select(d => new SelectListItem()
            {
                Text = d.NombreProvincia,
                Value = d.CodProvincia.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //Lista Provincia por Cod de Departamento
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListarProvincias_CodDpto(string codDpto)
        {
            M_Provincia_Service oM_Provincia_Service = new M_Provincia_Service();
            Obtener_Provincia_Por_CodDepartamento_Request oM_Provincia_Request = new Obtener_Provincia_Por_CodDepartamento_Request();
            oM_Provincia_Request.codPais = "589";
            oM_Provincia_Request.codDepartamento = codDpto;
            var modelLista = oM_Provincia_Service.Obtener_Provincia_Por_CodDepartamento(oM_Provincia_Request);
            if (modelLista == null) return Json("");
            var modelData = modelLista.Select(d => new SelectListItem()
            {
                Text = d.NombreProvincia,
                Value = d.CodProvincia.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        //Listar Conos por Pais, Dpto y Provincia

        public JsonResult ListarConos(string codPais, string codDepartamento, string codProvincia)
        {
            Sector_Service oM_SectorCono_Service = new Sector_Service();
            var modelList = oM_SectorCono_Service.obtener_sector(codPais, codDepartamento, codProvincia);
            if (modelList == null)
            {
                E_Sector lista = new E_Sector();
                List<E_Sector> modelList2 = new List<E_Sector>();
                lista.codSector = "0";
                lista.nombreSector = "Sin datos disponibles";
                modelList2.Add(lista);
                var modelData2 = modelList2.Select(u => new SelectListItem()
                {
                    Text = u.nombreSector,
                    Value = u.codSector.ToString(),

                });
                return Json(modelData2, JsonRequestBehavior.AllowGet);
            }
            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.nombreSector,
                Value = u.codSector.ToString(),

            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        //Listar Conos por Pais, Dpto y Provincia

        public JsonResult ListarConos2(string company_Id)
        {
            Sector_Service oM_SectorCono_Service = new Sector_Service();
            var modelList = oM_SectorCono_Service.obtener_sector_2(company_Id);
            if (modelList == null)
            {
                E_Sector lista = new E_Sector();
                List<E_Sector> modelList2 = new List<E_Sector>();
                lista.codSector = "0";
                lista.nombreSector = "Sin datos disponibles";
                modelList2.Add(lista);
                var modelData2 = modelList2.Select(u => new SelectListItem()
                {
                    Text = u.nombreSector,
                    Value = u.codSector.ToString(),

                });
                return Json(modelData2, JsonRequestBehavior.AllowGet);
            }
            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.nombreSector,
                Value = u.codSector.ToString(),

            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        //Listar Conos por Distribuidora
        public JsonResult ListarConos_Por_Dex(string codDex)
        {
            Sector_Service oM_SectorCono_Service = new Sector_Service();
            var modelList = oM_SectorCono_Service.obtener_sector_por_Dex(codDex);
            if (modelList == null)
            {
                E_Sector lista = new E_Sector();
                List<E_Sector> modelList2 = new List<E_Sector>();
                lista.codSector = "0";
                lista.nombreSector = "Sin datos disponibles";
                modelList2.Add(lista);
                var modelData2 = modelList2.Select(u => new SelectListItem()
                {
                    Text = u.nombreSector,
                    Value = u.codSector.ToString(),

                });
                return Json(modelData2, JsonRequestBehavior.AllowGet);
            }
            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.nombreSector,
                Value = u.codSector.ToString(),

            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //FILTRO-Listar distritos por Campania-Pais-Dpto-Provincia.
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult listarDistritos(string codPais, string codDepartamento, string codProvincia, string codSector)
        {
            M_Distrito_Service oM_Distrito_Service = new M_Distrito_Service();

            List<M_Distrito> Distritos = new List<M_Distrito>();
            var modelLista = oM_Distrito_Service.obtener_Distritos_por_sector(codPais, codDepartamento, codProvincia, codSector);
            if (modelLista == null)
            {
                M_Distrito Distrito = new M_Distrito();

                Distrito.CodDistrito = "0";
                Distrito.NombreDistrito = "Sin datos disponibles";
                Distritos.Add(Distrito);
                modelLista = Distritos;
            }
            var modelData = modelLista.Select(distrito => new SelectListItem()
            {
                Text = distrito.NombreDistrito,
                Value = distrito.CodDistrito.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //---obtener_Distritos_por_sector
        //FILTRO-Listar distritos por Campania-Pais-Dpto-Provincia.
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult listarDistritosAAVV(string codPais, string codDepartamento, string codProvincia, string codDistribuidora, string codSector)
        {
            M_Distrito_Service oM_Distrito_Service = new M_Distrito_Service();

            List<M_Distrito> Distritos = new List<M_Distrito>();
            var modelLista = oM_Distrito_Service.obtener_Distritos_por_sector_2(codPais, codDepartamento, codProvincia, codDistribuidora, codSector);
            if (modelLista == null)
            {
                M_Distrito Distrito = new M_Distrito();

                Distrito.CodDistrito = "0";
                Distrito.NombreDistrito = "Sin datos disponibles";
                Distritos.Add(Distrito);
                modelLista = Distritos;
            }
            var modelData = modelLista.Select(distrito => new SelectListItem()
            {
                Text = distrito.NombreDistrito,
                Value = distrito.CodDistrito.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //lista Reporte por Campaña
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListarReporte(string idcampania)
        {
            M_Reporte_Service oM_Reporte_Service = new M_Reporte_Service();

            var modelList = oM_Reporte_Service.consulta(idcampania);
            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Report_NameReport,
                Value = u.Report_Id.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //lista SubReportes por Tipo de Reporte 
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarSubReporte(string idreporte, string idcompania, string idcanal)
        {
            M_Sub_Reporte_Service oM_ListarSubReporte = new M_Sub_Reporte_Service();
            var modelList = oM_ListarSubReporte.consulta(idreporte, idcompania, idcanal);
            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Nombre_SubReporte,
                Value = u.Cod_SubReporte.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //lista Ciudades por Campania 
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarCiudades(string idcampania)
        {
            M_Ciudad_Service oM_Ciudad_Service = new M_Ciudad_Service();
            var modelList = oM_Ciudad_Service.getCiudadesxCampania(idcampania);
            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.NomCiudad,
                Value = u.CodCiudad.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //lista ciudades por campaña x departamento
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarCiudadxCampaniaxDpto(string codCam, string idDpto)
        {
            M_Ciudad_Service oM_Ciudad_Service = new M_Ciudad_Service();
            M_Ciudad oM_Ciudad = new M_Ciudad();
            oM_Ciudad.cod_campania = codCam;
            oM_Ciudad.Cod_Departamento = idDpto;
            var modelList = oM_Ciudad_Service.Consultar(oM_Ciudad);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.NomCiudad,
                Value = u.CodCiudad.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }

        //Listar mercados por campania, departamento, provincia(ciudad)
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarNodeComercial(string idcampania, string idDpto, string idCiudad)
        {
            M_NodeComercial_Service oM_NodeComercial_Service = new M_NodeComercial_Service();

            var modelList = oM_NodeComercial_Service.Listar_NodoCommercial_Por_CodCampania_CodDepartamento_CodProvincia(idcampania, idDpto, idCiudad);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.commercialNodeName,
                Value = u.id_NodeCommercial.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }

        //Listar mercados por campania, oficina(ciudad)
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarPDVPorCampaniaxCiudad(string idcampania, string idCiudad)
        {
            M_NodeComercial_Service oM_NodeComercial_Service = new M_NodeComercial_Service();

            var modelList = oM_NodeComercial_Service.Listar_NodeComercial_Por_CodCampania_CodOficina(idcampania, idCiudad);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.commercialNodeName,
                Value = u.id_NodeCommercial.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }
        ////////
        //Listar mercados por campania, Persona
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarPDVxCampaniaxPerson(string CodCampania, string CodPerson, string Fecha_Ini, string Fecha_Fin)
        {
            M_PuntoDeVenta_Service oM_PuntoDeVenta_Service = new M_PuntoDeVenta_Service();

            List<M_PuntoDeVenta> models = new List<M_PuntoDeVenta>();
            var modelList = oM_PuntoDeVenta_Service.ListarPDV_Campania_Person(CodCampania, CodPerson, Fecha_Ini, Fecha_Fin);
            if (modelList == null || modelList.Count == 0)
            {
                M_PuntoDeVenta oPDV = new M_PuntoDeVenta();
                oPDV.ClientPDV_Code = "0";
                oPDV.Pdv_Name = "Sin datos Disponibles";
                models.Add(oPDV);
                modelList = models;
            }

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Pdv_Name,
                Value = u.ClientPDV_Code.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }

        //Listar mercados por campania, Persona
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarPDVxCampaniaxPersonNodeFecIniFecFin(string CodCampania, string CodPerson, string CodNode, string Fecha_Ini, string Fecha_Fin)
        {
            M_PuntoDeVenta_Service oM_PuntoDeVenta_Service = new M_PuntoDeVenta_Service();

            List<M_PuntoDeVenta> models = new List<M_PuntoDeVenta>();
            var modelList = oM_PuntoDeVenta_Service.ListarPDV_Por_CodCampania_Person_Node_FecIni_FecFin(CodCampania, CodPerson, CodNode, Fecha_Ini, Fecha_Fin);
            if (modelList == null || modelList.Count == 0)
            {
                M_PuntoDeVenta oPDV = new M_PuntoDeVenta();
                oPDV.ClientPDV_Code = "0";
                oPDV.Pdv_Name = "Sin datos Disponibles";
                models.Add(oPDV);
                modelList = models;
            }

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Pdv_Name,
                Value = u.ClientPDV_Code.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }

        //Listar mercados por campania, Persona
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarPDVxCampaniaxNodeCommercial(string CodCampania, string CodNode)
        {
            M_PuntoDeVenta_Service oM_PuntoDeVenta_Service = new M_PuntoDeVenta_Service();

            List<M_PuntoDeVenta> models = new List<M_PuntoDeVenta>();
            var modelList = oM_PuntoDeVenta_Service.Listar_PDV_Por_Campania_NodeCommercial(CodCampania, CodNode);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Pdv_Name,
                Value = u.ClientPDV_Code.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //Listar_NodeComercial_Por_ClienteCanalOficinaSector
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Listar_NodeComercial_Por_ClienteCanalOficinaSector(string cod_Cliente, string cod_Canal, string cod_Oficina, string id_Sector)
        {
            M_NodeComercial_Service oM_NodeComercial_Service = new M_NodeComercial_Service();

            List<M_NodeComercial_receive> modelo = new List<M_NodeComercial_receive>();
            var modelList = oM_NodeComercial_Service.Listar_NodeComercial_Por_ClienteCanalOficinaSector(cod_Cliente, cod_Canal, cod_Oficina, id_Sector);

            if (modelList == null || modelList.Count == 0)
            {
                M_NodeComercial_receive oSec = new M_NodeComercial_receive();
                // CEYA
                oSec.id_NodeCommercial = "0";
                oSec.commercialNodeName = "Sin datos Disponibles";
                modelo.Add(oSec);
                modelList = modelo;
            }

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.commercialNodeName,
                Value = u.id_NodeCommercial.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //Listar supervisores por campania
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarSupervisores(string idcampania)
        {
            M_Supervisor_Service oM_Supervisor_Service = new M_Supervisor_Service();

            var modelList = oM_Supervisor_Service.consulta(idcampania);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Person_NameComplet,
                Value = u.Person_id.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }

        //Listar supervisores por campania, Dpto, prov y distrito
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarSupervisores_Camp_Dpto_Prov_Dist(string idcampania, string CodDpto, string CodProv, string CodDist)
        {
            M_Supervisor_Service oM_Supervisor_Service = new M_Supervisor_Service();

            var modelList = oM_Supervisor_Service.ListarSupervisorCampaniaDptoProvDist(idcampania, CodDpto, CodProv, CodDist);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Person_NameComplet,
                Value = u.Person_id.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }

        //Listar supervisores por campania
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarSupervisoresCampaniaOficina(string idCompany, string Cod_Campania, string CodOficina)
        {
            M_Supervisor_Service oM_Supervisor_Service = new M_Supervisor_Service();

            var modelList = oM_Supervisor_Service.ListarSupervisorCampaniaOficina(idCompany, Cod_Campania, CodOficina);
            if (modelList == null || modelList.Count == 0)
            {
                M_Supervisor oPDV = new M_Supervisor();
                oPDV.Person_id = 0;
                oPDV.Person_NameComplet = "Sin datos Disponibles";
                modelList.Add(oPDV);
            }
            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Person_NameComplet,
                Value = u.Person_id.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }
        //Listar mercaderistas
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarMercaderistas(string idcampania, string idsupervisor)
        {
            M_Mercaderista_Service oM_Mercaderista_Service = new M_Mercaderista_Service();

            var modelList = oM_Mercaderista_Service.consulta(idcampania, idsupervisor);
            if (modelList == null || modelList.Count == 0)
            {
                M_Mercaderista oPDV = new M_Mercaderista();
                oPDV.Person_id = 0;
                oPDV.Person_NameComplet = "Sin datos Disponibles";
                modelList.Add(oPDV);
            }
            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Person_NameComplet,
                Value = u.Person_id.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarCliente_Company_Person(string idcampania, string idPerson, string fecha_inicio, string fecha_fin)
        {
            M_PuntoDeVenta_Service oM_PuntoDeVenta_Service = new M_PuntoDeVenta_Service();

            var modelList = oM_PuntoDeVenta_Service.ListarPDV_Campania_Person(idcampania, idPerson, fecha_inicio, fecha_fin);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Pdv_Name,
                Value = u.ClientPDV_Code.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);

        }

        //lista pdv por campania y oficina
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarPDVxCampaniaxDptoxCiudadxCadena(string idcampania, string idCiudad, string idMercado)
        {
            M_PuntoDeVenta_Service oM_PuntoDeVenta_Service = new M_PuntoDeVenta_Service();

            var modelList = oM_PuntoDeVenta_Service.consultaPDV_CodCampania_CodCiudad_CodCadena(idcampania, idCiudad, idMercado);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Pdv_Name,
                Value = u.ClientPDV_Code.ToString(),

            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //lista pdv por campania y oficina y cono(malla)
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarPDVxCampaniaxOficinaxCono(string idcampania, string idCiudad, string idCono)
        {
            M_PuntoDeVenta_Service oM_PuntoDeVenta_Service = new M_PuntoDeVenta_Service();

            var modelList = oM_PuntoDeVenta_Service.Listar_PDV_Por_Campania_Oficina_Cono(idcampania, idCiudad, idCono);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Pdv_Name,
                Value = u.ClientPDV_Code.ToString(),

            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //lista pdv por Campania y NodeComercial(Cadena)
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult ListarPDVxCampaniaxCadena(string idcampania, string idMercado)
        {
            M_PuntoDeVenta_Service oM_PuntoDeVenta_Service = new M_PuntoDeVenta_Service();

            var modelList = oM_PuntoDeVenta_Service.consultaPDV_CodCampania_CodCadena(idcampania, idMercado);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Pdv_Name,
                Value = u.ClientPDV_Code.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        //[AcceptVerbs(HttpVerbs.Get)]
        //public JsonResult Listar_Anios_Planning(string id_planning)
        //{
        //    M_PuntoDeVenta_Service oM_PuntoDeVenta_Service = new M_PuntoDeVenta_Service();

        //    var modelList = oM_PuntoDeVenta_Service.consultaPDV_CodCampania_CodCadena(idcampania, idMercado);

        //    var modelData = modelList.Select(u => new SelectListItem()
        //    {
        //        Text = u.Pdv_Name,
        //        Value = u.ClientPDV_Code.ToString(),

        //    });
        //    return Json(modelData, JsonRequestBehavior.AllowGet);
        //}

        //CEYA Periodos

        #region Gestion de periodo

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Listar_Periodo_Por_CodServicio_CodCanal_CodCliente_CodReporte_Anio_Mes(string CodServicio, string CodCanal, string CodCliente, string CodReporte, string Anio, string Mes)
        {
            M_Periodo_Service oM_Periodo_Service = new M_Periodo_Service();

            List<M_Periodo> modelo = new List<M_Periodo>();
            var modelList = oM_Periodo_Service.Listar_Periodo_Por_CodServicio_CodCanal_CodCliente_CodReporte_Anio_Mes(CodServicio, CodCanal, CodCliente, CodReporte, Anio, Mes);

            if (modelList == null || modelList.Count == 0)
            {
                M_Periodo oSec = new M_Periodo();
                // CEYA
                oSec.Cod_Periodo = "0";
                oSec.Nombre_Periodo = "Sin datos Disponibles";
                modelo.Add(oSec);
                modelList = modelo;
            }

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Nombre_Periodo,
                Value = u.Cod_Periodo.ToString(),

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creado por: jlucero
        /// Fecha: 2014-03-05
        /// Descripción: UP_WEBXPLORA_PERIODO_X_PLANNING_REPORTS_ANIO_MES
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Periodo_Por_Planning_Reports_Anio_Mes(string planning, string report, string anio, string mes)
        {
            Periodo_Request oRq = new Periodo_Request();
            Periodo_Response oRs;

            oRq.id_planning = planning;
            oRq.id_report = int.Parse(report);
            oRq.anio = int.Parse(anio);
            oRq.mes = int.Parse(mes);

            oRs = JsonConvert.DeserializeObject<Periodo_Response>(Util.oCampaniaService.Periodo_Por_Planning_Reports_Anio_Mes(Util.SerializeObject(oRq)));
            if (oRs == null || oRs.Lista == null || oRs.Lista.Count == 0)
            {
                List<Periodo> oLs = new List<Periodo>();
                Periodo oOb = new Periodo();
                oOb.id = "0";
                oOb.descripcion = "No disponible";
                oLs.Add(oOb);
                oRs.Lista = oLs;
            }

            var modelData = oRs.Lista.Select(u => new SelectListItem()
            {
                Text = u.descripcion,
                Value = u.id
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        #endregion

        //Listar_Supervisor_Por_CodCampania
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Listar_Supervisor_Por_CodCampania(string CodCampania)
        {
            M_Supervisor_Service oM_Supervisor_Service = new M_Supervisor_Service();

            var modelList = oM_Supervisor_Service.Listar_Supervisor_Por_CodCampania(CodCampania);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Person_NameComplet,
                Value = u.Person_id.ToString(),

            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        #region Gestion de anios
        //lista Anios
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetAnios()
        {
            M_Periodo_Service oPeriodService = new M_Periodo_Service();

            var modelList = oPeriodService.GetAnios();
            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Anio.ToString(),
                Value = u.Anio.ToString()
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creado por: jlucero
        /// Fecha: 2014-03-04
        /// Descripción: UP_WEBXPLORA_PERIODO_X_PLANNING_REPORTS
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Anio_Por_Planning_Reports(string planning, string report)
        {
            Models.E_Anio_Request oRq = new Models.E_Anio_Request();
            Models.E_Anio_Response oRs;

            oRq.id_planning = planning;
            oRq.id_report = int.Parse(report);

            oRs = JsonConvert.DeserializeObject<Models.E_Anio_Response>(Util.oCampaniaService.Anio_Por_Planning_Reports(Util.SerializeObject(oRq)));
            if (oRs == null || oRs.Lista == null || oRs.Lista.Count == 0)
            {
                List<Models.E_Anio> oLs = new List<Models.E_Anio>();
                Models.E_Anio oOb = new Models.E_Anio();
                oOb.id = "0";
                oOb.descripcion = "No disponible";
                oLs.Add(oOb);
                oRs.Lista = oLs;
            }

            var modelData = oRs.Lista.Select(u => new SelectListItem()
            {
                Text = u.descripcion,
                Value = u.id
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Gestion de mes

        //lista Meses
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetMeses()
        {
            M_Periodo_Service oPeriodService = new M_Periodo_Service();

            var modelList = oPeriodService.GetMeses();
            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Nombre,
                Value = u.CodMes
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creado por: jlucero
        /// Fecha: 2014-03-04
        /// Descripción: UP_WEBXPLORA_MES_X_PLANNING_REPORTS_PERIODO
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Mes_Por_Planning_Reports_Anio(string planning, string report, string anio)
        {
            Meses_Request oRq = new Meses_Request();
            Meses_Response oRs;

            oRq.id_planning = planning;
            oRq.id_report = int.Parse(report);
            oRq.anio = int.Parse(anio);

            oRs = JsonConvert.DeserializeObject<Meses_Response>(Util.oCampaniaService.Mes_Por_Planning_Reports_Anio(Util.SerializeObject(oRq)));
            if (oRs == null || oRs.Lista == null || oRs.Lista.Count == 0)
            {
                List<Meses> oLs = new List<Meses>();
                Meses oOb = new Meses();
                oOb.id = "0";
                oOb.descripcion = "No disponible";
                oLs.Add(oOb);
                oRs.Lista = oLs;
            }

            var modelData = oRs.Lista.Select(u => new SelectListItem()
            {
                Text = u.descripcion,
                Value = u.id
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        #endregion

        //lista Meses
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetPeriodos(string codCampania, string anio, string mes, int codReporte)
        {
            M_Periodo_Service oPeriodService = new M_Periodo_Service();

            var modelList = oPeriodService.GetPeriodos(codCampania, anio, mes, codReporte);
            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Label,
                Value = u.Cod_Periodo

            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPeriodo(int codPeriodo, int anio, int mes)
        {
            M_Periodo_Service oPeriodService = new M_Periodo_Service();
            var modelPeriodo = oPeriodService.GetPeriodo(codPeriodo, anio, mes);

            return Json(modelPeriodo, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPeriodoShortString(int codPeriodo, int anio, int mes)
        {
            M_Periodo_Service oPeriodService = new M_Periodo_Service();
            var modelPeriodo = oPeriodService.GetPeriodoShortString(codPeriodo, anio, mes);

            return Json(modelPeriodo, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExportToExcel(string model, string data, string title)
        {
            DataSet ds = new DataSet();
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            ds.Tables.Add(dt);
            Session[title] = Util.ExportExcelWithShets(ds, title);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public FileResult GetExcelFile(string title)
        {
            // Is there a spreadsheet stored in session?
            if (Session[title] != null)
            {
                // Get the spreadsheet from seession.
                byte[] file = Session[title] as byte[];
                string filename = string.Format("{0}.xlsx", title);

                // Remove the spreadsheet from session.
                Session.Remove(title);

                // Return the spreadsheet.
                Response.Buffer = true;
                //Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", filename));
                return File(file, "application/ms-excel", filename);
            }
            else
            {
                throw new Exception(string.Format("{0} No se encontró", title));
            }
        }

        #region WebXplora - Mercaderista

        /// <summary>
        /// Creado por: jlucero
        /// Fecha: 2014-02-25
        /// Descripción: WebXplora_Mercaderista_Obtiene_Ciudad
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Obtiene_Ciudad(string cod_country, string cod_dpto)
        {
            E_Ciudad_Request oRq = new E_Ciudad_Request();
            E_Ciudad_Response oRs;
            oRq.cod_country = cod_country;
            oRq.cod_dpto = cod_dpto;


            oRs = JsonConvert.DeserializeObject<E_Ciudad_Response>(Util.oOperativaService.WebXplora_Mercaderista_Obtiene_Ciudad(Util.SerializeObject(oRq)));
            
            if (oRs == null) return Json("");
            var modelData = oRs.Lista.Select(u => new SelectListItem()
            {
                Text = u.NomCiudad,
                Value = u.CodCiudad
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creado por: jlucero
        /// Fecha: 2014-02-25
        /// Descripción: UP_WEBXPLORA_AUTOSERVICIO_DISTRITO
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Obtiene_Distrito(string pais, string departamento, string provincia)
        {
            E_Distrito_Request oRq = new E_Distrito_Request();
            E_Distrito_Response oRs;
            oRq.pais = pais;
            oRq.departamento = departamento;
            oRq.provincia = provincia;

            oRs = JsonConvert.DeserializeObject<E_Distrito_Response>(Util.oOperativaService.WebXplora_Mercaderista_Obtiene_Distrito(Util.SerializeObject(oRq)));

            if (oRs == null) return Json("");
            var modelData = oRs.Lista.Select(u => new SelectListItem()
            {
                Text = u.dst_descripcion,
                Value = u.dst_id
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creado por: jlucero
        /// Fecha: 2014-02-27
        /// Descripción: SP_XPL_GES_CAM_OBTENER_NODECOMMERCIAL_POR_CAMPANIA_DEPARTAMENTO_PROVINCIA_DISTRITO
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Obtiene_Cadena(string CodCampania, string CodDepartamento, string CodProvincia, string CodDistrito)
        {
            NodoCommercial_Campania_Departamento_Provincia_Distrito_Request oRq = new NodoCommercial_Campania_Departamento_Provincia_Distrito_Request();
            oRq.Cod_Campania = CodCampania;
            oRq.Cod_Departamento = CodDepartamento;
            oRq.Cod_Provincia = CodProvincia;
            oRq.Cod_Distrito = CodDistrito;

            var oModelo = JsonConvert.DeserializeObject<NodoCommercial_Campania_Departamento_Provincia_Distrito_Response>(Util.oCampaniaService.Listar_NodoCommercial_Por_CodCampania_CodDepartamento_CodProvincia_Distrito(Util.SerializeObject(oRq)));
            if (oModelo == null || oModelo.Lista == null || oModelo.Lista.Count == 0)
            { 
                List<NodoCommercial_Id_Name> oLs = new List<NodoCommercial_Id_Name>();
                NodoCommercial_Id_Name oOb = new NodoCommercial_Id_Name();
                oOb.id_NodeCommercial = "0";
                oOb.commercialNodeName = "Sin datos disponibles.";
                oLs.Add(oOb);
                oModelo.Lista = oLs;
            }

            var modelData = oModelo.Lista.Select(u => new SelectListItem()
            {
                Text = u.commercialNodeName,
                Value = u.id_NodeCommercial
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creado por: jlucero
        /// Fecha: 2014-02-27
        /// Descripción: SP_XPL_GES_CAM_OBTENER_PUNTODEVENTA_POR_CODCAMPANIA_CODDEPARTAMENTO_CODPROVINCIA_NODECOMMERCIAL
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Obtiene_Tienda(string CodCampania, string CodDepartamento, string CodProvincia, string CodNodoCommercial)
        {
            PuntoDeVenta_Campania_Departamento_Provincia_Cadena_Request oRq = new PuntoDeVenta_Campania_Departamento_Provincia_Cadena_Request();
            oRq.Cod_Campania = CodCampania;
            oRq.Cod_Departamento = CodDepartamento;
            oRq.Cod_Provincia = CodProvincia;
            oRq.Cod_NodoCommercial = CodNodoCommercial;

            var oModelo = JsonConvert.DeserializeObject<PuntoDeVenta_Campania_Departamento_Provincia_Cadena_Response>(Util.oCampaniaService.Listar_PuntoDeVenta_Por_CodCampania_CodDepartamento_CodProvincia_CodNodeCommercial(Util.SerializeObject(oRq)));

            if (oModelo == null || oModelo.Lista == null || oModelo.Lista.Count == 0)
            {
                List<PuntoDeVenta_Id_Name> oLs = new List<PuntoDeVenta_Id_Name>();
                PuntoDeVenta_Id_Name oOb = new PuntoDeVenta_Id_Name();
                oOb.ClientPDV_Code = "0";
                oOb.Pdv_Name = "Sin datos disponibles.";
                oLs.Add(oOb);
                oModelo.Lista = oLs;
            }

            var modelData = oModelo.Lista.Select(u => new SelectListItem()
            {
                Text = u.Pdv_Name,
                Value = u.ClientPDV_Code
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creado por: jlucero
        /// Fecha: 2014-03-05
        /// Descripción: UP_WEBXPLORA_DIAS_X_PERIODO
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Fecha_Por_Periodo(string id)
        {
            Fecha_Por_Periodo_Request oRq = new Fecha_Por_Periodo_Request();
            oRq.id = int.Parse(id);

            var oModelo = JsonConvert.DeserializeObject<Fecha_Por_Periodo_Response>(Util.oOperativaService.Fecha_Por_Periodo(Util.SerializeObject(oRq)));

            if (oModelo == null || oModelo.Lista == null || oModelo.Lista.Count == 0)
            {
                List<Models.Fecha> oLs = new List<Models.Fecha>();
                Models.Fecha oOb = new Models.Fecha();
                oOb.fec_id = "0";
                oOb.fec_fecha = "Sin datos disponibles.";
                oLs.Add(oOb);
                oModelo.Lista = oLs;
            }

            var modelData = oModelo.Lista.Select(u => new SelectListItem()
            {
                Text = u.fec_fecha,
                Value = u.fec_id
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creado por: jlucero
        /// Fecha: 2014-03-05
        /// Descripción: 
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Pla_MObservacion_Por_Planning_Report(string planning, int report)
        {
            Models.Pla_MObservacion_Request oRq = new Models.Pla_MObservacion_Request();
            oRq.planning = planning;
            oRq.report = report;

            var oModelo = JsonConvert.DeserializeObject<Models.Pla_MObservacion_Response>(Util.oOperativaService.Pla_MObservacion_Por_Planning_Report(Util.SerializeObject(oRq)));

            if (oModelo == null || oModelo.Lista == null || oModelo.Lista.Count == 0)
            {
                List<Models.Pla_MObservacion> oLs = new List<Models.Pla_MObservacion>();
                Models.Pla_MObservacion oOb = new Models.Pla_MObservacion();
                oOb.pmo_id = "0";
                oOb.pmo_descripcion = "Sin datos disponibles.";
                oLs.Add(oOb);
                oModelo.Lista = oLs;
            }

            var modelData = oModelo.Lista.Select(u => new SelectListItem()
            {
                Text = u.pmo_descripcion,
                Value = u.pmo_id
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creado por: jlucero
        /// Fecha: 2014-03-10
        /// Descripción: 
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Tipo_Oferta_Por_Planning_Report(string planning, int report)
        {
            Models.Tipo_Oferta_Request oRq = new Models.Tipo_Oferta_Request();
            oRq.planning = planning;
            oRq.report = report;

            var oModelo = JsonConvert.DeserializeObject<Models.Tipo_Oferta_Response>(Util.oOperativaService.Tipo_Oferta_Por_Planning_Report(Util.SerializeObject(oRq)));

            if (oModelo == null || oModelo.Lista == null || oModelo.Lista.Count == 0)
            {
                List<Models.Tipo_Oferta> oLs = new List<Models.Tipo_Oferta>();
                Models.Tipo_Oferta oOb = new Models.Tipo_Oferta();
                oOb.tof_id = "0";
                oOb.tof_descripcion = "Sin datos disponibles.";
                oLs.Add(oOb);
                oModelo.Lista = oLs;
            }

            var modelData = oModelo.Lista.Select(u => new SelectListItem()
            {
                Text = u.tof_descripcion,
                Value = u.tof_id
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creado por: jlucero
        /// Fecha: 2014-03-11
        /// Descripción: 
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Grupo_Objetivo_Por_Planning_Report(string planning, int report)
        {
            Models.Grupo_Objetivo_Request oRq = new Models.Grupo_Objetivo_Request();
            oRq.planning = planning;
            oRq.report = report;

            var oModelo = JsonConvert.DeserializeObject<Models.Grupo_Objetivo_Response>(Util.oOperativaService.Grupo_Objetivo_Por_Planning_Report(Util.SerializeObject(oRq)));

            if (oModelo == null || oModelo.Lista == null || oModelo.Lista.Count == 0)
            {
                List<Models.Grupo_Objetivo> oLs = new List<Models.Grupo_Objetivo>();
                Models.Grupo_Objetivo oOb = new Models.Grupo_Objetivo();
                oOb.gob_id = "0";
                oOb.gob_descripcion = "Sin datos disponibles.";
                oLs.Add(oOb);
                oModelo.Lista = oLs;
            }

            var modelData = oModelo.Lista.Select(u => new SelectListItem()
            {
                Text = u.gob_descripcion,
                Value = u.gob_id
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creado por: jlucero
        /// Fecha: 2014-03-12
        /// Descripción: 
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Tipo_Material_Por_Planning_Report_Company(string planning, int report, int company)
        {
            Models.Tipo_Material_Request oRq = new Models.Tipo_Material_Request();
            oRq.planning = planning;
            oRq.report = report;
            oRq.company = company;

            var oModelo = JsonConvert.DeserializeObject<Models.Tipo_Material_Response>(Util.oOperativaService.Tipo_Material_Por_Planning_Report_Company(Util.SerializeObject(oRq)));

            if (oModelo == null || oModelo.Lista == null || oModelo.Lista.Count == 0)
            {
                List<Models.Tipo_Material> oLs = new List<Models.Tipo_Material>();
                Models.Tipo_Material oOb = new Models.Tipo_Material();
                oOb.atm_id = "0";
                oOb.atm_descripcion = "Sin datos disponibles.";
                oLs.Add(oOb);
                oModelo.Lista = oLs;
            }

            var modelData = oModelo.Lista.Select(u => new SelectListItem()
            {
                Text = u.atm_descripcion,
                Value = u.atm_id
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Creado por: jlucero
        /// Fecha: 2014-03-12
        /// Descripción: 
        /// </summary>
        /// 
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Material_Por_Planning_Report_Company_Tipo_Material(string planning, int report, int company, string tipo_material)
        {
            Models.Material_Request oRq = new Models.Material_Request();
            oRq.planning = planning;
            oRq.report = report;
            oRq.company = company;
            oRq.tipo_material = tipo_material;

            var oModelo = JsonConvert.DeserializeObject<Models.Material_Response>(Util.oOperativaService.Material_Por_Planning_Report_Company_Tipo_Material(Util.SerializeObject(oRq)));

            if (oModelo == null || oModelo.Lista == null || oModelo.Lista.Count == 0)
            {
                List<Models.Material> oLs = new List<Models.Material>();
                Models.Material oOb = new Models.Material();
                oOb.pop_id = "0";
                oOb.pop_descripcion = "Sin datos disponibles.";
                oLs.Add(oOb);
                oModelo.Lista = oLs;
            }

            var modelData = oModelo.Lista.Select(u => new SelectListItem()
            {
                Text = u.pop_descripcion,
                Value = u.pop_id
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }

    //Clase con metodo para convertir lista en un table
    public static class Util
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {

            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable("Tabla");
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static string DataTableToJson(DataTable table)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

            foreach (DataRow row in table.Rows)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();

                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                list.Add(dict);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue };
            return serializer.Serialize(list);
        }

        public static DataTable ConvertJSONToDataTable(string jsonString)
        {
            DataTable dt = new DataTable();
            //strip out bad characters
            string[] jsonParts = Regex.Split(jsonString.Replace("[", "").Replace("]", "").Replace(":null", ":"), "},{");

            //hold column names
            List<string> dtColumns = new List<string>();

            //get columns
            foreach (string jp in jsonParts)
            {
                //only loop thru once to get column names
                string[] propData = Regex.Split(jp.Replace("{", "").Replace("}", ""), ",");
                foreach (string rowData in propData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string n = rowData.Substring(0, idx - 1);
                        string v = rowData.Substring(idx + 1);
                        if (!dtColumns.Contains(n))
                        {
                            dtColumns.Add(n.Replace("\"", ""));
                        }
                    }
                    catch (Exception)
                    {
                        throw new Exception(string.Format("Error Parsing Column Name : {0}", rowData));
                    }

                }
                break; // TODO: might not be correct. Was : Exit For
            }

            //build dt
            foreach (string c in dtColumns)
            {
                dt.Columns.Add(c);
            }
            //get table data
            foreach (string jp in jsonParts)
            {
                string[] propData = Regex.Split(jp.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dt.NewRow();
                foreach (string rowData in propData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string n = rowData.Substring(0, idx - 1).Replace("\"", "");
                        string v = rowData.Substring(idx + 1).Replace("\"", "");
                        nr[n] = v;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }

                }
                dt.Rows.Add(nr);
            }
            return dt;
        }

        public static string getRutaVirtualdeRutaFisica /*GetVirtualPathFromPhysicalFilePath*/(string rutafisica)
        {
            return rutafisica.Replace(HttpRuntime.AppDomainAppPath, "/").Replace(Path.DirectorySeparatorChar, '/');
        }

        public static void DataTableToExcel(DataTable tbl)
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            foreach (DataColumn c in tbl.Columns)
            {
                context.Response.Write(c.ColumnName + ";");
            }
            context.Response.Write(Environment.NewLine);
            foreach (DataRow r in tbl.Rows)
            {
                for (int i = 0; i < tbl.Columns.Count; i++)
                {
                    context.Response.Write(r[i].ToString().Replace(";", string.Empty) + ";");
                }
                context.Response.Write(Environment.NewLine);
            }
            context.Response.ContentType = "application/vnd.ms-excel";
            context.Response.AppendHeader("Content-Disposition",
                "attachment; filename=export.xlsx");
            context.Response.End();
        }

        public static DataTable procesoValidar(string Checked, string unChecked)
        {

            string[] aunChecked = unChecked.Split(',');
            string [] aChecked = Checked.Split(',');

            DataTable table = new DataTable("table");
            DataRow row;

            table.Columns.Add("Checked");
            table.Columns.Add("unChecked");

            foreach (String item in aunChecked)
            {
                row = table.NewRow();
                row["unChecked"] = item;
                table.Rows.Add(row);
            }
            foreach (String item in aChecked)
            {
                row = table.NewRow();
                row["Checked"] = item;
                table.Rows.Add(row);
            }

            ConnectionStringSettings settingconection;
            settingconection = ConfigurationManager.ConnectionStrings["ConectaDBLucky"];
            string oSqlConnIN = settingconection.ConnectionString;

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(oSqlConnIN))
            {
                bulkCopy.DestinationTableName = "tbl_datavalidada";
                //carga temporal para hacer el procedimiento a través de un SP
                bulkCopy.WriteToServer(table);
            }

            return table;
        }

        public static byte[] ExportExcelWithShets(DataSet ds, string FileName)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    //Create the worksheet
                    DataTable dt = ds.Tables[i];
                    string sheetName = dt.TableName;
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(sheetName);

                    //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                    ws.Cells["A1"].LoadFromDataTable(dt, true);

                    //Format the header for column 1-3
                    using (ExcelRange rng = ws.Cells[1, 1, 1, dt.Columns.Count])//Cells["A1:C1"]
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                        rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                        rng.Style.Font.Color.SetColor(Color.White);
                    }

                    //Example how to Format Column 1 as numeric 
                    using (ExcelRange col = ws.Cells[2, 1, 1 + dt.Rows.Count, dt.Columns.Count])
                    {
                        //col.Style.Numberformat.Format = "#,##0.00";                
                        col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    }
                }

                return pck.GetAsByteArray();
            }
        }

        //Convertir Datatable a Json
        public static string GetJSONString(DataTable Dt)
        {
            string RetVal = string.Empty;
            string[] StrDc = new string[Dt.Columns.Count];
            string HeadStr = string.Empty;

            StringBuilder Sb = new StringBuilder();
            string TempStr = string.Empty;
            int i = 0;
            int j = 0;

            try
            {
                for (i = 0; i <= Dt.Columns.Count - 1; i++)
                {
                    StrDc[i] = Dt.Columns[i].Caption;
                    HeadStr += "\"" + StrDc[i] + "\" : \"" + StrDc[i] + i.ToString() + "¾" + "\",";
                }

                HeadStr = HeadStr.Substring(0, HeadStr.Length - 1);

                Sb.Append("{\"" + Convert.ToString(Dt.TableName) + "\" : [");

                for (i = 0; i <= Dt.Rows.Count - 1; i++)
                {
                    TempStr = HeadStr;
                    Sb.Append("{");

                    for (j = 0; j <= Dt.Columns.Count - 1; j++)
                    {
                        TempStr = TempStr.Replace(Dt.Columns[j].ToString() + j.ToString() + "¾", Dt.Rows[i][j].ToString());
                    }

                    Sb.Append(TempStr + "},");
                }

                Sb = new StringBuilder(Sb.ToString().Substring(0, Sb.ToString().Length - 1));
                Sb.Append("]}");

                RetVal = Sb.ToString();
            }
            catch
            {
            }

            return RetVal;
        }

        #region Service References

        //-- BL_Ges_Operativa
        public static BL_GES_Operativa oBl = new BL_GES_Operativa();

        //-- Ges_OperativaServiceClient
        public static ServicioGestionOperativa.Ges_OperativaServiceClient oOperativaService = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");
       
        //-- Ges_CampaniaServiceClient
        public static ServicioGestionCampania.Ges_CampaniaServiceClient oCampaniaService = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
       
        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.None); //-- serializa parametro
        }

        #endregion
    }
}