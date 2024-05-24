using RecruiterApp.Domain.Entities;

namespace RecruiterApp.Domain.Interfaces
{
    public interface ICandidateExperienceRepository
    {
        Task<IEnumerable<CandidateExperience>> GetAllAsync();
        Task<CandidateExperience> GetByIdAsync(int id);
        Task AddAsync(CandidateExperience candidateExperience);
        Task UpdateAsync(CandidateExperience candidateExperience);
        Task DeleteAsync(int id);
    }
}
