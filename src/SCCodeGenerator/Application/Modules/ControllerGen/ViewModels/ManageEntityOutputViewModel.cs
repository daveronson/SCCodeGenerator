using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCCodeGenerator.ControllerGen.ViewModels
{
    public class ManageEntityOutputViewModel
    {
        [Display(Name="Entity Name")]
        public string EntityName { get; set; }
        public string AppNameSpace { get; set; }
        public string AppUsingPrefix { get; set; }
        public string ManageEntityCode { get; set; }
        public string ModuleName { get; set; }
        

    }
}
