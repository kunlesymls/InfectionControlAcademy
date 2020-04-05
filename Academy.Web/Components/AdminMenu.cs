using Academy.ViewModels.MenuVm;
using Covid.Models.Constant;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace Academy.Web.Components
{
    public class AdminMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuList = new List<Menu>();
            if (User.IsInRole(RoleName.SuperAdmin))
            {
                menuList = MenuList.GetMenuForRole(RoleName.SuperAdmin);
            }
            else if (User.IsInRole(RoleName.Admin))
            {
                menuList = MenuList.GetMenuForRole(RoleName.Admin);
            }
            else if (User.IsInRole(RoleName.Staff))
            {
                menuList = MenuList.GetMenuForRole(RoleName.Staff);
            }          
           
            return View(menuList);
        }
    }
}
