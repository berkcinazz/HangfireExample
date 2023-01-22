namespace HangfireExample.Models
{
    public class PackageReference
    {
        public string Include { get; set; } //get the nuget reference name
        public Version Version { get; set; } // get thee nuget package version
    }
}
