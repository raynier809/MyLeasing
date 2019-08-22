using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Document")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(30, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Document { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Address { get; set; }

        [Display(Name = "Owner Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Owner Name")]
        public string FullNameWihtDocument => $"{FirstName} {LastName} - {Document}";
    }
}
