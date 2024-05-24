using Moq;
using RecruiterApp.Application.DeleteCandidate;
using RecruiterApp.Domain.Interfaces;

namespace RecruiterApp.Tests.Application
{
    public class DeleteCandidateServiceTests
    {
        private readonly Mock<ICandidateRepository> _mockCandidateRepository;
        private readonly DeleteCandidateService _service;

        public DeleteCandidateServiceTests()
        {
            _mockCandidateRepository = new Mock<ICandidateRepository>();
            _service = new DeleteCandidateService(_mockCandidateRepository.Object);
        }

        [Fact]
        public async Task DeleteCandidateAsync_CallsDeleteAsyncOnRepository()
        {
            // Arrange
            var candidateId = 1;

            // Act
            await _service.DeleteCandidateAsync(candidateId);

            // Assert
            _mockCandidateRepository.Verify(repo => repo.DeleteAsync(candidateId), Times.Once);
        }
    }
}
