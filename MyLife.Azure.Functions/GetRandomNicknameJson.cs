using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MyLife.Core.Generator;

namespace MyLife.Azure.Functions
{
    public class GetRandomNicknameJson
    {
        private readonly ILogger<GetRandomNicknameJson> _logger;

        public GetRandomNicknameJson(ILogger<GetRandomNicknameJson> logger)
        {
            _logger = logger;
        }

        [Function("GetRandomNicknameJson")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var life = SampleGenerators.GenerateLife();
            var random = new Random();

            var randomIndex = random.Next(life.Persona.Nicknames.Length);
            var randomNickname = life.Persona.Nicknames[randomIndex];
            var model = new Nickname(randomNickname, DateTime.Now);
            return new OkObjectResult(model);
        }
    }

    record Nickname(string Name, DateTime CreatedAt);
}
