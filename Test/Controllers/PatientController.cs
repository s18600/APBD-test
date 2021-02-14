using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IService _service;

        public PatientController(IService service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            return Ok("ok");
        }
    }
}
