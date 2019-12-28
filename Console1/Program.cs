using System;

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



            try
            {
                int d5 = 0;
                int f = d5 / 0;
            }
            //catch (DivideByZeroException ex)
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Catch in Main : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finally in Main");
            }
        }
    }
}
