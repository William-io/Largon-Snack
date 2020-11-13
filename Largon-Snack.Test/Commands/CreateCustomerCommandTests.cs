using Largon_Snack.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Largon_Snack.Test.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "William";
            command.LastName = "Vilela";
            command.Document = "05570151460";
            command.Email = "capuletos@live.com";
            command.Phone = "5585988896969";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
