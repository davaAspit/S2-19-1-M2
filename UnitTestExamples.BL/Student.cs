using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestExamples.BL
{
    public class Student : Person
    {
        private string unilogin;

        public Student(string unilogin, string name, string cpr) : base(name, cpr)
        {
            Unilogin = unilogin;
        }

        public string Unilogin { get => unilogin; set => unilogin = value; }
    }
}
