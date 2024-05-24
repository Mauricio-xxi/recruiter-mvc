using Moq;
using RecruiterApp.Application.CreateCandidate;
using RecruiterApp.Domain.Entities;
using RecruiterApp.Domain.Interfaces;

namespace RecruiterApp.Tests.Application
{
    public class CreateCandidateServiceTests
    {
        private readonly Mock<ICandidateRepository> _mockCandidateRepository;
        private readonly CreateCandidateService _service;

        public CreateCandidateServiceTests()
        {
            _mockCandidateRepository = new Mock<ICandidateRepository>();
            _service = new CreateCandidateService(_mockCandidateRepository.Object);
        }

        [Fact]
        public async Task CreateCandidateAsync_CallsAddAsyncOnRepository()
        {
            // Arrange
            var candidate = new Candidate { IdCandidate = 1, Name = "John", Surname = "Doe" };

            // Act
            await _service.CreateCandidateAsync(candidate);

            // Assert
            _mockCandidateRepository.Verify(repo => repo.AddAsync(candidate), Times.Once);
        }
    }
}
