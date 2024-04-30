using MyLife.Core.Models;

namespace MyLife.Core.Extensions
{
    /// <summary>
    /// Summary of model extension.
    /// </summary>
    public static class ModelExtension
    {
        /// <summary>
        /// Get the full name of a person.
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Full name</returns>
        public static string GetFullname(this Persona persona)
        {
            return $"{persona.Firstname} {persona.Lastname}";
        }
    }
}
