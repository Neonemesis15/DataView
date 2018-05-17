using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuckyMer.Contracts.DataContract;
using Lucky.CFG.JavaMovil;
using Newtonsoft.Json;

namespace Datamercaderista.Models
{
    public class M_Ciudad
    {
        [JsonProperty("a")]
        public string cod_campania { get; set; }
        [JsonProperty("b")]
        public string Cod_Departamento;

    }

    public class M_Ciudad_receive
    {
        [JsonProperty("a")]
        public string CodCiudad { get; set; }
        [JsonProperty("b")]
        public string NomCiudad { get; set; }
    }

    public class M_Ciudad_Response
    {
        [JsonProperty("a")]
        public List<M_Ciudad_receive> M_Ciudad_receive { get; set; }
    }
    public class M_Ciudad_Request
    {
        [JsonProperty("a")]
        public M_Ciudad M_Ciudad { get; set; }
    }

    public class M_Ciudad_Service
    {

        public List<M_Ciudad_receive> Consultar(M_Ciudad oM_Ciudad)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = HelperJson.Serialize<M_Ciudad>(oM_Ciudad);

            dataJson = client.Listar_Ciudad_Por_CodCampania_CodDepartamento(request);//se tiene que cambier por el metodo correcto

            M_Ciudad_Response oM_Ciudad_Response = HelperJson.Deserialize<M_Ciudad_Response>(dataJson);



            return oM_Ciudad_Response.M_Ciudad_receive;

        }
        public List<M_Ciudad_receive> getCiudadesxCampania(string  idcampania)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = request = "{'a':'" + idcampania + "'}";

            dataJson = client.Listar_Ciudad_Por_CodCampania(request);

            M_Ciudad_Response oM_Ciudad_Response = HelperJson.Deserialize<M_Ciudad_Response>(dataJson);



            return oM_Ciudad_Response.M_Ciudad_receive;

        }

    }

    #region WebXplora - Mercaderista

    /// <summary>
    /// Creado por: jlucero
    /// Fecha: 2014-02-25
    /// </summary>
    ///
    public class E_Ciudad
    {
        [JsonProperty("a")]
        public string CodCiudad { get; set; }

        [JsonProperty("b")]
        public string NomCiudad { get; set; }
    }

    public class E_Ciudad_Request
    {
        [JsonProperty("a")]
        public string cod_country { get; set; }

        [JsonProperty("b")]
        public string cod_dpto { get; set; }
    }
    public class E_Ciudad_Response
    {
        [JsonProperty("a")]
        public List<E_Ciudad> Lista { get; set; }
    }

    #endregion
}