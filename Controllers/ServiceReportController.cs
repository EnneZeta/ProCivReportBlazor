using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProCivReport.Data;
using ProCivReport.Models;

namespace ProCivReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceReportController : ControllerBase
    {
        private readonly IRepo _repo;

        public ServiceReportController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public void Post(Persistency persistency)
        {
            _repo.Save(new List<Street>());
        }
    }
}