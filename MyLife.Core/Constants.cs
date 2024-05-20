namespace MyLife.Core
{
    /// <summary>
    /// Represents a summary of app-wide used constants.
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Internal path to the Blazor Wasm project.
        /// </summary>
        public const string MyLifeBlazorWasmLocalPath = "MyLife.Blazor.Wasm/";

        /// <summary>
        /// URL path to the life information JSON file.
        /// Default: "data/life.json"
        /// </summary>
        public const string LifeJsonPath = "data/life.json";

        /// <summary>
        /// URL path to the content creation publications JSON file.
        /// Default: "data/cc-publications.json"
        /// </summary>
        public const string ContentCreationPublicationsPath = "data/cc-publications.json";
    }
}
