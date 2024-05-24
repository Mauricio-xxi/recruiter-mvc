using Moq;
using RecruiterApp.Application.UpdateCandidate;
using RecruiterApp.Domain.Entities;
using RecruiterApp.Domain.Interfaces;

namespace RecruiterApp.Tests.Application
{
    public class UpdateCandidateServiceTests
    {
        private readonly Mock<ICandidateRepository> _mockCandidateRepository;
        private readonly Mock<ICandidateExperienceRepository> _mockExperienceRepository;
        private readonly UpdateCandidateService _service;

        public UpdateCandidateServiceTests()
        {
            _mockCandidateRepository = new Mock<ICandidateRepository>();
            _mockExperienceRepository = new Mock<ICandidateExperienceRepository>();
            _service = new UpdateCandidateService(_mockCandidateRepository.Object, _mockExperienceRepository.Object);
        }

        [Fact]
        public async Task UpdateCandidateAsync_CallsUpdateAsyncOnRepository()
        {
            // Arrange
            var candidate = new Candidate { IdCandidate = 1, Name = "John", Surname = "Doe" };
            var experiencesToDelete = new List<int> { 1, 2 };

            // Act
            await _service.UpdateCandidateAsync(candidate, experiencesToDelete);

            // Assert
            _mockCandidateRepository.Verify(repo => repo.UpdateAsync(candidate), Times.Once);
            _mockExperienceRepository.Verify(repo => repo.DeleteAsync(1), Times.Once);
            _mockExperienceRepository.Verify(repo => repo.DeleteAsync(2), Times.Once);
        }
    }
}
