using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;
namespace Datamercaderista.Models
{
    public class M_Distribuidor
    {
        [JsonProperty("a")]
        public string id_dist { get; set; }
        [JsonProperty("b")]
        public string distribuidor { get; set; }
    }
    public class Distribuidor_Request
    {
        [JsonProperty("a")]
        public string codCompania { get; set; }
    }
    public class Distribuidor_Response
    {
        [JsonProperty("a")]
        public List<M_Distribuidor> Distribuidores { get; set; }
    }
    public class M_Distribuidor_Service
    {
        public List<M_Distribuidor> ListarDistribuidorasPorCampania(string codCampania)
        {
            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");
            Distribuidor_Request request = new Distribuidor_Request();
            Distribuidor_Response response = new Distribuidor_Response();
            string requestJSON;
            string responseJSON;

            request.codCompania = codCampania;
            requestJSON = HelperJson.Serialize<Distribuidor_Request>(request);
            responseJSON = client.ListarDistribuidorasPorCampania(requestJSON);

            response = HelperJson.Deserialize<Distribuidor_Response>(responseJSON);

            return response.Distribuidores;
        }
    }


    public class Llenar_Distribuidoras_Request
    {
        [JsonProperty("a")]
        public string cod_equipo { get; set; }
    }
    public class M_Distribuidor_X_planning_Service
    {
        public List<M_Distribuidor> Listar_Distribuidoras_planning(string cod_planning)
        {
           // ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            ServicioGestionCampania.Ges_CampaniaServiceClient clientcampania = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            Llenar_Distribuidoras_Request request = new Llenar_Distribuidoras_Request();
            Distribuidor_Response response = new Distribuidor_Response();
            string requestJSON;
            string responseJSON;

            request.cod_equipo = cod_planning;
            requestJSON = HelperJson.Serialize<Llenar_Distribuidoras_Request>(request);

            responseJSON = clientcampania.Llenar_Distribuidoras(requestJSON);

            response = HelperJson.Deserialize<Distribuidor_Response>(responseJSON);

            return response.Distribuidores;
        }
    }


}