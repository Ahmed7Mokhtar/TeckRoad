using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TeckRoad.Entities.Interfaces;

namespace TeckRoad.Presentation.Extensions
{
    public static class ConvertExtensions
    {
        public static List<SelectListItem> ConvertToSelectList<T>(this IEnumerable<T> collection, 
                                        int selectedValue) where T : IPrimaryProperties
        {
            return collection.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id.ToString(),
                Selected = (x.Id == selectedValue)
            }).ToList();
        }
    }
}
