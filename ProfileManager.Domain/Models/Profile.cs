using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ProfileManager.Domain.Models
{
    public class Profile
    {
        [BsonId]
        public ObjectId Id { get; init; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Skill { get; set; }
    }
}
