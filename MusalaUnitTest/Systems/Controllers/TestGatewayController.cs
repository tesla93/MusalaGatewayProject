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
using System.Threading.Tasks;
using Xunit;

namespace MusalaUnitTest
{
    public class TestGatewayController
    {
        [Fact]
        public async Task GetGateways_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var logger = Mock.Of<ILogger<GatewayController>>();
            //mapperConfiguration
            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<Gateway>>();
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(ModelsGatewayFixture.GetGateways());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Gateways).Returns(mockRepository.Object);
            var contrInst = new GatewayController(uow.Object, logger, mapper);
            // Act
            var result = (OkObjectResult)(await contrInst.GetGateways());

            // Assert
            result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task GetGateways_OnSuccess_InvokeGenericRepositoryExactlyOnce()
        {
            // Arrange
            var logger = Mock.Of<ILogger<GatewayController>>();
            //mapperConfiguration
            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<Gateway>>();
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(ModelsGatewayFixture.GetGateways());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Gateways).Returns(mockRepository.Object);
            var contrInst = new GatewayController(uow.Object, logger, mapper);
            // Act
            var result = (OkObjectResult)(await contrInst.GetGateways());

            // Assert
            mockRepository.Verify(service => service.GetAll(null, null, null), Times.Exactly(1));
        }

        [Fact]
        public async Task GetGateways_OnSuccess_ReturnsListOfGateways()
        {
            // Arrange
            var logger = Mock.Of<ILogger<GatewayController>>();
            //mapperConfiguration
            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<Gateway>>();
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(ModelsGatewayFixture.GetGateways());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Gateways).Returns(mockRepository.Object);
            var contrInst = new GatewayController(uow.Object, logger, mapper);
            // Act
            var result = (OkObjectResult)(await contrInst.GetGateways());

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<GatewayDTO>>();
        }

        [Fact]
        public async Task GeGateways_OnNoGatewayFound_Returns404()
        {
            // Arrange
            var logger = Mock.Of<ILogger<GatewayController>>();
            //mapperConfiguration
            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<Gateway>>();
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(new List<Gateway>());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Gateways).Returns(mockRepository.Object);
            var contrInst = new GatewayController(uow.Object, logger, mapper);
            // Act
            var result = await contrInst.GetGateways();


            // Assert
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
        }



        [Fact]
        public async Task GeGateway_UnknowGuidPassed_Returns404()
        {
            // Arrange
            var logger = Mock.Of<ILogger<GatewayController>>();
            var guid = new Guid("92AB451F-D3F5-4F9D-A53F-08D9F7D527FF");

            //mapperConfiguration
            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<Gateway>>();
            mockRepository.Setup(service => service
            .Get(x=> x.SerialNumber==guid, new List<string> { nameof(Gateway.PeripheralDevices) }))
                .ReturnsAsync(ModelsGatewayFixture.GetOneGateway());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Gateways).Returns(mockRepository.Object);
            var contrInst = new GatewayController(uow.Object, logger, mapper);
            // Act
            var result = await contrInst.GetGateway(new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D"));

            // Assert
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task GeGateway_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var logger = Mock.Of<ILogger<GatewayController>>();
            //mapperConfiguration
            var guid = new Guid("92AB451F-D3F5-4F9D-A53F-08D9F7D527FF");
            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<Gateway>>();
            mockRepository.Setup(service => service.Get(x=> x.SerialNumber==guid, new List<string> { nameof(Gateway.PeripheralDevices) })).ReturnsAsync(ModelsGatewayFixture.GetOneGateway());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Gateways).Returns(mockRepository.Object);
            var contrInst = new GatewayController(uow.Object, logger, mapper);
            // Act
            var result = await contrInst.GetGateway(guid);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;         
            objectResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task CreateGateway_InvalidIpAddressPassed_ReturnBadRequest()
        {
            // Arrange
            var logger = Mock.Of<ILogger<GatewayController>>();
            //mapperConfiguration
            
            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<Gateway>>();
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Gateways).Returns(mockRepository.Object);
            var contrInst = new GatewayController(uow.Object, logger, mapper);
            // Act
            var result = await contrInst.CreateGateway(ModelsGatewayFixture.GetOneInvalidIpGatewayDTO());

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
            var objectResult = (BadRequestObjectResult)result;
            objectResult.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task CreateGateway_ValidModel_ReturnOkResult()
        {
            // Arrange
            var logger = Mock.Of<ILogger<GatewayController>>();
            //mapperConfiguration

            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<Gateway>>();
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Gateways).Returns(mockRepository.Object);
            var contrInst = new GatewayController(uow.Object, logger, mapper);
            // Act
            var result = await contrInst.CreateGateway(ModelsGatewayFixture.GetOneValidGatewayDTO());

            // Assert
            result.Should().BeOfType<CreatedAtRouteResult>();
            var objectResult = (CreatedAtRouteResult)result;
            objectResult.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task DeleteGateway_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid();
            var logger = Mock.Of<ILogger<GatewayController>>();
            //mapperConfiguration

            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<Gateway>>();
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Gateways).Returns(mockRepository.Object);
            var contrInst = new GatewayController(uow.Object, logger, mapper);
            // Act
            var result = await contrInst.DeleteGateway(notExistingGuid);
            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = (NotFoundObjectResult)result;
            objectResult.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task DeleteGateway_ExistingGuidPassed_ReturnsNoContent()
        {
            // Arrange
            var existingGuid = new Guid("D8835792-079D-4BF6-A92A-4C68D7FFCC3D");
            var logger = Mock.Of<ILogger<GatewayController>>();
            //mapperConfiguration

            var myProfile = new AutomapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var mockRepository = new Mock<IGenericRepository<Gateway>>();
            mockRepository.Setup(service => service
            .Get(q => q.SerialNumber == existingGuid, null))
                .ReturnsAsync(ModelsGatewayFixture.GetOneGateway());
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Gateways).Returns(mockRepository.Object);
            var contrInst = new GatewayController(uow.Object, logger, mapper);
            // Act
            var result = await contrInst.DeleteGateway(existingGuid);
            // Assert
            result.Should().BeOfType<NoContentResult>();
            var objectResult = (NoContentResult)result;
            objectResult.StatusCode.Should().Be(204);
        }


    }
}
