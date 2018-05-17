using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Lucky.CFG.JavaMovil;


namespace Datamercaderista.Models
{
    public class Anio_Response
    {
        [JsonProperty("a")]
        public List<M_Anio> Anios { get; set; }
    }
    public class M_Anio
    {
        [JsonProperty("a")]
        public int Anio { get; set; }
      
    }
    public class Mes_Response
    {
        [JsonProperty("a")]
        public List<M_Mes> Meses { get; set; }
    }
    public class M_Mes
    {
        [JsonProperty("a")]
        public string CodMes { get; set; }
        [JsonProperty("b")]
        public string Nombre { get; set; }
    }
    public class M_Periodo
    {
        [JsonProperty("a")]
        public string Cod_Periodo { get; set; }
        [JsonProperty("b")]
        public string Nombre_Periodo { get; set; }

        public string FecIni { get; set; }
        public string FecFin { get; set; }
        public string Label { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
        public int DateDiffNumMeses { get; set; }
        public string DateNow { get; set; }

    }

    public class M_Periodo_Response
    {
        [JsonProperty("a")]
        public List<M_Periodo> listaPeriodos { get; set; }
    }
    public class M_Periodo_receive
    {
        [JsonProperty("a")]
        public string Cod_Periodo { get; set; }
        [JsonProperty("b")]
        public string Nombre_Periodo { get; set; }
        
    }
    public class M_Periodo_Service
    {
        static List<M_Periodo> StaticPeriodos = new List<M_Periodo>();    
        public List<M_Anio> GetAnios()
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            
            string responseJSON = client.Listar_Anios();

            Anio_Response response = HelperJson.Deserialize<Anio_Response>(responseJSON);

            return response.Anios;
        }
        public List<M_Mes> GetMeses()
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");

            string responseJSON = client.Listar_Meses();

            Mes_Response response = HelperJson.Deserialize<Mes_Response>(responseJSON);

            return response.Meses;
        }
        public List<M_Periodo> Listar_Periodo_Por_CodServicio_CodCanal_CodCliente_CodReporte_Anio_Mes
            (string CodServicio, string CodCanal, string CodCliente, string CodReporte, string Anio, string Mes)
        {
            ServicioGestionCampania.Ges_CampaniaServiceClient client = new ServicioGestionCampania.Ges_CampaniaServiceClient("BasicHttpBinding_IGes_CampaniaService");
            string dataJson;
            string request;

            request = "{'a':'" + CodServicio + "','b':'" + CodCanal + "','c':'" + CodCliente + "','d':'" + CodReporte + "','e':'" + Anio + "','f':'" + Mes + "'}";
            dataJson = client.Listar_Periodo_Por_CodServicio_CodCanal_CodCliente_CodReporte_Anio_Mes(request);

            M_Periodo_Response oM_Periodo_Response = HelperJson.Deserialize<M_Periodo_Response>(dataJson);

            return oM_Periodo_Response.listaPeriodos;
        }
   
