using Academy.Infrastructure.Abstractions;
using Academy.ViewModels.MenuVm;
using Covid.Models.Constant;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace Academy.Web.Components
{
    public class UserProfile : ViewComponent
    {
        IGeneralQuery _query;
        public UserProfile(IGeneralQuery query)
        {
            _query = query;
        }
        public IViewComponentResult Invoke()
        {
            var userEmail = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = new UserNavBarVm();

            if (User.IsInRole(RoleName.SuperAdmin))
            {
                var staff = _query.GetStaffDetail(userEmail);
                model.FullName = staff?.FullName ?? "John Doe";
                model.RoleName = "Super Admin";
                model.ImageUrl = Url.Action("RenderImage", "Staffs", new { staffId = staff?.StaffId });
            }

            if (User.IsInRole(RoleName.Admin))
            {
                var staff = _query.GetStaffDetail(userEmail);
                model.FullName = staff?.FullName ?? "John Doe";
                model.RoleName = "Admin";
                model.ImageUrl = Url.Action("RenderImage", "Staffs", new { staffId = staff?.StaffId });
            }

            if (User.IsInRole(RoleName.Staff))
            {
                var staff = _query.GetStaffDetail(userEmail);
                model.FullName = staff?.FullName;
                model.RoleName = "Staff";
                model.ImageUrl = Url.Action("RenderImage", "Staffs", new { staffId = staff?.StaffId });
            }

            return View(model);
        }
    }
}
