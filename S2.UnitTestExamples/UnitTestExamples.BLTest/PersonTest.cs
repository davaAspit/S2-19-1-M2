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
            string correctName = "Daniel";

            //Act
            (bool isValid, string errMsg) = Person.ValidateName(correctName);

            //Assert
            Assert.True(isValid);
        }
        
        [Theory]
        [InlineData("Daniel")]
        [InlineData("Knud")]
        [InlineData("Ib")]
        [InlineData("Karl-Erik")]
        [InlineData("Lisbeth Iversen Jensen Karlsen")]
        public void ValidateName_CorrectValuesShouldReturnTrue(string name)
        {
            //Arrange
            //Act
            (bool isValid, string errMsg) = Person.ValidateName(name);

            //Assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("\n\n\n")]
        [InlineData("E")]
        public void ValidateName_WrongValuesShouldReturnFalse(string name)
        {
            //Arrange

            //Act
            (bool isValid, string errMsg) = Person.ValidateName(name);

            //Assert
            Assert.False(isValid);
        }
    }
}
