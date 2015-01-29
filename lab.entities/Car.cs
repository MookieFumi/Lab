using lab.crosscutting.Enums;

namespace lab.entities
{
    public class Car
    {
        public Car()
        {
            NumberOfDoors = NumberOfDoors.Two;
            Color =  Color.White;
            Abs = false;
        }

        public NumberOfDoors NumberOfDoors { get; set; }
        public Color Color { get; set; }
        public bool Abs { get; set; }
    }
}