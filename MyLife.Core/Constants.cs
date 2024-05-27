namespace MyLife.Core
{
    /// <summary>
    /// Represents a summary of app-wide used constants.
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Filename of the life information JSON file.
        /// </summary>
        public const string LifeJsonFilename = "life.json";

        /// <summary>
        /// Filename of the content creation publications JSON file.
        /// </summary>
        public const string ContentCreationPublicationsFilename = "cc-publications.json";

        /// <summary>
        /// Internal path to the Blazor Wasm project.
        /// </summary>
        public const string MyLifeBlazorWasmLocalPath = "MyLife.Blazor.Wasm/";

        /// <summary>
        /// URL path to the life information JSON file.
        /// Default: "data/life.json"
        /// </summary>
        public const string LifeJsonApiPath = "data/" + LifeJsonFilename;

        /// <summary>
        /// URL path to the content creation publications JSON file.
        /// Default: "data/cc-publications.json"
        /// </summary>
        public const string ContentCreationPublicationsApiPath = "data/" + ContentCreationPublicationsFilename;
    }
}
