using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using MusalaGatewayProject.Context;
using MusalaGatewayProject.Data;
using MusalaGatewayProject.Repository;
using MusalaUnitTest.Fixture;
using MusalaUnitTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MusalaUnitTest.Systems.Services
{
    public class TestRepository
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
        {
            // Arrange
            var gateways = GatewayFixture.GetGateways();
            var mockHttpHandler = MockHttpMessageHandler<Gateway>.SetupBasicGetResourceList(gateways);
            var httpClient = new HttpClient(mockHttpHandler.Object);
            var mockDbContext = new Mock<DatabaseContext>();
            
            mockDbContext.Setup(x => x.Set<Gateway>())
                .Returns(new DatabaseContext(DbContextOptions db));
               
            var sut = new GenericRepository<Gateway>(mockDbContext.Object);
            // Act
            await sut.GetAll();
            // Assert
            mockHttpHandler
             .Protected()
             .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>()
                );
        }
    }
}
