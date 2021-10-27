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
    public class ServiceReportController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly ServiceReportBuilder _serviceReportBuilder;

        public ServiceReportController(IRepo repo, ServiceReportBuilder serviceReportBuilder)
        {
            _repo = repo;
            _serviceReportBuilder = serviceReportBuilder;
        }

        [HttpPost]
        public void Post(Persistency persistency)
        {
            //_repo.Save(new List<Street>());
            _serviceReportBuilder.Build(persistency.ServiceReport);
        }
    }
}