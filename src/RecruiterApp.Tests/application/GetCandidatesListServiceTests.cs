using Moq;
using RecruiterApp.Application.GetCandidatesList;
using RecruiterApp.Domain.Entities;
using RecruiterApp.Domain.Interfaces;

namespace RecruiterApp.Tests.Application
{
    public class GetCandidatesListServiceTests
    {
        private readonly Mock<ICandidateRepository> _mockCandidateRepository;
        private readonly GetCandidatesListService _service;

        public GetCandidatesListServiceTests()
        {
            _mockCandidateRepository = new Mock<ICandidateRepository>();
            _service = new GetCandidatesListService(_mockCandidateRepository.Object);
        }

        [Fact]
        public async Task GetAllCandidatesAsync_CallsGetAllAsyncOnRepository()
        {
            // Arrange
            var candidates = new List<Candidate>
            {
                new Candidate { IdCandidate = 1, Name = "John", Surname = "Doe" },
                new Candidate { IdCandidate = 2, Name = "Jane", Surname = "Doe" }
            };
            _mockCandidateRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(candidates);

            // Act
            var result = await _service.GetAllCandidatesAsync();

            // Assert
            _mockCandidateRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
            Assert.Equal(candidates, result);
        }
    }
}
