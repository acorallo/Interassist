using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterAssistMVC;
using InterAssistMVC.Utils;

namespace InterAssistMVC.Controllers
{
    public class IAController : Controller
    {

        #region Constants

        public static readonly string ACCESS_DENY_VIEW = "~/Views/Shared/AccessDeny.cshtml";

        
        // QueryString Contants
        public static readonly string PARAM_EXTRA_SEARCH = "paramWideSearch";


        #endregion Constants

        protected string PARAM_WIDE_SEARCH
        {
            get
            {
                string result = string.Empty;


                result = this.Request.QueryString[PARAM_EXTRA_SEARCH];

                return result; 
            }
        }


        #region Methods
        #endregion Methods


    }
}