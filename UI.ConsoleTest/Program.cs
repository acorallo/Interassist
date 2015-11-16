using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognitas.Framework.Repository;
using DAL.InterAssist;

namespace UI.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Inicio Programa.");


            DBRepository respository = DBRepository.GetDbRepository(true);
            TicketDS ticket = new TicketDS();
            respository.BeginTransaction();

            ticket.Insert_Preveedor_Ticket(respository, 7612, 301, 7, "", "ObjectHash");

            
            respository.CommitTransaction();

            Console.WriteLine("Fin Programa.");
            Console.ReadLine();

        }
    }
}

