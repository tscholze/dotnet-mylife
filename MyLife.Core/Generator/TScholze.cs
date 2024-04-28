using MyLife.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLife.Core.Generator
{
    public class TScholze
    {
        public void GenerateLife()
        {

            var persona = SampleGenerators.Sample





            Life life = new Life
            {
                LastUpdated = DateTime.Now,
                Language = "en",
                Persona = persona,
                ContentCreation = [
                  new ContentCreation
            {
                Name = "My Awesome Blog Post",
                Description = "An informative article about content creation",
                Language = "English",
                Platform = "Medium",
                Url = new Uri("https://medium.com/my-blog/my-awesome-blog-post")
            }
                    ]
            };
        }
    }
}
