using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_Combo
    {
        [JsonProperty("a")]
        public string Value { get; set; }
        [JsonProperty("b")]
        public string Text { get; set; }
    }

#region Request - Response

    public class Listar_Combo_UPTable_Unacem_Request
    {
        [JsonProperty("a")]
        public string pametros { get; set; }
        [JsonProperty("b")]
        public int cod_op { get; set; }
    }
    public class Listar_Combo_UPTable_Unacem_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_Combo> oListaCombo { get; set; }

    }

#endregion

#region Metodo para consultar combo Unacem
    public class M_Consultar_ComboUPTable_Unacem_Service
    {
        public Listar_Combo_UPTable_Unacem_Response Listar_Combo_UPTable_Unacem(Listar_Combo_UPTable_Unacem_Request oListar_Combo_UPTable_Unacem_Request)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient oGes_CampaniaServiceClient = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string request;
            string dataJson;

            request = Lucky.CFG.JavaMovil.HelperJson.Serialize<Listar_Combo_UPTable_Unacem_Request>(oListar_Combo_UPTable_Unacem_Request);

            dataJson = oGes_CampaniaServiceClient.Listar_Combo_UPTable_Unacem(request);

            oGes_CampaniaServiceClient.Close();

            Listar_Combo_UPTable_Unacem_Response response = Lucky.CFG.JavaMovil.HelperJson.Deserialize<Listar_Combo_UPTable_Unacem_Response>(dataJson);

            return response;
        }

    }
#endregion

}