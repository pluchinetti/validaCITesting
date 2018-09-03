using System;
using Xunit;

namespace Person
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Person personCurrent = new Person("El clásico", "12345678");
            const bool expected = false;
            Assert.Equal(expected, personCurrent.ValidateId());
        }

        [Fact]
        public void Test2()
        {
            Person personCurrent = new Person("Personal Correcta", "47405029");
            const bool expected = true;
            Assert.Equal(expected, personCurrent.ValidateId());
        }

        [Fact]
        public void Test3()
        {
            Person personCurrent = new Person("Bomberman", "a");
            const bool expected = false;
            Assert.Equal(expected, personCurrent.ValidateId());
        }
        
        [Fact]
        public void Test4()
        {
            Person personCurrent = new Person("Guille Malo", "5.096.873-5");
            const bool expected = false;
            Assert.Equal(expected, personCurrent.ValidateId());
        }
        
        [Fact]
        public void Test5()
        {
            Person personCurrent = new Person("Guille Bueno", "50968735");
            const bool expected = true;
            Assert.Equal(expected, personCurrent.ValidateId());
        }

    }
}
