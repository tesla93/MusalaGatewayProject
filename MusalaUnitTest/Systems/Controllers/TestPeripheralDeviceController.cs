using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MusalaGatewayProject.Configuration;
using MusalaGatewayProject.Controllers;
using MusalaGatewayProject.Data;
using MusalaGatewayProject.Models;
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
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(ModelsFixture.GetPeripheralDevices());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.PeripheralDevices).Returns(mockRepository.Object);
            var contrInst = new PeripheralDeviceController(uow.Object, logger, mapper);
            // Act
            var result = (OkObjectResult)(await contrInst.GetPeripheralDevices());
            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetPeripheralDevices_OnSuccess_InvokeGenericRepositoryExactlyOnce()
        {
            // Arrange
            var logger = Mock.Of<ILogger<PeripheralDeviceController>>();
            //mapperConfiguration
            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<PeripheralDevice>>();
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(ModelsFixture.GetPeripheralDevices());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.PeripheralDevices).Returns(mockRepository.Object);
            var contrInst = new PeripheralDeviceController(uow.Object, logger, mapper);
            // Act
            var result = (OkObjectResult)(await contrInst.GetPeripheralDevices());
            //Assert
            mockRepository.Verify(service => service.GetAll(null, null, null), Times.Once);
        }

        [Fact]
        public async Task GetPeripheralDevices_OnSuccess_ReturnsListOfPeripheralDevices()
        {
            // Arrange
            var logger = Mock.Of<ILogger<PeripheralDeviceController>>();
            //mapperConfiguration
            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<PeripheralDevice>>();
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(ModelsFixture.GetPeripheralDevices());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.PeripheralDevices).Returns(mockRepository.Object);
            var contrInst = new PeripheralDeviceController(uow.Object, logger, mapper);
            // Act
            var result = (OkObjectResult)(await contrInst.GetPeripheralDevices());

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<PeripheralDeviceDTO>>();
        }

        [Fact]
        public async Task GeperipheralDevice_OnNoPeripheralDeviceFound_Returns404()
        {
            // Arrange
            var logger = Mock.Of<ILogger<PeripheralDeviceController>>();
            //mapperConfiguration
            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<PeripheralDevice>>();
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(new List<PeripheralDevice>());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.PeripheralDevices).Returns(mockRepository.Object);
            var contrInst = new PeripheralDeviceController(uow.Object, logger, mapper);
            // Act
            var result = await contrInst.GetPeripheralDevices();


            // Assert
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
        }
    }
}
