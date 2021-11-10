using System;
using System.Collections.Generic;

namespace ProCivReport.Models
{
    public class LightingBreakdownsDto
    {
        public string ReportNumber { get; set; }

        public DateTime Date { get; set; }

        public List<Break> Breaks { get; set; }
    }

    public class Break
    {
        public string Light { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }
    }
}