using System;
using System.Text;

namespace ConsoleCovariant
{
    class Person
    {
        public string Name { get; set; }
    }
    class Client : Person { }
    
    class Program
    {
        delegate Person PersonFactory(string name);
        delegate void ClientInfo(Client client);
        delegate void PersonInfo(Person person);

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //https://metanit.com/sharp/tutorial/3.28.php
            //Console.WriteLine("Hello World!");

            ClientInfo clientInfo = GetPersonInfo; // контравариантность
            Client client = new Client { Name = "Alice" };
            clientInfo(client);

            PersonInfo personInfo = GetPersonInfo;
            Person person = new Person { Name = "Person" };
            personInfo(person);
            Console.Read();
        }

        private static Client BuildClient(string name)
        {
            return new Client { Name = name };
        }

        private static void GetPersonInfo(Person p)
        {
            Console.WriteLine(p.Name);
        }
    }
}
