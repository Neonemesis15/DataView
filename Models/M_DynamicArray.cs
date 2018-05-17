using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lucky.CFG.JavaMovil;
using Newtonsoft.Json;

namespace Datamercaderista.Models
{
    public class llenarCombos_Request
    {
        [JsonProperty("a")]
        public string opcion { get; set; }
        [JsonProperty("b")]
        public string filtros { get; set; }
    }
    public class llenarCombos_Response : BaseResponse
    {
        [JsonProperty("a")]
        public M_DynamicArray DynamicArray { get; set; }
    } 
    public class M_DynamicArray
    {
        public M_DynamicArray() { }

        [JsonProperty("b")]
        public string[][] Contents { get; set; }
        [JsonProperty("a")]
        public string[] Header { get; set; }
    }
    public class M_DynamicArray_Service
    {
        public M_DynamicArray GetDynamicArrayResult(string opcion, string filtros)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            llenarCombos_Request request = new llenarCombos_Request();

            request.opcion=opcion;
            request.filtros=filtros;
            string requestJson = HelperJson.Serialize<llenarCombos_Request>(request);

            string responseJson = client.llenarCombos_Campania(requestJson);
            client.Close();

            llenarCombos_Response response = HelperJson.Deserialize<llenarCombos_Response>(responseJson);

            return response.DynamicArray;
        }
    }
}