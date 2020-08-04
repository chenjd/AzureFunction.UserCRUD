using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using UserCRUD.FuncApp.Services;

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
            var user = await _service.ReadAsync(new Guid(id));
            return new OkObjectResult(user);
        }
    }
}
