using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuckyMer.Contracts.DataContract;
using Lucky.CFG.JavaMovil;
using Newtonsoft.Json;

namespace Datamercaderista.Models
{
    public class M_Sub_Reporte
    {
        [JsonProperty("a")]
        public string Cod_SubReporte { get; set; }

        [JsonProperty("b")]
        public string Nombre_SubReporte { get; set; }
    }

    public class M_Sub_Reporte_Response
    {
        [JsonProperty("a")]
        public List<M_Sub_Reporte> listaSubReportes { get; set; }
    }


    public class M_Sub_Reporte_Service
    {

        public List<M_Sub_Reporte> consulta(string idreporte,string idcampania,string idcanal)
        {

            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string dataJson;
            string request;

            request = "{'a':'" + idreporte + "','b':'"+ idcampania +"','c':'"+ idcanal +"'}";
            dataJson = client.Listar_Sub_Reportes(request);
            M_Sub_Reporte_Response oM_Sub_Reporte = HelperJson.Deserialize<M_Sub_Reporte_Response>(dataJson);

            return oM_Sub_Reporte.listaSubReportes;
        }

    }
}