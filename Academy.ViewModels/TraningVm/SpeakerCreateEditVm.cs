using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Academy.ViewModels.TraningVm
{
    public class SpeakerCreateEditVm
    {
        public int SpeakerId { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Honours")]
        public string Honours { get; set; }

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
