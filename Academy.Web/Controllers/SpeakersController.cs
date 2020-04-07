using Academy.Infrastructure.Abstractions;
using Academy.Models.Training;
using Academy.ViewModels.TraningVm;

using AutoMapper;

using Covid.Models.Constant;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Academy.Web.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class SpeakersController : BaseController
    {
        private readonly IRepo<Speaker> _repo;
        public SpeakersController(IRepo<Speaker> repo, ITrainingQuery trainingQuery,
                                IMapper mapper, IGeneralQuery query) : base(mapper, query, trainingQuery)
        {
            _repo = repo;
        }

        // GET: Speakers
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetIndex()
        {
            var model = await _trainingQuery.SpeakerList();
            var data = model;
            return Json(new { data });
        }


        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            var model = await _repo.GetById(id);
            var data = _mapper.Map<SpeakerCreateEditVm>(model);
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(SpeakerCreateEditVm speakerVm)
        {
            var model = _mapper.Map<Speaker>(speakerVm);
            string message;

            if (ModelState.IsValid)
            {
                if (model.SpeakerId > 0)
                {
                    _repo.Update(model, userId);
                    message = $"{model.FullName} Speaker Updated Successfully";
                }
                else
                {
                    await _repo.Save(model, userId);
                    message = $"{model.FullName} Speaker Type created Successfully";
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
            return Json(new { status, message = status ? "Speaker has been deleted successfully" : message });

        }
    }
}
