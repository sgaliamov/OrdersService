using System;
using System.Threading.Tasks;
using System.Transactions;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using OrdersService.BusinessLogic;
using OrdersService.BusinessLogic.Contracts.DomainModels;
using OrdersService.BusinessLogic.Contracts.Persistence;
using OrdersService.DataAccess.Entities;
using Xunit;

namespace OrdersService.DataAccess.Tests
{
    public sealed class OrdersRepositoryTests : IDisposable
    {
        public OrdersRepositoryTests()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<OrdersServiceContext>()
                                 .UseSqlServer(configuration.GetConnectionString("OrdersService"))
                                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                                 .UseLoggerFactory(new LoggerFactory(new[] { new DebugLoggerProvider() }));
            var options = optionsBuilder.Options;

            var mapperConfiguration = new MapperConfiguration(RepositoryMapper.ConfigureMapper);
            mapperConfiguration.AssertConfigurationIsValid();
            var mapper = mapperConfiguration.CreateMapper();

            _repository = new OrdersRepository(new OrdersServiceContext(options), mapper);

            _transactionScope = new TransactionScope(
                TransactionScopeOption.RequiresNew,
                TransactionScopeAsyncFlowOption.Enabled);
        }

        public void Dispose()
        {
            _transactionScope.Dispose();
        }

        [Fact]
        public async Task Create_And_Get_By_Order_Id()
        {
            var entity = _fixture.Create<OrderEntity>();
            entity.Phone = entity.Phone.Substring(0, Constants.MaxPhoneLength);
            entity.PostCode = entity.PostCode.Substring(0, Constants.MaxPostCodeLength);

            await _repository.AddOrUpdateAsync(entity).ConfigureAwait(false);

            var actual = await _repository.GetByIdAsync(entity.OrderId).ConfigureAwait(false);

            actual.Should().BeEquivalentTo(entity);
        }

        private readonly TransactionScope _transactionScope;
        private readonly IOrdersRepository _repository;
        private readonly Fixture _fixture = new Fixture();
    }
}
