using System;
using lab.crosscutting;
using lab.crosscutting.Enums;
using NUnit.Framework;
using Rhino.Mocks;

//Patrón AAA
//Arrange:  Inicializa objetos y establece el valor de los parámetros del método de prueba
//Act:      Invoca al método en pruebas
//Assert:   Comprueba si la acción del método en pruebas se comporta de la forma prevista.

namespace lab.services.test
{
    class CarServiceTest
    {
        private CarService _sut;
        private IJsonSerializer _jsonSerializerMock;
        private string _carSerialized = @"{\r\n  \""NumberOfDoors\"": 2,\r\n  \""Color\"": 3,\r\n  \""Abs\"": false\r\n}";
        
        [TestFixtureSetUp]
        public void SetUp()
        {
            _jsonSerializerMock = MockRepository.GenerateMock<IJsonSerializer>();
            _jsonSerializerMock.Stub(x => x.SerializeObject(Arg<Object>.Is.Anything)).Return(_carSerialized).Repeat.Any();
            _sut = new CarService(_jsonSerializerMock);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
        }

        [Test]
        public void When_AddCar_calls_SerializedObject_method()
        {
            //Arrange
            var car = new CarBuilder()
                .WithDoors(NumberOfDoors.Four)
                .WithColor(Color.Thunder)
                .WithAbs(true)
                .Build();

            //Act
            _sut.AddCar(car);

            //Asert
            _jsonSerializerMock.AssertWasCalled(x => x.SerializeObject(Arg<object>.Is.Anything));
        }

        [Test]
        public void When_AddCar_cannot_save_not_serialized_objects()
        {
            //Arrange
            var car = new CarBuilder()
                .WithDoors(NumberOfDoors.Four)
                .WithColor(Color.Thunder)
                .WithAbs(true)
                .Build();

            //Act
            try
            {
                _sut.AddCar(car);
                //Assert
                Assert.Fail();
            }
            catch (Exception exception)
            {
            }
        }

        [Test]
        public void When_GetPrice_for_thunder_color_is_actual_price()
        {
            //Arrange
            var car = new CarBuilder()
                .WithDoors(NumberOfDoors.Four)
                .WithColor(Color.Thunder)
                .WithAbs(true)
                .Build();

            //Act
            var price = _sut.GetPrice(car);

            //Asert
            Assert.True(price==2m);
        }
    }
}
