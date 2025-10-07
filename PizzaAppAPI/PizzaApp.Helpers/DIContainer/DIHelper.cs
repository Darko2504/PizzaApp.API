using Microsoft.Extensions.DependencyInjection;
using PizzaApp.DataAcess.Repository.Abstractions;
using PizzaApp.DataAcess.Repository.Implementations;
using PizzaApp.Services.Abstractions;
using PizzaApp.Services.Implementations;
using PizzaApp.Services.UserServices.Abstractions;
using PizzaApp.Services.UserServices.Implementations;

namespace PizzaApp.Helpers.DIContainer
{
    public static class DIHelper
    {
        public static void InjectDbRepositories(IServiceCollection services)
        {
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
        
        }


        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IPizzaService, PizzaService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();

        }
    }
}
