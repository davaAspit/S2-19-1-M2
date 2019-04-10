using System;
using System.Linq;

namespace UnitTestExamples.BL
{
    public class Person
    {
        #region Fields
        private string name;
        private string cpr;
        #endregion

        

        public Person(string name, string cpr)
        {
            Name = name;
            Cpr = cpr;
            Console.WriteLine(ToString());
        }

        #region Properties
        public string Name
        {
            get { return name; }
            set
            {
                (bool isValid, string errMsg) = ValidateName(value);
                if (isValid)
                    name = value;
                else
                    throw new ArgumentException(errMsg, nameof(Name));
            }
        }

        public DateTime Birthday
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(cpr) && Cpr.Length >= 6)
                {
                    string datePartOfCprWithDash = $"{cpr[0]}{cpr[1]}-{cpr[2]}{cpr[3]}-{cpr[4]}{cpr[5]}";

                    if (DateTime.TryParse(datePartOfCprWithDash, out DateTime result))
                        return result;
                    else
                        throw new InvalidOperationException("Unable to extract birthday from CPR");
                }
                else
                    throw new InvalidOperationException("CPR is not yet saved");
                
            }
            
        }

       

        public string Cpr
        {
            get { return cpr; }
            set
            {
                (bool isValid, string errMsg) = ValidateCpr(value);
                if (isValid)
                    cpr = value;
                else
                    throw new ArgumentException(errMsg, nameof(Cpr));
            }
        }

        

        public bool IsWoman
        {
            get
            {
                if (int.TryParse(cpr, out int cprAsInt))
                {
                    if (cprAsInt % 2 == 0) //True when even
                        return true;
                    else
                        return false;
                }
                throw new InvalidOperationException("CPR is not yet saved");
            }
            
        }
        #endregion

        #region ValidationMethods
       
        public static (bool isValid, string errMsg) ValidateGender(bool value)
        {
            throw new NotImplementedException();
        }
        
        public static (bool isValid, string errMsg) ValidateCpr(string value)
        {
            string datePartOfCprWithDash = $"{value[0]}{value[1]}-{value[2]}{value[3]}-{value[4]}{value[5]}";

            if (!DateTime.TryParse(datePartOfCprWithDash, out DateTime result))
                return (false, "First six numbers are not a valid date");

            if (result.Date > DateTime.Today)
                return (false, "Birthday cannot be in the future");
            return (true, "");
        }
        public static (bool isValid, string errMsg) ValidateName(string value)
        {
            if (value is null)
                return (false, "Name is null");

            if (string.IsNullOrWhiteSpace(value))
                return (false, "Name only contains white spaces");

            if (value.Trim().Length < 2)
                return (false, "Name must be atleast two characters");

            if (!value.Contains(' '))
                return (false, "Name must consist of first and last name");

            return (true, "");
        }

        public int CompareTo(Person other)
        {
            if (other != null)
            {
                return DateTime.Compare(Birthday, other.Birthday);
            }
            else
                return 1;
        }
        #endregion

        public virtual string CreateIdentifier()
        {
            return Cpr;
        }

        public override string ToString()
        {
            return $"My name is: {Name}";
        }
    }
}
