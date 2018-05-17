using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_NodeComercial
    {
        [JsonProperty("a")]
        public string Cod_Campania { get; set; }

        [JsonProperty("b")]
        public string Cod_Departamento { get; set; }

        [JsonProperty("c")]
        public string Cod_Provincia { get; set; }

        [JsonProperty("d")]
        public string Cod_Distrito { get; set; }
    }

    public class M_NodeComercial_receive
    {
        [JsonProperty("a")]
        public string id_NodeCommercial { get; set; }

        [JsonProperty("b")]
        public string commercialNodeName { get; set; }

        [JsonProperty("c")]
        public string idNodeComType { get; set; }

        [JsonProperty("d")]
        public string NodeCommercial_Status { get; set; }

        [JsonProperty("e")]
        public string NodeCommercial_CreateBy { get; set; }

        [JsonProperty("f")]
        public string NodeCommercial_DateBy { get; set; }

        [JsonProperty("g")]
        public string NodeCommercial_ModiBy { get; set; }

        [JsonProperty("h")]
        public string NodeCommercial_DatemodiBy { get; set; }

        [JsonProperty("i")]
        public string id_Sector { get; set; }    //CEYA

        [JsonProperty("j")]
        public string Sector_name { get; set; }    //CEYA
    }

    public class M_NodeType
    {
        public M_NodeType() { }

        [JsonProperty("a")]
        public int idNodeComType { get; set; }

        [JsonProperty("b")]
        public string NodeComTypename { get; set; }

        [JsonProperty("c")]
        public bool NodeComTypeStatus { get; set; }

        [JsonProperty("d")]
        public string NodeComTypeCreateBy { get; set; }

        [JsonProperty("e")]
        public DateTime NodeComTypeDateBy { get; set; }

        [JsonProperty("f")]
        public string NodeComTypeModiBy { get; set; }

        [JsonProperty("g")]
        public DateTime NodeComTypeDateModiBy {get; set; }
    }

    public class NodeType_Response
    {
        [JsonProperty("a")]
        public List<M_NodeType> M_NodeTypes { get; set; }
    }

    public class NodeType_Request
    {
        [JsonProperty("a")]
        public string codCanal { get; set; }
    }

    public class M_NodeComercial_Response
    {
        [JsonProperty("a")]
        public List<M_NodeComercial_receive> M_NodeComercial_receive { get; set; }
    }

    public class M_NodeComercial_Request
    {
        [JsonProperty("a")]
        public M_NodeComercial M_NodeComercial { get; set; }
    }

    public class Listar_NodoCommercial_Por_CodCampania_CodPerson_Request
    {
        [JsonProperty("a")]
        public string Cod_Campania { get; set; }

        [JsonProperty("b")]
        public string Cod_Person { get; set; }
    }

    public class Listar_NodoCommercial_Por_CodCampania_CodSector_Request
    {
        [JsonProperty("a")]
        public string Cod_Campania { get; set; }

        [JsonProperty("b")]
        public string Cod_Sector { get; set; }
    }

    public class Listar_NodeComercial_Por_ClienteCanalOficina_Request
    {
        [JsonProperty("a")]
        public string cod_Cliente { get; set; }

        [JsonProperty("b")]
        public string cod_Canal { get; set; }

        [JsonProperty("c")]
        public string cod_Oficina { get; set; }
    }//string cod_Cliente, string cod_Canal, string cod_Oficina
    
    public class M_NodeComercial_Service
    {
        public List<M_NodeComercial_receive> Listar_NodeComercial_Por_ClienteCanalOficina(string cod_Cliente, string cod_Canal, string cod_Oficina)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + cod_Cliente + "','b':'" + cod_Canal + "','c':'" + cod_Oficina + "'}";
            dataJson = client.Listar_NodeComercial_Por_ClienteCanalOficina(request);

            M_NodeComercial_Response oM_NodeComercial_Response = HelperJson.Deserialize<M_NodeComercial_Response>(dataJson);

            return oM_NodeComercial_Response.M_NodeComercial_receive;
        }

        //CEYA
        public List<M_NodeComercial_receive> Listar_NodeComercial_Por_ClienteCanalOficinaSector(string cod_Cliente, string cod_Canal, string cod_Oficina, string id_Sector)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + cod_Cliente + "','b':'" + cod_Canal + "','c':'" + cod_Oficina + "','d':'" + id_Sector + "'}";
            dataJson = client.Listar_NodeComercial_Por_ClienteCanalOficinaSector(request);

            M_NodeComercial_Response oM_NodeComercial_Response = HelperJson.Deserialize<M_NodeComercial_Response>(dataJson);

            return oM_NodeComercial_Response.M_NodeComercial_receive;
        }

        public List<M_NodeComercial_receive> Listar_NodeComercial_Por_CodCampania_CodCiudad(string idCampania)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + idCampania + "','b':'0'}";
            dataJson = client.Listar_NodeComercial_Por_CodCampania_CodCiudad(request);

            M_NodeComercial_Response oM_NodeComercial_Response = HelperJson.Deserialize<M_NodeComercial_Response>(dataJson);

            return oM_NodeComercial_Response.M_NodeComercial_receive;
        }

        public List<M_NodeComercial_receive> Listar_NodeComercial_Por_CodCampania_CodOficina(string idCampania, string idOficina)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + idCampania + "','b':'" + idOficina + "'}";
            dataJson = client.Listar_NodeComercial_Por_CodCampania_CodCiudad(request);

            M_NodeComercial_Response oM_NodeComercial_Response = HelperJson.Deserialize<M_NodeComercial_Response>(dataJson);

            return oM_NodeComercial_Response.M_NodeComercial_receive;
        }

        public List<M_NodeComercial_receive> Listar_NodoCommercial_Por_CodCampania_CodDepartamento_CodProvincia(string idcampania, string idDpto, string idCiudad)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            M_NodeComercial oM_NodeComercial=new M_NodeComercial();
            oM_NodeComercial.Cod_Campania = idcampania;
            oM_NodeComercial.Cod_Departamento = idDpto;
            oM_NodeComercial.Cod_Provincia = idCiudad;
            string dataJson;
            string request;

            request = HelperJson.Serialize<M_NodeComercial>(oM_NodeComercial);

            dataJson = client.Listar_NodoCommercial_Por_CodCampania_CodDepartamento_CodProvincia(request);

            M_NodeComercial_Response oM_NodeComercial_Response = HelperJson.Deserialize<M_NodeComercial_Response>(dataJson);
            return oM_NodeComercial_Response.M_NodeComercial_receive;
        }
        
        public List<M_NodeType> Listar_NodeTypePorCanal(string canal)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            NodeType_Response response = new NodeType_Response();
            NodeType_Request request = new NodeType_Request();
            request.codCanal = canal;

            string requesJSON;
            string responseJSON;

            requesJSON = HelperJson.Serialize<NodeType_Request>(request);
            responseJSON = client.ListarTypeNodePorCanal(requesJSON);

            response = HelperJson.Deserialize<NodeType_Response>(responseJSON);

            return response.M_NodeTypes;
        }

        public List<M_NodeComercial_receive> Listar_NodoCommercial_Por_CodCampania_CodPerson(string idcampania, string idPerson)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            Listar_NodoCommercial_Por_CodCampania_CodPerson_Request oM_NodeComercial = new Listar_NodoCommercial_Por_CodCampania_CodPerson_Request();
            oM_NodeComercial.Cod_Campania = idcampania;
            oM_NodeComercial.Cod_Person = idPerson;
            string dataJson;
            string request;

            request = HelperJson.Serialize<Listar_NodoCommercial_Por_CodCampania_CodPerson_Request>(oM_NodeComercial);

            dataJson = client.Listar_NodoCommercial_Por_CodCampania_CodPerson(request);

            M_NodeComercial_Response oM_NodeComercial_Response = HelperJson.Deserialize<M_NodeComercial_Response>(dataJson);

            return oM_NodeComercial_Response.M_NodeComercial_receive;

        }
    }

    /* Cadena */

    public class E_Cadena
    {
        [JsonProperty("a")]
        public int Cod_Cadena { get; set; }

        [JsonProperty("b")]
        public string Nombre_Cadena { get; set; }
    }

    public class Llenar_Cadena_OficinaEQ_Request
    {
        [JsonProperty("a")]
        public string cod_equipo { get; set; }
        [JsonProperty("b")]
        public int cod_oficina { get; set; }

    }
    public class Llenar_Cadena_OficinaEQ_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<E_Cadena> oListaCadenas { get; set; }

    }
    public class M_Cadena_Service
    {
        public List<E_Cadena> Listar_Cadena_OficinaEQ(string cod_planning, int cod_oficina)
        {
            
            ServicioGestionCampania.Ges_CampaniaServiceClient clientcampania = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            Llenar_Cadena_OficinaEQ_Request request = new Llenar_Cadena_OficinaEQ_Request();
            Llenar_Cadena_OficinaEQ_Response response = new Llenar_Cadena_OficinaEQ_Response();
            string requestJSON;
            string responseJSON;

            request.cod_equipo = cod_planning;
            request.cod_oficina = cod_oficina;

            requestJSON = HelperJson.Serialize<Llenar_Cadena_OficinaEQ_Request>(request);

            responseJSON = clientcampania.Llenar_Cadena_oficinaEQ(requestJSON);

            response = HelperJson.Deserialize<Llenar_Cadena_OficinaEQ_Response>(responseJSON);

            return response.oListaCadenas;
        }
    }




    #region WebXplora - Mercaderista

    /// <summary>
    /// Creado por: jlucero
    /// Fecha: 2014-02-27
    /// Descripción: SP_XPL_GES_CAM_OBTENER_NODECOMMERCIAL_POR_CAMPANIA_DEPARTAMENTO_PROVINCIA_DISTRITO
    /// </summary>
    /// 
    public class NodoCommercial_Id_Name
    {
        [JsonProperty("a")]
        public string id_NodeCommercial { get; set; }

        [JsonProperty("b")]
        public string commercialNodeName { get; set; }
    }
    public class NodoCommercial_Campania_Departamento_Provincia_Distrito_Request
    {
        [JsonProperty("a")]
        public string Cod_Campania { get; set; }

        [JsonProperty("b")]
        public string Cod_Departamento { get; set; }

        [JsonProperty("c")]
        public string Cod_Provincia { get; set; }

        [JsonProperty("d")]
        public string Cod_Distrito { get; set; }
    }
    public class NodoCommercial_Campania_Departamento_Provincia_Distrito_Response : BaseResponse
    {
        [JsonProperty("a")]
        public List<NodoCommercial_Id_Name> Lista { get; set; }
    }
    

    #endregion

}