using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuckyMer.Contracts.DataContract;
using Lucky.CFG.JavaMovil;
using Newtonsoft.Json;
//using Lucky.Entity.Common.Servicio;

namespace Datamercaderista.Models
{
    public class M_Distrito
    {
        [JsonProperty("a")]
        public string CodDistrito { get; set; }

        [JsonProperty("b")]
        public string NombreDistrito { get; set; }
    }

    public class M_Distrito_Response
    {
        [JsonProperty("a")]
        public List<M_Distrito> listaDistrito { get; set; }
    }

    public class M_Distrito_Request
    {
        [JsonProperty("a")]
        public string CodCampania { get; set; }
        [JsonProperty("b")]
        public string codPais { get; set; }
        [JsonProperty("c")]
        public string codOficina { get; set; }
        [JsonProperty("d")]
        public string codDepartamento { get; set; }
        [JsonProperty("e")]
        public string codProvincia { get; set; }
    }

    public class Distrito_Request
    {
        [JsonProperty("a")]
        public string codPais { get; set; }

        [JsonProperty("b")]
        public string codDepartamento { get; set; }

        [JsonProperty("c")]
        public string codProvincia { get; set; }

        [JsonProperty("d")]
        public string codDistribuidora { get; set; }

        [JsonProperty("e")]
        public string codSector { get; set; }
    }

    public class Obtener_Distrito_Por_CodSector_Request
    {
        [JsonProperty("a")]
        public string codPais { get; set; }

        [JsonProperty("b")]
        public string codDepartamento { get; set; }

        [JsonProperty("c")]
        public string codProvincia { get; set; }

        [JsonProperty("d")]
        public string codSector { get; set; }
    }

    public class M_Distrito_Service
    {
        public List<M_Distrito> listarDistritos_Por_Campania_Por_CodPais_Por_codOficina_Por_codDepartamento_Por_Provincia(M_Distrito_Request oM_Distrito_Request)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string request = HelperJson.Serialize<M_Distrito_Request>(oM_Distrito_Request);
            string dataJson = client.listarDistritos_Por_Campania_Por_CodPais_Por_codOficina_Por_codDepartamento_Por_Provincia(request);

            M_Distrito_Response oM_Dsitrito_Response = HelperJson.Deserialize<M_Distrito_Response>(dataJson);

            return oM_Dsitrito_Response.listaDistrito;

        }

        public List<M_Distrito> obtener_Distritos_por_sector(string codPais, string codDepartamento, string codProvincia, string codSector)
        {
            ServicioGestionMaps.Ges_MapsServiceClient mapServices = new ServicioGestionMaps.Ges_MapsServiceClient("BasicHttpBinding_IGes_MapsService");

            Obtener_Distrito_Por_CodSector_Request oRequest = new Obtener_Distrito_Por_CodSector_Request();
            oRequest.codPais = codPais;
            oRequest.codDepartamento = codDepartamento;
            oRequest.codProvincia = codProvincia;
            oRequest.codSector = codSector;

            string request;
            string dataJson;

            request = Lucky.CFG.JavaMovil.HelperJson.Serialize<Obtener_Distrito_Por_CodSector_Request>(oRequest);
            dataJson = mapServices.Obtener_Distrito_Por_CodSector(request);

            M_Distrito_Response response = Lucky.CFG.JavaMovil.HelperJson.Deserialize<M_Distrito_Response>(dataJson);

            return response.listaDistrito;
        }

        public List<M_Distrito> obtener_Distritos_por_sector_2(string codPais, string codDepartamento, string codProvincia, string codDistribuidora, string codSector)
        {
            ServicioGestionMaps.Ges_MapsServiceClient mapServices = new ServicioGestionMaps.Ges_MapsServiceClient("BasicHttpBinding_IGes_MapsService");

            Distrito_Request oRequest = new Distrito_Request();
            oRequest.codPais = codPais;
            oRequest.codDepartamento = codDepartamento;
            oRequest.codProvincia = codProvincia;
            oRequest.codDistribuidora = codDistribuidora;
            oRequest.codSector = codSector;

            string request;
            string dataJson;

            request = Lucky.CFG.JavaMovil.HelperJson.Serialize<Distrito_Request>(oRequest);
            dataJson = mapServices.Obtener_Distrito_Por_CodSector_2(request);

            M_Distrito_Response response = Lucky.CFG.JavaMovil.HelperJson.Deserialize<M_Distrito_Response>(dataJson);

            return response.listaDistrito;
        }

        //Obtener_Distrito_Por_CodSector_2
    }

    #region WebXplora - Mercaderista

    /// <summary>
    /// Creado por: jlucero
    /// Fecha: 2014-02-25
    /// </summary>
    ///
    public class E_Distrito
    {
        [JsonProperty("a")]
        public string dst_id { get; set; }

        [JsonProperty("b")]
        public string dst_descripcion { get; set; }
    }

    public class E_Distrito_Request
    {
        [JsonProperty("a")]
        public string pais { get; set; }

        [JsonProperty("b")]
        public string departamento { get; set; }

        [JsonProperty("c")]
        public string provincia { get; set; }
    }
    public class E_Distrito_Response
    {
        [JsonProperty("a")]
        public List<E_Distrito> Lista { get; set; }
    }

    #endregion
}