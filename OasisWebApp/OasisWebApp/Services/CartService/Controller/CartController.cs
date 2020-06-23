using Microsoft.AspNetCore.Mvc;
using OasisWebApp.Controllers.Custom;
using OasisWebApp.Database.Entities;
using OasisWebApp.DTOs;
using OasisWebApp.Services.CartService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OasisWebApp.Services.CartService.Controller
{
    // TODO: в ActionFilter внести автоматизированный поиск корзины и присвоение значения переменной контроллера
    // + UserID
    // TODO 2: переделать cart.getCart на получение ID ИЛИ добавить GetCartId
    public class CartController : CustomController
    {
        private readonly CartService cartService;

        public CartController(CartService cartService)
        {
            this.cartService = cartService;
        }               
        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await cartService.GetCartAsync(userId);
            await cartService.Checkout(cart.CartId);
            return Ok();
        }

        public async Task<IActionResult> DeleteCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartId = await cartService.GetCartIdAsync(userId);
            await cartService.DeleteCartAsync(cartId);
            return Ok();
        }

        [Route("Cart")]
        public async Task<IActionResult> Cart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await cartService.GetCartAsync(userId);
            return View(cart);
        }

        // [FromRoute] int TicketId
        // TODO TicketService, TicketRepository
        public async Task<IActionResult> AddItem([FromRoute] int TicketId)
        {
            var ticket = new TicketDto();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await cartService.AddItemToCartAsync(ticket, userId);
            return RedirectToAction("Cart");
        }

        // TODO: как забрать со страницы объект? И передать его в контроллер
        public async Task<IActionResult> RemoveItem()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartId = await cartService.GetCartIdAsync(userId);
            var cartItem = new CartItemDto();
            await cartService.RemoveItemsAsync(cartItem, cartId);
            return RedirectToAction("Cart");
        }

    }
}
