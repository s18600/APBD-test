using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/medicaments")]
    [ApiController]
    public class MedicamentController : ControllerBase
    {
        IService _service;

        public MedicamentController(IService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetMedicament(int id)
        {
            var s = _service.GetMedicament(id);
            if (s != null)
            {
                return Ok(s);
            }
            return NotFound("Not found speciefied Id");
            
        }
    }
}
