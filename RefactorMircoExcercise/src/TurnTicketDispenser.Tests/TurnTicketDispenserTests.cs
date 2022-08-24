using NUnit.Framework;

namespace TDDMicroExercises.TurnTicketDispenser.Tests {
    public class TurnTicketDispenserTests {
        [Test]
        public void TurnTicketInicialTest()
        {
            var ticketDispenser = new TicketDispenser();

            var getTurnTicket = ticketDispenser.GetTurnTicket();

            Assert.NotZero(getTurnTicket.TurnNumber);
        }

        [Test]
        public void TurnTicketDifferentDispenserTest()
        {
            var ticketDispenser = new TicketDispenser();
            var getTurnTicket = ticketDispenser.GetTurnTicket();

            Assert.AreNotEqual(getTurnTicket.TurnNumber, getTurnTicket.TurnNumber);
            Assert.AreNotEqual(getTurnTicket.TurnNumber, getTurnTicket.TurnNumber);
            Assert.AreNotEqual(getTurnTicket.TurnNumber, getTurnTicket.TurnNumber);
            Assert.AreNotEqual(getTurnTicket.TurnNumber, getTurnTicket.TurnNumber);
        }
    }
}
