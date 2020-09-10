using System;
using Xunit;

namespace NetCore.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ///AAA
            PlayerCharacter test = new PlayerCharacter(); // Arrange
            
            test.FirstName = "Test"; // Act

            Assert.Equal("Test1", test.FirstName); // Assert

          //  Assert.

            //add new 

            // new name added
        }

    }
}
