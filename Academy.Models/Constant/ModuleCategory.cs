using System.Collections.Generic;

namespace Academy.Models.Constant
{
    public static class ModuleCategory
    {
        public const string Dashboard = "DASHBOARD";
        public const string Training = "TRAINING SETUO";
        public const string Extra = "SETTINGS";

        public static List<string> GetCategory()
        {
            return new List<string>
            {
                Dashboard, Training, Extra
            };
        }
    }
}
