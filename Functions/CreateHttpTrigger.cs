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
    public class CreateHttpTrigger
    {
        private ICRUDService _service;
        public CreateHttpTrigger(ICRUDService service)
        {
            _service = service;
        }

        [FunctionName("create")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "create")] HttpRequest req,
            ILogger log)
        {
            string bodyStr = await new StreamReader(req.Body).ReadToEndAsync();
            var userToCreate = JsonConvert.DeserializeObject<User>(bodyStr);
            var user = await _service.CreateAsync(userToCreate);
            if(user == null)
            {
                return new BadRequestObjectResult($"username {userToCreate.Name} exists!");
            }
            var responseMsg = $"user is created, the id is {user.Id}";
            return new OkObjectResult(responseMsg);
        }
    }
}
