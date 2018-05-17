using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuckyMer.Contracts.DataContract;
using Lucky.CFG.JavaMovil;
using Newtonsoft.Json;

namespace Datamercaderista.Models
{
    public class M_Departamento
    {
        [JsonProperty("a")]
        public string CodDepartamento { get; set; }

        [JsonProperty("b")]
        public string NombreDepartamento { get; set; } 
    }

    public class M_Departamento_Request
    {
        [JsonProperty("a")]
        public string CodCliente { get; set; }
        [JsonProperty("b")]
        public string CodCampania { get; set; }
        [JsonProperty("c")]
        public string codPais { get; set; }
        [JsonProperty("d")]
        public string codOficina { get; set; }        
    }

    public class M_Departamento_Response
    {
        [JsonProperty("a")]
        public List<M_Departamento> listaDepartamento { get; set; }
    }

    public class M_Departamento_Service
    {

        public List<M_Departamento> listarDepartamentos_Por_CodCliente_Por_CodCampania_Por_CodPais_CodOficina(M_Departamento_Request oM_Departamento_Request)
        {

            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = HelperJson.Serialize<M_Departamento_Request>(oM_Departamento_Request);
            dataJson = client.listarDepartamentos_Por_CodCliente_Por_CodCampania_Por_CodPais_CodOficina(request);

            M_Departamento_Response oM_Departamento_Response = HelperJson.Deserialize<M_Departamento_Response>(dataJson);

            return oM_Departamento_Response.listaDepartamento;
        }

        public List<M_Departamento> getDepartamentoxCampania( string campania)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = request = "{'a':'" + campania + "'}";

            dataJson = client.Listar_Departamento_Por_CodCampania(request);//se tiene que cambier por el metodo correcto

            M_Departamento_Response oM_Departamento_Response = HelperJson.Deserialize<M_Departamento_Response>(dataJson);



            return oM_Departamento_Response.listaDepartamento;

        }
    }
}