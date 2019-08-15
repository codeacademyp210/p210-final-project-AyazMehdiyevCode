﻿using _56_Xeber.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _56_Xeber.Controllers
{
    public class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string lang = null;

            HttpCookie languageCookie = Request.Cookies["culture"];
            if (languageCookie != null)
            {
                lang = languageCookie.Value;
            }
            else
            {
                string[] userLanguage = Request.UserLanguages;
                string userLang = userLanguage[0] != null ? userLanguage[0] : "";
                if (userLang != "")
                {
                    lang = userLang;
                }
                else
                {
                    lang = LanguageM.GetDefLanguage();
                }
            }
            new LanguageM().SetLanguage(lang);

            return base.BeginExecuteCore(callback, state);
        }
    }
}