using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.InterAssistMVC.App_Code
{
    public class UISecurityManager
    {
        /// <summary>
        /// Return Whether the user is authenticated on the system
        /// </summary>
        /// <returns></returns>
        public static bool IsAuthenticated()
        {
            bool result = false;
            
            // Write the authentication routine.

            result = true;
            
            return result;
        }

        public static String GetUser()
        {
            string result = String.Empty;
            result = "Andres Corallo";
            return result;
        }
    }
}