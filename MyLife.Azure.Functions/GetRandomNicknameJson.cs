using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MyLife.Core.Generator;

namespace MyLife.Azure.Functions
{
    /// <summary>
    /// Azure Function that returns a random nickname as JSON object.
    /// </summary>
    public class GetRandomNicknameJson
    {
        private readonly ILogger<GetRandomNicknameJson> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRandomNicknameJson"/> class.
        /// </summary>
        /// <param name="logger">The logger instance for this function.</param>
        public GetRandomNicknameJson(ILogger<GetRandomNicknameJson> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Executes the function and returns a random nickname with metadata.
        /// </summary>
        /// <param name="req">The HTTP request containing the trigger data.</param>
        /// <returns>An action result containing the random nickname as JSON object.</returns>
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

    /// <summary>
    /// Record representing a nickname with its creation timestamp.
    /// </summary>
    /// <param name="Name">The nickname string.</param>
    /// <param name="CreatedAt">The timestamp when the nickname was generated.</param>
    record Nickname(string Name, DateTime CreatedAt);
}
