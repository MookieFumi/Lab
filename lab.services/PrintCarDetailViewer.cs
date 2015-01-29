using System;
using lab.entities;

namespace lab.services
{
    public class PrintCarDetailViewer : ICarDetailViewer
    {
        public void Show(Car car)
        {
            Console.WriteLine("Printing car info");
        }
    }
}