using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adonai_DevNat.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class CreateCodeController : ControllerBase
    {
        [AcceptVerbs("GET")]
        [Route("createmodel")]
        public string createCode()
        {
            String code = "Teste\n 2";

            return code;
        }
    }
}
