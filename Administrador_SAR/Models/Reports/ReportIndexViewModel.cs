using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Administrador_SAR.Models.Reports
{
    public class ReportIndexViewModel
    {
        public List<ReportResponseViewModel> Reports { get;set; }
        public int WorkPlaceId { get; set; }

    }
}