using TeamCitySharp.DomainEntities;

namespace Mo.TeamCityScreensaver.classes
{
    public class BuildConfiguration
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string WebUrl { get; set; }
        public Build Build { get; set; }
        public Project ParentProject { get; set; }
    }
}