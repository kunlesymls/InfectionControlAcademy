using Academy.Infrastructure.Abstractions;
using Academy.Models.Training;
using Academy.ViewModels.TraningVm;
using AutoMapper;
using Covid.Models.Constant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Academy.Web.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class TraningTypesController : BaseController
    {
        private readonly IRepo<TraningType> _repo;
        public TraningTypesController(IRepo<TraningType> repo, IMapper mapper, IGeneralQuery query) : base(mapper, query)
        {
            _repo = repo;
        }

        // GET: TraningTypes
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetIndex()
        {
            var model = await _repo.GetAll();
            var data = _mapper.Map<List<TraningTypeVm>>(model);
            return Json(new { data });
        }


        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            var model = await _repo.GetById(id);
            var data = _mapper.Map<TraningTypeVm>(model);
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(TraningTypeVm traningTypeVm)
        {
            var model = _mapper.Map<TraningType>(traningTypeVm);
            string message;

            if (ModelState.IsValid)
            {
                if (model.TraningTypeId > 0)
                {
                    _repo.Update(model, userId);
                    message = $"{model.TraningName} Training Type Updated Successfully";
                }
                else
                {
                    await _repo.Save(model, userId);
                    message = $"{model.TraningName} Training Type created Successfully";
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
            return Json(new { status, message = status ? "Training Type has been deleted successfully" : message });

        }
    }
}
