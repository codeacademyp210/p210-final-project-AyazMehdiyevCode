﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _56_Xeber.Helpers
{
    public class Acsess : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["AdminAcsess"] == null || (bool)HttpContext.Current.Session["AdminAcsess"] == false)
            {
                filterContext.Result = new RedirectResult("~/Admin/Login");
            }

            base.OnActionExecuting(filterContext);
        }


            
    }
}