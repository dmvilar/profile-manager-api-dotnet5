using MongoDB.Bson;
using MongoDB.Driver;
using ProfileManager.Domain.Interfaces;
using ProfileManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProfileManager.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly MongoDbContext _dbContext;
        public ProfileRepository(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateProfileAsync(Profile profile, CancellationToken cancellationToken)
        {
            await _dbContext.Profile.InsertOneAsync(profile, null, cancellationToken);
        }

        public async Task<bool> DeleteProfileAsync(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Profile>.Filter.Eq(p => p.Id, id);

            var result = await _dbContext.Profile.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<IEnumerable<Profile>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Profile.Find<Profile>(x => true).ToListAsync(cancellationToken);
        }   

        public async Task<Profile> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Profile.Find<Profile>(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Profile>> GetBySkillAsync(string skill, CancellationToken cancellationToken)
        {
            return await _dbContext.Profile.Find<Profile>(x => x.Skill.Equals(skill, StringComparison.CurrentCultureIgnoreCase)).ToListAsync(cancellationToken);
        }

        public async Task<bool> UpdateProfileAsync(Profile profile, CancellationToken cancellationToken)
        {
            var filter = Builders<Profile>.Filter.Eq(p => p.Id, profile.Id);
            var update = Builders<Profile>.Update
                .Set(p => p.Name, profile.Name)
                .Set(p => p.LastName, profile.LastName)
                .Set(p => p.Skill, profile.Skill);

            var result = await _dbContext.Profile.UpdateOneAsync(filter, update, null, cancellationToken);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
