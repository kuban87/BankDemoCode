namespace Bank.UnitTests
{
    public class BankAccountTests
    {
        private BankAccount bankAccount;

        [SetUp]
        public void Setup()
        {
            bankAccount = new BankAccount(2000);
        }

        [Test]
        [Category("High")]
        public void Test_CreateNewBankAccount()
        {
            var expectedAmount = 2000;
            Assert.That(bankAccount.Amount, Is.EqualTo(expectedAmount), "Bank account should be equal to 1000");
        }

        [Test]
        [Category("High")]
        public void Test_CanDepositPositiveAmount()
        {
            // Act
            bankAccount.Deposit(500);

            // Assert
            Assert.That(bankAccount.Amount, Is.EqualTo(2500), "Bank account deposit");
        }

        [Test]
        [Category("Low")]
        public void Test_CannotCreateAccountWithNegativeAmount()
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(-1000));
        }

        [Test]
        public void Test_CannotDepositNegativeAmount()
        {
            Assert.Throws<ArgumentException>(() => bankAccount.Deposit(-1000));
        }

        [Test]
        public void Test_CanWithdrawAmount()
        {
            bankAccount.Withdraw(500);
            Assert.That(bankAccount.Amount, Is.EqualTo(1475), "Bank account withdraw");
        }

        [Test]
        [Category("Critical")]
        public void Test_CannotWithdrawMoreThanBalance()
        {
            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(3000),
                "Withdrawal should fail if the amount exceeds the balance.");
        }

     


    }
}
