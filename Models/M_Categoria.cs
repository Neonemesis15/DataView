using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_Categoria
    {
        [JsonProperty("a")]
        public string Id_ProductCategory { get; set; }
        [JsonProperty("b")]
        public string Product_Category { get; set; }
        [JsonIgnore()]
        public string Group_Category { get; set; }
        [JsonIgnore()]
        public bool ProductCategory_Status { get; set; }
        [JsonIgnore()]
        public int Company_id { get; set; }
        [JsonIgnore()]
        public string ProductCategory_CreateBy { get; set; }
        [JsonIgnore()]
        public DateTime ProductCategory_DateBy { get; set; }
        [JsonIgnore()]
        public string ProductCategory_ModiBy { get; set; }
        [JsonIgnore()]
        public string ProductCategory_DateModiBy { get; set; }
    }

    public class M_Categoria_Response
    {
        [JsonProperty("a")]
        public List<M_Categoria> listaCategoria { get; set; }
    }
    public class M_Categoria_Service
    {

        public List<M_Categoria> consulta(string CodCampania)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + CodCampania + "'}";
            dataJson = client.Listar_Categoria_Por_CodCampania(request);

            M_Categoria_Response oM_Categoria_Response = HelperJson.Deserialize<M_Categoria_Response>(dataJson);

            return oM_Categoria_Response.listaCategoria;
        }

        public List<M_Categoria> Listar_Categoria_por_Compania_Status(string Company_id,string Status)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + Company_id + "','b':'" + Status + "'}";
            dataJson = client.Listar_Categoria_Sancela(request);

            M_Categoria_Response oM_Categoria_Response = HelperJson.Deserialize<M_Categoria_Response>(dataJson);

            return oM_Categoria_Response.listaCategoria;
        }





        public List<M_Categoria> consulta_Fotografico(string CodCampania)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + CodCampania + "'}";
            dataJson = client.Listar_Categoria_Por_CodCampania_Fotografico(request);

            M_Categoria_Response oM_Categoria_Response = HelperJson.Deserialize<M_Categoria_Response>(dataJson);

            return oM_Categoria_Response.listaCategoria;
        }
        //public List<M_Categoria> Listar_Categoria_Por_CodCampania_Presencia(string CodCampania)
        //{
        //    ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
        //    string dataJson;
        //    string request;

        //    request = "{'a':'" + CodCampania + "'}";
        //    dataJson = client.Listar_Categoria_Por_CodCampania_Presencia(request);

        //    M_Categoria_Response oM_Categoria_Response = HelperJson.Deserialize<M_Categoria_Response>(dataJson);

        //    return oM_Categoria_Response.listaCategoria;
        //}
        public List<M_Categoria> Listar_Categoria_porCampania(string CodCampania)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + CodCampania + "'}";
            dataJson = client.Listar_Categoria_Por_CodCampania_FotograficoTMP(request);

            M_Categoria_Response oM_Categoria_Response = HelperJson.Deserialize<M_Categoria_Response>(dataJson);

            return oM_Categoria_Response.listaCategoria;
        }

        public List<M_Categoria> Listar_Categoria_ReporteEQ(string CodCampania, string CodReporte)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient clientcampania = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            Listar_Categoria_Por_CodCampania_y_CodReporte_Request request = new Listar_Categoria_Por_CodCampania_y_CodReporte_Request();
            Listar_Categoria_Por_CodCampania_y_CodReporte_Response response = new Listar_Categoria_Por_CodCampania_y_CodReporte_Response();
            string requestJSON;
            string responseJSON;

            request.CodCampania = CodCampania;
            request.CodReporte = CodReporte;

            requestJSON = HelperJson.Serialize<Listar_Categoria_Por_CodCampania_y_CodReporte_Request>(request);

            responseJSON = clientcampania.Listar_Categoria_Por_CodCampania_y_CodReporte(requestJSON);
            
            response = HelperJson.Deserialize<Listar_Categoria_Por_CodCampania_y_CodReporte_Response>(responseJSON);

            return response.oListaCategoria;
        }


    }

/* Categoria por reporte y equipo */
    public class Listar_Categoria_Por_CodCampania_y_CodReporte_Request
    {
        [JsonProperty("a")]
        public string CodCampania { get; set; }
        [JsonProperty("b")]
        public string CodReporte { get; set; }
    }
    public class Listar_Categoria_Por_CodCampania_y_CodReporte_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<M_Categoria> oListaCategoria { get; set; }
    }




}