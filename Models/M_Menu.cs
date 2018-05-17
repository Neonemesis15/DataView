using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_Menu
    {
        [JsonProperty("a")]
        private string Id;
        public int id {
            get
            {
                return Convert.ToInt32(Id);
            }
            set{}
        }
        [JsonProperty("b")]
        public string text { get; set; }
        [JsonProperty("c")]
        public Boolean leaf { get; set; }
        [JsonProperty("d")]
        public string icon { get; set; }
        [JsonProperty("e")]
        public string hrefTarget { get; set; }
        [JsonProperty("g")]
        public Boolean expanded { get; set; }
        [JsonProperty("f")]
        private string Parent_Id;
        public int parent_id
        {
            get{
                return Convert.ToInt32(Parent_Id);
            }
            set{}
        }

    }
    public class M_Menu_Response
    {
        [JsonProperty("a")]
        public List<M_Menu> listaMenu { get; set; }
    }

    public class M_Menu_Service
    {

        public List<M_Menu> obtenerMenu(string idcompany,string nodo,string canal)
        {

            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = "{'a':'01','b':'"+idcompany+"','c':'" + nodo + "','d':'"+canal+"'}";
            dataJson = client.Listar_Menu_Datamercaderista(request);
            client.Close();

            M_Menu_Response oM_Menu = HelperJson.Deserialize<M_Menu_Response>(dataJson);

            return oM_Menu.listaMenu;
        }
        public List<M_Menu> obtenerMenu(string idcompany, string nodo, string canal, string modulo)
        {

            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = "{'a':'" + modulo + "','b':'" + idcompany + "','c':'" + nodo + "','d':'" + canal + "'}";
            dataJson = client.Listar_Menu_Datamercaderista(request);
            client.Close();

            M_Menu_Response oM_Menu = HelperJson.Deserialize<M_Menu_Response>(dataJson);

            return oM_Menu.listaMenu;
        }

    }
}