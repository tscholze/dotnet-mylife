using MyLife.Core.Models;

namespace MyLife.Core.Extensions
{
    public static class ModelExtension
    {
        public static string GetFullname(this Persona persona)
        {
            return $"{persona.Firstname} {persona.Lastname}";
        }
    }
}
