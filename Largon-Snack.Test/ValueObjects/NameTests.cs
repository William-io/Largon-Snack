using Largon_Snack.Domain.StoreContext.Entities;
using Largon_Snack.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Largon_Snack.Test.ValueObjects
{
    [TestClass]
    public class NameTests
    {

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            var name = new Name("", "William");
            Assert.AreEqual(false, name.IsValid);
            Assert.AreEqual(1, name.Notifications.Count);
        }
    }
}