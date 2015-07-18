using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognitas.Framework.Repository;

namespace UI.InterAssist.Interfaces
{
    public interface IListable
    {
        Filter Filtro { get; set; }
        void CargarListado(Filter filtro);

    }
}
