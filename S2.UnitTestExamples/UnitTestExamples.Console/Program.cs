using System;
using System.Collections.Generic;
using UnitTestExamples.BL;

namespace UnitTestExamples.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person("Dani K", "0101010101"),
                new Employee("ALSU", "Alberte Sund", "0102010222"),
                new Student("karl9041", "Karl Iversen", "0102010221"),
                new Person("Kenneth Sund", "0102010229")
            };

            int numberOfEmployees = 0;
            int numberOfStudents = 0;

            foreach (Person person in people)
            {
                switch (person)
                {
                    case Employee e:
                        numberOfEmployees++;
                        break;
                    case Student s:
                        numberOfStudents++;
                        break;
                    default:
                        break;
                }
            }

            //List<int> numbers = new List<int>()
            //{
            //    3,5,1,23,6,12
            //};
            //Console.WriteLine("Unsorted");
            //foreach (int number in numbers)
            //    Console.WriteLine(number);

            //Console.WriteLine("Sorted");
            //numbers.Sort();
            //foreach (int number in numbers)
            //    Console.WriteLine(number);


            //Person p = new Person()
            //{
            //    Name = "Knud Erik",
            //    Cpr = "0311891515"
            //};

            //Employee e = new Employee()
            //{
            //    Name = "Daniel Valsby-Koch",
            //    Cpr = "3009661575",
            //    Initials = "DAVA"
            //};

            //Student s = new Student()
            //{
            //    Name = "Niklasine Pontoppidan",
            //    Cpr = "1907667544",
            //    Unilogin = "nikl5432"
            //};

            //List<Person> persons = new List<Person>()
            //{
            //    e,s,p
            //};

            //foreach (Person currentPerson in persons)
            //{
            //    Console.WriteLine(currentPerson.CreateIdentifier());
            //}

            //Person p2 = new Person();
            //Person p3 = new Person("Knud Erik", "0404041234");
            //Employee e2 = new Employee()

        }
    }
}
