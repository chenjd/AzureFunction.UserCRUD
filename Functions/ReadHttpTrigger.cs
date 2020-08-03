using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UserCRUD.FuncApp.Services;
using UserCRUD.FuncApp.Model;

namespace UserCRUD.Function
{
    public class ReadHttpTrigger
    {
        private ICRUDService _service;
        public ReadHttpTrigger(ICRUDService service)
        {
            _service = service;
        }

        [FunctionName("read")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "read/{id}")] HttpRequest req, 
            string id,
            ILogger log)
        {
            if(string.IsNullOrEmpty(id))
            {
                return new BadRequestObjectResult($"Error: the input is null!");
            }
            var user = await _service.ReadAsync(new Guid(id));
            return new OkObjectResult(user);
        }
    }
}
