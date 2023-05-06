using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using ProfileManager.Domain.Models;

namespace ProfileManager.Domain.Interfaces
{
    public interface IProfileRepository
    {
        Task CreateProfileAsync(Profile people, CancellationToken cancellationToken);
        Task<bool> UpdateProfileAsync(Profile people, CancellationToken cancellationToken);
        Task<bool> DeleteProfileAsync(Guid id, CancellationToken cancellationToken);
        Task<Profile> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Profile>> GetBySkillAsync(string skill, CancellationToken cancellationToken);
        Task<IEnumerable<Profile>> GetAllAsync(CancellationToken cancellationToken);
    }
}
