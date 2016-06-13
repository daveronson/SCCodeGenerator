using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCCodeGenerator.ControllerGen.ViewModels
{
    public class ControllerOutputViewModel
    {
        [Display(Name="Controller Name")]
        public string ControllerName { get; set; }
        [Display(Name = "AutoMapper Support?")]
        public bool AutoMapperSupport { get; set; }
        public string ControllerCode { get; set; }
        

    }
}
