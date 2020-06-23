using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Cart> Checkout(string cartId)
        {
            var cart = await dbContext.Cart.SingleAsync(c => c.CartId == cartId);
            cart.IsCheckedOut = true;
            return cart;
        }

        public async Task DeleteCartAsync(string cartId)
        {
            var cart = await dbContext.Cart.SingleAsync(c => c.CartId == cartId);
            dbContext.Cart.Remove(cart);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Cart> GetCartAsync(string userId, string cartId = default)
        {
            if (cartId != default)
            {
                var cart = await dbContext.Cart
                    .Include(c => c.CartItems)
                    .SingleAsync(c => c.CartId == cartId && c.UserId == userId);
                return cart;
            }
            else
            {
                var cart = await dbContext.Cart
                    .Include(c => c.CartItems)
                    .SingleAsync(c => c.UserId == userId);
                return cart;
            }
        }

        public async Task<Cart> CreateCartAsync(string userId)
        {
            var cart = new Cart()
            {
                CartId = Guid.NewGuid().ToString(),
                UserId = userId
            };
            await dbContext.Cart.AddAsync(cart);
            await dbContext.SaveChangesAsync();
            return cart;
        }
        public async Task RemoveItemAsync(CartItem cartItem, string cartId)
        {
            var cart = await GetCartAsync(cartId);
            if (cart != null)
            {
                dbContext.CartItems.Remove(cartItem);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task AddItemToCartAsync(
            Ticket ticket,
            string userId,
            string cartId = default)
        {
            Cart cart = new Cart();
            if (cartId == default)
            {
                cart = await CreateCartAsync(userId);
                cartId = cart.CartId;
            }

            if (cartId != default)
            {
                cart = await GetCartAsync(cartId, userId);
            }

            var item = new CartItem()
            { 
                CartId = cartId,
                CartItemId = Guid.NewGuid().ToString(),
                Ticket = ticket
            };
            await dbContext.CartItems.AddAsync(item);
            await dbContext.SaveChangesAsync();
        }
        public async Task<string> GetCartIdAsync(string userId)
        {
            var cart = await dbContext.Cart
                .SingleAsync(c => c.UserId == userId);
            var cartId = cart.CartId;
            return cartId;
        }

    }
}
