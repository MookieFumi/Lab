using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using lab.crosscutting;
using lab.crosscutting.Enums;
using lab.entities;

namespace lab.services
{
    public class CarService : ICarService
    {
        private readonly IJsonSerializer _jsonSerialize;
        private readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
        private readonly Dictionary<Color, decimal> _dictionary = new Dictionary<Color, decimal>();
        const decimal ColorPrice = 1m;

        public CarService(IJsonSerializer jsonSerialize)
        {
            _jsonSerialize = jsonSerialize;
            _dictionary.Add(Color.Thunder, 2m);
        }

        public void AddCar(Car car)
        {
            var stringBuilder = new StringBuilder();
            var serializeObject = _jsonSerialize.SerializeObject(car);

            DbC.Require(() => serializeObject != null, "No se ha serializado");

            stringBuilder.Append(serializeObject);

            FileUtilities.CreateFolderIfNotExists(_path);

            File.AppendAllText(Path.Combine(_path, "data.txt"), stringBuilder.ToString());
            stringBuilder.Clear();
        }

        public decimal GetPrice(Car car)
        {
            var valuePairs = _dictionary.Where(p => p.Key == car.Color).ToList();
            return valuePairs.Any() ? valuePairs.Single().Value : ColorPrice;
        }

        public void ViewCarDetail(Car car, ICarDetailViewer carDetailViewer)
        {
            carDetailViewer.Show(car);
        }
    }
}
