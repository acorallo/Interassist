using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognitas.Framework.UserInterface
{
    public interface ICrmPage
    {
        int EntityID { set;  get; }
        bool IsNew { get; }
        string ObjectHash { set; get; }
    }
}
