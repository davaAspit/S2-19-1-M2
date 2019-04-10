using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestExamples.BL
{
    public class Employee : Person
    {
        private string initials;

        public Employee(string initials, string name, string cpr) : base(name, cpr)
        {
            Initials = initials;
        }

        public string Initials { get => initials; set => initials = value; }

        public override string ToString()
        {
            return $"Watch out - I'm an employee named {Name}";
        }

        public override string CreateIdentifier()
        {
            return Initials;
        }
    }
}
