using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCliente.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EmpresaController : ControllerBase
    {
        [Route("CadastrarEmpresa")]
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
