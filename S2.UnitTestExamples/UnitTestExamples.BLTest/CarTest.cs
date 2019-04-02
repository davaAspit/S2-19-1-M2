using System;
using System.Collections.Generic;
using System.Text;
using UnitTestExamples.BL;
using Xunit;

namespace UnitTestExamples.BLTest
{
    public class CarTest
    {
        [Fact]
        public void PriceTag_ValidValueShouldSaveWithoutChange()
        {
            //Arrange
            decimal validPriceTag = 500;
            Car c = new Car();

            //Act
            c.PriceTag = validPriceTag;
            decimal actualPriceTag = c.PriceTag;

            //Assert
            Assert.Equal(validPriceTag, actualPriceTag);
        }

        [Fact]
        public void PriceTag_InvalidValueShouldCastException()
        {
            //Arrange
            decimal validPriceTag = -500;
            Car c = new Car();

            //Assert
            Assert.Throws<ArgumentException>( () => c.PriceTag = validPriceTag);
            
        }

        [Fact]
        public void ValidatePriceTag_ValidValueShouldReturnTrue()
        {
            //Arrange
            decimal validPriceTag = 2000;

            //Act
            (bool isValid, string errMsg) = Car.ValidatePriceTag(validPriceTag);

            //Assert
            Assert.True(isValid, $"A priceTag of {validPriceTag} should be valid");
        }

        [Fact]
        public void ValidatePriceTag_InvalidValueShouldReturnFalse()
        {
            //Arrange
            decimal invalidPriceTag = -2000;

            //Act
            (bool isValid, string errMsg) = Car.ValidatePriceTag(invalidPriceTag);

            //Assert
            Assert.False(isValid, $"A priceTag of {invalidPriceTag} should be valid");
        }

        [Theory]
        [InlineData(-2000)]
        [InlineData(-0.1)]
        [InlineData(-1209201901)]
        public void ValidatePriceTag_InvalidValuesShouldReturnFalse(decimal invalidPriceTag)
        {
            //Act
            (bool isValid, string errMsg) = Car.ValidatePriceTag(invalidPriceTag);

            //Assert
            Assert.False(isValid, $"A priceTag of {invalidPriceTag} should be valid");
        }


    }
}
