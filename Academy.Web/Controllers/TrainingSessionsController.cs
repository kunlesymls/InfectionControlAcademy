using Academy.Infrastructure.Abstractions;
using Academy.Models.Training;
using Academy.ViewModels.TraningVm;

using AutoMapper;
using Covid.Models.Constant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Threading.Tasks;

namespace Academy.Web.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class TrainingSessionsController : BaseController
    {
        private readonly IRepo<TrainingSession> _repo;
        public TrainingSessionsController(IRepo<TrainingSession> repo, IApplicantQuery applicantQuery,
                    ITrainingQuery trainingQuery, IMapper mapper, IGeneralQuery query) : base(mapper, query, trainingQuery, applicantQuery)
        {
            _repo = repo;
        }

        // GET: TrainingSessions
        public async Task<IActionResult> Index()
        {
            ViewData["TrainingScheduleId"] = new SelectList(await _trainingQuery.TrainingScheduleList(), "TrainingScheduleId", "Subject");
            return View();
        }

        public async Task<IActionResult> GetIndex()
        {
            var model = await _trainingQuery.TrainingSessionList();
            var data = model;
            return Json(new { data });
        }


        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            var model = await _repo.GetById(id);
            var data = _mapper.Map<TrainingSessionVm>(model);
            ViewData["TrainingScheduleId"] = new SelectList(await _trainingQuery.TrainingScheduleList(), 
                                                "TrainingScheduleId", "Subject", model?.TrainingScheduleId);
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(TrainingSessionVm trainingSessionVm)
        {
            var model = _mapper.Map<TrainingSession>(trainingSessionVm);
            string message;

            if (ModelState.IsValid)
            {
                if (model.TrainingSessionId > 0)
                {
                    _repo.Update(model, userId);
                    message = $"{model.SessionName} Training Session Updated Successfully";
                }
                else
                {
                    await _repo.Save(model, userId);
                    message = $"{model.SessionName} Training Session created Successfully";
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
            return Json(new { status, message = status ? "Training Session has been deleted successfully" : message });
        }
    }
}
