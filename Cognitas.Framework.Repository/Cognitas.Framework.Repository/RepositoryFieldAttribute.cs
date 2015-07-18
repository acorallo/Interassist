using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RepositoryFieldAttribute : Attribute
    {

        #region Members

        string _name = string.Empty;
        

        #endregion Members

        #region Constructors

        public RepositoryFieldAttribute(string name)
        {
            this._name = name;
        }

        public RepositoryFieldAttribute()
        {

        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        #endregion Constructors

    }
}
