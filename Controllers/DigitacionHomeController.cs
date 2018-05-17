using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datamercaderista.Models.Ecuador;

namespace Datamercaderista.Controllers.Ecuador
{
    public partial class EcuDigitacionController : Controller
    {
        #region VISTAS

        //
        // GET: /EcuDigitacionHome/
        public ActionResult Precios()
        {
            DateTime Hoy = DateTime.Today;
            ViewBag.fecRelevo = Hoy.ToString("dd/MM/yyyy");
            ViewBag.codPais = "774";
            return View();
        }
        public ActionResult Visibilidad()
        {
            DateTime Hoy = DateTime.Today;
            ViewBag.fecRelevo = Hoy.ToString("dd/MM/yyyy");
            ViewBag.codPais = "774";
            ViewBag.codReporte = "66";
            return View();
        }
        public ActionResult Promociones()
        {
            DateTime Hoy = DateTime.Today;
            ViewBag.fecRelevo = Hoy.ToString("dd/MM/yyyy");
            ViewBag.codPais = "774";
            ViewBag.codReporte = "55";
            return View();
        }
        public ActionResult Publicaciones()
        {
            DateTime Hoy = DateTime.Today;
            ViewBag.fecRelevo = Hoy.ToString("dd/MM/yyyy");
            ViewBag.codPais = "774";
            //ViewBag.codReporte = "66";
            return View();
        }
        public ActionResult Exhibiciones()
        {
            DateTime Hoy = DateTime.Today;
            ViewBag.fecRelevo = Hoy.ToString("dd/MM/yyyy");
            ViewBag.codPais = "774";
            //ViewBag.codReporte = "66";
            return View();
        }
        public ActionResult SOD()
        {
            DateTime Hoy = DateTime.Today;
            ViewBag.fecRelevo = Hoy.ToString("dd/MM/yyyy");
            ViewBag.codPais = "774";
            //ViewBag.codReporte = "66";
            return View();
        }
        public ActionResult Stock()
        {
            DateTime Hoy = DateTime.Today;
            ViewBag.fecRelevo = Hoy.ToString("dd/MM/yyyy");
            ViewBag.codPais = "774";
            //ViewBag.codReporte = "66";
            return View();
        }
        public ActionResult Quiebres()
        {
            DateTime Hoy = DateTime.Today;
            ViewBag.fecRelevo = Hoy.ToString("dd/MM/yyyy");
            ViewBag.codPais = "774";
            //ViewBag.codReporte = "66";
            return View();
        }
        public ActionResult ProductosVista()
        {
            DateTime Hoy = DateTime.Today;
            ViewBag.fecRelevo = Hoy.ToString("dd/MM/yyyy");
            ViewBag.codPais = "774";
            ViewBag.codReporte = "165";
            return View();
        }
        /*FALTAN ASIGNAR SUS REPORTES CORRECTOS*/
        #endregion
        #region LAYOUT DATAMERCADERISTA
        public ActionResult Index()
        {
            Session["usuario"] = "colgate ecuador";
            Session["idcompania"] = "1670";
            Session["canaluser"] = "1241";
            ViewBag.idcompania = "1670";
            ViewBag.canal = "1241";
            try
            {
                string usuario = Session["usuario"].ToString();
                ViewBag.idcompania = Session["idcompania"].ToString();
                ViewBag.canal = Session["canaluser"].ToString();
                if (usuario == "" || usuario == null)
                {
                    this.Session.Abandon();
                    System.Web.HttpContext.Current.Response.Redirect("http://services.lucky.com.pe:8082/login.aspx");
                    //System.Web.HttpContext.Current.Response.Redirect("http://localhost:61260/login.aspx");
                }
            }
            catch
            {
                this.Session.Abandon();
                System.Web.HttpContext.Current.Response.Redirect("http://services.lucky.com.pe:8082/login.aspx");
                //System.Web.HttpContext.Current.Response.Redirect("http://localhost:61260/login.aspx");
            }
            return View();
        }
        #endregion
        #region OBTENCION PARA LOS FILTROS 

