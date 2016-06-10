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

        public string ControllerClassGen(string controllerName)
        {

            string controllerClassCode = "public class " + controllerName + "Controller : Controller" + lb +
                "{" + lb +
                tab + "public " + controllerName + "Controller()" + lb +
                tab + "{" + lb +
                tab + "}" + lb;

            return controllerClassCode;
        }
    }
}
