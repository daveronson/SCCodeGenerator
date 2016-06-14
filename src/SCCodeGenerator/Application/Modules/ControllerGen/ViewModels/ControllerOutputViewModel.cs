using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCCodeGenerator.ControllerGen.ViewModels
{
    public class ControllerOutputViewModel
    {
        [Display(Name="Entity Name")]
        public string EntityName { get; set; }
        [Display(Name = "DbContext Name")]
        public string DbContextName { get; set; }
        public string ControllerCode { get; set; }
        

    }
}
