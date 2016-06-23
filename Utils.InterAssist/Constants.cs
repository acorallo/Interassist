using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.InterAssist
{
    public class Constants
    {


        public static bool IsNewPrefix(string ID)
        {
            bool result = false;

            result = ID.IndexOf(CONST_NEW_PREFIX) == 0;

            return result;
        }


        public const string CONST_NEW_PREFIX = "Prex_";

        public enum PersistOperationType
        {   
            Persist,
            Delete,
            Void
        }

    }
}
