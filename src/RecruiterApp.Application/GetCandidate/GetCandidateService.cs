using RecruiterApp.Domain.Entities;
using RecruiterApp.Domain.Interfaces;

namespace RecruiterApp.Application.GetCandidate
{
    public class GetCandidateService : IGetCandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public GetCandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public Task<Candidate> GetCandidateByIdAsync(int IdCandidate)
        {
            return _candidateRepository.GetByIdAsync(IdCandidate);
        }
    }
}
