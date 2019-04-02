using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestExamples.BL
{
    public class Car
    {
        private string make;
        private decimal priceTag;

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
                    throw new ArgumentException(errMsg, nameof(Make));
                }
            }
        }

        public decimal PriceTag
        {
            get => priceTag;
            set
            {
                (bool isValid, string errMsg) = ValidatePriceTag(value);
                if (isValid)
                {
                    priceTag = value;
                }
                else
                {
                    throw new ArgumentException(errMsg, nameof(PriceTag));
                }
            }
        }

        /// <summary>
        /// Validates the input. Cannot be negative.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static (bool isValid, string errMsg) ValidatePriceTag(decimal value)
        {
            if (value < 0)
                return (false, "PriceTag cannot be negative");

            return (true, "");
        }

        /// <summary>
        /// Validates the input. Cannot be null, must start with capital letter
        /// and must be more than or equal to three characters.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static (bool isValid, string errMsg) ValidateMake(string value)
        {
            if (value is null)
            {
                return (false, "Make is null");
            }

            if (value.Length < 3)
            {
                return (false, $"Make is only {value.Length} characters long. Must be more than 2");
            }

            if (char.IsLower(value[0]))
            {
                return (false, "The first letter is lowercase. Must be uppercase");
            }

            return (true, "");
        }
    }
}
