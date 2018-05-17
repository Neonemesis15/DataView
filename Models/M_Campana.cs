using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_Campana
    {
        [JsonProperty("a")]
        public string Id_planning { get; set; }
        [JsonProperty("b")]
        public string Planning_Name { get; set; }


    }

    public class M_Campana_Response
    {
        [JsonProperty("a")]
        public List<M_Campana> listaCampanias { get; set; }
    }



    public class M_Campana_Service
    {

        public List<M_Campana> consulta(string id, string idcompania)
        {

            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");



            string dataJson;
            string request;

            request = "{'b':'" + idcompania + "','a':'" + id + "'}";
            dataJson = client.Listar_Campania_Por_CodCanal_y_CodCompania(request);


            M_Campana_Response oM_Campana_Response = HelperJson.Deserialize<M_Campana_Response>(dataJson);

            return oM_Campana_Response.listaCampanias;
        }

    }
}