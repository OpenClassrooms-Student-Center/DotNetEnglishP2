using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    /// <summary>
    /// The class that manages order data
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders;

        public OrderRepository()
        {
            _orders = new List<Order>();
        }

        /// <summary>
        /// Saves an order
        /// </summary>
        public void Save(Order order)
        {
            _orders.Add(order);
        }
    }
}