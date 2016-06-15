using SCCodeGenerator.SelectListGen.BusinessLogic;
using SCCodeGenerator.SelectListGen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SCCodeGenerator.Controllers
{
    public class SelectListGenController : Controller
    {
        public IActionResult SelectListCreate()
        {
            return View();
        }

        public IActionResult SelectListCreateResults(SelectListOutputViewModel selectListOutputViewModel)
        {
            var selectListGenBusinessLogic = new SelectListGenBusinessLogic();
            selectListOutputViewModel.SelectListCode = selectListGenBusinessLogic.SelectListCode(selectListOutputViewModel);

            return View(selectListOutputViewModel);
        }
    }
}