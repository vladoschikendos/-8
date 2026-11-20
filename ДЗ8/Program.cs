using System;
using System.Collections;
using System.Collections.Generic;  
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ДЗ8
{
    public class BankTransaction
    {
        private readonly DateTime dt;
        private readonly decimal am;
        public DateTime Dt
        {
            get { return dt; }
        }

        public decimal Am
        {
            get { return am; }
        }
        public BankTransaction(decimal amount)
        {
            dt = DateTime.Now;
            am = amount;
        }
        public override string ToString()
        {
            return $"{dt}:{am}";
        }
    }
    public class BankAccount
    {
        private decimal b;
        private Queue q;
        public BankAccount(decimal initialBalance)
        {
            b = initialBalance;
            q = new Queue();
        }
        public decimal Balance
        {
            get { return b;}
        }
        public void Deposite(decimal amount)
        {
            b += amount;
            BankTransaction t = new BankTransaction(amount);
            q.Enqueue(t);
        }
        public void Withdraw(decimal amount)
        {
            if (amount > b)
            {
                Console.WriteLine("Недостаточно средств!");
                return;
            }

            b -= amount;
            BankTransaction t = new BankTransaction(-amount);
            q.Enqueue(t);
        }
        public void PrintTransactions()
        {
            Console.WriteLine("---Транзакция в очередь---");
            foreach (BankTransaction t in q)
            {
                Console.WriteLine(t.ToString());
            }
        }
    }
        internal class Program
        {
        static void Main(string[] args)
        {
            BankAccount a = new BankAccount(1000);
            a.Deposite(500);
            a.Withdraw(300);
            Console.WriteLine($"Баланс:{a.Balance}");
            a.PrintTransactions();
        }
    }
}
