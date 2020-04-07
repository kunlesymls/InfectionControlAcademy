using Academy.Infrastructure.Abstractions;
using Academy.Models.TrainingApplication;
using Academy.ViewModels.ApplicationVm;

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Academy.Web.Controllers
{
    [Authorize()]
    public class WorkingExperiencesController : BaseController
    {
        private readonly IRepo<WorkingExperience> _repo;
        public WorkingExperiencesController(IRepo<WorkingExperience> repo, IApplicantQuery applicantQuery,
                                IMapper mapper, IGeneralQuery query) : base(mapper, query, applicantQuery)
        {
            _repo = repo;
        }

        // GET: WorkingExperiences
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetIndex()
        {
            var model = await _applicantQuery.WorkingExperienceList(applicantId);
            var data = model;
            return Json(new { data });
        }


        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            var model = await _repo.GetById(id);
            var data = _mapper.Map<WorkingExperienceVm>(model);
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(WorkingExperienceVm workingExperienceVm)
        {
            var model = _mapper.Map<WorkingExperience>(workingExperienceVm);
            string message;

            if (ModelState.IsValid)
            {
                if (model.WorkingExperienceId > 0)
                {
                    _repo.Update(model, userId);
                    message = $"{model.Organization} Working Experience Updated Successfully";
                }
                else
                {
                    await _repo.Save(model, userId);
                    message = $"{model.Organization} Working Experience created Successfully";
                }

                var response = await _repo.SaveContext();
                return Json(new { response.status, message = response.status ? message : response.message });
            }
            message = $"Bad Data is supplied please fill all compulsory field(s)";
            return Json(new { status = false, message });
        }


        [HttpPost, ActionName("Delete")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.Delete(id);
            var (status, message) = await _repo.SaveContext();
            return Json(new { status, message = status ? "Working Experience has been deleted successfully" : message });

        }
    }
}
