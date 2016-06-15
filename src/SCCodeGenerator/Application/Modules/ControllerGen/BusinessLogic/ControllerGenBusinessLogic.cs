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
            string controllerName = controllerOutputVM.ControllerName;
            string entityName = controllerOutputVM.EntityName;
            string dbContextName = controllerOutputVM.DbContextName;
            string appNameSpace = controllerOutputVM.AppNameSpace;
            string appUsingPrefix = controllerOutputVM.AppUsingPrefix;
            string moduleName = controllerOutputVM.ModuleName;

            string controllerClassCode = null;

            controllerClassCode += ControllerUsingCode(appUsingPrefix, moduleName);
            controllerClassCode += ControllerNamespaceCode(appNameSpace);
            controllerClassCode += "{" + lb;
            controllerClassCode += tab + "public class " + controllerName + "Controller : Controller" + lb;
            controllerClassCode += tab + "{" + lb;

            controllerClassCode += ControllerClassVarsCode(dbContextName);
            controllerClassCode += ControllerConstructorCode(controllerName, dbContextName);
            controllerClassCode += ControllerIndexCode(entityName);
            controllerClassCode += ControllerDetailsCode(entityName);
            controllerClassCode += ControllerCreateCode(entityName);
            controllerClassCode += ControllerEditCode(entityName);
            controllerClassCode += ControllerDeleteCode(entityName);
            controllerClassCode += tab + "}" + lb;
            controllerClassCode += "}" + lb;
            return controllerClassCode;
        }

        private string ControllerUsingCode(string appUsingPrefix, string moduleName)
        {
            string controllerUsingCode = null;

            controllerUsingCode += "using AutoMapper;" + lb;
            controllerUsingCode += "using Microsoft.AspNetCore.Mvc;" + lb;
            controllerUsingCode += "using Microsoft.EntityFrameworkCore;" + lb;
            controllerUsingCode += "using " + appUsingPrefix + "." + moduleName + ".BusinessLogic;" + lb;
            controllerUsingCode += "using " + appUsingPrefix + "." + moduleName + ".Models;" + lb;
            controllerUsingCode += "using " + appUsingPrefix + "." + moduleName + ".ViewModels;" + lb;
            controllerUsingCode += "using " + appUsingPrefix + ".DAL;" + lb;
            controllerUsingCode += "using System.Collections.Generic;" + lb;
            controllerUsingCode += "using System.Linq;" + lb;
            controllerUsingCode += "using System.Threading.Tasks;" + lb;
            controllerUsingCode += lb;

            return controllerUsingCode;
        }

        private string ControllerNamespaceCode(string appNameSpace)
        {
            string controllerNamespaceCode = null;

            controllerNamespaceCode += "namespace " + appNameSpace + lb;

            return controllerNamespaceCode;
        }

        private string ControllerClassVarsCode(string dbContextName)
        {
            string controllerClassVarsCode = null;

            controllerClassVarsCode += tab + tab + "private readonly " + dbContextName + " db;" + lb;
            controllerClassVarsCode += tab + tab + "private IMapper mapper { get; set; }" + lb;
            controllerClassVarsCode += lb;

            return controllerClassVarsCode;
        }

        private string ControllerConstructorCode(string controllerName, string dbContextName)
        {
            string controllerConstructorCode = null;
            controllerConstructorCode += tab + tab + "public " + controllerName + "Controller(" + dbContextName + " db, IMapper mapper)" + lb;
            controllerConstructorCode += tab + tab + "{" + lb;
            controllerConstructorCode += tab + tab + tab + "this.db = db;" + lb;
            controllerConstructorCode += tab + tab + tab + "this.mapper = mapper;" + lb;
            controllerConstructorCode += tab + tab + "}" + lb;
            controllerConstructorCode += lb;

            return controllerConstructorCode;
        }

        private string ControllerIndexCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string controllerIndexCode = null;

            controllerIndexCode += tab + tab + "public async Task" + lt + "IActionResult" + gt + " " + entityName + "Index()" + lb;
            controllerIndexCode += tab + tab + "{" + lb;
            controllerIndexCode += tab + tab + tab + "var manage" + entityName + " = new Manage" + entityName + "(db, mapper);" + lb;
            controllerIndexCode += tab + tab + tab + "List " + lt + entityName + "ViewModel" + gt + entityNameLocal + "s = await manage" + entityName + ".GetAll" + entityName + "s();" + lb;
            controllerIndexCode += tab + tab + tab + "return View(" + entityNameLocal + "s);" + lb;
            controllerIndexCode += tab + tab + "}" + lb;
            controllerIndexCode += lb;

            return controllerIndexCode;
        }

        private string ControllerCreateCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string controllerCreateCode = null;

            controllerCreateCode += tab + tab + "public IActionResult " + entityName + "Create()" + lb;
            controllerCreateCode += tab + tab + "{" + lb;
            controllerCreateCode += tab + tab + tab + "return View();" + lb;
            controllerCreateCode += tab + tab + "}" + lb;

            controllerCreateCode += lb;
            controllerCreateCode += tab + tab + "[HttpPost]" + lb;
            controllerCreateCode += tab + tab + "[ValidateAntiForgeryToken]" + lb;
            controllerCreateCode += tab + tab + "public async Task" + lt + "IActionResult" + gt + " " + entityName + "Create(" + entityName + "ViewModel " + entityNameLocal + "ViewModel)" + lb;
            controllerCreateCode += tab + tab + "{" + lb;
            controllerCreateCode += tab + tab + tab + "if (ModelState.IsValid)" + lb;
            controllerCreateCode += tab + tab + tab + "{" + lb;
            controllerCreateCode += tab + tab + tab + tab + "var manage" + entityName + " = new Manage" + entityName + "(db, mapper);" + lb;
            controllerCreateCode += tab + tab + tab + tab + "await manage" + entityName + ".Create" + entityName + "(" + entityNameLocal + "ViewModel);" + lb;
            controllerCreateCode += lb;
            controllerCreateCode += tab + tab + tab + tab + "return RedirectToAction(\"" + entityName + "Index\");" + lb;
            controllerCreateCode += tab + tab + tab + "}" + lb;
            controllerCreateCode += lb;
            controllerCreateCode += tab + tab + tab + "return View(" + entityNameLocal + "ViewModel);" + lb;
            controllerCreateCode += tab + tab + "}" + lb;
            controllerCreateCode += lb;

            return controllerCreateCode;
        }

        private string ControllerDetailsCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string controllerDetailsCode = null;

            controllerDetailsCode += tab + tab + "public async Task" + lt + "IActionResult" + gt + " " + entityName + "Details(int id)" + lb;
            controllerDetailsCode += tab + tab + "{" + lb;
            controllerDetailsCode += tab + tab + tab + "var manage" + entityName + " = new Manage" + entityName + "(db, mapper);" + lb;
            controllerDetailsCode += tab + tab + tab + entityName + "ViewModel " + entityNameLocal + "ViewModel = await manage" + entityName + ".Get" + entityName + "(id);" + lb;
            controllerDetailsCode += tab + tab + tab + "if (" + entityNameLocal + "ViewModel == null)" + lb;
            controllerDetailsCode += tab + tab + tab + "{" + lb;
            controllerDetailsCode += tab + tab + tab + tab + "return NotFound();" + lb;
            controllerDetailsCode += tab + tab + tab + "}" + lb;
            controllerDetailsCode += lb;
            controllerDetailsCode += tab + tab + tab + "return View(" + entityNameLocal + "ViewModel);" + lb;
            controllerDetailsCode += tab + tab + "}" + lb;
            controllerDetailsCode += lb;

            return controllerDetailsCode;
        }

        private string ControllerEditCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string controllerEditCode = null;

            controllerEditCode += tab + tab + "public async Task" + lt + "IActionResult" + gt + " " + entityName + "Edit(int id)" + lb;
            controllerEditCode += tab + tab + "{" + lb;
            controllerEditCode += tab + tab + tab + "var manage" + entityName + " = new Manage" + entityName + "(db, mapper);" + lb;
            controllerEditCode += tab + tab + tab + entityName + "ViewModel " + entityNameLocal + "ViewModel = await manage" + entityName + ".Get" + entityName + "(id);" + lb;

            controllerEditCode += tab + tab + tab + "if (" + entityNameLocal + "ViewModel == null)" + lb;
            controllerEditCode += tab + tab + tab + "{" + lb;
            controllerEditCode += tab + tab + tab + tab + "return NotFound();" + lb;
            controllerEditCode += tab + tab + tab + "}" + lb;

            controllerEditCode += tab + tab + tab + "return View(" + entityNameLocal + "ViewModel);" + lb;
            controllerEditCode += tab + tab + "}" + lb;
            controllerEditCode += lb;

            controllerEditCode += tab + tab + "[HttpPost]" + lb;
            controllerEditCode += tab + tab + "[ValidateAntiForgeryToken]" + lb;
            controllerEditCode += tab + tab + "public async Task" + lt + "IActionResult" + gt + " " + entityName + "Edit(" + entityName + "ViewModel " + entityNameLocal + "ViewModel)" + lb;
            controllerEditCode += tab + tab + "{" + lb;
            controllerEditCode += tab + tab + tab + "if (ModelState.IsValid)" + lb;
            controllerEditCode += tab + tab + tab + "{" + lb;
            controllerEditCode += tab + tab + tab + tab + "var manage" + entityName + " = new Manage" + entityName + "(db, mapper);" + lb;
            controllerEditCode += tab + tab + tab + tab + "await manage" + entityName + ".Update" + entityName + "(" + entityNameLocal + "ViewModel);" + lb;
            controllerEditCode += tab + tab + tab + tab + "return RedirectToAction(\"" + entityName + "Details\", new { id = " + entityNameLocal + "ViewModel.ID });" + lb;
            controllerEditCode += tab + tab + tab + "}" + lb;
            controllerEditCode += lb;
            controllerEditCode += tab + tab + tab + "return View(" + entityNameLocal + "ViewModel);" + lb;
            controllerEditCode += tab + tab + "}" + lb;
            controllerEditCode += lb;

            return controllerEditCode;
        }

        private string ControllerDeleteCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string controllerDeleteCode = null;

            controllerDeleteCode += tab + tab + "public async Task" + lt + "IActionResult" + gt + " " + entityName + "Delete(int id)" + lb;
            controllerDeleteCode += tab + tab + "{" + lb;
            controllerDeleteCode += tab + tab + tab + "var manage" + entityName + " = new Manage" + entityName + "(db, mapper);" + lb;
            controllerDeleteCode += tab + tab + tab + entityName + "ViewModel " + entityNameLocal + "ViewModel = await manage" + entityName + ".Get" + entityName + "(id);" + lb;
            controllerDeleteCode += tab + tab + tab + "if (" + entityNameLocal + "ViewModel == null)" + lb;
            controllerDeleteCode += tab + tab + tab + "{" + lb;
            controllerDeleteCode += tab + tab + tab + tab + "return NotFound();" + lb;
            controllerDeleteCode += tab + tab + tab + "}" + lb;
            controllerDeleteCode += lb;
            controllerDeleteCode += tab + tab + tab + "return View( " + entityNameLocal + "ViewModel);" + lb;
            controllerDeleteCode += tab + tab + "}" + lb;


            controllerDeleteCode += tab + tab + "[HttpPost, ActionName(\"" + entityName + "Delete\")]" + lb;
            controllerDeleteCode += tab + tab + "[ValidateAntiForgeryToken]" + lb;
            controllerDeleteCode += tab + tab + "public async Task" + lt + "IActionResult" + gt + " " + entityName + "DeleteConfirmed(int id)" + lb;
            controllerDeleteCode += tab + tab + "{" + lb;
            controllerDeleteCode += tab + tab + tab + "var manage" + entityName + " = new Manage" + entityName + "(db, mapper);" + lb;
            controllerDeleteCode += tab + tab + tab + "await manage" + entityName + ".Delete" + entityName + "(id);" + lb;
            controllerDeleteCode += lb;
            controllerDeleteCode += tab + tab + tab + "return RedirectToAction(\"" + entityName + "Index\");" + lb;
            controllerDeleteCode += lb;
            controllerDeleteCode += tab + tab + "}" + lb;

            return controllerDeleteCode;
        }
    }
}
