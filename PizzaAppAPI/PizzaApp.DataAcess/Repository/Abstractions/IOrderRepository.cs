using PizzaApp.Domain.Entities;

namespace PizzaApp.DataAcess.Repository.Abstractions
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetOrderWithDetails();
    }
}
