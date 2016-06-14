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

            string manageEntityClassCode = null;
            manageEntityClassCode += "public class Manage" + entityName + lb;
            manageEntityClassCode += "{" + lb;

            manageEntityClassCode += ManageEntityClassVarsCode();
            manageEntityClassCode += ManageEntityConstructorCode(entityName);          
            manageEntityClassCode += ManageEntityIndexCode(entityName);
            manageEntityClassCode += ManageEntityDetailsCode(entityName);
            manageEntityClassCode += ManageEntityCreateCode(entityName);
            manageEntityClassCode += ManageEntityUpdateCode(entityName);

            manageEntityClassCode += "}" + lb;

            return manageEntityClassCode;
        }

        private string ManageEntityClassVarsCode()
        {
            string manageEntityClassVarsCode = null;
            manageEntityClassVarsCode += tab + "private readonly SCLifeDbContext db;" + lb;
            manageEntityClassVarsCode += tab + "private IMapper mapper { get; set; }" + lb;
            manageEntityClassVarsCode += lb;

            return manageEntityClassVarsCode;
        }

        private string ManageEntityConstructorCode(string entityName)
        {
            string manageEntityConstructorCode = null;

            manageEntityConstructorCode += tab + "public Manage" + entityName + "(";

            manageEntityConstructorCode += "SCLifeDbContext db";
            manageEntityConstructorCode += ",";
            manageEntityConstructorCode += "IMapper mapper";

            manageEntityConstructorCode += ")" + lb;
            manageEntityConstructorCode += tab + "{" + lb;
            manageEntityConstructorCode += tab + tab + "this.db = db;" + lb;
            manageEntityConstructorCode += tab + tab + "this.mapper = mapper;" + lb;
            manageEntityConstructorCode += tab + "}" + lb;
            manageEntityConstructorCode += lb;

            return manageEntityConstructorCode;
        }

        private string ManageEntityIndexCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);

            string manageEntityIndexCode = null;
            manageEntityIndexCode += tab + "public async Task" + lt + "List" + lt + entityName + "ViewModel" + gt + gt + "GetAll" + entityName + "s()" + lb;
            manageEntityIndexCode += tab + "{" + lb;

                manageEntityIndexCode += tab + tab + "var " + entityNameLocal + "sViewModel = new List" + lt + entityName + "ViewModel" + gt + "();" + lb;

                manageEntityIndexCode += tab + tab + "var " + entityNameLocal + "s = await db." + entityName + ";" + lb;
                manageEntityIndexCode += tab + tab + tab + ".ToListAsync();" + lb;

                manageEntityIndexCode += tab + tab + "foreach (var " + entityNameLocal + " in " + entityNameLocal + "s)" + lb;
                manageEntityIndexCode += tab + tab + "{" + lb;
                manageEntityIndexCode += tab + tab + tab + entityName + "ViewModel " + entityNameLocal + "ViewModel = mapper.Map" + lt + entityName + ", " + entityName + "ViewModel" + gt + "(" + entityNameLocal + ");" + lb;
                manageEntityIndexCode += tab + tab + tab + entityNameLocal + "sViewModel.Add(" + entityNameLocal + "ViewModel);" + lb;
                manageEntityIndexCode += tab + tab + "}" + lb;
                manageEntityIndexCode += tab + tab + "return " + entityNameLocal + "sViewModel;" + lb;

            manageEntityIndexCode += tab + "}" + lb;
            manageEntityIndexCode += lb;

            return manageEntityIndexCode;
        }

        private string ManageEntityDetailsCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string entityNameShort = Char.ToLowerInvariant(entityName[0]).ToString();
            string manageEntityDetailsCode = null;

            manageEntityDetailsCode += tab + "public async Task" + lt + entityName + "ViewModel" + gt + "Get" + entityName + "(int id)" + lb;
            manageEntityDetailsCode += tab + "{" + lb;
            manageEntityDetailsCode += tab + tab + "var " + entityNameLocal + " = await db." + entityName + ";" + lb;
            manageEntityDetailsCode += tab + tab + tab + ".SingleOrDefaultAsync(" + entityNameShort + " => " + entityNameShort + ".ID == id);" + lb;
            manageEntityDetailsCode += tab + tab + entityName + "ViewModel " + entityNameLocal + "VM = mapper.Map" + lt + entityName + ", " + entityName + "ViewModel" + gt + "(" + entityNameLocal + ");" + lb;
            manageEntityDetailsCode += tab + tab + "return " + entityNameLocal + "VM;" + lb;
            manageEntityDetailsCode += tab + "}" + lb;
            manageEntityDetailsCode += lb;

            return manageEntityDetailsCode;
        }

        private string ManageEntityCreateCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string entityNameShort = Char.ToLowerInvariant(entityName[0]).ToString();
            string manageEntityCreateCode = null;


            manageEntityCreateCode += tab + "public async Task Create" + entityName + "(" + entityName + "ViewModel " + entityNameLocal + "VM)" + lb;
            manageEntityCreateCode += tab + "{" + lb;
            manageEntityCreateCode += tab + tab + entityName + " " + entityNameLocal + " = mapper.Map" + lt + entityName + "ViewModel, " + entityName + gt + "(" + entityNameLocal + "VM);" + lb;

            manageEntityCreateCode += tab + tab + "db." + entityName + ".Add(" + entityNameLocal + ");" + lb;
            manageEntityCreateCode += tab + tab + "await db.SaveChangesAsync();" + lb;

            manageEntityCreateCode += tab + tab + "return;" + lb;
            manageEntityCreateCode += tab + "}" + lb;
            manageEntityCreateCode += tab + lb;

            return manageEntityCreateCode;
        }

        private string ManageEntityUpdateCode(string entityName)
        {
            string entityNameLocal = Char.ToLowerInvariant(entityName[0]) + entityName.Substring(1);
            string entityNameShort = Char.ToLowerInvariant(entityName[0]).ToString();
            string manageEntityUpdateCode = null;

            manageEntityUpdateCode += tab + "public async Task Update" + entityName + "(" + entityName + "ViewModel " + entityNameLocal + "ViewModel)" + lb;
            manageEntityUpdateCode += tab + "{" + lb;
            manageEntityUpdateCode += tab + tab + "var " + entityNameLocal + " = mapper.Map" + lt + entityName + "ViewModel, " + entityName + gt + "(" + entityNameLocal + "ViewModel);" + lb;
            manageEntityUpdateCode += tab + tab + "db.Update(" + entityNameLocal + ");" + lb;
            manageEntityUpdateCode += tab + tab + "await db.SaveChangesAsync();" + lb;
            manageEntityUpdateCode += tab + "}" + lb;

            return manageEntityUpdateCode;
        }
    }
}
