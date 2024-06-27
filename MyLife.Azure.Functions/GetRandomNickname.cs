using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MyLife.Core.Generator;

namespace MyLife.Azure.Functions
{
    public class GetRandomNickname
    {
        #region Private properties 

        private readonly ILogger<GetRandomNickname> _logger;

        #endregion

        #region Constructor

        public GetRandomNickname(ILogger<GetRandomNickname> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Life cycle

        [Function("GetRandomNickname")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var life = SampleGenerators.GenerateLife();
            var random = new Random();

            var randomIndex = random.Next(life.Persona.Nicknames.Length);
            var randomNickname = life.Persona.Nicknames[randomIndex];

            return new OkObjectResult(randomNickname);
        }

        #endregion
    }
}
