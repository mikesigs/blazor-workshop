using Microsoft.AspNetCore.Mvc;
using BlazingPizza.Server.Data;

namespace BlazingPizza.Server.Controllers
{
    [Route("pizzas")]
    [ApiController]
    public class PizzasController : Controller
    {
        private readonly PizzaStoreContext _db;

        public PizzasController(PizzaStoreContext db)
        {
            _db = db;
        }
    }
}
