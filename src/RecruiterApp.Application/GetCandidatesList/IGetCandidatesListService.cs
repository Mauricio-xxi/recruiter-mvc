using RecruiterApp.Domain.Entities;

namespace RecruiterApp.Application.GetCandidatesList
{
    public interface IGetCandidatesListService
    {
        Task<IEnumerable<Candidate>> GetAllCandidatesAsync();
    }
}
