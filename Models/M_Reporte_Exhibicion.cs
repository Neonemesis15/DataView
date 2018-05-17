using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models
{
    public class M_Reporte_Exhibicion
    {
        [JsonProperty("a")]
        public string Nombre_PuntoDeVenta { get; set; }

        [JsonProperty("b")]
        public string Nombre_Categoria { get; set; }

        [JsonProperty("c")]
        public string Nombre_Marca { get; set; }

        [JsonProperty("d")]
        public string Fecha_Inicio { get; set; }

        [JsonProperty("e")]
        public string Fecha_Fin { get; set; }

        [JsonProperty("f")]
        public int Cantidad { get; set; }

        [JsonProperty("g")]
        public string Descripcion { get; set; }

        [JsonProperty("h")]
        public string Registrado_Por { get; set; }

        [JsonProperty("i")]
        public Boolean Validado { get; set; }

        [JsonProperty("j")]
        public Boolean Validado_Cliente { get; set; }

        [JsonProperty("k")]
        public int Cod_Exhibicion_Detalle { get; set; }

        [JsonProperty("l")]
        public string Nombre_Mercaderista { get; set; }

        [JsonProperty("m")]
        public string Fecha_Registro_BD { get; set; }

        [JsonProperty("n")]
        public string Modificado_Por { get; set; }

        [JsonProperty("o")]
        public string Fecha_Modificacion { get; set; }

        [JsonProperty("p")]
        public string Codigo_PuntoDeVenta { get; set; }

        [JsonProperty("q")]
        public string Nombre_NodoComercial { get; set; }

        [JsonProperty("r")]
        public string Nombre_Foto { get; set; }

        [JsonProperty("s")]
        public string Num_Fila { get; set; }

        [JsonProperty("t")]
        public string Id_Reporte { get; set; }
    }

    public class M_Reporte_Exhibicion_R
    {
        [JsonProperty("Nombre_PuntoDeVenta")]
        public string Nombre_PuntoDeVenta { get; set; }

        [JsonProperty("Nombre_Categoria")]
        public string Nombre_Categoria { get; set; }

        [JsonProperty("Nombre_Marca")]
        public string Nombre_Marca { get; set; }

        [JsonProperty("Fecha_Inicio")]
        public string Fecha_Inicio { get; set; }

        [JsonProperty("Fecha_Fin")]
        public string Fecha_Fin { get; set; }

        [JsonProperty("Cantidad")]
        public int Cantidad { get; set; }

        [JsonProperty("Descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("Registrado_Por")]
        public string Registrado_Por { get; set; }

        [JsonProperty("Validado")]
        public Boolean Validado { get; set; }

        [JsonProperty("Validado_Cliente")]
        public Boolean Validado_Cliente { get; set; }

        [JsonProperty("Cod_Exhibicion_Detalle")]
        public int Cod_Exhibicion_Detalle { get; set; }

        [JsonProperty("Nombre_Mercaderista")]
        public string Nombre_Mercaderista { get; set; }

        [JsonProperty("Fecha_Registro_BD")]
        public string Fecha_Registro_BD { get; set; }

        [JsonProperty("Modificado_Por")]
        public string Modificado_Por { get; set; }

        [JsonProperty("Fecha_Modificacion")]
        public string Fecha_Modificacion { get; set; }

        [JsonProperty("Codigo_PuntoDeVenta")]
        public string Codigo_PuntoDeVenta { get; set; }

        [JsonProperty("Nombre_NodoComercial")]
        public string Nombre_NodoComercial { get; set; }

        [JsonProperty("Nombre_Foto")]
        public string Nombre_Foto { get; set; }

        [JsonProperty("Num_Fila")]
        public string Num_Fila { get; set; }

        [JsonProperty("Id_Reporte")]
        public string Id_Reporte { get; set; }
    }

    public class M_Reporte_Exhibicion_Response
    {
        [JsonProperty("a")]
        public List<M_Reporte_Exhibicion> listaReporteExhibicion { get; set; }
    }

    public class M_Reporte_Exhibicion_Service
    {

        public List<M_Reporte_Exhibicion> consulta(string CodPersona, string CodCampania, string CodCanal, string CodOficina, string CodNodoComercial, string CodigoPDV_Compania, string CodCategoria, string CodMarca, string f_incio, string f_fin)
        {

            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string dataJson;
            string request;

            request = "{'a':'" + CodPersona + "','b':'" + CodCampania + "','c':'" + CodCanal + "','d':'" + CodOficina + "','e':'" + CodNodoComercial + "','f':'" + CodigoPDV_Compania + "','g':'" + CodCategoria + "','h':'" + CodMarca + "','i':'" + f_incio + "','j':'" + f_fin + "'}";
            dataJson = client.Consultar_Reporte_Exhibicion(request);

            M_Reporte_Exhibicion_Response oM_Reporte_Exhibicion_Response = HelperJson.Deserialize<M_Reporte_Exhibicion_Response>(dataJson);

            return oM_Reporte_Exhibicion_Response.listaReporteExhibicion;
        }

        public string Update(string CodReporte, int Cantidad, string ModifyBy, string DateModify, string DateRegistro)
        {

            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string dataJson;
            string request;

            request = "{'a':'" + CodReporte + "','b':" + Cantidad + ",'c':'" + ModifyBy + "','d':'" + DateModify + "','e':'" + DateRegistro + "'}";
            dataJson = client.Actualizar_Reporte_Exhibicion(request);

            //M_Reporte_Exhibicion_Response response = HelperJson.Deserialize<M_Reporte_Exhibicion_Response>(dataJson);

            return dataJson;
        }

        public string Validando(string Checked, string unChecked)
        {

            ServicioGestionOperativa.Ges_OperativaServiceClient client = new ServicioGestionOperativa.Ges_OperativaServiceClient("BasicHttpBinding_IGes_OperativaService");

            string dataJson;
            string request;

            request = "{'a':'" + Checked + "','b':'" + unChecked + "'}";
            dataJson = client.Validar_Reporte_Exhibicion(request);

            //M_Reporte_Exhibicion_Response response = HelperJson.Deserialize<M_Reporte_Exhibicion_Response>(dataJson);

            return dataJson;
        }

    }
}