using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCCodeGenerator.ModuleFolders
{
    public class ModuleFolderLocationRemapper : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            return viewLocations.MoveViewsIntoFeaturesFolder().CutomizeSharedWithUnderScore();
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // do nothing.. not entirely needed for this 
        }
    }

    public static class FeatureFolderExtensions
    {
        public static IEnumerable<string> CutomizeSharedWithUnderScore(this IEnumerable<string> viewLocations)
        {
            return viewLocations.Select(f => f.Replace("/Views/Shared/", "/Application/Modules/_Shared/"));
        }

        public static IEnumerable<string> MoveViewsIntoFeaturesFolder(this IEnumerable<string> viewLocations)
        {
            return viewLocations.Select(f => f.Replace("/Views/{1}", "/Application/Modules/{1}/Views"));
        }


    }
}