using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestExamples.BL
{
    public class Car
    {
        private string make;

        public string Make
        {
            get { return make; }
            set
            {
                (bool isValid, string errMsg) = ValidateMake(value);
                if (isValid)
                {
                    make = value;
                }
                else
                {
                    throw new ArgumentException(errMsg);
                }
            }
        }

        /// <summary>
        /// Validates the input. Cannot be null, must start with capital letter
        /// and must be more than or equal to three characters.
        /// </summary>
        /// <param name="make"></param>
        /// <returns></returns>
        public static (bool isValid, string errMsg) ValidateMake(string make)
        {
            if (make is null)
            {
                return (false, "Make is null");
            }

            if (make.Length < 3)
            {
                return (false, $"Make is only {make.Length} characters long. Must be more than 2");
            }

            if (char.IsLower(make[0]))
            {
                return (false, "The first letter is lowercase. Must be uppercase");
            }

            return (true, "");
        }
    }
}
