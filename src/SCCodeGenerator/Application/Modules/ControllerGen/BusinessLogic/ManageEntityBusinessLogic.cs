using SCCodeGenerator.ControllerGen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SCCodeGenerator.ControllerGen.BusinessLogic
{
    public class ManageEntityBusinessLogic
    {
        private readonly string lb = "<br/>";
        private readonly string lt = "&lt;";
        private readonly string gt = "&gt;";
        private readonly string tab = "&nbsp;&nbsp;&nbsp;&nbsp;";

        public string ManageEntityClassGen(ManageEntityOutputViewModel manageEntityOutputVM)
        {
            string entityName = manageEntityOutputVM.EntityName;
            string appNameSpace = manageEntityOutputVM.AppNameSpace;
            string appUsingPrefix = manageEntityOutputVM.AppUsingPrefix;
            string moduleName = manageEntityOutputVM.ModuleName;

            string manageEntityClassCode = null;

            manageEntityClassCode += ManageEntityUsingCode(appUsingPrefix, moduleName);
            manageEntityClassCode += ManageEntityNamespaceCode(appNameSpace);
            manageEntityClassCode += "{" + lb;
            manageEntityClassCode += tab + "public class Manage" + entityName + lb;
            manageEntityClassCode += tab + "{" + lb;

            manageEntityClassCode += ManageEntityClassVarsCode();
            manageEntityClassCode += ManageEntityConstructorCode(entityName);          
            manageEntityClassCode += ManageEntityIndexCode(entityName);
            manageEntityClassCode += ManageEntityDetailsCode(entityName);
            manageEntityClassCode += ManageEntityCreateCode(entityName);
            manageEntityClassCode += ManageEntityUpdateCode(entityName);
            manageEntityClassCode += ManageEntityDeleteCode(entityName);

            manageEntityClassCode += tab + "}" + lb;
            manageEntityClassCode += "}" + lb;

            return manageEntityClassCode;
        }

        private string ManageEntityUsingCode(string appUsingPrefix, string moduleName)
        {
            string manageEntityUsingCode = null;

            manageEntityUsingCode += "using AutoMapper;" + lb;
            manageEntityUsingCode += "using Microsoft.EntityFrameworkCore;" + lb;
            manageEntityUsingCode += "using " + appUsingPrefix + "." + moduleName + ".Models;" + lb;
            manageEntityUsingCode += "using " + appUsingPrefix + "." + moduleName + ".ViewModels;" + lb;
            manageEntityUsingCode += "using " + appUsingPrefix + ".DAL;" + lb;
            manageEntityUsingCode += "using System.Collections.Generic;" + lb;
            manageEntityUsingCode += "using System.Threading.Tasks;" + lb;
            manageEntityUsingCode += lb;
            return manageEntityUsingCode;
        }

        private string ManageEntityNamespaceCode(string appNameSpace)
        {
            string manageEntityNamespaceCode = null;

            manageEntityNamespaceCode += "namespace " + appNameSpace + lb;

            return manageEntityNamespaceCode;
        }

        private string ManageEntityClassVarsCode()
        {
            string manageEntityClassVarsCode = null;
            manageEntityClassVarsCode += tab + tab + "private readonly SCLifeDbContext db;" + lb;
            manageEntityClassVarsCode += tab + tab + "private IMapper mapper { get; set; }" + lb;
            manageEntityClassVarsCode += lb;

            return manageEntityClassVarsCode;
        }

        private string ManageEntityConstructorCode(string entityName)
        {
            string manageEntityConstructorCode = null;

            manageEntityConstructorCode += tab + tab + "public Manage" + entityName + "(";

            manageEntityConstructorCode += "SCLifeDbContext db";
            manageEntityConstructorCode += ",";
            manageEntityConstructorCode += "IMapper mapper";

            manageEntityConstructorCode += ")" + lb;
            manageEntityConstructorCode += tab + tab + "{" + lb;
            manageEntityConstructorCode += tab + tab + tab + "this.db = db;" + lb;
            manageEntityConstructorCode += tab + tab + tab + "this.mapper = mapper;" + lb;
            manageEntityConstructorCode += tab + tab + "}" + lb;
            manageEntityConstructorCode += lb;

            return manageEntityConstructorCode;
        }

        private string ManageEntityIndexCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string manageEntityIndexCode = null;

            manageEntityIndexCode += tab + tab + "public async Task" + lt + "List" + lt + entityName + "ViewModel" + gt + gt + "GetAll" + entityName + "s()" + lb;
            manageEntityIndexCode += tab + tab + "{" + lb;

            manageEntityIndexCode += tab + tab + tab + "var " + entityNameLocal + "sViewModel = new List" + lt + entityName + "ViewModel" + gt + "();" + lb;
            manageEntityIndexCode += lb;
            manageEntityIndexCode += tab + tab + tab + "var " + entityNameLocal + "s = await db." + entityName + lb;
            manageEntityIndexCode += tab + tab + tab + tab + ".ToListAsync();" + lb;
            manageEntityIndexCode += lb;
            manageEntityIndexCode += tab + tab + tab + "foreach (var " + entityNameLocal + " in " + entityNameLocal + "s)" + lb;
            manageEntityIndexCode += tab + tab + tab + "{" + lb;
            manageEntityIndexCode += tab + tab + tab + tab + entityName + "ViewModel " + entityNameLocal + "ViewModel = mapper.Map" + lt + entityName + ", " + entityName + "ViewModel" + gt + "(" + entityNameLocal + ");" + lb;
            manageEntityIndexCode += tab + tab + tab + tab + entityNameLocal + "sViewModel.Add(" + entityNameLocal + "ViewModel);" + lb;
            manageEntityIndexCode += tab + tab + tab + "}" + lb;
            manageEntityIndexCode += tab + tab + tab + "return " + entityNameLocal + "sViewModel;" + lb;

            manageEntityIndexCode += tab + tab + "}" + lb;
            manageEntityIndexCode += lb;

            return manageEntityIndexCode;
        }

        private string ManageEntityDetailsCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string entityNameShort = Char.ToLowerInvariant(entityName[0]).ToString();
            string manageEntityDetailsCode = null;

            manageEntityDetailsCode += tab + tab + "public async Task" + lt + entityName + "ViewModel" + gt + "Get" + entityName + "(int id)" + lb;
            manageEntityDetailsCode += tab + tab + "{" + lb;
            manageEntityDetailsCode += tab + tab + tab + "var " + entityNameLocal + " = await db." + entityName + lb;
            manageEntityDetailsCode += tab + tab + tab + tab + ".SingleOrDefaultAsync(" + entityNameShort + " => " + entityNameShort + ".ID == id);" + lb;
            manageEntityDetailsCode += tab + tab + tab + entityName + "ViewModel " + entityNameLocal + "VM = mapper.Map" + lt + entityName + ", " + entityName + "ViewModel" + gt + "(" + entityNameLocal + ");" + lb;
            manageEntityDetailsCode += tab + tab + tab + "return " + entityNameLocal + "VM;" + lb;
            manageEntityDetailsCode += tab + tab + "}" + lb;
            manageEntityDetailsCode += lb;

            return manageEntityDetailsCode;
        }

        private string ManageEntityCreateCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string entityNameShort = Char.ToLowerInvariant(entityName[0]).ToString();
            string manageEntityCreateCode = null;

            manageEntityCreateCode += tab + tab + "public async Task Create" + entityName + "(" + entityName + "ViewModel " + entityNameLocal + "ViewModel)" + lb;
            manageEntityCreateCode += tab + tab + "{" + lb;
            manageEntityCreateCode += tab + tab + tab + entityName + " " + entityNameLocal + " = mapper.Map" + lt + entityName + "ViewModel, " + entityName + gt + "(" + entityNameLocal + "ViewModel);" + lb;
            manageEntityCreateCode += lb;
            manageEntityCreateCode += tab + tab + tab + "db." + entityName + ".Add(" + entityNameLocal + ");" + lb;
            manageEntityCreateCode += tab + tab + tab + "await db.SaveChangesAsync();" + lb;
            manageEntityCreateCode += lb;
            manageEntityCreateCode += tab + tab + tab + "return;" + lb;
            manageEntityCreateCode += tab + tab + "}" + lb;
            manageEntityCreateCode += lb;

            return manageEntityCreateCode;
        }

        private string ManageEntityUpdateCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string entityNameShort = Char.ToLowerInvariant(entityName[0]).ToString();
            string manageEntityUpdateCode = null;

            manageEntityUpdateCode += tab + tab + "public async Task Update" + entityName + "(" + entityName + "ViewModel " + entityNameLocal + "ViewModel)" + lb;
            manageEntityUpdateCode += tab + tab + "{" + lb;
            manageEntityUpdateCode += tab + tab + tab + "var " + entityNameLocal + " = mapper.Map" + lt + entityName + "ViewModel, " + entityName + gt + "(" + entityNameLocal + "ViewModel);" + lb;
            manageEntityUpdateCode += tab + tab + tab + "db.Update(" + entityNameLocal + ");" + lb;
            manageEntityUpdateCode += tab + tab + tab + "await db.SaveChangesAsync();" + lb;
            manageEntityUpdateCode += tab + tab + "}" + lb;
            manageEntityUpdateCode += lb;

            return manageEntityUpdateCode;
        }

        private string ManageEntityDeleteCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string entityNameShort = Char.ToLowerInvariant(entityName[0]).ToString();
            string manageEntityDeleteCode = null;

            manageEntityDeleteCode += tab + tab + "public async Task Delete" + entityName + "(int id)" + lb;
            manageEntityDeleteCode += tab + tab + "{" + lb;
            manageEntityDeleteCode += tab + tab + tab + "var " + entityNameLocal + " = await db." + entityName + lb;
            manageEntityDeleteCode += tab + tab + tab + tab + ".SingleAsync(" + entityNameShort + " => " + entityNameShort + ".ID == id);" + lb;
            manageEntityDeleteCode += lb;
            manageEntityDeleteCode += tab + tab + tab + "db." + entityName + ".Remove(" + entityNameLocal + ");" + lb;
            manageEntityDeleteCode += tab + tab + tab + "await db.SaveChangesAsync();" + lb;
            manageEntityDeleteCode += lb;
            manageEntityDeleteCode += tab + tab + tab + "return;" + lb;
            manageEntityDeleteCode += tab + tab + "}" + lb;
            manageEntityDeleteCode += lb;

            return manageEntityDeleteCode;
    }
    }
}
