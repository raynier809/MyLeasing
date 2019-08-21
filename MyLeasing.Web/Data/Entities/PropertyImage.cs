using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data.Entities
{
    public class PropertyImage
    {
        public int Id { get; set; }

        [Display(Name = "Has Parking Lot?")]
        [Required(ErrorMessage ="The field {0} is mandatory.")]
        public string ImageUrl { get; set; }

        //TODO: change  the path when publish
        public string ImageFullPath => $"https://TBD.azuerewebsites.net{ImageUrl.Substring(1)}";

        public Property Property { get; set; }
    }
}
