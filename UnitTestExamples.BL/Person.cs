using System;
using System.Linq;

namespace UnitTestExamples.BL
{
public class Person
{
    private string firstName;
    public string FirstName
    {
        get { return firstName; }
        set
        {
            (bool isValid, string errMsg) = ValidateName(value);
            if (isValid)
                firstName = value;
            else
                throw new ArgumentException(errMsg, nameof(FirstName));
        }
    }
    public static (bool isValid, string errMsg) ValidateName(string name)
    {
        if (name is null)
            return (false, "Name is null");

        name = name.Trim();
        if (string.IsNullOrWhiteSpace(name))
            return (false, "Name only contains white spaces");

        if (name.Length < 2)
            return (false, "Name must be longer than two characters");

        return (true, "");
    }
}
}
