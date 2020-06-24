using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OasisWebApp.Controllers.Custom;
using OasisWebApp.DTOs;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OasisWebApp.Services.CartService.Controller
{
    // TODO: TicketService, TicketRepository
    // TODO: как забрать со страницы объект

    public class CartController : CustomController
    {
        private readonly CartService cartService;
        private string userId, cartId;

        public override async Task OnActionExecutionAsync(
      ActionExecutingContext context,
      ActionExecutionDelegate next)
        {
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            cartId = await cartService.GetCartIdAsync(userId);
            await base.OnActionExecutionAsync(context, next);
        }



        public CartController(CartService cartService)
        {
            this.cartService = cartService;
        }               
        public async Task<IActionResult> Checkout()
        {
            await cartService.Checkout(cartId);
            return Ok();
        }

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

        // [FromRoute] int TicketId
        // TODO TicketService, TicketRepository
        public async Task<IActionResult> AddItem([FromRoute] int TicketId)
        {
            var ticket = new TicketDto();
            await cartService.AddItemToCartAsync(ticket, userId);
            return RedirectToAction("Cart");
        }

        // TODO: как забрать со страницы объект? И передать его в контроллер
        public async Task<IActionResult> RemoveItem()
        {
            var cartItem = new CartItemDto();
            await cartService.RemoveItemsAsync(cartItem, cartId);
            return RedirectToAction("Cart");
        }

    }
}
