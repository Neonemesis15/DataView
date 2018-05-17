using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_Malla
    {
        [JsonProperty("a")]
        public string Cod_Malla { get; set; }
        [JsonProperty("b")]
        public string Name_Malla { get; set; }
    }

    public class M_Malla_Request
    {
        [JsonProperty("a")]
        public string Cod_Channel { get; set; }
        [JsonProperty("b")]
        public string Cod_Compania { get; set; }
        [JsonProperty("c")]
        public string Cod_Oficina { get; set; }
    }

    public class M_Malla_Response
    {
        [JsonProperty("a")]
        public List<M_Malla> listaMalla { get; set; }
    }

    public class M_Malla_Service
    {

        public List<M_Malla> Consultar_Malla(M_Malla_Request oM_Malla)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = HelperJson.Serialize<M_Malla_Request>(oM_Malla);

            dataJson = client.Listar_Malla(request);//se tiene que cambier por el metodo correcto

            M_Malla_Response oM_Malla_Response = HelperJson.Deserialize<M_Malla_Response>(dataJson);



            return oM_Malla_Response.listaMalla;

        }
    }
}