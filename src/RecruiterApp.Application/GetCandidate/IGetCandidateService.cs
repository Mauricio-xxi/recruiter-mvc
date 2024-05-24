using RecruiterApp.Domain.Entities;

namespace RecruiterApp.Application.GetCandidate
{
    public interface IGetCandidateService
    {
        Task<Candidate> GetCandidateByIdAsync(int IdCandidate);
    }
}
