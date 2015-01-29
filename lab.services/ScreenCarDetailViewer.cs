using System;
using lab.entities;

namespace lab.services
{
    public class ScreenCarDetailViewer : ICarDetailViewer
    {
        public void Show(Car car)
        {
            Console.WriteLine(String.Format("Num. Puertas: {0}", car.NumberOfDoors));
            Console.WriteLine(String.Format("Color: {0}", car.Color));
            Console.WriteLine(String.Format("Abs: {0}", car.Abs));
        }
    }
}