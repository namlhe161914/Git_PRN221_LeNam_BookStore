using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class SessionFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.HttpContext.Session.GetString("account") != null)
        {
            context.Result = new RedirectResult("~/");
        }
        else if (context.HttpContext.Session.GetString("account2") == null)
        {
            context.Result = new RedirectResult("~/Login");
        }

        base.OnActionExecuting(context);
    }
}
