using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Models
{
    public class AddUserViewMadel : EditUserViewModel
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string username { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [StringLength(20, MinimumLength =6, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirm")]
        [Compare("Password")]
        public string PasswordConfrirm { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Register as")]
        [Range(1,int.MaxValue, ErrorMessage ="You must select a role")]
        public int RoleId { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
