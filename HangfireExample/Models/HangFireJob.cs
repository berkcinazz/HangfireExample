using System.Xml.Linq;
using System.Xml.XPath;

namespace HangfireExample.Models
{
    public class HangfireJob
    {
        public Task SendWelcome(string userName)
        {
            Console.WriteLine($"Send welcome {userName}");
            return Task.CompletedTask;
        }

        public Task SendVersionOfHangFire()
        {
            var fullPathOfCsProj = "HangfireExample.csproj";

            var doc = XDocument.Load(fullPathOfCsProj);
            var packageReferences = doc.XPathSelectElements("//PackageReference")
                .Select(pr => new PackageReference
                {
                    Include = pr.Attribute("Include").Value,
                    Version = new Version(pr.Attribute("Version").Value)
                });

            Console.WriteLine($"Project file contains {packageReferences.Count()} package references:");
            foreach (var packageReference in packageReferences)
            {
                Console.WriteLine($"{packageReference.Include}, version {packageReference.Version}");
            }

            return Task.CompletedTask;
        }
    }
}
