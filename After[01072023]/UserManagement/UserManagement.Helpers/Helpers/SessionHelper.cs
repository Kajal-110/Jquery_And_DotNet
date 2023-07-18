using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UserManagement.Helpers.Helpers
{
    public class SessionHelper
    {
        public static int Id
        {
            get
            {
                return HttpContext.Current.Session["Id"] != null ? (int)HttpContext.Current.Session["Id"] : 0;
            }
            set
            {
                HttpContext.Current.Session["Id"] = value;
            }
        }

        public static string Email
        {
            get
            {
                return HttpContext.Current.Session["Email"] != null ? (string)HttpContext.Current.Session["Email"] : null;
            }
            set
            {
                HttpContext.Current.Session["Email"] = value;
            }
        }

        public static string Firstname
        {
            get
            {
                return HttpContext.Current.Session["Firstname"] != null ? (string)HttpContext.Current.Session["Firstname"] : null;
            }
            set
            {
                HttpContext.Current.Session["Firstname"] = value;
            }
        }

        public static string Lastname
        {
            get
            {
                return HttpContext.Current.Session["Lastname"] != null ? (string)HttpContext.Current.Session["Lastname"] : null;
            }
            set
            {
                HttpContext.Current.Session["Lastname"] = value;
            }
        }

    }
}
