using System;
using System.Text;

namespace Console1
{
    class Person
    {
        public string Name { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Person person = new Person { Name = "Tom" };
            Console.WriteLine(person.GetType());    // Person

            Type t = person.GetType();
            //https://stackoverflow.com/questions/752/how-to-create-a-new-object-instance-from-a-type
            Person person2 = (Person)Activator.CreateInstance(t);
            Console.WriteLine(person2.GetType());    // Person

            //https://metanit.com/sharp/tutorial/2.1.php

            int d = 6;
            Console.WriteLine($"Hello World! d={d}");

            var hello = "Hell to World";
            var c = 20;
            Console.WriteLine(c.GetType().ToString());
            Console.WriteLine(hello.GetType().ToString());


            //https://metanit.com/sharp/tutorial/2.24.php 
            int a = 4;
            int b = 1;
            //4 = 100 | 001 = 5 (101)
            int k = a | b;
            Console.WriteLine($"k={k}");



            // создаем банковский счет
            Account account = new Account(200);
            // Добавляем в делегат ссылку на метод Show_Message
            // а сам делегат передается в качестве параметра метода RegisterHandler
            account.RegisterHandler(new Account.AccountStateHandler(Show_Message));
            //THE SAME
            //account.RegisterHandler(Show_Message);

            // Два раза подряд пытаемся снять деньги
            account.Withdraw(100);
            account.Withdraw(150);
            Console.ReadLine();
        }

        private static void Show_Message(String message)
        {
            Console.WriteLine(message);
        }
    }

    class Account
    {
        // Объявляем делегат
        public delegate void AccountStateHandler(string message);
        // Создаем переменную делегата
        AccountStateHandler _del;

        // Регистрируем делегат
        public void RegisterHandler(AccountStateHandler del)
        {
            _del = del;
        }

        int _sum; // Переменная для хранения суммы

        public Account(int sum)
        {
            _sum = sum;
        }

        public int CurrentSum
        {
            get { return _sum; }
        }

        public void Put(int sum)
        {
            _sum += sum;
        }

        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;

                if (_del != null)
                    _del($"Сумма {sum} снята со счета");
            }
            else
            {
                if (_del != null)
                    _del("Недостаточно денег на счете");
            }
        }
    }
}
