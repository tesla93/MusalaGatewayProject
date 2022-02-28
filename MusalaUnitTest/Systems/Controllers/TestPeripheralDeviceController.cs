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
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(ModelsPeripheralDeviceFixture.GetTenPeripheralDevices());
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
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(ModelsPeripheralDeviceFixture.GetTenPeripheralDevices());
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
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(ModelsPeripheralDeviceFixture.GetTenPeripheralDevices());
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
        public async Task GetPeripheralDevice_OnNoPeripheralDeviceFound_Returns404()
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

        [Fact]
        public async Task GePeripheralDevice_UnknowIdPasses_Returns404()
        {
            // Arrange
            var logger = Mock.Of<ILogger<PeripheralDeviceController>>();
            var id = 2;
            //mapperConfiguration
            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<PeripheralDevice>>();
            mockRepository.Setup(service => service
            .Get(x => x.Id == id, new List<string> { nameof(PeripheralDevice.GatewayNavigation) }))
                .ReturnsAsync(ModelsPeripheralDeviceFixture.GetOnePeripheralDevice());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.PeripheralDevices).Returns(mockRepository.Object);
            var contrInst = new PeripheralDeviceController(uow.Object, logger, mapper);

            // Act            
            var result = await contrInst.GetPeripheralDevice(1);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task GetPeripheralDevice_ExistingIdPasses_ReturnsOkResult()
        {
            // Arrange
            var logger = Mock.Of<ILogger<PeripheralDeviceController>>();
            //mapperConfiguration
            var id = 1;
            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<PeripheralDevice>>();
            mockRepository.Setup(service => service
            .Get(x => x.Id == id, new List<string> { nameof(PeripheralDevice.GatewayNavigation) }))
                .ReturnsAsync(ModelsPeripheralDeviceFixture.GetOnePeripheralDevice());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.PeripheralDevices).Returns(mockRepository.Object);
            var contrInst = new PeripheralDeviceController(uow.Object, logger, mapper);

            // Act            
            var result = await contrInst.GetPeripheralDevice(id);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.StatusCode.Should().Be(200);
        }

       


        [Fact]
        public async Task DeletePeripheralDevice_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingId = 99;
            var logger = Mock.Of<ILogger<PeripheralDeviceController>>();
            //mapperConfiguration

            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<PeripheralDevice>>();
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.PeripheralDevices).Returns(mockRepository.Object);
            var contrInst = new PeripheralDeviceController(uow.Object, logger, mapper);
            // Act
            var result = await contrInst.DeletePeripheralDevice(notExistingId);
            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = (NotFoundObjectResult)result;
            objectResult.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task DeletePeripheralDevice_ExistingGuidPassed_ReturnsNoContent()
        {
            // Arrange
            var id = 1;
            var logger = Mock.Of<ILogger<PeripheralDeviceController>>();
            //mapperConfiguration

            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<PeripheralDevice>>();
            mockRepository.Setup(service => service
            .Get(q => q.Id == id, null))
                .ReturnsAsync(ModelsPeripheralDeviceFixture.GetOnePeripheralDevice());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.PeripheralDevices).Returns(mockRepository.Object);
            var contrInst = new PeripheralDeviceController(uow.Object, logger, mapper);
            // Act
            var result = await contrInst.DeletePeripheralDevice(id);
            // Assert
            result.Should().BeOfType<NoContentResult>();
            var objectResult = (NoContentResult)result;
            objectResult.StatusCode.Should().Be(204);
        }
    }
}
