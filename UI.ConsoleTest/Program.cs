using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Cognitas.Framework.Repository;
using DAL.InterAssist;

namespace UI.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Inicio Programa.");


            DBRepository respository = DBRepository.GetDbRepository();
            TicketDS ticket = new TicketDS();

            DataTable dt = ticket.ObtenercasosMensuales(2015, 6, "715420/1");

            
            Console.WriteLine("Fin Programa.");
            Console.ReadLine();

        }
    }
}

