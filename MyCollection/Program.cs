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
        }
    }
}
