using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.InterAssist;
using Cognitas.Framework.Repository;

using Cognitas.Framework.Repository.Oracle;

namespace Test.InterAssist
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            TicketDS ticket = new TicketDS();
            DBRepository r = DBRepository.GetDbRepository(true);
            r.BeginTransaction();
            ticket.Insert_Preveedor_Ticket(r, 7612, 112, 8, "Esta es una prueba desde un test unitario", "Hash");
            
            

        }
    }
}
