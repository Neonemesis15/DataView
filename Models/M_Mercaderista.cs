using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_Mercaderista
    {
        [JsonProperty("a")]
        public int Person_id { get; set; }
        [JsonProperty("h")]
        public string Person_NameComplet { get; set; }
    }
    public class M_Mercaderista_Response
    {
        [JsonProperty("a")]
        public List<M_Mercaderista> listaMercaderista { get; set; }
    }

    public class M_Mercaderista_Service
    {

        public List<M_Mercaderista> consulta(string idC, string idS)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + idC + "','b':'" + idS + "'}";
            dataJson = client.Listar_Generadores_Por_CodCampania_Por_CodSupervisor(request);

            M_Mercaderista_Response oM_Mercaderista_Response = HelperJson.Deserialize<M_Mercaderista_Response>(dataJson);

            return oM_Mercaderista_Response.listaMercaderista;
        }


    }
}