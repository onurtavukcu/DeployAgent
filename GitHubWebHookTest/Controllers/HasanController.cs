using GitHubWebHookTest.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace GitHubWebHookTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HasanController: ControllerBase
    {
        [HttpPost("hook")]
        public IActionResult HookTest(/*[FromBody] HookModel data*/)
        {
            var request = HttpContext.Request;
            request.EnableBuffering();

            using var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true);
            
            var body = reader.ReadToEnd();

            request.Body.Position = 0;

            Console.WriteLine($"Incoming data: { JsonConvert.SerializeObject(body) }");
            Console.WriteLine($"Incoming data: { body }");

            return Created("asd", 31);
        }
    }
}
