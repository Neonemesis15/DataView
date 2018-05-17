using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuckyMer.Contracts.DataContract;
using Lucky.CFG.JavaMovil;
using Newtonsoft.Json;

namespace Datamercaderista.Models
{
   

        public class M_Reporte
        {
            [JsonProperty("a")]
            public int Report_Id { get; set; }
            [JsonProperty("b")]
            public string Report_NameReport { get; set; }

            
        }


        public class M_Reporte_Response
        {
            [JsonProperty("a")]
            public List<M_Reporte> listaReportes{ get; set; }
        }



        public class M_Reporte_Service
        {

            public List<M_Reporte> consulta(string id)
            {

                ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");



                string dataJson;
                string request;

                request = "{'a':'" + id + "'}";
                dataJson = client.Listar_Reporte_Por_CodCampania(request);

                M_Reporte_Response oM_Reporte = HelperJson.Deserialize<M_Reporte_Response>(dataJson);

                return oM_Reporte.listaReportes;
            }

        }


    
}