using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileManager.Domain.Models;
using ProfileManager.Domain.Interfaces;
using System.Threading;

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
        public async Task CreateProfile(Profile profile, CancellationToken cancellationToken)
        {
            try
            {
                await _profileRepository.CreateProfileAsync(profile, cancellationToken);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet("/GetAll")]
        public async Task<IEnumerable<Profile>> GetAll(CancellationToken cancellationToken)
        {
            return await _profileRepository.GetAllAsync(cancellationToken);
        }

        //[HttpGet]
        //public Profile GetById()
        //{
        //    return new Profile();
        //}

        //[HttpGet]
        //public IEnumerable<Profile> GetBySkill()
        //{
        //    return new[] { new Profile() };
        //}

    }
}
