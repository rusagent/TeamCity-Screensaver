﻿namespace TeamCitySharp.DomainEntities
{
    public class Project
    {
        public bool Archived { get; set; }
        public string Description { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string WebUrl { get; set; }

        public BuildTypeWrapper BuildTypes { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}