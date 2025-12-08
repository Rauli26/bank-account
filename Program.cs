// See https://aka.ms/new-console-template for more information
using Classes;

var account = new BankAccount("<name>", 1000);
Console.WriteLine($"Account {account.AccountNumber} was created for {account.Owner} with {account.Balance} balance.");

account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine($"Account balance after withdrawal: {account.Balance}");
account.MakeDeposit(100, DateTime.Now, "friend paid me back");
Console.WriteLine($"Account balance after deposit: {account.Balance}");

//test initial balance must be positive 
try
{
    var invalidAccount = new BankAccount("<name>", -50);
}
catch (ArgumentOutOfRangeException e)
{

    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
}

// test for negative balance
try
{
    account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");

}
catch (InvalidOperationException e)
{

    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}
// Get Account history
Console.WriteLine("\nAccount history\n");
Console.WriteLine(account.GetAccountHistory());