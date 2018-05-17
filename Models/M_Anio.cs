using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_Anio
    {
        [JsonProperty("a")]
        public int anio { get; set; }
        [JsonProperty("b")]
        public string id_planning { get; set; }
    }

    public class M_Anio_Response
    {
        [JsonProperty("a")]
        public List<M_Anio> listaAnio { get; set; }
    }


    public class M_Anio_Service
    {

        public List<M_Canal> obtenerAnio(string id_planning)
        {

            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = "{'a':'" + id_planning + "'}";
            dataJson = client.Listar_Anios_Planning(request);

            M_Canal_Response oM_Canal = HelperJson.Deserialize<M_Canal_Response>(dataJson);

            return oM_Canal.listaCanales;
        }
    }
}
