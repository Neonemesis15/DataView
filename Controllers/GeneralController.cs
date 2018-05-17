using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datamercaderista.Models;

namespace Datamercaderista.Controllers
{
    public class GeneralController : Controller
    {
        //
        // GET: /General/

        public ActionResult Index()
        {
            return View();
        }

        //lista Canal por Compañia y Perfil
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListarCanal()
        {
            string idcompania = Session["idcompania"].ToString();//HttpContext.Request.Cookies["companyid"].Value;"1561"
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
        public ActionResult ListarCampaniaxCanal_Compania(string id, string idcompania)
        {
            M_Campana oM_Campana = new M_Campana();
            M_Campana_Service oM_Campana_Service = new M_Campana_Service();

            string a = id;
            var modelList = oM_Campana_Service.consulta(id, idcompania);

            var modelData = modelList.Select(u => new SelectListItem()
            {
                Text = u.Planning_Name,
                Value = u.Id_planning.ToString(),

            });
            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        
        
    }
}
