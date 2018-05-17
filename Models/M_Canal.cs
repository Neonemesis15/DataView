using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_Canal
    {
        [JsonProperty("a")]
        public string Codchanel { get; set; }

        [JsonProperty("c")]
        public string Namechannel { get; set; }
    }

    public class M_Canal_Response
    {
        [JsonProperty("a")]
        public List<M_Canal> listaCanales { get; set; }
    }


    public class M_Canal_Service
    {

        public List<M_Canal> obtenerCanal(string idcompania)
        {

            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = "{'a':'" + idcompania + "'}";
            dataJson = client.Listar_Canales_Por_CodCompania(request);

            M_Canal_Response oM_Canal = HelperJson.Deserialize<M_Canal_Response>(dataJson);

            return oM_Canal.listaCanales;
        }
    }
}