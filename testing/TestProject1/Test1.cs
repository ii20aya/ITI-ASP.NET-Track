using BankAccountNS;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        //1
        [TestMethod]

        public void Constructor_ValidBalance_100()
        {
            // Arrange
            var acc = new BankAccount("aya", 100);

            // Act
            double result = acc.Balance;

            // Assert
            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void Constructor_ZeroBalance()
        {
            // Arrange
            BankAccount acc = new BankAccount("aya", 0);

            // Act
            double result = acc.Balance;

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_NegativeBalance_ShouldThrow()
        {
            // Arrange + Act + Assert
          
                BankAccount acc = new BankAccount("aya", -50);
           
        }


        //2

        [TestMethod]
        public void Deposit_PositiveAmount_50()
        {
            // Arrange
            BankAccount acc = new BankAccount("aya", 100);

            // Act
            acc.Deposit(50);

            // Assert
            Assert.AreEqual(150, acc.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Deposit_Negative_ShouldThrow()
        {
            // Arrange
            BankAccount acc = new BankAccount("aya", 100);

            // Act + Assert
           
                acc.Deposit(-10);
           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Deposit_Zero_ShouldThrow()
        {
            // Arrange
            BankAccount acc = new BankAccount("aya", 100);

            // Act + Assert
           
                acc.Deposit(0);
        
        }



        //3


        [TestMethod]
        public void Withdrawal_ValidAmount()
        {
            // Arrange
            BankAccount acc = new BankAccount("aya", 100);

            // Act
            acc.Withdrawal(50);

            // Assert
            Assert.AreEqual(50, acc.Balance);
        }



        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Withdrawal_MoreThanBalance_ShouldThrow()
        {
            // Arrange
            BankAccount acc = new BankAccount("aya", 100);

            // Act + Assert
           
                acc.Withdrawal(200);
          
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Withdrawal_Negative_ShouldThrow()
        {
            // Arrange
            BankAccount acc = new BankAccount("aya", 100);

            // Act + Assert
           
                acc.Withdrawal(-10);
           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Withdrawal_Zero_ShouldThrow()
        {
            // Arrange
            BankAccount acc = new BankAccount("aya", 100);

            // Act + Assert
          
                acc.Withdrawal(0);
          
        }

        //4


        [TestMethod]
        public void Transfer_ValidAmount()
        {
            // Arrange
            BankAccount acc1 = new BankAccount("aya", 100);
            BankAccount acc2 = new BankAccount("ahmed", 50);

            // Act
            acc1.Transfer(30, acc1, acc2);

            // Assert
            Assert.AreEqual(70, acc1.Balance);
            Assert.AreEqual(80, acc2.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Transfer_MoreThanBalance_ShouldThrow()
        {
            // Arrange
            BankAccount acc1 = new BankAccount("aya", 100);
            BankAccount acc2 = new BankAccount("ahmed", 50);


            // Act + Assert
           
                acc1.Transfer(200, acc1, acc2);
          
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Transfer_Negative_ShouldThrow()
        {
            // Arrange
            BankAccount acc1 = new BankAccount("aya", 100);
            BankAccount acc2 = new BankAccount("ahmed", 50);

            // Act + Assert
           
                acc1.Transfer(-10, acc1, acc2);
          
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Transfer_Zero_ShouldThrow()
        {
            // Arrange
            BankAccount acc1 = new BankAccount("aya", 100);
            BankAccount acc2 = new BankAccount("ahmed", 50);

            // Act + Assert
           
                acc1.Transfer(0, acc1, acc2);
          
        }
    }
}