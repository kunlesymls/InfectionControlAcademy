using System.Collections.Generic;

namespace Academy.ViewModels.MenuVm
{
    public class Menu
    {
        public string CategoryName { get; set; }
        public string ModuleName { get; set; }
        public string IconName { get; set; }
        public bool HasSub { get; set; } = true;
        public string ActionValue { get; set; }
        public string ControllerValue { get; set; }
        public string Role { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public List<string> MenuRoles { get; set; }
    }
}
