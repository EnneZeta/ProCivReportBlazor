using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProCivReport.Data;
using ProCivReport.Models;
using ProCivReport.PdfBuilder;

namespace ProCivReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintController : ControllerBase
    {

        private readonly ServiceReportBuilder _serviceReportBuilder;
        private readonly LightingBreakdownsBuilder _lightingBreakdownsBuilder;
        private readonly PathBuilder _pathBuilder;

        public PrintController(ServiceReportBuilder serviceReportBuilder, LightingBreakdownsBuilder lightingBreakdownsBuilder, PathBuilder pathBuilder)
        {
            _serviceReportBuilder = serviceReportBuilder;
            _lightingBreakdownsBuilder = lightingBreakdownsBuilder;
            _pathBuilder = pathBuilder;
        }

        [HttpPost]
        public void Post(Persistency persistency)
        {
            _serviceReportBuilder.Build(persistency.ServiceReport);
            _lightingBreakdownsBuilder.Build(persistency.LightingBreakdowns);
            _pathBuilder.Build(persistency.Paths);

        }
    }
}