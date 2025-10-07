using Microsoft.EntityFrameworkCore;
using PizzaApp.DataAcess.DbContext;
using PizzaApp.DataAcess.Repository.Abstractions;
using PizzaApp.Domain.Entities;

namespace PizzaApp.DataAcess.Repository.Implementations
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly PizzaAppDbContext _pizzaAppDbContext;
        public OrderRepository(PizzaAppDbContext pizzaAppDbContext) : base(pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;
        }
        public async Task<List<Order>> GetOrderWithDetails()
        {
            var Orders = await _pizzaAppDbContext.Order.Include(x => x.Pizzas)
                                                        .Include(x => x.User)
                                                        .ToListAsync();
            return Orders;
        }
    }
}
