using Microsoft.AspNetCore.Mvc;
using SCCodeGenerator.ControllerGen.BusinessLogic;
using SCCodeGenerator.ControllerGen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SCCodeGenerator.ControllerGen
{
    public class ControllerGenController : Controller
    {
        public IActionResult ControllerCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ControllerCreateResults(ControllerOutput controllerOutputViewModel)
        {
            var controllerGenBusinessLogic = new ControllerGenBusinessLogic();
            controllerOutputViewModel.ControllerCode = controllerGenBusinessLogic.ControllerClassGen(controllerOutputViewModel.ControllerName);

            return View(controllerOutputViewModel);
        }
    }
}
