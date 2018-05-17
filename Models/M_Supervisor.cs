using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuckyMer.Contracts.DataContract;
using Lucky.CFG.JavaMovil;
using Newtonsoft.Json;


namespace Datamercaderista.Models
{
    public class M_Supervisor
    {
        [JsonProperty("a")]
        public int Person_id { get; set; }
        [JsonProperty("h")]
        public string Person_NameComplet { get; set; }

    }

    public class M_Supervisor_Response
    {
        [JsonProperty("a")]
        public List<M_Supervisor> listaSupervisor { get; set; }
    }

    //Request de supervisores por equipo

    public class Llenar_Supervisor_equipo_Request
    {
        [JsonProperty("a")]
        public string cod_equipo { get; set; }
        [JsonProperty("b")]
        public int cod_empresa { get; set; }
    }
    public class Llenar_GIE_equipo_Request
    {
        [JsonProperty("a")]
        public string cod_equipo { get; set; }
        [JsonProperty("b")]
        public int cod_empresa { get; set; }
        [JsonProperty("c")]
        public int cod_supervisor { get; set; }
    }
    public class Llenar_Supervisor_equipo_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_Supervisor> oListaSupervisores { get; set; }

    }

    public class M_Supervisor_Service
    {
        public List<M_Supervisor> consulta(string idC)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = "{'a':'" + idC + "'}";
            dataJson = client.Listar_Supervisor_Por_CodCampania(request);
            M_Supervisor_Response oM_Supervisor_Response = HelperJson.Deserialize<M_Supervisor_Response>(dataJson);
            return oM_Supervisor_Response.listaSupervisor;
        }

        public List<M_Supervisor> ListarSupervisorCampaniaOficina(string idCompany, string Cod_Campania, string CodOficina)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = "{'a':'" + idCompany + "','b':'" + Cod_Campania + "','c':'" + CodOficina + "'}";
            dataJson = client.Listar_Supervisor_Por_CodCampania_Por_CodOficina(request);
            M_Supervisor_Response oM_Supervisor_Response = HelperJson.Deserialize<M_Supervisor_Response>(dataJson);
            return oM_Supervisor_Response.listaSupervisor;
        }

        public List<M_Supervisor> ListarSupervisorCampaniaDptoProvDist(string Cod_Campania, string CodDpto, string CodProv, string CodDist)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = "{'a':'" + Cod_Campania + "','b':'" + CodDpto + "','c':'" + CodProv + "','d':'" + CodDist + "'}";
            dataJson = client.Listar_Supervisor_Por_CodCampania_Dpto_Prov_Dist(request);
            M_Supervisor_Response oM_Supervisor_Response = HelperJson.Deserialize<M_Supervisor_Response>(dataJson);
            return oM_Supervisor_Response.listaSupervisor;
        }

        public List<M_Supervisor> Listar_Supervisor_Por_CodCampania(string Cod_Campania)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = "{'a':'" + Cod_Campania + "'}";
            dataJson = client.Listar_Supervisor_Por_CodCampania(request);
            M_Supervisor_Response oM_Supervisor_Response = HelperJson.Deserialize<M_Supervisor_Response>(dataJson);
            return oM_Supervisor_Response.listaSupervisor;
        }
        /*Listar_Supervisor_Por_CodCampania*/

        public List<M_Supervisor> Listar_Supervisores_equipo(string cod_planning, int cod_emprea)
        {           
            ServicioGestionCampania.Ges_CampaniaServiceClient clientcampania = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            Llenar_Supervisor_equipo_Request request = new Llenar_Supervisor_equipo_Request();
            Llenar_Supervisor_equipo_Response response = new Llenar_Supervisor_equipo_Response();
            string requestJSON;
            string responseJSON;

            request.cod_equipo = cod_planning;
            request.cod_empresa = cod_emprea;
            requestJSON = HelperJson.Serialize<Llenar_Supervisor_equipo_Request>(request);

            responseJSON = clientcampania.Llenar_Supervisores_equipo(requestJSON);

            response = HelperJson.Deserialize<Llenar_Supervisor_equipo_Response>(responseJSON);

            return response.oListaSupervisores;
        }
        public List<M_Supervisor> Listar_GIE_equipo(string cod_planning, int cod_emprea,int cod_supervisor)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient clientcampania = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            Llenar_GIE_equipo_Request request = new Llenar_GIE_equipo_Request();
            Llenar_Supervisor_equipo_Response response = new Llenar_Supervisor_equipo_Response();
            string requestJSON;
            string responseJSON;

            request.cod_equipo = cod_planning;
            request.cod_empresa = cod_emprea;
            request.cod_supervisor = cod_supervisor;
            requestJSON = HelperJson.Serialize<Llenar_GIE_equipo_Request>(request);

            responseJSON = clientcampania.Llenar_GIE_equipo(requestJSON);

            response = HelperJson.Deserialize<Llenar_Supervisor_equipo_Response>(responseJSON);

            return response.oListaSupervisores;
        }


    }
}