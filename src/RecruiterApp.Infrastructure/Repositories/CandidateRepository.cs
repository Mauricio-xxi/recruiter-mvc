using Microsoft.EntityFrameworkCore;
using RecruiterApp.Domain.Entities;
using RecruiterApp.Domain.Interfaces;
using RecruiterApp.Infrastructure.Contexts;

namespace RecruiterApp.Infrastructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly RecruiterAppContext _context;

        public CandidateRepository(RecruiterAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidate>> GetAllAsync()
        {
            return await _context.Candidates.Include(c => c.CandidateExperiences).ToListAsync();
        }

        public async Task<Candidate> GetByIdAsync(int id)
        {
            return await _context.Candidates.Include(c => c.CandidateExperiences)
                .Include(x => x.CandidateExperiences)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.IdCandidate == id);
        }

        public async Task AddAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
