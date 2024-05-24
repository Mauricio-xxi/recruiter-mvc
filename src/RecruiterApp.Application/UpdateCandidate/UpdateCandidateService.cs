using RecruiterApp.Domain.Entities;
using RecruiterApp.Domain.Interfaces;

namespace RecruiterApp.Application.UpdateCandidate
{
    public class UpdateCandidateService : IUpdateCandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICandidateExperienceRepository _experienceRepository;
        public UpdateCandidateService(ICandidateRepository candidateRepository, ICandidateExperienceRepository experienceRepository)
        {
            _candidateRepository = candidateRepository;
            _experienceRepository = experienceRepository;
        }

        public Task UpdateCandidateAsync(Candidate candidate, List<int> experiencesToDelete)
        {
            foreach (var experienceId in experiencesToDelete)
            {
                _experienceRepository.DeleteAsync(experienceId);
            }
            return _candidateRepository.UpdateAsync(candidate);
        }
    }
}
