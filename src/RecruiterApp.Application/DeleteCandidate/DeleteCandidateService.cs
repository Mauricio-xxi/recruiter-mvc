using RecruiterApp.Domain.Interfaces;

namespace RecruiterApp.Application.DeleteCandidate
{
    public class DeleteCandidateService : IDeleteCandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public DeleteCandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public Task DeleteCandidateAsync(int IdCandidate)
        {
            return _candidateRepository.DeleteAsync(IdCandidate);
        }
    }
}
