using System;
using UnitTestExamples.BL;
using Xunit;

namespace UnitTestExamples.BLTest
{
    public class PersonTest
    {
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
        [Fact]
        public void NameSet_ValidValuesShouldBeSaved()
        {
            //Arrange
            string validName = "Daniel Koch";
            Person p = new Person();

            //Act
            p.Name = validName;
            string actualName = p.Name;

            //Assert
            Assert.Equal(validName, actualName);
        }
        //[Fact]
        //public void BirthdaySet_InvalidValuesShouldCastException()
        //{
        //    //Arrange
        //    DateTime invalidBirthday = DateTime.Today.AddDays(1);
        //    Person p = new Person();

        //    //Act
        //    Assert.Throws<ArgumentException>(() => p.Birthday = invalidBirthday);
            
        //    //Assert

        //}
    }
}
