using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCCodeGenerator.SelectListGen.ViewModels
{
    public class SelectListOutputViewModel
    {
        [Display(Name = "Field Name")]
        public string FieldName { get; set; }
        [Display(Name="Entity Name")]
        public string EntityName { get; set; }    
        public string SelectListCode { get; set; }    
    }
}
