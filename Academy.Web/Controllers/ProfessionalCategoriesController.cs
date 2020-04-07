using Academy.Infrastructure.Abstractions;
using Academy.Models.Core;
using Academy.ViewModels.CoreVm;

using AutoMapper;

using Covid.Models.Constant;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Academy.Web.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class ProfessionalCategoriesController : BaseController
    {
        private readonly IRepo<ProfessionalCategory> _repo;
        public ProfessionalCategoriesController(IRepo<ProfessionalCategory> repo, IMapper mapper, IGeneralQuery query) : base(mapper, query)
        {
            _repo = repo;
        }

        // GET: ProfessionalCategories
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetIndex()
        {
            var model = await _query.ProfessionalCategoryList();
            var data = model;
            return Json(new { data });
        }


        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            var model = await _repo.GetById(id);
            var data = _mapper.Map<ProfessionalCategoryVm>(model);
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProfessionalCategoryVm categoryVm)
        {
            var model = _mapper.Map<ProfessionalCategory>(categoryVm);
            string message;

            if (ModelState.IsValid)
            {
                if (model.ProfessionalCategoryId > 0)
                {
                    _repo.Update(model, userId);
                    message = $"{model.ProfessionalName} Professional Category Updated Successfully";
                }
                else
                {
                    await _repo.Save(model, userId);
                    message = $"{model.ProfessionalName} Professional Category created Successfully";
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
            return Json(new { status, message = status ? "Professional Category has been deleted successfully" : message });

        }
    }
}
