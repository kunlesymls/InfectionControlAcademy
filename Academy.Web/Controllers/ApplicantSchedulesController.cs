using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academy.DAL.Context;
using Academy.Models.TrainingApplication;
using Covid.Models.Constant;
using Microsoft.AspNetCore.Authorization;
using Academy.Infrastructure.Abstractions;
using AutoMapper;
using Academy.ViewModels.ApplicationVm;

namespace Academy.Web.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class ApplicantSchedulesController : BaseController
    {
        private readonly IRepo<ApplicantSchedule> _repo;
        public ApplicantSchedulesController(IRepo<ApplicantSchedule> repo, ITrainingQuery trainingQuery,
                                IApplicantQuery applicantQuery, IMapper mapper, IGeneralQuery query) 
                                    : base(mapper, query, trainingQuery, applicantQuery)
        {
            _repo = repo;
        }

        // GET: ApplicantSchedules
        public async Task<IActionResult> Index()
        {
            ViewData["TrainingScheduleId"] = new SelectList(await _trainingQuery.TrainingScheduleList(), "TrainingScheduleId", "Subject");
            return View();
        }

        public async Task<IActionResult> GetIndex()
        {
            var model = await _applicantQuery.ApplicantScheduleList(applicantId);
            var data = model;
            return Json(new { data });
        }


        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            var model = await _repo.GetById(id);
            var data = _mapper.Map<ApplicantScheduleCreateVm>(model);
            ViewData["TrainingScheduleId"] = new SelectList(await _trainingQuery.TrainingScheduleList(), 
                                                "TrainingScheduleId", "Subject", model?.TrainingScheduleId);
            return PartialView(data);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ApplicantScheduleCreateVm scheduleCreateVm)
        {
            var model = _mapper.Map<ApplicantSchedule>(scheduleCreateVm);
            string message;

            if (ModelState.IsValid)
            {
                if (model.ApplicantScheduleId > 0)
                {
                    _repo.Update(model, userId);
                    message = $"Training Schedule Updated Successfully";
                }
                else
                {
                    await _repo.Save(model, userId);
                    message = $"Training Schedule created Successfully";
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
