using System;
using System.Collections.Generic;
using System.Text;

namespace MyCollection
{
    class Person
    {
        // простой класс, в котором хранятся данные о человеке
        private string firstName;

        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        // добавим свойства классу, потому что можем
        public string FirstName
        {
            get => firstName;
            set => firstName = value;
        }

        public string LastName
        {
            get => lastName;
            set => lastName = value;
        }

        public override string ToString()
        {
            return "First name:\t" + firstName + ",\tlast name:\t" + lastName;
        }
    }
}
