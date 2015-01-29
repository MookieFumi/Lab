using System;
using NUnit.Framework;

namespace lab.app
{
    class Kata
    {
        public bool IsHappyNumber(int number)
        {
            const int HAPPY_RESULT = 1;
            const double POW_EXPONENT = 2D;
            const int MAX_LOOPS = 20;

            var chars = number.ToString();
            var total = 0;
            var loops = 0;

            while (number != HAPPY_RESULT && loops <= MAX_LOOPS)
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    total += (int)Math.Pow(double.Parse(chars[i].ToString()), POW_EXPONENT);
                }
                number = total;
                loops++;
            }

            return number == HAPPY_RESULT;
        }
    }

    class KataTest
    {
        [Test]
        public void When_number_is_one_number_is_happy()
        {
            //Arrange
            var sut = new Kata();
            var happyNumber = 1;

            //Act
            var isHappy = sut.IsHappyNumber(happyNumber);

            //Assert
            Assert.True(isHappy);
        }

        [Test]
        public void When_number_is_two_number_is_not_happy()
        {
            //Arrange
            var sut = new Kata();
            var happyNumber = 2;

            //Act
            var isHappy = sut.IsHappyNumber(happyNumber);

            //Assert
            Assert.False(isHappy);
        }

        [Test]
        public void When_number_is_ten_number_is_happy()
        {
            //Arrange
            var sut = new Kata();
            var happyNumber = 10;

            //Act
            var isHappy = sut.IsHappyNumber(happyNumber);

            //Assert
            Assert.True(isHappy);
        }

        [Test]
        public void When_number_is_one_hundrer_number_is_happy()
        {
            //Arrange
            var sut = new Kata();
            var happyNumber = 100;

            //Act
            var isHappy = sut.IsHappyNumber(happyNumber);

            //Assert
            Assert.True(isHappy);
        }
    }
}
