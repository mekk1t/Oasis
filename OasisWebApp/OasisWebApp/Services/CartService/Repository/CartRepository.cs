using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OasisWebApp.Database;
using OasisWebApp.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisWebApp.Services.CartService.Repository
{
    public class CartRepository
    {
        private readonly OasisCinemaDbContext dbContext;

        public CartRepository(
            [FromServices] OasisCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public Task<Cart> GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            string CartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", CartId);
            return Task.FromResult(new Cart() 
            { CartId = CartId }
            );
        }
    }
}
