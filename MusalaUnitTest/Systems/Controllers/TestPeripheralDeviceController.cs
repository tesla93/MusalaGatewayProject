using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using MusalaGatewayProject.Configuration;
using MusalaGatewayProject.Controllers;
using MusalaGatewayProject.Data;
using MusalaGatewayProject.Repository;
using MusalaUnitTest.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MusalaUnitTest.Systems.Controllers
{
    public class TestPeripheralDeviceController
    {
        [Fact]
        public async Task GetPeripheralDevices_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var logger = Mock.Of<ILogger<PeripheralDeviceController>>();
            //mapperConfiguration
            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<PeripheralDevice>>();
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(GatewayFixture.GetGateways());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Gateways).Returns(mockRepository.Object);
            var contrInst = new GatewayController(uow.Object, logger, mapper);
            // Act
            var result = (OkObjectResult)(await contrInst.GetGateways());

            // Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
