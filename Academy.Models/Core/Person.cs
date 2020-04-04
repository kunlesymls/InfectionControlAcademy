using System;

namespace Academy.Models.Core
{
    public abstract class Person : Audit
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Religion { get; set; }
        public string MaritalStatus { get; set; }
        public string TownOfBirth { get; set; }
        public string Lga { get; set; }
        public string StateOfOrigin { get; set; }
        public string Nationality { get; set; }
        public string CountryOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                var t = DateTime.Now - DateTime.Parse(DateOfBirth.ToString());
                return t.Days / 365;
            }
        }
        public string UserName => LastName + " " + FirstName;
        public string FullName => LastName + " " + FirstName + " " + MiddleName;

        public byte[] Passport { get; set; }
        public byte[] Signature { get; set; }
    }
}