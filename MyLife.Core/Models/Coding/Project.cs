using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLife.Core.Models.Coding
{
    public record Project
    (
        [JsonProperty("name")]
        string Name,

        [JsonProperty("description")]
        string Descripton,

        [JsonProperty("image_url")]
        Uri ImageUrl,

        [JsonProperty("github_url")]
        string GithubUrl,

        [JsonProperty("programming_language")]
        string ProgrammingLanguage
    );
}
