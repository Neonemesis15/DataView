using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuckyMer.Contracts.DataContract;
using Lucky.CFG.JavaMovil;
using Newtonsoft.Json;
using Lucky.Entity.Common.Servicio;

namespace Datamercaderista.Models
{
    public class Sector_request
    {
        [JsonProperty("a")]
        public string codPais { get; set; }

        [JsonProperty("b")]
        public string codDepartamento { get; set; }

        [JsonProperty("c")]
        public string codProvincia { get; set; }
    }

    public class Sector_por_Dex_request
    {
        [JsonProperty("a")]
        public string codDex { get; set; }
    }

    public class Sector_Response
    {
        [JsonProperty("a")]
        public List<E_Sector> listaSector { get; set; }
    }

    #region Sector por oficina - equipo : Request
    public class Llenar_Sector_OficinaEQ_Request
    {
        [JsonProperty("a")]
        public string cod_equipo { get; set; }
        [JsonProperty("b")]
        public int cod_oficina { get; set; }

    }
    #endregion
    #region Sector por oficina - equipo : Response
    public class Llenar_Sector_OficinaEQ_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<E_Sector> oListaSectores { get; set; }

    }
    #endregion



    public class Sector_Service
    {
        public List<E_Sector> obtener_sector(string codPais, string codDepartamento, string codProvincia)
        {
            ServicioGestionMaps.Ges_MapsServiceClient mapServices = new ServicioGestionMaps.Ges_MapsServiceClient("BasicHttpBinding_IGes_MapsService");

            Sector_request oRequest = new Sector_request();
            oRequest.codPais = codPais;
            oRequest.codDepartamento = codDepartamento;
            oRequest.codProvincia = codProvincia;

            string request;
            string dataJson;

            request = Lucky.CFG.JavaMovil.HelperJson.Serialize<Sector_request>(oRequest);
            dataJson = mapServices.Obtener_Sector_Por_PaisDepartamentoProvincia(request);

            Sector_Response response = Lucky.CFG.JavaMovil.HelperJson.Deserialize<Sector_Response>(dataJson);

            return response.listaSector;
        }

        public List<E_Sector> obtener_sector_2(string company_Id)
        {
            ServicioGestionMaps.Ges_MapsServiceClient mapServices = new ServicioGestionMaps.Ges_MapsServiceClient("BasicHttpBinding_IGes_MapsService");

            Sector_request oRequest = new Sector_request();
            oRequest.codPais = company_Id;

            string request;
            string dataJson;

            request = Lucky.CFG.JavaMovil.HelperJson.Serialize<Sector_request>(oRequest);
            dataJson = mapServices.Obtener_Sector_Por_Company_x_Malla(request);

            Sector_Response response = Lucky.CFG.JavaMovil.HelperJson.Deserialize<Sector_Response>(dataJson);

            return response.listaSector;
        }

        public List<E_Sector> obtener_sector_por_Dex(string codDex)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient campServices = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            Sector_por_Dex_request oRequest = new Sector_por_Dex_request();
            oRequest.codDex = codDex;

            string request;
            string dataJson;

            request = Lucky.CFG.JavaMovil.HelperJson.Serialize<Sector_por_Dex_request>(oRequest);
            dataJson = campServices.Obtener_Sector_Por_Dex(request);

            Sector_Response response = Lucky.CFG.JavaMovil.HelperJson.Deserialize<Sector_Response>(dataJson);

            return response.listaSector;
        }
        
        public List<E_Sector> Listar_Sector_OficinaEQ(string cod_planning, int cod_oficina)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient clientcampania = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            Llenar_Sector_OficinaEQ_Request request = new Llenar_Sector_OficinaEQ_Request();
            Llenar_Sector_OficinaEQ_Response response = new Llenar_Sector_OficinaEQ_Response();
            string requestJSON;
            string responseJSON;

            request.cod_equipo = cod_planning;
            request.cod_oficina = cod_oficina;

            requestJSON = HelperJson.Serialize<Llenar_Sector_OficinaEQ_Request>(request);

            responseJSON = clientcampania.Llenar_Sector_oficinaEQ(requestJSON);

            response = HelperJson.Deserialize<Llenar_Sector_OficinaEQ_Response>(responseJSON);

            return response.oListaSectores;
        }
    
    }


}