using System;

namespace Vladmainproject
{
    class BankAccount
    {
        public string Owner;
        public decimal Balance;
        public string AccountType;
        public int Number;

        private static int _counter = 0;

        private void GenerateAccountNumber()
        {
            _counter++;
            Number = _counter;
        }

        public BankAccount()
        {
            Owner = "Неизвестно";
            Balance = 0;
            AccountType = "обычный";
            GenerateAccountNumber();
        }

        public BankAccount(decimal balance)
        {
            Owner = "Неизвестно";
            Balance = balance;
            AccountType = "обычный";
            GenerateAccountNumber();
        }

        public BankAccount(string accountType)
        {
            Owner = "Неизвестно";
            Balance = 0;
            AccountType = accountType;
            GenerateAccountNumber();
        }

        public BankAccount(decimal balance, string accountType)
        {
            Owner = "Неизвестно";
            Balance = balance;
            AccountType = accountType;
            GenerateAccountNumber();
        }

        public void Transfer(BankAccount from, decimal sum)
        {
            if (from.Balance < sum)
            {
                Console.WriteLine($"Недостаточно средств на счёте {from.Owner}");
                return;
            }
            from.Balance -= sum;
            this.Balance += sum;
            Console.WriteLine($"Переведено {sum} от {from.Owner} к {this.Owner}");
        }

        public override string ToString()
        {
            return $"Счёт №{Number}: {Owner}, баланс: {Balance}, тип: {AccountType}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== УПРАЖНЕНИЕ 9.1 =====");

            BankAccount a = new BankAccount();
            BankAccount b = new BankAccount(1000);
            BankAccount c = new BankAccount("сберегательный");
            BankAccount d = new BankAccount(5000, "кредитный");

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);

            Console.WriteLine("\nПеревод 300 с b на d:");
            d.Transfer(b, 300);

            Console.WriteLine("\nПосле перевода:");
            Console.WriteLine(b);
            Console.WriteLine(d);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}