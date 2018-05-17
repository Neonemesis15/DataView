using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_Marca
    {
        [JsonProperty("a")]
        public int Id_Brand { get; set; }
        [JsonIgnore()]
        public int Company_id { get; set; }
        [JsonIgnore()]
        public string Id_ProductCategory { get; set; }
        [JsonProperty("d")]
        public string Name_Brand { get; set; }
        [JsonIgnore()]
        public bool Brand_Status { get; set; }
        [JsonIgnore()]
        public string Brand_CreateBy { get; set; }
        [JsonIgnore()]
        public DateTime Brand_DateBy { get; set; }
        [JsonIgnore()]
        public string Brand_ModiBy { get; set; }
        [JsonIgnore()]
        public DateTime Brand_DateModiBy { get; set; }
    }

    public class M_Marca_Response
    {
        [JsonProperty("a")]
        public List<M_Marca> listaMarca { get; set; }
    }
    public class M_Marca_Service
    {

        public List<M_Marca> consulta(string CodCategoria)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + CodCategoria + "'}";
            dataJson = client.Listar_Marca_Por_CodCategoria(request);

            M_Marca_Response oM_Marca_Response = HelperJson.Deserialize<M_Marca_Response>(dataJson);

            return oM_Marca_Response.listaMarca;
        }

        public List<M_Marca> Listar_Marcas_Categoria_ReporteEQ(string CodCampania, string CodReporte, string CodCategoria)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient clientcampania = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            Listar_Marca_Por_CodCampania_CodReporte_y_CodCategoria_Request request = new Listar_Marca_Por_CodCampania_CodReporte_y_CodCategoria_Request();
            Listar_Marca_Por_CodCampania_CodReporte_y_CodCategoria_Response response = new Listar_Marca_Por_CodCampania_CodReporte_y_CodCategoria_Response();
            string requestJSON;
            string responseJSON;

            request.CodCampania = CodCampania;
            request.CodReporte = CodReporte;
            request.CodCategoria = CodCategoria;

            requestJSON = HelperJson.Serialize<Listar_Marca_Por_CodCampania_CodReporte_y_CodCategoria_Request>(request);

            responseJSON = clientcampania.Listar_Marca_Por_CodCampania_CodReporte_y_CodCategoria(requestJSON);

            response = HelperJson.Deserialize<Listar_Marca_Por_CodCampania_CodReporte_y_CodCategoria_Response>(responseJSON);

            return response.oListaMarca;
        }

    }

  /* Listado de marcas por categoria, reporte, equipo  */

    public class Listar_Marca_Por_CodCampania_CodReporte_y_CodCategoria_Request
    {
        [JsonProperty("a")]
        public string CodCampania { get; set; }

        [JsonProperty("b")]
        public string CodReporte { get; set; }

        [JsonProperty("c")]
        public string CodCategoria { get; set; }
    }
    public class Listar_Marca_Por_CodCampania_CodReporte_y_CodCategoria_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_Marca> oListaMarca { get; set; }
    }

}