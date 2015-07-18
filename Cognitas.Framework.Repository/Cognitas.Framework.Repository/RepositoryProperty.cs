using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Cognitas.Framework.Repository
{
    public class RepositoryProperty
    {

        #region Members

        private string _name;
        private PropertyInfo _propertyInfo;

        #endregion Members

        #region Constructors

        private RepositoryProperty()
        {
        }

        public RepositoryProperty(PropertyInfo property, string name)
        {
            this._propertyInfo = property;
            this._name = name;
        }

        #endregion Constructors

        #region Properties

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public PropertyInfo PropertyInfo
        {
            get
            {
                return this._propertyInfo;
            }
        }

        #endregion Properties

    }
}
