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
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(ModelsFixture.GetGateways());
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
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(ModelsFixture.GetGateways());
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
            mockRepository.Setup(service => service.GetAll(null, null, null)).ReturnsAsync(ModelsFixture.GetGateways());
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
        public async Task GeGetGateways_OnNogatewayFound_Returns404()
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
    }
}
