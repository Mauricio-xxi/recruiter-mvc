using RecruiterApp.Domain.Entities;
using RecruiterApp.Domain.Interfaces;

namespace RecruiterApp.Application.CreateCandidate
{
    public class CreateCandidateService : ICreateCandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CreateCandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public Task CreateCandidateAsync(Candidate candidate)
        {
            return _candidateRepository.AddAsync(candidate);
        }
    }
}
