using AutoMapper;
using RecruiterApp.Api.Models;
using RecruiterApp.Domain.Entities;

namespace RecruiterApp.Api.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CandidateModel, Candidate>();
            CreateMap<Candidate, CandidateModel>();
            CreateMap<Candidate, CandidateCreateViewModel>();
            CreateMap<CandidateCreateViewModel, Candidate>();
            CreateMap<Candidate, CandidateViewModel>();
            CreateMap<CandidateViewModel, Candidate>();
            CreateMap<Candidate, CandidateEditViewModel>();
            CreateMap<CandidateEditViewModel, Candidate>();
            CreateMap<CandidateExperience, CandidateExperienceViewModel>();
            CreateMap<CandidateExperienceViewModel, CandidateExperience>();
            CreateMap<CandidateExperience, CandidateExperienceEditViewModel>();
            CreateMap<CandidateExperienceEditViewModel, CandidateExperience>();
        }
    }
}
