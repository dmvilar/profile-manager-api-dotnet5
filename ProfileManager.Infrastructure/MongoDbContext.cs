using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProfileManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileManager.Infrastructure
{
    public class MongoDbContext : DbContext
    {

        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoConnection");
            var databaseName = "Cluster0";

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Profile> Profile => _database.GetCollection<Profile>("profile");

    }
}
