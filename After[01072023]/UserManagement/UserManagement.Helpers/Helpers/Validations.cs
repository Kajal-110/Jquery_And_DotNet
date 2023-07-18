using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UserManagement.Helpers.Helpers
{
    public class Validations : ActionFilterAttribute
    {
       
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(SessionHelper.Email == null)
            {
                filterContext.Result = new RedirectResult("~/User/SignIn");
            }
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }
}
