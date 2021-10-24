using System.Collections.Generic;
using ProCivReport.Models;

namespace ProCivReport
{
    public class Persistency
    {
        public Persistency()
        {
            ServiceReport = new ServiceReportDto { Operators = new List<Operator>(), Vehicles = new List<Vehicle>() };
            LightingBreakdowns = new LightingBreakdownsDto();
            Paths = new Paths { StreetList = new List<Street>() };
        }

        public LightingBreakdownsDto LightingBreakdowns { get; set; }

        public ServiceReportDto ServiceReport { get; set; }

        public Paths Paths { get; set; }

    }
}