using System;

namespace MyCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ээээкспиременты!!!
            MyList<Person> people = new MyList<Person>();
            people.Add(new Person("Maxim", "Shchukin"));
            people.Add(new Person("Nikita", "Shchukin"));
            people.Add(new Person("Vasiliy", "Pupkin"));
            people.Add(new Person("Aleshka", "Grabovod"));
            // тест ToString
            Console.WriteLine(people.ToString());
            // тест foreach
            foreach(var person in people)
            {
                Console.WriteLine("Hello " + person.FirstName + "!");
            }

            // тест Remove
            Console.WriteLine("__________Test 1__________");
            people.Remove(new Person("Vasiliy", "Pupkin"));
            Console.WriteLine(people.ToString());
            Console.WriteLine("__________Test 2__________");
            people.Remove(new Person("Maxim", "Shchukin"));
            Console.WriteLine(people.ToString());
            Console.WriteLine("__________Test 3__________");
            people.Remove(new Person("Aleshka", "Grabovod"));
            Console.WriteLine(people.ToString());
            Console.WriteLine("__________Test 4__________");
            people.Remove(new Person("Nikita", "Shchukin"));
            Console.WriteLine(people.ToString());
            Console.WriteLine("Count is: " + people.Count);
        }
    }
}
