using Academy.Models.Constant;
using Academy.ViewModels.MenuVm;
using Covid.Models.Constant;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Web.Components
{
    public static class MenuList
    {
        public static List<Menu> GetAllMenuList()
        {
            return new List<Menu>
            {
                /* Core Tin Management */ 
                //Dashboard
                new Menu
                {
                    CategoryName = ModuleCategory.Dashboard, ModuleName = "Admin Dashboard", IconName = "fa fa-home", HasSub = false,
                    ActionValue = "AdminDashboard", ControllerValue = "Home",
                    MenuRoles = new List<string>{RoleName.Admin}
                },

                 // Recruitment Setup
                new Menu
                {
                    CategoryName = ModuleCategory.Training, ModuleName = "Recruitment Setup", IconName = "fa fa-th-list",
                    MenuItems =   new List<MenuItem>
                    {
                        new MenuItem { DisplayValue = "Salary Structure",  ActionValue = "Index", ControllerValue = "SalaryStructures",
                        MenuRoles = new List<string>{RoleName.Admin}},
                        new MenuItem { DisplayValue = "Job Positions", ActionValue = "Index", ControllerValue = "RecruitmentPositions",
                        MenuRoles = new List<string>{RoleName.Admin}},
                        new MenuItem { DisplayValue = "Dept Job Position", ActionValue = "Index", ControllerValue = "AssignRecruitmentPositionToDepts",
                        MenuRoles = new List<string>{RoleName.Admin}},
                        new MenuItem { DisplayValue = "Reg Setting", ActionValue = "Index", ControllerValue = "RecruitmentRegSettings",
                        MenuRoles = new List<string>{RoleName.Admin}}
                    }
                },
                // Document Setup
                new Menu
                {
                    CategoryName = ModuleCategory.Training, ModuleName = "Document Setup", IconName = "fa fa-file",
                    MenuItems =   new List<MenuItem>
                    {
                        new MenuItem { DisplayValue = "Document Type",  ActionValue = "Index", ControllerValue = "RecruitmentDocumentTypes",
                        MenuRoles = new List<string>{RoleName.Admin}},
                        new MenuItem { DisplayValue = "Dept Document", ActionValue = "Index", ControllerValue = "DeptRequiredDocuments",
                        MenuRoles = new List<string>{RoleName.Admin}}
                    }
                },

                /* Setup Management */ 
                // Basic Setup
                new Menu
                {
                    CategoryName = ModuleCategory.Extra, ModuleName = "School Setup", IconName = "fa fa-tasks",
                    MenuItems =   new List<MenuItem>
                    {
                        new MenuItem { DisplayValue = "School Programme",  ActionValue = "Index", ControllerValue = "SchoolProgrammes",
                        MenuRoles = new List<string>{RoleName.Admin}},
                        new MenuItem { DisplayValue = "School/Faculty",  ActionValue = "Index", ControllerValue = "SchoolOrFaculties",
                        MenuRoles = new List<string>{RoleName.Admin}},
                        new MenuItem { DisplayValue = "Department",  ActionValue = "Index", ControllerValue = "Departments",
                        MenuRoles = new List<string>{RoleName.Admin}},
                        new MenuItem { DisplayValue = "Dept Option",  ActionValue = "Index", ControllerValue = "Programmes",
                        MenuRoles = new List<string>{RoleName.Admin}},
                        new MenuItem { DisplayValue = "Level",  ActionValue = "Index", ControllerValue = "Levels",
                        MenuRoles = new List<string>{RoleName.Admin}},
                         new MenuItem { DisplayValue = "Session",  ActionValue = "Index", ControllerValue = "Sessions",
                        MenuRoles = new List<string>{RoleName.Admin}},
                    }
                },

            };
        }

        public static List<Menu> GetMenuForRole(string roleName)
        {
            var menus = GetAllMenuList().ToList();
            var menuList = new List<Menu>();
            foreach (var menu in menus)
            {
                if (menu.HasSub.Equals(false))
                {
                    if (menu.MenuRoles != null && menu.MenuRoles.Contains(roleName))
                    {
                        menuList.Add(menu);
                    }
                }
                else
                {
                    var menuItem = new Menu();
                    var menuItemList = new List<MenuItem>();

                    if (menu.MenuItems.Count() > 0)
                    {
                        var count = 0;
                        foreach (var item in menu.MenuItems)
                        {
                            if (item.MenuRoles != null && item.MenuRoles.Contains(roleName))
                            {
                                if (count == 0)
                                {
                                    menuItem = menu;
                                    count = 1;
                                }
                                menuItemList.Add(item);
                            }
                            if (menuItemList.Count() > 0)
                            {
                                menuItem.MenuItems = menuItemList;
                            }
                        }
                        if (count == 1)
                        {
                            menuList.Add(menuItem);
                        }
                    }

                }

            }
            return menuList;
        }

    }
}


