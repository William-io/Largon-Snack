using Largon_Snack.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Largon_Snack.Domain.StoreContext.Handlers;
using Largon_Snack.Test.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Largon_Snack.Test.Handler
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        /*Deve registrar cliente quando o comando é válido*/
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "William";
            command.LastName = "Vilela";
            command.Document = "28659170377";
            command.Email = "capuletos@live.com";
            command.Phone = "85988896969";

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailServices());

            var result = handler.Handle(command);
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
          
        }
    }
}