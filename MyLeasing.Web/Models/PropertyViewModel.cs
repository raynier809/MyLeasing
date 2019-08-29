using Microsoft.AspNetCore.Mvc.Rendering;
using MyLeasing.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Models
{
    public class PropertyViewModel: Property
    {
        public int OwnerId { get; set; }

        [Display(Name = "Property Type")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Range(1,int.MaxValue, ErrorMessage = "You moust select a property type.")]
        public int PropertyTypeId { get; set; }
        public IEnumerable<SelectListItem> PropertyTypes { get; set; }
    }
}
