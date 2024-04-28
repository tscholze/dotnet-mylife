using MyLife.Core.Models;

namespace MyLife.Core.Generator
{
    public static class SampleGenerators
    {
        internal static Persona Sample(this Persona persona)
        {
            return new Persona
            (
                Firstname: "Tobias",
                Lastname: "Scholze",
                Nicknames: ["The Stuttering Nerd", "Tobonaut"],
                LocationPath: ["Germany", "Bavaria", "Augsburg"],
                Languages: ["German", "Emglish"],
                YearOfBirth: 1985,
                AcademicTitle: "Bachelor of Science"
            );
        }
    }
}
