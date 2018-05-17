using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_Perfil
    {
    }

    #region Request - Response Consulta tipo Perfil Unacem
        public class Consul_perfil_Unacem_Request
        {
            [JsonProperty("a")]
            public string oParametros { get; set; }
        }
        public class Consul_perfil_Unacem_Response : BaseResponse
        {
            [JsonProperty("a")]
            public string TipoPerfil { get; set; }
        }
    #endregion
#region  Metodo - Consulta tipo perfil unacem

        public class M_Consul_Perfil_Unacem_Service
        {
            public Consul_perfil_Unacem_Response Consultar_Perfil_Unacem(Consul_perfil_Unacem_Request oConsul_perfil_Unacem_Request)
            {
                ServicioGestionOperativa.Ges_OperativaServiceClient oOperativaServiceClient = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");
                string request;
                string dataJson;

                request = Lucky.CFG.JavaMovil.HelperJson.Serialize<Consul_perfil_Unacem_Request>(oConsul_perfil_Unacem_Request);

                dataJson = oOperativaServiceClient.Consul_Perfil_user_Unacem(request);

                oOperativaServiceClient.Close();

                Consul_perfil_Unacem_Response response = Lucky.CFG.JavaMovil.HelperJson.Deserialize<Consul_perfil_Unacem_Response>(dataJson);

                return response;
            }
        }

#endregion
}