using AvanSight.Models;
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
    }


}
