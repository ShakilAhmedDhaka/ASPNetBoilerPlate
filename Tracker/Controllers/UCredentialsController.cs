using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tracker.Auth;
using Tracker.Dtos.UCredentialDtos;


namespace Tracker.Controllers
{
    [Authorize]
    [Route("api/ucredentials")]
    [ApiController]
    public class UCredentialsController : ControllerBase
    {
        private readonly ICRUDRepo<UCredential> _repository;
        private readonly IMapper _mapper;
        private readonly IAuthenticationManager _authManager;

        public UCredentialsController(ICRUDRepo<UCredential> repository, IMapper mapper, IAuthenticationManager authManager)
        {
            _repository = repository;
            _mapper = mapper;
            _authManager = authManager;
        }


        // GET api/ucredentials
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<UCredentialReadDto>> GetAllUCredentials()
        {
            var credFromModel = _repository.GetAllRows();
            return Ok(_mapper.Map<IEnumerable<UCredentialReadDto>>(credFromModel));
        }

        
        // POST api/ucredentials/authenticate
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult Authenciate([FromBody] UCredential uCred)
        {
            var token = _authManager.Authenticate(uCred.Username, uCred.Password);

            if (token == null) Unauthorized();
            
            return Ok(token);
        }

       
    }
}
