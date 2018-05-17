using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;

namespace Datamercaderista.Models.Ecuador
{
    public class M_Llenar_Filtros_Rprecio
    {
    }

    public class E_DinamicArray
    {

        [JsonProperty("a")]
        public string[] Header { get; set; }

        [JsonProperty("b")]
        public string[][] Contents { get; set; }

    }

    public class llenarCombos_Request
    {
        [JsonProperty("a")]
        public string opcion { get; set; }
        [JsonProperty("b")]
        public string filtros { get; set; }
    }

    public class llenarCombos_Response : BaseResponse
    {
        [JsonProperty("a")]
        public E_DinamicArray oE_DinamicArray { get; set; }
    }



    public class M_LlenarCombo_Service
    {
        public E_DinamicArray Llenar_Combo(llenarCombos_Request ollenarCombos_Request)
        {
            ServicioEcuDataMer.Ges_Ecu_DMServiceClient campaniServices = new ServicioEcuDataMer.Ges_Ecu_DMServiceClient("BasicHttpBinding_IGes_Ecu_DMService");

            string request;
            string dataJson;

            request = Lucky.CFG.JavaMovil.HelperJson.Serialize<llenarCombos_Request>(ollenarCombos_Request);

            dataJson = campaniServices.llenarCombos(request);
            
            campaniServices.Close();

            llenarCombos_Response response = Lucky.CFG.JavaMovil.HelperJson.Deserialize<llenarCombos_Response>(dataJson);

            return response.oE_DinamicArray;
        }
        public List<M_combo> GetComboItems(int codOption, params object[] values)
        {
            M_LlenarCombo_Service service = new M_LlenarCombo_Service();
            llenarCombos_Request ollenarCombos_Request = new llenarCombos_Request();
            E_DinamicArray oE_DinamicArray = new E_DinamicArray();
            ollenarCombos_Request.opcion = codOption.ToString();

            for (int i = 0; i < values.Length; i++)
            {
                if (i == (values.Length - 1))
                    ollenarCombos_Request.filtros += values[i].ToString();
                else
                    ollenarCombos_Request.filtros += values[i].ToString() + ",";
            }

            oE_DinamicArray = service.Llenar_Combo(ollenarCombos_Request);
            int v_cant = oE_DinamicArray.Contents.Length;
            List<M_combo> oListM_combo = new List<M_combo>();

            for (int x = 0; x < v_cant; x++)
            {
                int v_cant2 = oE_DinamicArray.Contents[x].Length;
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = oE_DinamicArray.Contents[x][0];
                oM_combo.descripcion = oE_DinamicArray.Contents[x][1];

                oListM_combo.Add(oM_combo);
            }

            if (oListM_combo.Count > 0)
            {
                return oListM_combo;
            }
            else
            {
                M_combo oM_combo = new M_combo();
                oM_combo.codigo = "0";
                oM_combo.descripcion = "Sin resultado";
                oListM_combo.Add(oM_combo);
                return oListM_combo;
            }
        }
    }
    public class M_combo {
        public string codigo { get; set; }
        public string descripcion { get; set; }
    }

    public class M_Filtros {
        public string CodCliente { get; set; }
        public string CodCanal { get; set; }
        public string CodPlanning { get; set; }
    }
}