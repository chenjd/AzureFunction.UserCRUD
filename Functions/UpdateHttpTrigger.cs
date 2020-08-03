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
    public class UpdateHttpTrigger
    {
        private ICRUDService _service;
        public UpdateHttpTrigger(ICRUDService service)
        {
            _service = service;
        }

        [FunctionName("update")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "update/{id}")] HttpRequest req, 
            string id,
            ILogger log)
        {
            string bodyStr = await new StreamReader(req.Body).ReadToEndAsync();
            var updatedUser = JsonConvert.DeserializeObject<User>(bodyStr);

            if(string.IsNullOrEmpty(id))
            {
                return new BadRequestObjectResult($"Error: the input is null!");
            }
            var user = await _service.UpdateAsync(new Guid(id), updatedUser);
            return new OkObjectResult(user);
        }
    }
}
