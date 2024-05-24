using RecruiterApp.Domain.Entities;

namespace RecruiterApp.Application.UpdateCandidate
{
    public interface IUpdateCandidateService
    {
        Task UpdateCandidateAsync(Candidate candidate, List<int> experiencesToDelete);
    }
}
