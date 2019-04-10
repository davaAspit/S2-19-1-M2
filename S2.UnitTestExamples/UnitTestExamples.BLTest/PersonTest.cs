using System;
using System.Collections.Generic;
using UnitTestExamples.BL;
using Xunit;

namespace UnitTestExamples.BLTest
{
    public class PersonTest
    {
        [Fact]
        public void CompareTo_SortList()
        {
            Person p1 = new Person()
            {
                Cpr = "0311891234",
                Name = "Daniel Valsby-Koch"
            };
            Person p2 = new Person()
            {
                Cpr = "0211891234",
                Name = "Anders Jensen"
            };
            Person p3 = new Person()
            {
                Cpr = "0411891234",
                Name = "Erik Gren"
            };
            List<Person> persons = new List<Person>()
            {
                p1,
                p2,
                p3
            };

            persons.Sort();

            Assert.Equal(p2, persons[0]);
        }
        [Fact]
        public void ValidateName_CorrectValueShouldReturnTrue()
        {
            //Arrange
            string correctName = "Daniel Jensen";
            //Act
            (bool isValid, string errMsg) = Person.ValidateName(correctName);
            //Assert
            Assert.True(isValid, $"{correctName} should be valid");
        }

        [Theory]
        [InlineData("Daniel Koch")]
        [InlineData("Knud Hansen")]
        [InlineData("Ib Rene Cairo")]
        [InlineData("Karl-Erik Jes")]
        [InlineData("Lisbeth Iversen Jensen Karlsen")]
        public void ValidateName_CorrectValuesShouldReturnTrue(string name)
        {
            //Act
            (bool isValid, string errMsg) = Person.ValidateName(name);
            //Assert
            Assert.True(isValid, $"{name} should be valid");
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("\n\n\n")]
        [InlineData("E")]
        [InlineData("daniel")]
        public void ValidateName_WrongValuesShouldReturnFalse(string name)
        {
            //Arrange

            //Act
            (bool isValid, string errMsg) = Person.ValidateName(name);

            //Assert
            Assert.False(isValid);
        }

        [Fact]
        public void NameSet_WrongValuesShouldCastException()
        {
            //Arrange
            string invalidName = "";
            Person p = new Person();

            //Act
            Assert.Throws<ArgumentException>(() => p.Name = invalidName);
        }

        [Theory]
        [InlineData("daniel vaLsby-koch")]
        [InlineData("Ea Trea")]
        [InlineData("Jens Larsen")]
        public void SetName_ValidValuesShouldNotBeChanged(string inputName)
        {
            //Arrange
            Person p = new Person();

            //Act
            p.Name = inputName;
            string actualName = p.Name;

            //Assert
            Assert.Equal(inputName, actualName);
        }

    }
}
