using System;
using System.Collections.Generic;

using Newtonsoft;
using Newtonsoft.Json;

namespace Datamercaderista.Models
{
    #region Gestion de mes

    /// <summary>
    /// Creado: jlucero
    /// Fecha: 2014-03-04
    /// </summary>
    ///
    public class Meses
    {
        [JsonProperty("a")]
        public string id { get; set; }

        [JsonProperty("b")]
        public string descripcion { get; set; }
    }
    public class Meses_Request
    {
        [JsonProperty("a")]
        public string id_planning { get; set; }

        [JsonProperty("b")]
        public int id_report { get; set; }

        [JsonProperty("c")]
        public int anio { get; set; }
    }
    public class Meses_Response
    {
        [JsonProperty("a")]
        public List<Meses> Lista { get; set; }
    }

    #endregion
}