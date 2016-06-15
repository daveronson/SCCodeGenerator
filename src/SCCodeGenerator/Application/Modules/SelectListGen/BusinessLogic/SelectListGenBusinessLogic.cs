using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCCodeGenerator.SelectListGen.ViewModels;

namespace SCCodeGenerator.SelectListGen.BusinessLogic
{
    public class SelectListGenBusinessLogic
    {
        private readonly string lb = "<br/>";
        private readonly string lt = "&lt;";
        private readonly string gt = "&gt;";
        private readonly string tab = "&nbsp;&nbsp;&nbsp;&nbsp;";

        public string SelectListCode(SelectListOutputViewModel selectListOutputViewModel)
        {          
            string entityName = selectListOutputViewModel.EntityName;
            string fieldName = selectListOutputViewModel.FieldName;
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);


            string selectListCode = null;

            selectListCode += tab + "private void Populate" + entityName + "DropDownList(int selectedValue)" + lb;
            selectListCode += tab + "{" + lb;
            selectListCode += tab + tab + "List" + lt + entityName + "ViewModel" + gt + entityNameLocal + "ViewModel = new List" + lt + entityName + "ViewModel" + gt + "();" + lb;
            selectListCode += lb;
            selectListCode += tab + tab + "var " + entityNameLocal + "s = db." + entityName + lb;
            selectListCode += tab + tab + tab + ".ToList();" + lb;

            selectListCode += tab + tab + "foreach (var " + entityNameLocal + " in " + entityNameLocal + "s)" + lb;
            selectListCode += tab + tab + "{" + lb;
            selectListCode += tab + tab + tab + entityName + "ViewModel " + entityNameLocal + "ViewModel = mapper.Map" + lt + entityName + ", " + entityName + "ViewModel" + gt + "(" + entityNameLocal + ");" + lb;
            selectListCode += tab + tab + tab + entityNameLocal + "sViewModel.Add(" + entityNameLocal + "ViewModel);" + lb;
            selectListCode += tab + tab + "}" + lb;
            selectListCode += lb;
            selectListCode += tab + tab + "ViewBag." + entityName + "s = new SelectList(" + entityNameLocal + "sViewModel, \"ID\",\"" + fieldName + "\", selectedValue);" + lb;
            selectListCode += tab + "}" + lb;     

            return selectListCode;
        }
    }
}
