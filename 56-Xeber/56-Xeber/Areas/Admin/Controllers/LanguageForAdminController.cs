using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using _56_Xeber.Class;

namespace _56_Xeber.Areas.Admin.Controllers
{
    public class LanguageForAdminController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string lang = LanguageM.GetDefLanguage();
            CultureInfo culture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture.Name);

            return base.BeginExecuteCore(callback, state);

        }
    }
}