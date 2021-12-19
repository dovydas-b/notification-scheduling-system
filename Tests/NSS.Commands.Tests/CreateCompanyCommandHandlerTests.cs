using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using notification_scheduling_system.DataContracts.Command.Request;
using notification_scheduling_system.DataContracts.Domain;
using notification_scheduling_system.DataContracts.Dtos;
using notification_scheduling_system.DataContracts.Enums;
using NSS.Infrastructure.Providers;
using NSS.Repository.Contracts;

namespace NSS.Commands.Tests
{
    [TestClass]
    public class CreateCompanyCommandHandlerTests
    {
        [TestMethod]
        public async Task ExecuteAsync_ShouldCreateNotificationForCompanyAndReturnSuccessResult_WhenCompanyCreated()
        {
            var company = new Company
            {
                Id = Guid.NewGuid()
            };

            var dateTimeNow = new DateTime(2021, 12, 19);

            var marketData = new MarketDataDto
            {
                ApplicableCompanyTypes = new[] {CompanyType.Large},
                SendNotificationOnDays = new[] {1}
            };

            var commandRequest = new CreateCompanyCommandHandlerRequest
            {
                Type = CompanyType.Large,
                MarketType = MarketType.Denmark,
                Name = "CompanyName",
                Number = "123445465"
            };

            var expectedNotificationSendingDate = dateTimeNow.AddDays(1);

            var dateTimeProvider = new Mock<IDateTimeProvider>();
            dateTimeProvider
                .Setup(x => x.UtcNow())
                .Returns(dateTimeNow);

            var companyRepositoryMock = new Mock<ICompanyRepository>();
            companyRepositoryMock.Setup(x =>
                    x.InsertAsync(It.Is<Company>(comp => 
                        comp.MarketType == commandRequest.MarketType &&
                        comp.Type == commandRequest.Type &&
                        comp.Notifications.Count == marketData.SendNotificationOnDays.Length &&
                        comp.Notifications.All(notification => notification.SendingDate == expectedNotificationSendingDate)), It.IsAny<CancellationToken>(), It.IsAny<bool>()))
                .ReturnsAsync(company);

            var marketDateRepository = new Mock<IMarketDataRepository>();

            marketDateRepository
                .Setup(x => x.GetMarketDataByMarketType(It.Is<MarketType>(mt => mt == commandRequest.MarketType)))
                .Returns(marketData);

            var command = new CreateCompanyCommandHandler(companyRepositoryMock.Object, dateTimeProvider.Object,
                marketDateRepository.Object);

            var result = await command.ExecuteAsync(commandRequest, CancellationToken.None);

            Assert.IsNull(result.Error);
            Assert.IsNotNull(result.Payload);
            Assert.AreEqual(company.Id, result.Payload.Id);
        }
    }
}