namespace TeamCitySharp.DomainEntities
{
    public class Group
    {
        public string Href { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }

        public UserWrapper Users { get; set; }
        public RoleWrapper Roles { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}