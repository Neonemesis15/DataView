using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuckyMer.Contracts.DataContract;
using Lucky.CFG.JavaMovil;
using Newtonsoft.Json;

namespace Datamercaderista.Models
{
    public class M_Provincia
    {
        [JsonProperty("a")]
        public string CodProvincia { get; set; }

        [JsonProperty("b")]
        public string NombreProvincia { get; set; }  
    }

    public class M_Provincia_Response
    {
        [JsonProperty("a")]
        public List<M_Provincia> listaProvincia { get; set; }
    }

    public class M_Provincia_Request
    {
        [JsonProperty("a")]
        public string CodCampania { get; set; }
        [JsonProperty("b")]
        public string codPais { get; set; }
        [JsonProperty("c")]
        public string codOficina { get; set; }
        [JsonProperty("d")]
        public string codDepartamento { get; set; }
    }

    public class Obtener_Provincia_Por_CodDepartamento_Request
    {
        [JsonProperty("a")]
        public string codPais { get; set; }

        [JsonProperty("b")]
        public string codDepartamento { get; set; }
    }

    public class M_Provincia_Service
	{
        public List<M_Provincia> listarProvincias_Por_Campania_Por_CodPais_Por_CodOficina_Por_codDepartamento(M_Provincia_Request oM_Provincia_Request) 
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string request=HelperJson.Serialize<M_Provincia_Request>(oM_Provincia_Request);
            string datajson=client.listarProvincias_Por_Campania_Por_CodPais_Por_CodOficina_Por_codDepartamento(request);

            M_Provincia_Response oM_Provincia_Response=HelperJson.Deserialize<M_Provincia_Response>(datajson);

            return oM_Provincia_Response.listaProvincia;
        }

        public List<M_Provincia> Obtener_Provincia_Por_CodDepartamento(Obtener_Provincia_Por_CodDepartamento_Request oM_Provincia_Request)
        {
            ServicioGestionMaps.Ges_MapsServiceClient client = new ServicioGestionMaps.Ges_MapsServiceClient("BasicHttpBinding_IGes_MapsService");

            string request = HelperJson.Serialize<Obtener_Provincia_Por_CodDepartamento_Request>(oM_Provincia_Request);
            string datajson = client.Obtener_Provincia_Por_CodDepartamento(request);

            M_Provincia_Response oM_Provincia_Response = HelperJson.Deserialize<M_Provincia_Response>(datajson);

            return oM_Provincia_Response.listaProvincia;
        }
	}
}