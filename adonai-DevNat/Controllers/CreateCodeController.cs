using adonai_DevNat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace adonai_DevNat.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class CreateCodeController : ControllerBase
    {
        [AcceptVerbs("POST")]
        [Route("createcode")]
        public string createCode([FromBody] dynamic config)
        {
            String code = "Teste\n 2";
            // GenerateCode ge = JsonSerializer.Deserialize<GenerateCode>(config);
            return code;
        }
    }
}
