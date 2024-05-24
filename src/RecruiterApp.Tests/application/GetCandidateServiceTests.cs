using Moq;
using RecruiterApp.Application.GetCandidate;
using RecruiterApp.Domain.Entities;
using RecruiterApp.Domain.Interfaces;

namespace RecruiterApp.Tests.Application
{
    public class GetCandidateServiceTests
    {
        private readonly Mock<ICandidateRepository> _mockCandidateRepository;
        private readonly GetCandidateService _service;

        public GetCandidateServiceTests()
        {
            _mockCandidateRepository = new Mock<ICandidateRepository>();
            _service = new GetCandidateService(_mockCandidateRepository.Object);
        }

        [Fact]
        public async Task GetCandidateByIdAsync_CallsGetByIdAsyncOnRepository()
        {
            // Arrange
            var candidateId = 1;
            var candidate = new Candidate { IdCandidate = candidateId, Name = "John", Surname = "Doe" };
            _mockCandidateRepository.Setup(repo => repo.GetByIdAsync(candidateId)).ReturnsAsync(candidate);

            // Act
            var result = await _service.GetCandidateByIdAsync(candidateId);

            // Assert
            _mockCandidateRepository.Verify(repo => repo.GetByIdAsync(candidateId), Times.Once);
            Assert.Equal(candidate, result);
        }
    }
}
