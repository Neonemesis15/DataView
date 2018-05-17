using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_Usuario_Data
    {
        [JsonProperty("a")]
        public string codigoCliente { get; set; }

        [JsonProperty("b")]
        public string fotoCliente { get; set; }

        [JsonProperty("c")]
        public string nombreCliente { get; set; }

        [JsonProperty("d")]
        public string codigoUsuario { get; set; }

        [JsonProperty("e")]
        public string codigoPerfil { get; set; }

        [JsonProperty("f")]
        public string nombreUsuario { get; set; }

        [JsonProperty("g")]
        public string nombreCompleto { get; set; }

        [JsonProperty("h")]
        public string emailUsuario { get; set; }

        [JsonProperty("i")]
        public string canalUsuario { get; set; }
    }

    public class M_Usuario_Data_Request
    {
        [JsonProperty("a")]
        public string nombreUsuario { get; set; }
    }

    public class M_Usuario_Data_Response : BaseResponse
    {
        [JsonProperty("a")]
        public M_Usuario_Data usuarioData { get; set; }
    }

    public class M_Usuario_Data_Service
    {
        public M_Usuario_Data Obtener_Usuario_Data(string nombreUsuario)
        {
            ServicioGestionCliente.Ges_ClienteServiceClient user = new ServicioGestionCliente.Ges_ClienteServiceClient("BasicHttpBinding_IGes_ClienteService");

            string dataJson;
            string request;

            request = "{'a':'" + nombreUsuario + "'}";
            dataJson = user.Obtener_Usuario_Digitacion(request);

            M_Usuario_Data_Response oM_Usuario_Response = HelperJson.Deserialize<M_Usuario_Data_Response>(dataJson);

            return oM_Usuario_Response.usuarioData;
        }
    }
}