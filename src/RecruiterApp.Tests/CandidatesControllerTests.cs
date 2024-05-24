using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecruiterApp.Api.AutoMapper;
using RecruiterApp.Api.Controllers;
using RecruiterApp.Api.Models;
using RecruiterApp.Application.CreateCandidate;
using RecruiterApp.Application.DeleteCandidate;
using RecruiterApp.Application.GetCandidate;
using RecruiterApp.Application.GetCandidatesList;
using RecruiterApp.Application.UpdateCandidate;
using RecruiterApp.Domain.Entities;

namespace RecruiterApp.Tests
{
    public class CandidatesControllerTests
    {
        private readonly Mock<ICreateCandidateService> _mockCreateService;
        private readonly Mock<IDeleteCandidateService> _mockDeleteService;
        private readonly Mock<IGetCandidateService> _mockGetService;
        private readonly Mock<IGetCandidatesListService> _mockGetListService;
        private readonly Mock<IUpdateCandidateService> _mockUpdateService;
        private readonly IMapper _mapper;
        private readonly CandidatesController _controller;

        public CandidatesControllerTests()
        {
            _mockCreateService = new Mock<ICreateCandidateService>();
            _mockDeleteService = new Mock<IDeleteCandidateService>();
            _mockGetService = new Mock<IGetCandidateService>();
            _mockGetListService = new Mock<IGetCandidatesListService>();
            _mockUpdateService = new Mock<IUpdateCandidateService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();

            _controller = new CandidatesController(
                _mockCreateService.Object,
                _mockDeleteService.Object,
                _mockGetService.Object,
                _mockGetListService.Object,
                _mockUpdateService.Object,
                _mapper
            );
        }

        [Fact]
        public async Task Index_ReturnsViewResult_WithListOfCandidates()
        {
            // Arrange
            var candidates = new List<Candidate> { new Candidate { IdCandidate = 1, Name = "John", Surname = "Doe", Email = "john@example.com" } };
            _mockGetListService.Setup(service => service.GetAllCandidatesAsync()).ReturnsAsync(candidates);

            // Act
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<CandidateViewModel>>(viewResult.Model);
            Assert.Single(model);
        }

        [Fact]
        public void Create_ReturnsViewResult_WithEmptyViewModel()
        {
            // Act
            var result = _controller.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CandidateCreateViewModel>(viewResult.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task Create_Post_ReturnsRedirectToActionResult_WhenModelIsValid()
        {
            // Arrange
            var candidateModel = new CandidateCreateViewModel
            {
                Name = "John",
                Surname = "Doe",
                Email = "john@example.com"
            };
            _mockCreateService.Setup(service => service.CreateCandidateAsync(It.IsAny<Candidate>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(candidateModel);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Edit_ReturnsNotFoundResult_WhenIdIsNull()
        {
            // Act
            var result = await _controller.Edit(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Edit_ReturnsViewResult_WithCandidateViewModel()
        {
            // Arrange
            var candidate = new Candidate { IdCandidate = 1, Name = "John", Surname = "Doe", Email = "john@example.com" };
            _mockGetService.Setup(service => service.GetCandidateByIdAsync(1)).ReturnsAsync(candidate);

            // Act
            var result = await _controller.Edit(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CandidateEditViewModel>(viewResult.Model);
            Assert.Equal("John", model.Name);
        }

        [Fact]
        public async Task DeleteConfirmed_ReturnsRedirectToActionResult()
        {
            // Arrange
            _mockDeleteService.Setup(service => service.DeleteCandidateAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteConfirmed(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
