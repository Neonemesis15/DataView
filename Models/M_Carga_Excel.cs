using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace Datamercaderista.Models
{
    public class M_Carga_Excel
    {
    }

    public class Tabla
    {
        public string comentario { get; set; }
        public string cantidad { get; set; }

    }
    public class Tabla_request
    {
        [JsonProperty("Table")]
        public List<Tabla> olistaTabla { get; set; }
    }
}