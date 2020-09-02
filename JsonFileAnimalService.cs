using FeedIt.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace FeedItv2.Services
{
    public class JsonFileAnimalService
    {
        public JsonFileAnimalService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "animals.json"); }
        }

        public IEnumerable<Animal> GetAnimals()
        {
            using StreamReader jsonFileReader = File.OpenText(JsonFileName);

            return JsonSerializer.Deserialize<Animal[]>(jsonFileReader.ReadToEnd());
        }

        
    }
}
