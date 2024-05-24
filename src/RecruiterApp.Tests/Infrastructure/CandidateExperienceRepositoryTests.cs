using Microsoft.EntityFrameworkCore;
using RecruiterApp.Domain.Entities;
using RecruiterApp.Infrastructure.Contexts;
using RecruiterApp.Infrastructure.Repositories;

namespace RecruiterApp.Tests.Infrastructure
{
    public class CandidateExperienceRepositoryTests : IDisposable
    {
        private readonly RecruiterAppContext _context;
        private readonly CandidateExperienceRepository _repository;

        public CandidateExperienceRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<RecruiterAppContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new RecruiterAppContext(options);
            _repository = new CandidateExperienceRepository(_context);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllCandidateExperiences()
        {
            // Arrange
            _context.CandidateExperiences.AddRange(
                new CandidateExperience { IdCandidateExperience = 1, Company = "Company A", Job = "Job A", Description = "Description A", Salary = 50000, BeginDate = DateTime.Now },
                new CandidateExperience { IdCandidateExperience = 2, Company = "Company B", Job = "Job B", Description = "Description B", Salary = 60000, BeginDate = DateTime.Now }
            );
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsCandidateExperience()
        {
            // Arrange
            var candidateExperience = new CandidateExperience { IdCandidateExperience = 1, Company = "Company A", Job = "Job A", Description = "Description A", Salary = 50000, BeginDate = DateTime.Now };
            _context.CandidateExperiences.Add(candidateExperience);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync(candidateExperience.IdCandidateExperience);

            // Assert
            Assert.Equal(candidateExperience.IdCandidateExperience, result.IdCandidateExperience);
        }

        [Fact]
        public async Task AddAsync_AddsCandidateExperience()
        {
            // Arrange
            var candidateExperience = new CandidateExperience { IdCandidateExperience = 1, Company = "Company A", Job = "Job A", Description = "Description A", Salary = 50000, BeginDate = DateTime.Now };

            // Act
            await _repository.AddAsync(candidateExperience);
            var result = await _context.CandidateExperiences.FindAsync(candidateExperience.IdCandidateExperience);

            // Assert
            Assert.Equal(candidateExperience.IdCandidateExperience, result.IdCandidateExperience);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesCandidateExperience()
        {
            // Arrange
            var candidateExperience = new CandidateExperience { IdCandidateExperience = 1, Company = "Company A", Job = "Job A", Description = "Description A", Salary = 50000, BeginDate = DateTime.Now };
            _context.CandidateExperiences.Add(candidateExperience);
            await _context.SaveChangesAsync();

            // Act
            candidateExperience.Company = "Company B";
            await _repository.UpdateAsync(candidateExperience);
            var result = await _context.CandidateExperiences.FindAsync(candidateExperience.IdCandidateExperience);

            // Assert
            Assert.Equal("Company B", result.Company);
        }

        [Fact]
        public async Task DeleteAsync_DeletesCandidateExperience()
        {
            // Arrange
            var candidateExperience = new CandidateExperience { IdCandidateExperience = 1, Company = "Company A", Job = "Job A", Description = "Description A", Salary = 50000, BeginDate = DateTime.Now };
            _context.CandidateExperiences.Add(candidateExperience);
            await _context.SaveChangesAsync();

            // Act
            await _repository.DeleteAsync(candidateExperience.IdCandidateExperience);
            var result = await _context.CandidateExperiences.FindAsync(candidateExperience.IdCandidateExperience);

            // Assert
            Assert.Null(result);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
