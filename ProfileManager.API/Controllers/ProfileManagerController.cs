using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileManager.Domain.Models;
using ProfileManager.Domain.Interfaces;
using System.Threading;
using MongoDB.Bson;
using System.Net;

namespace ProfileManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileManagerController : ControllerBase
    {
        private readonly ILogger<ProfileManagerController> _logger;

        private readonly IProfileRepository _profileRepository;

        public ProfileManagerController(ILogger<ProfileManagerController> logger, IProfileRepository profileRepository)
        {
            _logger = logger;
            _profileRepository = profileRepository;
        }

        [HttpPost("/CreateProfile")]
        public async Task CreateProfile(string Name, string LastName, string Skill, CancellationToken cancellationToken)
        {
            await _profileRepository.CreateProfileAsync(new Profile(Name, LastName, Skill), cancellationToken);
        }

        [HttpGet("/GetAll")]
        public async Task<IEnumerable<Profile>> GetAll(CancellationToken cancellationToken)
        {
            return await _profileRepository.GetAllAsync(cancellationToken);
        }

        [HttpGet("/GetById")]
        public async Task<Profile> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _profileRepository.GetByIdAsync(id, cancellationToken);
        }

        [HttpGet("/GetBySkill")]
        public async Task<IEnumerable<Profile>> GetBySkill(string skill, CancellationToken cancellationToken)
        {
            return await _profileRepository.GetBySkillAsync(skill, cancellationToken);
        }

        [HttpDelete("/DeleteProfile")]
        public async Task<bool> DeleteProfile(Guid id, CancellationToken cancellationToken)
        {
            return await _profileRepository.DeleteProfileAsync(id, cancellationToken);
        }

        [HttpPut("/UpdateProfile")]
        public async Task<bool> UpdateProfile(Profile profile, CancellationToken cancellationToken)
        {
            return await _profileRepository.UpdateProfileAsync(profile, cancellationToken);
        }
    }
}
