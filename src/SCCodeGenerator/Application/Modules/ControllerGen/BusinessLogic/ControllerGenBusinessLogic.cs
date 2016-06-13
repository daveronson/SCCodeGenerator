using SCCodeGenerator.ControllerGen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCCodeGenerator.ControllerGen.BusinessLogic
{
    public class ControllerGenBusinessLogic
    {
        private readonly string lb = "<br/>";
        private readonly string tab = "&nbsp;&nbsp;&nbsp;&nbsp;";

        public string ControllerClassGen(ControllerOutputViewModel controllerOutputVM)
        {

            string controllerClassCode = null;
            controllerClassCode += "public class " + controllerOutputVM.ControllerName + "Controller : Controller" + lb;
            controllerClassCode += "{" + lb;

            //Conditionally add AutoMapper variable
            if(controllerOutputVM.AutoMapperSupport) { controllerClassCode += tab + "private IMapper mapper { get; set; }" + lb +lb; }

            controllerClassCode += tab + "public " + controllerOutputVM.ControllerName + "Controller(";
                if (controllerOutputVM.AutoMapperSupport) { controllerClassCode += "IMapper mapper"; }
            controllerClassCode += ")" + lb;
            controllerClassCode += tab + "{" + lb;
            controllerClassCode += tab + "}" + lb;

            return controllerClassCode;
        }
    }
}
