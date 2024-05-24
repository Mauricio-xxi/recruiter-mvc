using RecruiterApp.Domain.Entities;

namespace RecruiterApp.Application.CreateCandidate
{
    public interface ICreateCandidateService
    {
        Task CreateCandidateAsync(Candidate candidate);
    }
}
