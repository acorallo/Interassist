using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository.Helpers;
 
namespace Entities.InterAsisst
{
    public abstract class PersistEntity : IRepositoryHelper
    {

        #region Miembros

        public static readonly Int32 NULL_ID = -1;

        public static Nullable<float> FloatConvet(object value)
        {
            Nullable<float> result = null;

            if (value.ToString() != string.Empty)
            {
                result = float.Parse(value.ToString());
            }

            return result;
        }

        public static int Int32Convert(object value)
        {
            int result = int.MaxValue;

            if (value.ToString() != string.Empty)
            {
                result = Int32.Parse(value.ToString());

            }

            return result;
        }

        public static Int32 NuleableInt(string value)
        {
            Int32 result = -1;

            if (value != string.Empty)
                result = Int32.Parse(value);

            return result;
        }

        #endregion Miembros

        #region Properties

        #endregion Properties

    }
}
