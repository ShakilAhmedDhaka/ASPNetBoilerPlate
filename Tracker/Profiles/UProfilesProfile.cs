using AutoMapper;
using Tracker.Dtos.UProfileDtos;
using Entities.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tracker.Profiles
{
    public class UProfilesProfile : Profile
    {
        public UProfilesProfile()
        {
            CreateMap<UProfile, UProfileReadDto>()
                .ForMember(dest => dest.Age,
                opt => opt.MapFrom(src => src.getAge()))
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Sex,
                opt => opt.MapFrom(src => src.Sex))
                .ForAllOtherMembers(m => m.Ignore());

            CreateMap<UCredential, UProfileReadDto>()
                .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
                .ForAllOtherMembers(m => m.Ignore());

            CreateMap<List<UCredential>, List<UProfileReadDto>>()
                .AfterMap((s, d) =>
               {
                   for (int i = 0; i < s.Count; i++)
                   {
                       d[i].UserName = s[i].Username;
                       d[i].Email = s[i].Email;
                   }
               }).ForAllOtherMembers(m => m.Ignore());


            CreateMap<UProfileCreateDto, UProfile>()
                .ForMember(dest => dest.Dob,
                opt => opt.MapFrom(src => src.getDob()));

            CreateMap<UProfileUpdateDto, UProfile>();

            CreateMap<UProfile, UProfileUpdateDto>();

        }

    }
}