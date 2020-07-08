using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OasisWebApp.Controllers.Custom;
using OasisWebApp.DTOs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OasisWebApp.Services.CartService.Controller
{
    public class CartController : CustomController
    {
        private readonly OrderService.OrderService orderService;
        private readonly CartService cartService;
        private string userId, cartId;

        public override async Task OnActionExecutionAsync(
      ActionExecutingContext context,
      ActionExecutionDelegate next)
        {
            if (userId == null)
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            if (cartId == null)
            {
                cartId = await cartService.GetCartIdAsync(userId);
            }
            await base.OnActionExecutionAsync(context, next);
        }



        public CartController(
            CartService cartService,
            OrderService.OrderService orderService)
        {
            this.cartService = cartService;
            this.orderService = orderService;
        }      
        [Route("Checkout")]
        public async Task<IActionResult> Checkout()
        {
            var cartCheckedOut = await cartService.Checkout(cartId);            
            ICollection<TicketDto> tickets = new Collection<TicketDto>();
            foreach (var cartItem in cartCheckedOut.CartItems)
            {
                tickets.Add(cartItem.Ticket);
            }
            await orderService.CreateOrderAsync(userId, tickets);
            await cartService.DeleteCartAsync(cartId);
            return RedirectToAction("Cart");
        }

        [Route("OrderSuccess")]
        public IActionResult OrderSuccess()
        {
            return View();
        }


        [Route("DeleteCart")]
        public async Task<IActionResult> DeleteCart()
        {
            await cartService.DeleteCartAsync(cartId);
            return Ok();
        }

        [Route("Cart")]
        public async Task<IActionResult> Cart()
        {
            var cart = await cartService.GetCartAsync(userId);
            return View(cart);
        }

        [Route("AddItem/{TicketId}")]

        public async Task<IActionResult> AddItem([FromRoute] int TicketId)
        {
            await cartService.AddItemToCartAsync(TicketId, userId);
            return RedirectToAction("Cart");
        }

        [Route("RemoveItem")]
        // TODO: забрать CartItemId, найти такой товар и удалить его из CartItems
        public async Task<IActionResult> RemoveItem(string cartItemId)
        {
            await cartService.RemoveItemAsync(cartItemId, cartId);
            return RedirectToAction("Cart");
        }

    }
}
