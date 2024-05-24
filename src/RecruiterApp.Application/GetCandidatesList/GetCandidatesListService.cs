using RecruiterApp.Domain.Entities;
using RecruiterApp.Domain.Interfaces;

namespace RecruiterApp.Application.GetCandidatesList
{
    public class GetCandidatesListService : IGetCandidatesListService
    {
        private readonly ICandidateRepository _candidateRepository;

        public GetCandidatesListService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public async Task<IEnumerable<Candidate>> GetAllCandidatesAsync()
        {
            return await _candidateRepository.GetAllAsync();
        }
    }
}
