using System;
using System.Collections.Generic;

using Newtonsoft;
using Newtonsoft.Json;

namespace Datamercaderista.Models
{
    /// <summary>
    /// Fecha: 2014-03-05
    /// Creado: jlucero
    /// </summary>
    /// 
    public class Quiebre
    {
        [JsonProperty("a")]
        public string qui_id { get; set; }

        [JsonProperty("b")]
        public string qui_descripcion { get; set; }
    }
    public class Quiebre_Request
    {
        [JsonProperty("a")]
        public string planning { get; set; }

        [JsonProperty("b")]
        public int report { get; set; }
    }
    public class Quiebre_Response
    {
        [JsonProperty("a")]
        public List<Quiebre> Lista { get; set; }
    }
}