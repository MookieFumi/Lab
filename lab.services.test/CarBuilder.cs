using lab.crosscutting.Enums;
using lab.entities;

namespace lab.services.test
{
    public class CarBuilder
    {
        private readonly Car _car;

        public CarBuilder()
        {
            _car = new Car();
        }

        public CarBuilder WithDoors(NumberOfDoors numberOfDoors)
        {
            _car.NumberOfDoors = numberOfDoors;
            return this;
        }

        public CarBuilder WithColor(Color color)
        {
            _car.Color = color;
            return this;
        }

        public CarBuilder WithAbs(bool withAbs)
        {
            _car.Abs = withAbs;
            return this;
        }

        public Car Build()
        {
            return _car;
        }
    }
}