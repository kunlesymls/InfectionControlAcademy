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
    public class TrainingSchedulesController : BaseController
    {
        private readonly IRepo<TrainingSchedule> _repo;
        public TrainingSchedulesController(IRepo<TrainingSchedule> repo, ITrainingQuery trainingQuery,
                                IMapper mapper, IGeneralQuery query) : base(mapper, query, trainingQuery)
        {
            _repo = repo;
        }


        // GET: TrainingSchedules
        public async Task<IActionResult> Index()
        {
            ViewData["TraningTypeId"] = new SelectList(await _trainingQuery.TrainingTypeList(), "TraningTypeId", "TraningName");
            return View();
        }

        public async Task<IActionResult> GetIndex()
        {
            var model = await _trainingQuery.TrainingScheduleList();
            var data = model;
            return Json(new { data });
        }


        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            var model = await _repo.GetById(id);
            var data = _mapper.Map<TrainingScheduleVm>(model);
            ViewData["TraningTypeId"] = new SelectList(await _trainingQuery.TrainingTypeList(), "TraningTypeId", "TraningName",
                                                            model?.TraningTypeId);
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(TrainingScheduleVm trainingScheduleVm)
        {
            var model = _mapper.Map<TrainingSchedule>(trainingScheduleVm);
            string message;

            if (ModelState.IsValid)
            {
                if (model.TrainingScheduleId > 0)
                {
                    _repo.Update(model, userId);
                    message = $"{model.Subject} Training Schedule Updated Successfully";
                }
                else
                {
                    await _repo.Save(model, userId);
                    message = $"{model.Subject} Training Schedule created Successfully";
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
            return Json(new { status, message = status ? "Training Schedule has been deleted successfully" : message });
        }
    }
}
