using lab.entities;

namespace lab.services
{
    public interface ICarService
    {
        void AddCar(Car car);
        decimal GetPrice(Car car);
        void ViewCarDetail(Car car, ICarDetailViewer carDetailViewer);
    }
}