using Largon_Snack.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection.Metadata;

namespace Largon_Snack.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer(
                "William",
                "Vilela",
                "055701",
                "capuletos@live.com",
                "88899999",
                "Professor Alguma Coisa");

            System.Console.WriteLine(c);
        }
    }
}
