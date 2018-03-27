using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using OrdersService.BusinessLogic.Contracts;
using OrdersService.WebApi.Models;
using Xunit;

namespace OrdersService.Tests.OrdersService.WebApi.Models
{
    public class OrdersPresenterTests
    {
        public OrdersPresenterTests()
        {
            _ordersRepository = new Mock<IOrdersRepository>(MockBehavior.Strict);
            _mapper = new Mock<IMapper>(MockBehavior.Strict);

            _target = new OrdersPresenter(_ordersRepository.Object, _mapper.Object);
            _fixture = new Fixture();
        }

        private readonly Mock<IOrdersRepository> _ordersRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly OrdersPresenter _target;
        private readonly Fixture _fixture;

        [Fact]
        public void Test_GetById()
        {
            var id = _fixture.Create<string>();
            var entity = _fixture.Create<OrderEntity>();
            var model = _fixture.Create<OrderReadModel>();

            _ordersRepository.Setup(x => x.GetById(id)).Returns(entity);
            _mapper.Setup(x => x.Map<OrderReadModel>(entity)).Returns(model);

            // act
            var actual = _target.GetById(id);

            // assert
            _ordersRepository.Verify(x => x.GetById(id), Times.Once);
            _mapper.Verify(x => x.Map<OrderReadModel>(entity), Times.Once);
            actual.Should().BeEquivalentTo(model);
        }
    }
}