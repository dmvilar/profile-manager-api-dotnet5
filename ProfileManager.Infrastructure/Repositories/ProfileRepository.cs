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
        public async Task CreateProfileAsync(Profile people, CancellationToken cancellationToken)
        {
            await _dbContext.Profile.InsertOneAsync(people, cancellationToken);
        }

        public Task DeleteProfileAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Profile>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Profile.Find<Profile>(x => true).ToListAsync();
        }

        public Task<Profile> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Profile>> GetBySkillAsync(string skill)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProfileAsync(Profile people)
        {
            throw new NotImplementedException();
        }
    }
}
