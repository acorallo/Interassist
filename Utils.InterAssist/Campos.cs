using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.InterAssist
{
    public class Campos
    {
        public string Campo = string.Empty;
        public string Valor = string.Empty;

        public Campos()
        {
        }

        public Campos(string campo, string valor)
        {
            this.Campo = campo;
            this.Valor = valor;
        }

    }
}
