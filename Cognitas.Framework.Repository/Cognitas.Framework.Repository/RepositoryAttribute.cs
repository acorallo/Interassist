using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.Repository
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RepositoryAttribute : System.Attribute
    {

        private string _name = string.Empty; 
            
        public RepositoryAttribute()
        {
        }

        public RepositoryAttribute(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }
    }
}
