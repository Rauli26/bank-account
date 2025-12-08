using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class BankAccount
    {
        /// <summary>
        /// s_accountNumberSeed - data member
        /// private - means it can only be accessed by the code inside BankAccount class.
        /// static - which means all BankAccount objects share the same single instance of this variable. 
        /// The s denoting static and _ denoting private field as per C# naming conventions. 
        /// </summary>
        private static int s_accountNumberSeed = 1234567890;
        /// <summary>
        /// Properties - Properties are data elements and can have code that enforce validation or other rules.
        /// </summary>
        public string AccountNumber { get; set; }
        public string Owner { get; set; }
        /// <summary>
        /// Balance will be sum of all the transaction.
        /// </summary>
        private decimal _balance;
        public decimal Balance
        {
            get
            {
                decimal _balance = 0;
                foreach (var item in _allTransactions)
                {
                    _balance += item.Amount;
                }

                return _balance;
            }
        }
        /// <summary>
        /// Methods - Methods are block of codes that perform a single function. 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="note"></param>


        // Constructor - A constructor is a member that has same name as the class. 
        // It's used to initialize objects of that class type.
        // Constructors are called when you create an object using new.
        public BankAccount(string name, decimal initialBalance) 
        {
            this.Owner = name;  // this qualifier is optional and usually omitted. The this qualifier is only required when a local variable or parameter has the same name as that field or property.
            AccountNumber = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        private List<Transaction> _allTransactions = new List<Transaction>();
        /// <summary>
        /// MakeDeposit method will add deposit amount to transaction 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="note"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0) { 
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
           
                var deposit = new Transaction(amount, date, note); 
                _allTransactions.Add(deposit);
        }
        /// <summary>
        /// MakeWithdrawal method will substract the amount withdrawn. 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="note"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void MakeWithdrawal(decimal amount, DateTime date, string note) 
        {
            if (amount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0) {
                throw new InvalidOperationException("Not sufficient fund for this withdrawal");
            }
        
                var withdrawal = new Transaction(-amount, date, note);
                _allTransactions.Add(withdrawal);
        }

        /// <summary>
        /// GetAccountHistory method will provide transaction history. 
        /// </summary>
        /// <returns></returns>
        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            decimal balance = 0;
            report.Append("Date\t\t\tAmount\tBalance\tNote\n");
            foreach (var item in _allTransactions) {
                balance += item.Amount;
                report.Append($"{item.Date}\t{item.Amount}\t{balance}\t{item.Notes}\n");
            }
            return report.ToString();
        }
    }
}
