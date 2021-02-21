using System.Web;
using System.Web.Mvc;

namespace Joachim_Johnson_ConsidAplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
