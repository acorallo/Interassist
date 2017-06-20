using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterAssistMVC.Utils
{
    public class UISecurityManager
    {
        public static readonly string PROVIDER_CREATE_KEY = "IA.Provider.Create";
        public static readonly string PROVIDER_LIST_KEY = "IA.Provider.List";
        public static readonly string PROVIDER_MODIFY_KEY = "IA.Provider.Modify";

        public static readonly string CASE_CREATE_KEY = "IA.Case.Create";
        public static readonly string CASE_MODIFY_KEY = "IA.Case.Modify";
        public static readonly string CASE_CHANGE_STATUS_KEY = "IA.Case.ChangeStatus";


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

        /// <summary>
        /// Return user name logged into the application
        /// </summary>
        /// <returns></returns>
        public static String GetUser()
        {
            string result = String.Empty;
            result = "Andres Corallo";
            return result;
        }

        // EGV 22May2017 Inicio
        public static int GetOperador()
        {
            return 25;
        }
        // EGV 22May2017 Fin

        /// <summary>
        /// Verify whether the user has access to specific key
        /// </summary>
        /// <param name="SecurityKey"></param>
        /// <returns></returns>
        public static bool HasAccessTo(string SecurityKey)
        {
            bool result = true;
            if (SecurityKey == CASE_CHANGE_STATUS_KEY)
                result = true;
            return result;
        }
    }
}