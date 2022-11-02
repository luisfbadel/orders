using Microsoft.EntityFrameworkCore;
using orders.core.Configuration.DatabaseConfiguration;
using orders.core.Interfaces;
using orders.core.Models;
using orders.core.Requests;

namespace order.infrastructure
{
    public class OrderAdapter : IOrderAdapter
    {
        #region Private Properties

        private readonly DataContext _context;

        #endregion

        #region Constructor

        /// <summary>
        /// Controller
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public OrderAdapter(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));          
        }

        #endregion

        public async Task<string> CreateOrder(Order request)
        {
            _context.Orders.Add(request);
            _context.SaveChanges();
            return request.Id;
        }

        public async Task<Order> GetOrderById(GetOrderByIdRequest request)
        {
            return await _context.Orders.FindAsync(request.Id);
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<bool> UpdateOrder(Order request)
        {
            var order = await _context.Orders.FindAsync(request.Id);
            if (order != null)
            {
                _context.Entry(order).State = EntityState.Detached;
                request.CreatedDate = order.CreatedDate;
                _context.Update(request);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteOrder(GetOrderByIdRequest request)
        {   
            var order = await _context.Orders.FindAsync(request.Id);
            if(order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return true;
            }
            return false;            
            
        }
    }
}