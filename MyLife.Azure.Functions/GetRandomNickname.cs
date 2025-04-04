using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MyLife.Core.Generator;

namespace MyLife.Azure.Functions
{
    /// <summary>
    /// Azure Function that returns a random nickname as plain text.
    /// </summary>
    public class GetRandomNickname
    {
        #region Private properties 

        private readonly ILogger<GetRandomNickname> _logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRandomNickname"/> class.
        /// </summary>
        /// <param name="logger">The logger instance for this function.</param>
        public GetRandomNickname(ILogger<GetRandomNickname> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Life cycle

        /// <summary>
        /// Executes the function and returns a random nickname.
        /// </summary>
        /// <param name="req">The HTTP request containing the trigger data.</param>
        /// <returns>An action result containing the random nickname as plain text.</returns>
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
