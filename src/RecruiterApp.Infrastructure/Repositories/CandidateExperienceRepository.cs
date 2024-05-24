using Microsoft.EntityFrameworkCore;
using RecruiterApp.Domain.Entities;
using RecruiterApp.Domain.Interfaces;
using RecruiterApp.Infrastructure.Contexts;

namespace RecruiterApp.Infrastructure.Repositories
{
    public class CandidateExperienceRepository : ICandidateExperienceRepository
    {
        private readonly RecruiterAppContext _context;

        public CandidateExperienceRepository(RecruiterAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CandidateExperience>> GetAllAsync()
        {
            return await _context.CandidateExperiences.ToListAsync();
        }

        public async Task<CandidateExperience> GetByIdAsync(int id)
        {
            return await _context.CandidateExperiences.FindAsync(id);
        }

        public async Task AddAsync(CandidateExperience candidateExperience)
        {
            await _context.CandidateExperiences.AddAsync(candidateExperience);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CandidateExperience candidateExperience)
        {
            _context.CandidateExperiences.Update(candidateExperience);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var candidateExperience = await _context.CandidateExperiences.FindAsync(id);
            if (candidateExperience != null)
            {
                _context.CandidateExperiences.Remove(candidateExperience);
                await _context.SaveChangesAsync();
            }
        }
    }
}
