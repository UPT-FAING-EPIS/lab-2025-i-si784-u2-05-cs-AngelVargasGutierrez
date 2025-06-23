using Bank.Domain;
using System;
using Xunit;

namespace Bank.Domain.Tests;
public class BankAccountTests
{
    [Theory]
    [InlineData(11.99, 4.55, 7.44)]
    [InlineData(12.3, 5.2, 7.1)]
    public void MultiDebit_WithValidAmount_UpdatesBalance(
        double beginningBalance, double debitAmount, double expected )
    {
        // Arrange
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
        // Act
        account.Debit(debitAmount);
        // Assert
        double actual = account.Balance;
        Assert.Equal(Math.Round(expected,2), Math.Round(actual,2));
    }

    [Fact]
    public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
    {
        // Arrange
        double beginningBalance = 11.99;
        double debitAmount = -100.00;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
        // Act and assert
        Assert.Throws<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
    }

    [Fact]
    public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
    {
        // Arrange
        double beginningBalance = 11.99;
        double debitAmount = 20.0;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
        // Act
        try
        {
            account.Debit(debitAmount);
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            // Assert
            Assert.Contains(BankAccount.DebitAmountExceedsBalanceMessage, e.Message);
        }
    }

    [Fact]
    public void Credit_WithValidAmount_UpdatesBalance()
    {
        // Arrange
        double beginningBalance = 10.0;
        double creditAmount = 5.0;
        BankAccount account = new BankAccount("Cliente", beginningBalance);
        // Act
        account.Credit(creditAmount);
        // Assert
        Assert.Equal(15.0, account.Balance);
    }

    [Fact]
    public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
    {
        // Arrange
        double beginningBalance = 10.0;
        double creditAmount = -1.0;
        BankAccount account = new BankAccount("Cliente", beginningBalance);
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
    }

    [Fact]
    public void CustomerName_ReturnsCorrectName()
    {
        // Arrange
        string name = "Cliente Prueba";
        BankAccount account = new BankAccount(name, 0);
        // Act & Assert
        Assert.Equal(name, account.CustomerName);
    }

    [Fact]
    public void Balance_ReturnsCorrectBalance()
    {
        // Arrange
        double balance = 123.45;
        BankAccount account = new BankAccount("Cliente", balance);
        // Act & Assert
        Assert.Equal(balance, account.Balance);
    }

    [Fact]
    public void Debit_WithZeroAmount_UpdatesBalance()
    {
        // Arrange
        double beginningBalance = 10.0;
        double debitAmount = 0.0;
        BankAccount account = new BankAccount("Cliente", beginningBalance);
        // Act
        account.Debit(debitAmount);
        // Assert
        Assert.Equal(10.0, account.Balance);
    }
} 