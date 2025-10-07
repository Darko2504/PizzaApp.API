using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace PizzaApp.Domain.Entities
{
    public class User : IdentityUser
    {
        public bool FirstLogIn { get; set; }
        [JsonIgnore] // izbegnuva nesting 
        public List<Order> Orders { get; set; } = new List<Order>();
        [JsonIgnore]
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    }
}
