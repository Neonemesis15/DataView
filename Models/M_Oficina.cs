using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_Oficina
    {
        [JsonProperty("a")]
        public long Cod_Oficina { get; set; }
        [JsonIgnore()]
        public int Company_id { get; set; }
        [JsonProperty("c")]
        public string Name_Oficina { get; set; }
        [JsonIgnore()]
        public string Abreviatura { get; set; }
        [JsonIgnore()]
        public int Orden { get; set; }
        [JsonIgnore()]
        public int Id_malla { get; set; }//Add 27/04/2012 PSA. No existe en el Framework Entity.Common.Application
        [JsonIgnore()]
        public bool Oficina_Status { get; set; }
        [JsonIgnore()]
        public string Oficina_CreateBy { get; set; }
        [JsonIgnore()]
        public DateTime Oficina_DateBy { get; set; }
        [JsonIgnore()]
        public string Oficina_ModiBy { get; set; }
        [JsonIgnore()]
        public DateTime Oficina_DateModiBy { get; set; }
    }

    public class M_Oficina_Response
    {
        [JsonProperty("a")]
        public List<M_Oficina> listaOficinas { get; set; }
    }

    public class M_Oficina_Request
    {
        [JsonProperty("a")]
        public string codPais { get; set; }
        [JsonProperty("b")]
        public string codCliente { get; set; }
        [JsonProperty("c")]
        public string codCampania { get; set; }
    }

// Request para consulta de oficinas por distribuidora
    public class Llenar_Ofinas_distribuidora_Request
    {
        [JsonProperty("a")]
        public string cod_equipo { get; set; }
        [JsonProperty("b")]
        public int cod_distribuidora { get; set; }
    }

    public class M_Oficina_Service
    {

        public List<M_Oficina> consulta(string idcompania)
        {

            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = "{'a':'" + idcompania + "'}";
            dataJson = client.Listar_Oficinas_Por_CodCompania(request);

            M_Oficina_Response oM_Oficina_Response = HelperJson.Deserialize<M_Oficina_Response>(dataJson);

            return oM_Oficina_Response.listaOficinas;
        }
        public List<M_Oficina> consultarOficinas_Por_CodPais_CodCliente_CodCampania(M_Oficina_Request oM_Oficina_Request)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string request = HelperJson.Serialize<M_Oficina_Request>(oM_Oficina_Request);
            string response = client.Listar_Oficinas_Por_CodPais_CodCliente_CodCampania(request);
            M_Oficina_Response oM_Oficina_Response = HelperJson.Deserialize<M_Oficina_Response>(response);
            return oM_Oficina_Response.listaOficinas;

        }


        public List<M_Oficina> Listar_oficinas_x_Distribuidor(string cod_planning,int cod_distribuidora)
        {
            // ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            ServicioGestionCampania.Ges_CampaniaServiceClient clientcampania = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            Llenar_Ofinas_distribuidora_Request request = new Llenar_Ofinas_distribuidora_Request();
            M_Oficina_Response response = new M_Oficina_Response();
            string requestJSON;
            string responseJSON;

            request.cod_equipo = cod_planning;
            request.cod_distribuidora = cod_distribuidora;
            requestJSON = HelperJson.Serialize<Llenar_Ofinas_distribuidora_Request>(request);

            responseJSON = clientcampania.Llenar_Oficinas_Distribuidor(requestJSON);

            response = HelperJson.Deserialize<M_Oficina_Response>(responseJSON);

            return response.listaOficinas;
        }
    }
}