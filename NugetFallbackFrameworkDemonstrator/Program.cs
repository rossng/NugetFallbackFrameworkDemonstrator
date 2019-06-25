using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.ProjectModel;
using System.IO;

namespace NugetFallbackFrameworkDemonstrator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dependencyGraph = ReadDependencyGraph(args[0]);
        }

        public static DependencyGraphSpec ReadDependencyGraph(string dependencyGraphPath)
        {
            using (var file = File.OpenText(dependencyGraphPath))
            using (var reader = new JsonTextReader(file))
            {
                return new DependencyGraphSpec((JObject)JToken.ReadFrom(reader));
            }
        }
    }
}
