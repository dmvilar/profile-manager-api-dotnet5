using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ProfileManager.Domain.Models
{
    public sealed record Profile
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string LastName { get; init; }
        public string Skill { get; init; }

        public Profile(string name, string lastName, string skill)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Skill = skill;
        }
    }
}
