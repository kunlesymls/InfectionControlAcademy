using Microsoft.AspNetCore.Http;

using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Academy.ViewModels.CoreVm
{
    public class ApplicantCreateEditVm
    {
        public string ApplicantId { get; set; }

        [Display(Name = "Professional Category")]
        [Required]
        public int ProfessionalCategoryId { get; set; }

        [Display(Name = "License Number")]
        public string LicenseNumber { get; set; }

        [Display(Name = "License Authority")]
        public string LicenseAuthority { get; set; }


        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Other Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        [Required]
        public string Gender { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "Current Address")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Local Government Area")]
        [Required]
        public string Lga { get; set; }

        [Display(Name = "State of Origin")]
        [Required]
        public string StateOfOrigin { get; set; }
        public byte[] Passport { get; set; }
        public byte[] Signature { get; set; }

        [Display(Name = "Upload A Passposrt")]
        [ValidateFile(ErrorMessage = "Please select a PNG/JPEG image smaller than 1MB")]
        public IFormFile File
        {
            get
            {
                return null;
            }
            set
            {
                try
                {
                    using var memoryStream = new MemoryStream();
                    value.CopyTo(memoryStream);
                    Passport = memoryStream.ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        [Display(Name = "Upload A Signature")]
        [ValidateFile(ErrorMessage = "Please select a PNG/JPEG image smaller than 1MB")]
        public IFormFile FileSignature
        {
            get
            {
                return null;
            }
            set
            {
                try
                {
                    using var memoryStream = new MemoryStream();
                    value.CopyTo(memoryStream);
                    Signature = memoryStream.ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public string UserName => LastName + " " + FirstName;
        public string FullName => LastName + " " + FirstName + " " + MiddleName;
    }
}
