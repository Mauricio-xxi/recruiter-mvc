using Microsoft.EntityFrameworkCore;
using RecruiterApp.Domain.Entities;
using RecruiterApp.Infrastructure.Contexts;
using RecruiterApp.Infrastructure.Repositories;

namespace RecruiterApp.Tests.Infrastructure
{
    public class CandidateRepositoryTests : IDisposable
    {
        private readonly RecruiterAppContext _context;
        private readonly CandidateRepository _repository;

        public CandidateRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<RecruiterAppContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new RecruiterAppContext(options);
            _context.Database.EnsureCreated();
            _repository = new CandidateRepository(_context);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllCandidates()
        {
            // Arrange
            _context.Candidates.AddRange(
                new Candidate { IdCandidate = 1, Name = "John", Surname = "Doe", Email = "john@example.com" },
                new Candidate { IdCandidate = 2, Name = "Jane", Surname = "Doe", Email = "jane@example.com" }
            );
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsCandidate()
        {
            // Arrange
            var candidate = new Candidate { IdCandidate = 1, Name = "John", Surname = "Doe", Email = "john@example.com" };
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync(candidate.IdCandidate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(candidate.IdCandidate, result.IdCandidate);
        }

        [Fact]
        public async Task AddAsync_AddsCandidate()
        {
            // Arrange
            var candidate = new Candidate { IdCandidate = 1, Name = "John", Surname = "Doe", Email = "john@example.com" };

            // Act
            await _repository.AddAsync(candidate);
            var result = await _context.Candidates.FindAsync(candidate.IdCandidate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(candidate.IdCandidate, result.IdCandidate);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesCandidate()
        {
            // Arrange
            var candidate = new Candidate { IdCandidate = 1, Name = "John", Surname = "Doe", Email = "john@example.com" };
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            candidate.Name = "Johnny";

            // Act
            await _repository.UpdateAsync(candidate);
            var result = await _context.Candidates.FindAsync(candidate.IdCandidate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Johnny", result.Name);
        }

        [Fact]
        public async Task DeleteAsync_DeletesCandidate()
        {
            // Arrange
            var candidate = new Candidate { IdCandidate = 1, Name = "John", Surname = "Doe", Email = "john@example.com" };
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            // Act
            await _repository.DeleteAsync(candidate.IdCandidate);
            var result = await _context.Candidates.FindAsync(candidate.IdCandidate);

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
