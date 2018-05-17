using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_PuntoDeVenta
    {
        //Parametros necesarios hasta el momento 15/11/2012 Psa.
        [JsonProperty("a")]
        public string ClientPDV_Code { get; set; }
        [JsonProperty("b")]
        public string Pdv_Name { get; set; }
    }

    public class M_PuntoDeVenta_Response
    {
        [JsonProperty("a")]
        public List<M_PuntoDeVenta> listaPDV { get; set; }
    }
    public class M_PuntoDeVenta_Service
    {

        public List<M_PuntoDeVenta> consulta(string CodCampania, string CodOficina, string CodZona)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + CodCampania + "','b':'" + CodOficina + "','c':'" + CodZona + "'}";
            dataJson = client.Listar_PuntoDeVenta_Por_CodCampania_CodOficina_CodCadena(request);

            M_PuntoDeVenta_Response oM_PuntoDeVenta_Response = HelperJson.Deserialize<M_PuntoDeVenta_Response>(dataJson);

            return oM_PuntoDeVenta_Response.listaPDV;
        }

        public List<M_PuntoDeVenta> ListarPDV_Campania_Person(string CodCampania, string CodPerson, string Fecha_Ini, string Fecha_Fin)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + CodCampania + "','b':'" + CodPerson + "','c':'" + Fecha_Ini + "','d':'" + Fecha_Fin + "'}";
            dataJson = client.ListarPuntodeVenta_Por_CodCampania_codPersona(request);

            M_PuntoDeVenta_Response oM_PuntoDeVenta_Response = HelperJson.Deserialize<M_PuntoDeVenta_Response>(dataJson);

            return oM_PuntoDeVenta_Response.listaPDV;
        }

        public List<M_PuntoDeVenta> consultaPDV_CodCampania_CodCiudad_CodCadena(string idC, string idCiudad, string idM)
        {

            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");


            string dataJson;
            string request;

            request = "{'a':'" + idC + "','b':'" + idCiudad + "','c':'" + idM + "'}";
            dataJson = client.Listar_NodeComercial_Por_CodCampania_CodCiudad(request);


            M_PuntoDeVenta_Response oM_PuntoDeVenta_Response = HelperJson.Deserialize<M_PuntoDeVenta_Response>(dataJson);

            return oM_PuntoDeVenta_Response.listaPDV;
        }

        public List<M_PuntoDeVenta> Listar_PDV_Por_Campania_Oficina_Cono(string idCampania, string idCiudad, string idCono)
        {

            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");


            string dataJson;
            string request;

            request = "{'a':'" + idCampania + "','b':'" + idCiudad + "','c':'" + idCono + "'}";
            dataJson = client.Listar_PDV_Por_Campania_Oficina_Cono(request);


            M_PuntoDeVenta_Response oM_PuntoDeVenta_Response = HelperJson.Deserialize<M_PuntoDeVenta_Response>(dataJson);

            return oM_PuntoDeVenta_Response.listaPDV;
        }

        public List<M_PuntoDeVenta> Listar_PDV_Por_Campania_NodeCommercial(string idCampania, string idNode)
        {

            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");


            string dataJson;
            string request;

            request = "{'a':'" + idCampania + "','b':'" + idNode + "'}";
            dataJson = client.Listar_PDV_Por_Campania_NodeCommercial(request);


            M_PuntoDeVenta_Response oM_PuntoDeVenta_Response = HelperJson.Deserialize<M_PuntoDeVenta_Response>(dataJson);

            return oM_PuntoDeVenta_Response.listaPDV;
        }

        //Presencia Mayorista
        public List<M_PuntoDeVenta> consultaPDV_CodCampania_CodCadena(string idC, string idM)
        {

            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");


            string dataJson;
            string request;

            request = "{'a':'" + idC + "','b':'" + idM + "'}";
            dataJson = client.Listar_PuntoDeVenta_Por_CodCampania_CodNodeCommercial(request);


            M_PuntoDeVenta_Response oM_PuntoDeVenta_Response = HelperJson.Deserialize<M_PuntoDeVenta_Response>(dataJson);

            return oM_PuntoDeVenta_Response.listaPDV;
        }

        public List<M_PuntoDeVenta> ListarPDV_Por_CodCampania_Person_Node_FecIni_FecFin(string CodCampania, string CodPerson, string CodNode, string Fecha_Ini, string Fecha_Fin)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + CodCampania + "','b':'" + CodPerson + "','c':'" + CodNode + "','d':'" + Fecha_Ini + "','e':'" + Fecha_Fin + "'}";
            dataJson = client.Listar_PDV_Por_CodCampania_Person_Node_FecIni_FecFin(request);

            M_PuntoDeVenta_Response oM_PuntoDeVenta_Response = HelperJson.Deserialize<M_PuntoDeVenta_Response>(dataJson);

            return oM_PuntoDeVenta_Response.listaPDV;
        }
    }

    #region WebXplora - Mercaderista

    /// <summary>
    /// Creado por: jlucero
    /// Fecha: 2014-02-27
    /// Descripción: SP_XPL_GES_CAM_OBTENER_PUNTODEVENTA_POR_CODCAMPANIA_CODDEPARTAMENTO_CODPROVINCIA_NODECOMMERCIAL
    /// </summary>
    /// 
    public class PuntoDeVenta_Id_Name
    {
        [JsonProperty("a")]
        public string ClientPDV_Code { get; set; }

        [JsonProperty("b")]
        public string Pdv_Name { get; set; }
    }
    public class PuntoDeVenta_Campania_Departamento_Provincia_Cadena_Request
    {
        [JsonProperty("a")]
        public string Cod_Campania { get; set; }

        [JsonProperty("b")]
        public string Cod_Departamento { get; set; }

        [JsonProperty("c")]
        public string Cod_Provincia { get; set; }

        [JsonProperty("d")]
        public string Cod_NodoCommercial { get; set; }
    }
    public class PuntoDeVenta_Campania_Departamento_Provincia_Cadena_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<PuntoDeVenta_Id_Name> Lista { get; set; }
    }

    #endregion
}