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
        private readonly string lt = "&lt;";
        private readonly string gt = "&gt;";
        private readonly string tab = "&nbsp;&nbsp;&nbsp;&nbsp;";

        public string ControllerClassGen(ControllerOutputViewModel controllerOutputVM)
        {
            string entityName = controllerOutputVM.EntityName;
            string dbContextName = controllerOutputVM.DbContextName;

            string controllerClassCode = null;
            controllerClassCode += "public class " + entityName + "Controller : Controller" + lb;
            controllerClassCode += "{" + lb;

            controllerClassCode += ControllerClassVarsCode(dbContextName);
            controllerClassCode += ControllerConstructorCode(entityName, dbContextName);
            controllerClassCode += ControllerIndexCode(entityName);
            controllerClassCode += ControllerCreateCode(entityName);
            controllerClassCode += ControllerDetailsCode(entityName);
            controllerClassCode += ControllerEditCode(entityName);
            controllerClassCode += "}" + lb;

            return controllerClassCode;
        }

        private string ControllerClassVarsCode(string dbContextName)
        {
            string controllerClassVarsCode = null;

            controllerClassVarsCode += tab + "private " + dbContextName + " db;" + lb;
            controllerClassVarsCode += tab + "private IMapper mapper { get; set; }" + lb + lb;
            controllerClassVarsCode += lb;

            return controllerClassVarsCode;
        }

        private string ControllerConstructorCode(string entityName, string dbContextName)
        {
            string controllerConstructorCode = null;
            controllerConstructorCode += tab + "public " + entityName + "Controller(" + dbContextName + " db, IMapper mapper)" + lb;
            controllerConstructorCode += tab + "{" + lb;
            controllerConstructorCode += tab + tab + "this.db = db;" + lb;
            controllerConstructorCode += tab + tab + "this.mapper = mapper;" + lb;
            controllerConstructorCode += tab + "}" + lb;
            controllerConstructorCode += lb;

            return controllerConstructorCode;
        }

        private string ControllerIndexCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string controllerIndexCode = null;

            controllerIndexCode += tab + "public async Task" + lt + "IActionResult" + gt + entityName + "Index(int id)" + lb;
            controllerIndexCode += tab + "{" + lb;
            controllerIndexCode += tab + tab + "var manage" + entityName + " = new Manage" + entityName + "(db, mapper);" + lb;
            controllerIndexCode += tab + tab + "List " + lt + entityName + "ViewModel" + gt + entityNameLocal + "s = await manage" + entityName + ".GetAll" + entityName + "s(id);" + lb;
            controllerIndexCode += tab + tab + "return View(" + entityNameLocal + "s);" + lb;
            controllerIndexCode += tab + "}" + lb;
            controllerIndexCode += lb;

            return controllerIndexCode;
        }

        private string ControllerCreateCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string controllerCreateCode = null;

            controllerCreateCode += tab + "public IActionResult " + entityName + "Create()" + lb;
            controllerCreateCode += tab + "{" + lb;
            controllerCreateCode += tab + tab + "return View();" + lb;
            controllerCreateCode += tab + "}" + lb;

            controllerCreateCode += lb;
            controllerCreateCode += tab + "[HttpPost]" + lb;
            controllerCreateCode += tab + "[ValidateAntiForgeryToken]" + lb;
            controllerCreateCode += tab + "public async Task" + lt + "IActionResult" + gt + entityName + "Create(" + entityName + "ViewModel " + entityNameLocal + "ViewModel)" + lb;
            controllerCreateCode += tab + "{" + lb;
            controllerCreateCode += tab + tab + "if (ModelState.IsValid)" + lb;
            controllerCreateCode += tab + tab + "{" + lb;
            controllerCreateCode += tab + tab + tab + "var manage" + entityName + " = new Manage" + entityName + "(db, mapper);" + lb;
            controllerCreateCode += tab + tab + tab + "await manage" + entityName + ".Create" + entityName + "(" + entityNameLocal + "ViewModel);" + lb;
            controllerCreateCode += lb;
            controllerCreateCode += tab + tab + tab + "return RedirectToAction(\"" + entityName + "Index);" + lb;
            controllerCreateCode += tab + tab + "}" + lb;
            controllerCreateCode += lb;
            controllerCreateCode += tab + tab + "return View(" + entityNameLocal + "ViewModel);" + lb;
            controllerCreateCode += tab + "}" + lb;
            controllerCreateCode += lb;

            return controllerCreateCode;
        }

        private string ControllerDetailsCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string controllerDetailsCode = null;

            controllerDetailsCode += tab + "public async Task" + lt + "IActionResult" + gt + entityName + "Details(int id)" + lb;
            controllerDetailsCode += tab + "{" + lb;
            controllerDetailsCode += tab + tab + "var manage" + entityName + " = new Manage" + entityName + "(db, mapper);" + lb;
            controllerDetailsCode += tab + tab + entityName + "ViewModel " + entityNameLocal + "ViewModel = await manage" + entityName + ".Get" + entityName + "(id);" + lb;
            controllerDetailsCode += tab + tab + "if (" + entityNameLocal + "ViewModel == null)" + lb;
            controllerDetailsCode += tab + tab + "{" + lb;
            controllerDetailsCode += tab + tab + tab + "return NotFound();" + lb;
            controllerDetailsCode += tab + tab + "}" + lb;
            controllerDetailsCode += lb;
            controllerDetailsCode += tab + tab + "return View(" + entityNameLocal + "ViewModel);" + lb;
            controllerDetailsCode += tab + "}" + lb;
            controllerDetailsCode += lb;

            return controllerDetailsCode;
        }

        private string ControllerEditCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string controllerEditCode = null;

            controllerEditCode += tab + "public async Task" + lt + "IActionResult" + gt + entityName + "Edit(int id)" + lb;
            controllerEditCode += tab + "{" + lb;
            controllerEditCode += tab + tab + "var manage" + entityName + " = new Manage" + entityName + "(db, mapper);" + lb;
            controllerEditCode += tab + tab + entityName + "ViewModel " + entityNameLocal + "ViewModel = await manage" + entityName + ".Get" + entityName + "(id);" + lb;

            controllerEditCode += tab + tab + "if (" + entityNameLocal + "ViewModel == null)" + lb;
            controllerEditCode += tab + tab + "{" + lb;
            controllerEditCode += tab + tab + tab + "return NotFound();" + lb;
            controllerEditCode += tab + tab + "}" + lb;

            controllerEditCode += tab + tab + "return View(" + entityNameLocal + "ViewModel);" + lb;
            controllerEditCode += tab + "}" + lb;
            controllerEditCode += lb;

            controllerEditCode += tab + "[HttpPost]" + lb;
            controllerEditCode += tab + "[ValidateAntiForgeryToken]" + lb;
            controllerEditCode += tab + "public async Task" + lt + "IActionResult" + gt + entityName + "Edit(" + entityName + "ViewModel " + entityNameLocal + "ViewModel)" + lb;
            controllerEditCode += tab + "{" + lb;
            controllerEditCode += tab + tab + "if (ModelState.IsValid)" + lb;
            controllerEditCode += tab + tab + "{" + lb;
            controllerEditCode += tab + tab + tab + "var manage" + entityName + " = new Manage" + entityName + "(db, mapper);" + lb;
            controllerEditCode += tab + tab + tab + "await manage" + entityName + ".Update" + entityName + "(" + entityNameLocal + "ViewModel);" + lb;
            controllerEditCode += tab + tab + tab + "return RedirectToAction(\"" + entityName + "Details\", new { id = " + entityNameLocal + "ViewModel.ID });" + lb;
            controllerEditCode += tab + tab + "}" + lb;
            controllerEditCode += lb;
            controllerEditCode += tab + tab + "return View(" + entityNameLocal + "ViewModel);" + lb;
            controllerEditCode += tab + "}" + lb;
            controllerEditCode += lb;

            return controllerEditCode;
        }
    }
}
