using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Cognitas.Framework.Repository.Interfaces;

namespace Cognitas.Framework.Repository.Helpers
{
    public abstract class DALBase
    {
        public virtual int Persist(IRepository repositoryObj)
        {
            int result = -1;

            return result;
        }

        public abstract DataSet GetById(int id);
       

    }
}
