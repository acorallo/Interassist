﻿using System;
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

        /// <summary>
        /// Verify whether the user has access to specific key
        /// </summary>
        /// <param name="SecurityKey"></param>
        /// <returns></returns>
        public static bool HasAccessTo(string SecurityKey)
        {
            bool result = true;
            return result;
        }
    }
}