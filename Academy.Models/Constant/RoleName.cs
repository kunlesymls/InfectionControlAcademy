using System.Collections.Generic;

namespace Covid.Models.Constant
{
    public static class RoleName
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Admin = "Admin";
        public const string Staff = "Staff";
        public const string Applicant = "Applicant";

        public static List<string> GetRoleList()
        {
            return new List<string>
            {
                Admin, Staff, Applicant
            };
        }
    }
}
