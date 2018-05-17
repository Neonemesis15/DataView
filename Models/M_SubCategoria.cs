using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lucky.CFG.JavaMovil;
using Newtonsoft.Json;

namespace Datamercaderista.Models
{
    public class M_SubCategoria
    {
            [JsonProperty("a")]
            public string Cod_SubCategoria { get; set; }

            [JsonProperty("b")]
            public string Nombre_SubCategoria { get; set; }
    }
    public class M_SubCategoria_Response
    {
        [JsonProperty("a")]
        public List<M_SubCategoria> listasubCategoria { get; set; }
    }
    public class M_SubCategoria_Service
    {

        public List<M_SubCategoria> consulta(string id_subcategoria)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + id_subcategoria + "'}";
            dataJson = client.ListarSubCategoria_Por_CodCategoria(request);

            M_SubCategoria_Response oM_Categoria_Response = HelperJson.Deserialize<M_SubCategoria_Response>(dataJson);

            return oM_Categoria_Response.listasubCategoria;
        }

    }
}