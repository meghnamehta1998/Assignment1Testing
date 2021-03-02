using CruiseManagement.Controllers;
using CruiseManagement.Repository;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Xunit;

namespace Passenger.Test
{
    public class PassengerControllerTest
    {
        private readonly Mock<IDataRepository> mockDtaRepository = new Mock<IDataRepository>();
        private readonly PassengerController _passengerController;

        public PassengerControllerTest()
        {
            _passengerController = new PassengerController(mockDtaRepository.Object);
        }

        [Fact]
        public void Test_GetPassenger()
        {
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.getUsersList()).Returns(GetPassenger());

            // Act
            var response = _passengerController.Get();

            // Asert
            Assert.Equal(3, response.Count);

        }

        [Fact]
        public void Test_Deletepassenger()
        {
            var passenger = new CruiseManagement.Models.Passenger();
            passenger.PassengerNumber = 1;
            // Arrange
            var resultObj = mockDtaRepository.Setup(x => x.Delete(passenger.PassengerNumber)).Returns(true);

            // Act
            var response = _passengerController.Delete(passenger.PassengerNumber);

            //Assert
            Assert.True(response);

        }

        [Fact]
        public void Test_GetpassengerById()
        {
            // Arrange
            var passenger = new CruiseManagement.Models.Passenger();
            passenger.PassengerNumber = 4;
            passenger.FName = "Shankar";
            passenger.LName = "Mahadevan";
            passenger.phoneNumber = "9852124525";

            // Act
            var responseObj = mockDtaRepository.Setup(x => x.GetById(passenger.PassengerNumber)).Returns(passenger);
            var result = _passengerController.Get(passenger.PassengerNumber);
            var isNull = Assert.IsType<OkNegotiatedContentResult<CruiseManagement.Models.Passenger>>(result);
            // Assert
            Assert.NotNull(isNull);
        }

        [Fact]
        public void Test_Addpassenger()
        {
            var newpassenger = new CruiseManagement.Models.Passenger();
            newpassenger.PassengerNumber = 4;
            newpassenger.FName = "Shankar";
            newpassenger.LName = "Mahadevan";
            newpassenger.phoneNumber = "9852124525";
            // Act
            var response = mockDtaRepository.Setup(x => x.AddPassenger(newpassenger)).Returns(Addpassenger());
            var result = _passengerController.Post(newpassenger);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_Updatepassenger()
        {
            // Arrange
            var model = JsonConvert.DeserializeObject<CruiseManagement.Models.Passenger>(File.ReadAllText("Data/UpdatePassenger.json"));

            // Act
            var resultObj = mockDtaRepository.Setup(x => x.Update(model)).Returns(model);
            var response = _passengerController.Put(model);
            // Assert
            Assert.Equal(model, response);
        }


        private static IList<CruiseManagement.Models.Passenger> GetPassenger()
        {
            IList<CruiseManagement.Models.Passenger> passengers = new List<CruiseManagement.Models.Passenger>()
            {
                new CruiseManagement.Models.Passenger() {PassengerNumber=1,FName="Mukesh",LName="Ambani",phoneNumber="9123456789"},
                new CruiseManagement.Models.Passenger() {PassengerNumber=2,FName="Ratan",LName="Tata",phoneNumber="923456789"},
                new CruiseManagement.Models.Passenger() {PassengerNumber=3,FName="Mittal",LName="Shah",phoneNumber="9123452512"},

            };
            return passengers;
        }

        private static CruiseManagement.Models.Passenger Addpassenger()
        {
            var newpassenger = new CruiseManagement.Models.Passenger();
            newpassenger.PassengerNumber = 4;
            newpassenger.FName = "Shankar";
            newpassenger.LName = "Mahadevan";
            newpassenger.phoneNumber = "9852124525";
            return newpassenger;
        }
    }
}
