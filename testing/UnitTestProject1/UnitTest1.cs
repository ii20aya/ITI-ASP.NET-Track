using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    


    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Constructor_WithValidBalance_ShouldSetBalance()
        {
            var account = new BankAccount("Aya", 100.0);

            Assert.AreEqual(100.0, account.Balance);
        }
    }

}
