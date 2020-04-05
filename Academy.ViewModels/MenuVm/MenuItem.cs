using System.Collections.Generic;

namespace Academy.ViewModels.MenuVm
{
    public class MenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
        public string ControllerValue { get; set; }
        public List<string> MenuRoles { get; set; }
    }
}
