using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.EntityFrameworkCore.Infrastructure;
using DAL.UProfileData;
using Tracker.Dtos.UProfileDtos;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using DAL;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Tracker.Controllers
{
	[Authorize]
	[Route("api/uprofiles")]
	[ApiController]
	public class UProfilesControllers: ControllerBase
	{
		private readonly ICRUDRepo<UProfile> _profileRepo;
		private readonly ICRUDRepo<UCredential> _credRepo;
		private readonly IMapper _mapper;

		public UProfilesControllers(ICRUDRepo<UProfile> profileRepo, ICRUDRepo<UCredential> credRepo, IMapper mapper)
		{
			_profileRepo = profileRepo;
			_credRepo = credRepo;
			_mapper = mapper;
		}

		// GET api/uprofiles
		[HttpGet]
		[Authorize(Roles = "Admin")]
		public ActionResult <IEnumerable<UProfileReadDto>> GetAllUProfiles()
		{
			var uprofiles = _profileRepo.GetAllRows().ToList();
			var creds = _credRepo.GetAllRows().ToList();

			var userInfos = _mapper.Map<List<UProfileReadDto>>(uprofiles);
			_mapper.Map(creds, userInfos);

			return Ok(userInfos);
		}


		// GET api/uprofiles/{id}
		[HttpGet("profile", Name = "GetUProfileById")]
		public ActionResult <UProfileReadDto> GetUProfileById()
		{
			var username = HttpContext.User.Identity.Name;
			var uCred = _credRepo.GetRowByKey(username);
			if(uCred == null)
			{
				return NotFound();
			}

			var uProfile = _profileRepo.GetRowByKey(uCred.Id.ToString());
			var userInfo = _mapper.Map<UProfileReadDto>(uProfile);
			_mapper.Map(uCred, userInfo);

			return Ok(userInfo);
		}

		//POST api/uprofiles
		[HttpPost]
		public ActionResult<UProfileReadDto> CreateUProfile(UProfileCreateDto uprofiledto)
		{
			var uCred = _credRepo.GetRowById(uprofiledto.UserId);
			if(uCred == null)
			{
				return NotFound("Such user does not exist");
			}


			var uprofileModel = _mapper.Map<UProfile>(uprofiledto);
			_profileRepo.CreateRow(uprofileModel);
			_profileRepo.SaveChanges();


			var pinfoReadDto = _mapper.Map<UProfileReadDto>(uprofileModel);
			return CreatedAtRoute(nameof(GetUProfileById),
				new { Id = uprofileModel.UserId }, pinfoReadDto);
		}


		//PUT api/uprofiles/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateUProfile(int id, UProfileUpdateDto uprofiledto)
		{
			var uCred = _credRepo.GetRowById(id);
			if (uCred == null)
			{
				return NotFound("Such user does not exist");
			}


			var uprofileFromRepo = _profileRepo.GetRowById(id);
			if(uprofileFromRepo == null)
			{
				return NotFound();
			}


			_mapper.Map(uprofiledto, uprofileFromRepo);
			_profileRepo.UpdateRow(uprofileFromRepo);
			_profileRepo.SaveChanges();

			return NoContent();
		}


		//PATCH api/uprofiles/{id}
		[HttpPatch("{id}")]
		public ActionResult ParticalUProfileUpdate(
			int id, JsonPatchDocument<UProfileUpdateDto> patchdoc)
		{
			var uCredFromRepo = _credRepo.GetRowById(id);
			if (uCredFromRepo == null)
			{
				return NotFound("Such user does not exist");
			}


			var uprofileFromRepo = _profileRepo.GetRowById(id);
			if (uprofileFromRepo == null)
			{
				return NotFound("Such user does not exist");
			}


			var pinfoToPatch = _mapper.Map<UProfileUpdateDto>(
				uprofileFromRepo);

			patchdoc.ApplyTo(pinfoToPatch, ModelState);
			if (!TryValidateModel(pinfoToPatch))
			{
				return ValidationProblem(ModelState);
			}


			_mapper.Map(pinfoToPatch, uprofileFromRepo);
			_profileRepo.UpdateRow(uprofileFromRepo);
			_profileRepo.SaveChanges();

			return NoContent();
		}


		//DELETE api/uprofiles/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteUProfile(int id)
		{
			var uCredFromRepo = _credRepo.GetRowById(id);
			if (uCredFromRepo == null)
			{
				return NotFound("Such user does not exist");
			}


			var uprofileFromRepo = _profileRepo.GetRowById(id);
			if (uprofileFromRepo == null)
			{
				return NotFound("Such user does not exist");
			}


			_profileRepo.DeleteRow(uprofileFromRepo);
			_profileRepo.SaveChanges();

			return NoContent();
		}


	}
}