        public JsonResult Obtener_Clientes(int v_codperson, int v_country)
        {

            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "1";
            ollenarCombos_Request.filtros = v_codperson.ToString() + ",774";


            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                int v_cant2 = oE_DinamicArray.Contents[x].Length;
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }
            if (oListM_combo.Count > 0)
            {
                var modelData = oListM_combo.Select(u => new SelectListItem()
                {
                    Value = u.codigo.ToString(),
                    Text = u.descripcion.ToString(),
                });
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelData = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0",Text ="Sin resultado"}
                };
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }      
        }
        public JsonResult Obtener_Canal(int v_codCliente, int v_country)
        {

            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "2";
            ollenarCombos_Request.filtros = v_codCliente.ToString() + "," + v_country.ToString();


            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                int v_cant2 = oE_DinamicArray.Contents[x].Length;
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }

            if (oListM_combo.Count > 0)
            {
                var modelData = oListM_combo.Select(u => new SelectListItem()
                {
                    Value = u.codigo.ToString(),
                    Text = u.descripcion.ToString(),
                });
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelData = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0",Text ="Sin resultado"}
                };
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }      

        }
        public JsonResult Obtener_Equipo(int v_codcliente, int v_codcanal)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "3";
            ollenarCombos_Request.filtros = "774," + v_codcliente.ToString() + "," + v_codcanal.ToString();


            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                int v_cant2 = oE_DinamicArray.Contents[x].Length;
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }

            if (oListM_combo.Count > 0)
            {
                var modelData = oListM_combo.Select(u => new SelectListItem()
                {
                    Value = u.codigo.ToString(),
                    Text = u.descripcion.ToString(),
                });
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelData = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0",Text ="Sin resultado"}
                };
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }      

        }
        public JsonResult Obtener_Anio(string v_codequipo)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "8";
            ollenarCombos_Request.filtros = v_codequipo.ToString() + ",19";


            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                int v_cant2 = oE_DinamicArray.Contents[x].Length;
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }

            var modelData = oListM_combo.Select(u => new SelectListItem()
            {
                Value = u.codigo.ToString(),
                Text = u.descripcion.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Obtener_Mes(string v_codequipo, string v_codanio)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "9";
            ollenarCombos_Request.filtros = v_codequipo.ToString() + ",19," + v_codanio.ToString();


            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                int v_cant2 = oE_DinamicArray.Contents[x].Length;
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }

            var modelData = oListM_combo.Select(u => new SelectListItem()
            {
                Value = u.codigo.ToString(),
                Text = u.descripcion.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Obtener_Fabricante_x_Planning(string v_codequipo)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "24";
            ollenarCombos_Request.filtros = v_codequipo.ToString();


            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                int v_cant2 = oE_DinamicArray.Contents[x].Length;
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }

            var modelData = oListM_combo.Select(u => new SelectListItem()
            {
                Value = u.codigo.ToString(),
                Text = u.descripcion.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Obtener_Periodo(string v_codequipo, string v_codanio, string v_codmes)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "10";
            ollenarCombos_Request.filtros = v_codequipo.ToString() + ",19," + v_codanio.ToString() + "," + v_codmes.ToString();


            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                int v_cant2 = oE_DinamicArray.Contents[x].Length;
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }

            var modelData = oListM_combo.Select(u => new SelectListItem()
            {
                Value = u.codigo.ToString(),
                Text = u.descripcion.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Obtener_Periodo2(string v_codequipo, string v_codreporte)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "27";
            ollenarCombos_Request.filtros = v_codequipo.ToString() + "," + v_codreporte.ToString();


            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                int v_cant2 = oE_DinamicArray.Contents[x].Length;
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }

            var modelData = oListM_combo.Select(u => new SelectListItem()
            {
                Value = u.codigo.ToString(),
                Text = u.descripcion.ToString(),
            });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Obtener_TipoCadena(int v_codcliente, string v_codequipo)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "4";
            ollenarCombos_Request.filtros = v_codcliente.ToString() + "," + v_codequipo;


            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                int v_cant2 = oE_DinamicArray.Contents[x].Length;
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }

            if (oListM_combo.Count > 0)
            {
                var modelData = oListM_combo.Select(u => new SelectListItem()
                {
                    Value = u.codigo.ToString(),
                    Text = u.descripcion.ToString(),
                });
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelData =new List<SelectListItem>
                {
                    new SelectListItem{Value = "0",Text ="Sin resultado"}
                };
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }           
        }
        public JsonResult Obtener_Cadena(int v_codcliente, string v_codequipo, string v_codtipcadena)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "5";
            ollenarCombos_Request.filtros = v_codcliente.ToString() + "," + v_codequipo.ToString() + "," + v_codtipcadena.ToString();


            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                int v_cant2 = oE_DinamicArray.Contents[x].Length;
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }

            if (oListM_combo.Count > 0)
            {
                var modelData = oListM_combo.Select(u => new SelectListItem()
                {
                    Value = u.codigo.ToString(),
                    Text = u.descripcion.ToString(),
                });
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelData = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0",Text ="Sin resultado"}
                };
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }      

        }
        public JsonResult Obtener_Depart(int v_codcliente, string v_codequipo, string v_codtipcadena, string v_codcadena)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "6";
            ollenarCombos_Request.filtros = "774," + v_codcliente.ToString() + "," + v_codequipo.ToString() + "," + v_codtipcadena.ToString() + "," + v_codcadena.ToString();


            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                int v_cant2 = oE_DinamicArray.Contents[x].Length;
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }

            if (oListM_combo.Count > 0)
            {
                var modelData = oListM_combo.Select(u => new SelectListItem()
                {
                    Value = u.codigo.ToString(),
                    Text = u.descripcion.ToString(),
                });
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelData = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0",Text ="Sin resultado"}
                };
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }      
        }
        public JsonResult Obtener_Provin(int v_codcliente, string v_codequipo, string v_codtipcadena, string v_codcadena, string v_coddepart)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "7";
            ollenarCombos_Request.filtros = "774," + v_codcliente.ToString() + "," + v_codequipo.ToString() + "," + v_codtipcadena.ToString() + "," + v_codcadena.ToString() + "," + v_coddepart.ToString();


            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                int v_cant2 = oE_DinamicArray.Contents[x].Length;
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }

            if (oListM_combo.Count > 0)
            {
                var modelData = oListM_combo.Select(u => new SelectListItem()
                {
                    Value = u.codigo.ToString(),
                    Text = u.descripcion.ToString(),
                });
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelData = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0",Text ="Sin resultado"}
                };
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }      
        }

        //Creado Por :Ditmar Estrada
        //18/09/2013
        public JsonResult Obtener_GiesPorCampaniaUbigeo
            (string v_codequipo, string v_codpais,string v_codDept,string v_codCity)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "12";
            ollenarCombos_Request.filtros = v_codequipo + "," + v_codpais + "," + v_codDept + "," + v_codCity;

            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }

            if (oListM_combo.Count > 0)
            {
                var modelData = oListM_combo.Select(u => new SelectListItem()
                {
                    Value = u.codigo.ToString(),
                    Text = u.descripcion.ToString(),
                });
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelData = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0",Text ="Sin resultado"}
                };
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }      
        }
        //Creado Por :Ditmar Estrada
        //18/09/2013
        public JsonResult Obtener_PdvsPorCampaniaPersonaUbigeo(string v_codequipo, string v_codpais, string v_codDept, string v_codCity,string v_codPersona)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "13";
            ollenarCombos_Request.filtros = v_codequipo + "," + v_codpais + "," + v_codDept + "," + v_codCity+","+v_codPersona;

            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }
            if (oListM_combo.Count > 0)
            {
                var modelData = oListM_combo.Select(u => new SelectListItem()
                {
                    Value = u.codigo.ToString(),
                    Text = u.descripcion.ToString(),
                });
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelData = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0",Text ="Sin resultado"}
                };
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }      
        }
        //Creado Por :Ditmar Estrada
        //18/09/2013

        public JsonResult Obtener_CategoriasPorCampaniaReporte(string v_codequipo, string v_codReporte)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "14";
            ollenarCombos_Request.filtros = v_codequipo + ","+ v_codReporte;

            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }
            if (oListM_combo.Count > 0)
            {
                var modelData = oListM_combo.Select(u => new SelectListItem()
                {
                    Value = u.codigo.ToString(),
                    Text = u.descripcion.ToString(),
                });
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelData = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0",Text ="Sin resultado"}
                };
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }      
        }

        public JsonResult Obtener_SubCategoriasPorCategoria(string v_codcategoria)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "25";
            ollenarCombos_Request.filtros = v_codcategoria;

            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }
            if (oListM_combo.Count > 0)
            {
                var modelData = oListM_combo.Select(u => new SelectListItem()
                {
                    Value = u.codigo.ToString(),
                    Text = u.descripcion.ToString(),
                });
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelData = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0",Text ="Sin resultado"}
                };
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }
        }

        //Creado Por :Ditmar Estrada
        //18/09/2013
        public JsonResult Obtener_MarcasPorCampaniaCategoReporte(string v_codequipo, string v_codReporte,string v_codCategoria)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = "15";
            ollenarCombos_Request.filtros = v_codequipo + "," + v_codReporte + "," + v_codCategoria;

            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }
            if (oListM_combo.Count > 0)
            {
                var modelData = oListM_combo.Select(u => new SelectListItem()
                {
                    Value = u.codigo.ToString(),
                    Text = u.descripcion.ToString(),
                });
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var modelData = new List<SelectListItem>
                {
                    new SelectListItem{Value = "0",Text ="Sin resultado"}
                };
                return Json(modelData, JsonRequestBehavior.AllowGet);
            }      
        }
        public JsonResult Obtener_SubReportes(string codReporte)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            List<M_combo> oListM_combo = service.GetComboItems(21, codReporte);
            var modelData = oListM_combo.Select(u => new SelectListItem()
            {
                Value = u.codigo.ToString(),
                Text = u.descripcion.ToString(),
            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
