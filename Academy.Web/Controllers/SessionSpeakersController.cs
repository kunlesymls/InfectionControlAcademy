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
    public class SessionSpeakersController : BaseController
    {
        private readonly IRepo<SessionSpeaker> _repo;
        public SessionSpeakersController(IRepo<SessionSpeaker> repo, ITrainingQuery trainingQuery,
                                IMapper mapper, IGeneralQuery query) : base(mapper, query, trainingQuery)
        {
            _repo = repo;
        }

        // GET: SessionSpeakers
        public async Task<IActionResult> Index()
        {
            ViewData["SpeakerId"] = new SelectList(await _trainingQuery.SpeakerList(), "SpeakerId", "FullName");
            ViewData["TrainingSessionId"] = new SelectList(await _trainingQuery.TrainingSessionList(), "TrainingSessionId", "SessionName");
            return View();
        }

        public async Task<IActionResult> GetIndex()
        {
            var model = await _trainingQuery.SessionSpeakerList();
            var data = model;
            return Json(new { data });
        }


        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            var model = await _repo.GetById(id);
            var data = _mapper.Map<SessionSpeakerVm>(model);
            ViewData["SpeakerId"] = new SelectList(await _trainingQuery.SpeakerList(), "SpeakerId", "FullName", model?.SpeakerId);
            ViewData["TrainingSessionId"] = new SelectList(await _trainingQuery.TrainingSessionList(),
                                                "TrainingSessionId", "SessionName", model?.TrainingSessionId);
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(SessionSpeakerVm sessionSpeakerVm)
        {
            var model = _mapper.Map<SessionSpeaker>(sessionSpeakerVm);
            string message;

            if (ModelState.IsValid)
            {
                if (model.SessionSpeakerId > 0)
                {
                    _repo.Update(model, userId);
                    message = $"Session Speaker Updated Successfully";
                }
                else
                {
                    await _repo.Save(model, userId);
                    message = $"Session Speaker created Successfully";
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
            return Json(new { status, message = status ? "Session Speaker has been deleted successfully" : message });

        }
    }
}
