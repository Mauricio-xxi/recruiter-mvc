using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecruiterApp.Api.Models;
using RecruiterApp.Application.CreateCandidate;
using RecruiterApp.Application.DeleteCandidate;
using RecruiterApp.Application.GetCandidate;
using RecruiterApp.Application.GetCandidatesList;
using RecruiterApp.Application.UpdateCandidate;
using RecruiterApp.Domain.Entities;

namespace RecruiterApp.Api.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICreateCandidateService _createCandidateService;
        private readonly IDeleteCandidateService _deleteCandidateService;
        private readonly IGetCandidateService _getCandidateService;
        private readonly IGetCandidatesListService _getCandidatesListService;
        private readonly IUpdateCandidateService _updateCandidateService;
        private readonly IMapper _mapper;

        public CandidatesController(
            ICreateCandidateService createCandidateService,
            IDeleteCandidateService deleteCandidateService,
            IGetCandidateService getCandidateService,
            IGetCandidatesListService getCandidatesListService,
            IUpdateCandidateService updateCandidateService,
            IMapper mapper)
        {
            _createCandidateService = createCandidateService;
            _deleteCandidateService = deleteCandidateService;
            _getCandidateService = getCandidateService;
            _getCandidatesListService = getCandidatesListService;
            _updateCandidateService = updateCandidateService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var candidates = await _getCandidatesListService.GetAllCandidatesAsync();
            var model = _mapper.Map<List<CandidateViewModel>>(candidates);
            return View(model); ;
        }

        public IActionResult Create()
        {
            var model = new CandidateCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidateCreateViewModel candidateModel)
        {
            if (ModelState.IsValid)
            {
                var candidate = _mapper.Map<Candidate>(candidateModel);
                await _createCandidateService.CreateCandidateAsync(candidate);
                return RedirectToAction(nameof(Index));
            }
            return View(candidateModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _getCandidateService.GetCandidateByIdAsync(id.Value);
            if (candidate == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CandidateEditViewModel>(candidate);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CandidateEditViewModel candidateModel)
        {
            if (id != candidateModel.IdCandidate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var candidate = _mapper.Map<Candidate>(candidateModel);
                await _updateCandidateService.UpdateCandidateAsync(candidate, candidateModel.ExperiencesToRemove);
                return RedirectToAction(nameof(Index));
            }
            return View(candidateModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _deleteCandidateService.DeleteCandidateAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}