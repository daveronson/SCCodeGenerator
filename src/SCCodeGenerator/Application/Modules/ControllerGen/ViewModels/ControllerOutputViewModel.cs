using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCCodeGenerator.ControllerGen.ViewModels
{
    public class ControllerOutputViewModel
    {
        [Required]
        [Display(Name = "Controller Name")]
        public string ControllerName { get; set; }
        [Display(Name="Entity Name")]
        public string EntityName { get; set; }
        [Display(Name = "Application Namespace")]
        public string AppNameSpace { get; set; }
        [Display(Name = "Using Prefix")]
        public string AppUsingPrefix { get; set; }
        [Display(Name = "DbContext Name")]
        public string DbContextName { get; set; }
        public string ControllerCode { get; set; }
        [Display(Name = "Module Name")]
        public string ModuleName { get; set; }


    }
}
