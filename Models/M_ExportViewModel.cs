using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Datamercaderista.Models
{
    public class M_ExportViewModel
    {
        [AllowHtml]
        public String File { get; set; }
        public String TokenValue { get; set; }
    }
}