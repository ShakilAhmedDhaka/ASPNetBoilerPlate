using AutoMapper;
using Tracker.Dtos.UCredentialDtos;
using Entities.Models;

namespace Tracker.Profiles
{
    public class UCredentialsProflile : Profile
    {
        public UCredentialsProflile()
        {
            CreateMap<UCredential, UCredentialReadDto>();
        }
    }
}