        public List<M_Periodo> GetPeriodos(string codCampania, string anio, string mes, int codReporte)
        {
            M_DynamicArray_Service dynamicServ = new M_DynamicArray_Service();

            mes=(mes.Length==1)?("0"+mes):mes;

            string filters = codCampania + "," + anio + "," + mes+"," + codReporte;

            M_DynamicArray Dynamics = dynamicServ.GetDynamicArrayResult("GetPeriodos", filters);
 
            List<M_Periodo> Periodos = new List<M_Periodo>();
            try
            {
                if (Dynamics.Contents.Length > 0)
                {
                    for (int i = 0; i < Dynamics.Contents.Length; i++)
                    {
                        M_Periodo Periodo = new M_Periodo();
                        Periodo.Cod_Periodo = Dynamics.Contents[i][0].ToString();
                        Periodo.Label = Dynamics.Contents[i][1].ToString();
                        Periodo.FecIni = Dynamics.Contents[i][2].ToString();
                        Periodo.FecFin = Dynamics.Contents[i][3].ToString();

                        Periodos.Add(Periodo);
                    }

                    StaticPeriodos = Periodos;
                }
                else
                {
                    M_Periodo sinPeriodo = new M_Periodo();

                    sinPeriodo.Label = "Sin Datos disponibles";
                    sinPeriodo.Cod_Periodo = "0";
                    
                    Periodos.Add(sinPeriodo);
                }
            }
            catch
            {
                M_Periodo sinPeriodo = new M_Periodo();
                sinPeriodo.Label = "Sin Datos disponibles";
                sinPeriodo.Cod_Periodo = "0";
                Periodos.Add(sinPeriodo);
            }
            return Periodos;
        }
        public M_Periodo GetPeriodo(int codPeriodo, int anio, int mes)
        {

            if (codPeriodo.ToString() == "0")
            {
                M_Periodo periodo1 = new M_Periodo();

//                DateTime fi = Convert.ToDateTime(periodo1.FecIni);
  //              DateTime ff = Convert.ToDateTime(periodo1.FecFin);

                DateTime fecha1 = new DateTime(anio, mes , 1);
                DateTime fecha2 = new DateTime(anio, mes + 1, 1).AddDays(-1);

                periodo1.FecIni = fecha1.ToShortDateString();
                periodo1.FecFin = fecha2.ToShortDateString();

                return periodo1;

            }

            else
            {
                var periodo = StaticPeriodos.SingleOrDefault(p => p.Cod_Periodo == codPeriodo.ToString());

                periodo.FecIni = Convert.ToDateTime(periodo.FecIni).ToShortDateString() + " " + Convert.ToDateTime(periodo.FecIni).ToShortTimeString();
                periodo.FecFin = Convert.ToDateTime(periodo.FecFin).ToShortDateString() + " " + Convert.ToDateTime(periodo.FecFin).ToShortTimeString();

                return periodo as M_Periodo;
            }
        }
        public M_Periodo GetPeriodoShortString(int codPeriodo, int anio, int mes)
        {
            var periodo = StaticPeriodos.SingleOrDefault(p => p.Cod_Periodo == codPeriodo.ToString());

            if (periodo != null)
            {
                periodo.FecIni = Convert.ToDateTime(periodo.FecIni).ToShortDateString();
                periodo.FecFin = Convert.ToDateTime(periodo.FecFin).ToShortDateString();
                periodo.DateDiffNumMeses = Convert.ToDateTime(periodo.FecFin).Subtract(Convert.ToDateTime(periodo.FecIni)).Days;
            }
            else
            {
                periodo = new M_Periodo();
                periodo.FecIni = DateTime.Now.AddYears(-10).ToShortDateString();
                periodo.FecFin = DateTime.Now.AddYears(10).ToShortDateString();
                periodo.DateDiffNumMeses = Convert.ToDateTime(periodo.FecFin).Subtract(Convert.ToDateTime(periodo.FecIni)).Days;
                periodo.DateNow = DateTime.Today.Date.ToShortDateString();
            }
            return periodo as M_Periodo;
        }
    }

    #region Gestion de Anio

    /// <summary>
    /// Creado: jlucero
    /// Fecha: 2014-03-04
    /// </summary>
    ///
    public class E_Anio
    {
        [JsonProperty("a")]
        public string id { get; set; }

        [JsonProperty("b")]
        public string descripcion { get; set; }
    }
    public class E_Anio_Request
    {
        [JsonProperty("a")]
        public string id_planning { get; set; }

        [JsonProperty("b")]
        public int id_report { get; set; }
    }
    public class E_Anio_Response
    {
        [JsonProperty("a")]
        public List<E_Anio> Lista { get; set; }
    }

    #endregion

    #region Gestion de periodo

    /// <summary>
    /// Creado: jlucero
    /// Fecha: 2014-03-05
    /// </summary>
    ///
    public class Periodo
    {
        [JsonProperty("a")]
        public string id { get; set; }

        [JsonProperty("b")]
        public string descripcion { get; set; }
    }
    public class Periodo_Request
    {
        [JsonProperty("a")]
        public string id_planning { get; set; }

        [JsonProperty("b")]
        public int id_report { get; set; }

        [JsonProperty("c")]
        public int anio { get; set; }

        [JsonProperty("d")]
        public int mes { get; set; }
    }
    public class Periodo_Response
    {
        [JsonProperty("a")]
        public List<Periodo> Lista { get; set; }
    }

    #endregion
}
