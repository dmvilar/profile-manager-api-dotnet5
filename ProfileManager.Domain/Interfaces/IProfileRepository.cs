using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProfileManager.Domain.Models;

namespace ProfileManager.Domain.Interfaces
{
    public interface IProfileRepository
    {
        Task CreateProfileAsync(Profile people, CancellationToken cancellationToken);
        Task UpdateProfileAsync(Profile people);
        Task DeleteProfileAsync(int id);
        Task<Profile> GetByIdAsync(int id);
        Task<IEnumerable<Profile>> GetBySkillAsync(string skill);
        Task<IEnumerable<Profile>> GetAllAsync(CancellationToken cancellationToken);
    }
}
