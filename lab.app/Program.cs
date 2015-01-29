using System;
using lab.crosscutting;
using lab.crosscutting.Enums;
using lab.entities;
using lab.services;
using NUnit.Framework;

namespace lab.app
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new CarService(new JsonSerializer());
            var car = new Car() { Abs = true, Color = Color.Thunder, NumberOfDoors = NumberOfDoors.Four };
            a.ViewCarDetail(car, new ScreenCarDetailViewer());
            a.ViewCarDetail(car, new PrintCarDetailViewer());
            Console.ReadKey();
        }
    }

    class Katayuno
    {
        private int CalculateSquare(int number)
        {
            var chars = number.ToString();
            var total = 0;
            for (var i = 0; i < chars.Length; i++)
            {
                var currentChar = chars[i].ToString();
                var currentNumber = int.Parse(currentChar);
                total += currentNumber * currentNumber;
            }
            return total;
        }

        public bool IsHappyNumber(int number)
        {
            var chars = number.ToString();
            if (chars.Length == 1)
            {
                if (int.Parse(chars[0].ToString()) == 1)
                {
                    return true;
                }
                return false;
            }
            var result = CalculateSquare(number);
            var maxLoops = 0;
            do
            {
                if (result == 1)
                {
                    return true;
                }
                result = CalculateSquare(result);
                maxLoops++;
            } while (maxLoops < 20);
            return false;

        }
    }

    class KatayunoTests
    {
        [Test]
        public void IsHappyNumber([Values(1, 10, 19, 82, 68, 100)]int numero)
        {
            //Arrange
            var katayuno = new Katayuno();
            //Act
            var expected = katayuno.IsHappyNumber(numero);
            //Assert
            Assert.True(expected);
        }

        [Test]
        public void NotIsHappyNumber([Values(2, 11)]int numero)
        {
            //Arrange
            var katayuno = new Katayuno();
            //Act
            var expected = katayuno.IsHappyNumber(numero);
            //Assert
            Assert.False(expected);
        }
    }
}
