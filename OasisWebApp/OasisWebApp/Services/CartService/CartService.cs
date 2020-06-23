using AutoMapper;
using OasisWebApp.Database.Entities;
using OasisWebApp.DTOs;
using OasisWebApp.Services.CartService.Repository;
using System.Threading.Tasks;

namespace OasisWebApp.Services.CartService
{
    public class CartService
    {
        private readonly CartRepository cartRepository;
        private readonly IMapper mapper;
        public CartService(
            CartRepository cartRepository,
            IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.mapper = mapper;
        }

        public async Task<CartDto> Checkout(string cartId)
        {
            // мб вернуть просто bool
            var cart = await cartRepository.Checkout(cartId);
            var cartDto = mapper.Map<CartDto>(cart);
            return cartDto;
        }

        public async Task DeleteCartAsync(string cartId)
        {
            await cartRepository.DeleteCartAsync(cartId);
        }

        // мб искать по корзине определенного пользователя? или добавить доп. метод
        public async Task<CartDto> GetCartAsync(string userId, string cartId = default)
        {
            var cart = await cartRepository.GetCartAsync(userId);
            var cartDto = mapper.Map<CartDto>(cart);
            return cartDto;
        }

        public async Task<CartDto> CreateCartAsync(string userId)
        {
            var cart = await cartRepository.CreateCartAsync(userId);
            var cartDto = mapper.Map<CartDto>(cart);
            return cartDto;
        }

        public async Task RemoveItemsAsync(CartItemDto cartItem, string cartId)
        {
            // TODO: foreach + вызов ?
            var cartItemDto = mapper.Map<CartItem>(cartItem);
            await cartRepository.RemoveItemAsync(cartItemDto, cartId);
        }

        public async Task AddItemToCartAsync(
            TicketDto ticket,
            string userId,
            string cartId = default)
        {
            // TODO: как-то получить Ticket в бд-модели 
            var ticketDto = mapper.Map<Ticket>(ticket);
            await cartRepository.AddItemToCartAsync(ticketDto, userId);            
        }
        public async Task<string> GetCartIdAsync(string userId)
        {
            var cartId = await cartRepository.GetCartIdAsync(userId);
            return cartId;
        }


    }
}
