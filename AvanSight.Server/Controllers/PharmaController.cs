using AvanSight.Models;
using AvanSight.Models.DomainModels;
using AvanSight.Services;
using Microsoft.AspNetCore.Mvc;

namespace AvanSight.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PharmaController : ControllerBase
    {
        private readonly PharmaDataService _pharmaDataService;

        public PharmaController(PharmaDataService pharmaDataService)
        {
            _pharmaDataService = pharmaDataService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PharmaDataBase>> GetPharmaList()
        {
            var pharmaList = _pharmaDataService.GetPharmaList();
            return Ok(pharmaList);
        }

        [HttpGet("{pharmaName}")]
        public ActionResult<List<Study>> GetStudyAsync(string pharmaName)
        {
            var pharmaList = _pharmaDataService.GetStudies(pharmaName);
            return Ok(pharmaList);
        }

        [HttpGet("{pharmaName}/study/{studyName}")]
        public ActionResult<List<Patient>> GetPatientsAsync(string pharmaName, string studyName)
        {
            var pharmaList = _pharmaDataService.GetPatients(pharmaName, studyName);
            return Ok(pharmaList);
        }
    }
}
