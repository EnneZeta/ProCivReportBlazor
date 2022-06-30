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
        private readonly IMailSender _mailSender;

        public PrintController(ServiceReportBuilder serviceReportBuilder, LightingBreakdownsBuilder lightingBreakdownsBuilder, PathBuilder pathBuilder, IMailSender mailSender)
        {
            _serviceReportBuilder = serviceReportBuilder;
            _lightingBreakdownsBuilder = lightingBreakdownsBuilder;
            _pathBuilder = pathBuilder;
            _mailSender = mailSender;
        }

        [HttpPost]
        public IActionResult Post(Persistency persistency)
        {
            var srPath = _serviceReportBuilder.Build(persistency.ServiceReport);
            var lbPath = _lightingBreakdownsBuilder.Build(persistency);
            var pPath = _pathBuilder.Build(persistency);


            //_mailSender.Send(new List<string>
            //{
            //    srPath,lbPath, pPath
            //});

            var pdfList = new Dictionary<string, string>
            {
                { "Rapporto di Servizio", srPath },
                { "Guasti Illuminazione", lbPath },
                { "Percorsi", pPath }
            };

            return Ok(pdfList);
        }
    }
}