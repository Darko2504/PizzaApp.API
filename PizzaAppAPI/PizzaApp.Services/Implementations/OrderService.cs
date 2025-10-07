using AutoMapper;
using PizzaApp.DataAcess.Repository.Abstractions;
using PizzaApp.Domain.Entities;
using PizzaApp.Dtos.OrderDtos;
using PizzaApp.Services.Abstractions;
using PizzaApp.Shared.Responses;

namespace PizzaApp.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public async Task<CustomResponse<OrderDto>> CreateOrder(string userId, AddOrderDto addOrderDto)
        {
            try
            {
                Order order = _mapper.Map<Order>(addOrderDto);
                order.UserId = userId;
                foreach (Pizza pizza in order.Pizzas)
                {
                    pizza.UserId = userId;
                }
                await _orderRepository.Add(order);
                OrderDto orderDto = _mapper.Map<OrderDto>(order);
                return new CustomResponse<OrderDto>(orderDto);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<CustomResponse> DeleteOrder(string userId, int id)
        {
            try
            {
                Order order = await _orderRepository.GetByIdInt(id);
                if (order == null) return new CustomResponse("Order not found!");
                if (order.UserId != userId) return new CustomResponse("");

               await _orderRepository.Remove(order);
                return new CustomResponse() { IsSuccessfull = true };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CustomResponse<List<OrderDto>>> GetAllOrders(bool isOrderForUser)
        {
            try
            {
                List<Order> orders = await _orderRepository.GetAll();
                if (isOrderForUser == true) orders = await _orderRepository.GetOrderWithDetails();
                List<OrderDto> ordersDto = _mapper.Map<List<OrderDto>>(orders);
                return new CustomResponse<List<OrderDto>>(ordersDto);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CustomResponse<OrderDto>> GetOrderById(int id)
        {
            try
            {
                Order order = await _orderRepository.GetByIdInt(id);
                if (order == null) return new CustomResponse<OrderDto>("Order not found");
                OrderDto orderDto = _mapper.Map<OrderDto>(order);
                return new CustomResponse<OrderDto>(orderDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CustomResponse<OrderDto>> UpdateOrder(string userId, int orderId, UpdateOrderDto updateOrderDto)
        {
            try
            {
                Order order = await _orderRepository.GetByIdInt(orderId);
                if (order == null) return new CustomResponse<OrderDto>("Order was not found");
                if (order.UserId != userId) return new CustomResponse<OrderDto>("You do not have permission to update this pizza");


                _mapper.Map(updateOrderDto, order);
                await _orderRepository.Update(order);
                OrderDto orderDtoResult = _mapper.Map<OrderDto>(order);
                return new CustomResponse<OrderDto> { IsSuccessfull = true , Result = orderDtoResult};

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
