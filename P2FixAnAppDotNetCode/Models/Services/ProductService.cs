using System.Collections;
using System.Collections.Generic;
using System.Linq;
using P2FixAnAppDotNetCode.Models.Repositories;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
        public Product[] GetAllProducts()
        {
            // TODO change the return type from array to List<T> and propagate the change
            // thoughout the application
            // List<Product> repositoryArrToList = new List<Product>(_productRepository.GetAllProducts());
            // var prod = new List<Product[]>();
            //
            // return repositoryArrToList.ToArray();

            // List<Product> arrayToList = new List<Product>(_productRepository.GetAllProducts());
            // return arrayToList.ToArray();
            return _productRepository.GetAllProducts();
        }

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            // TODO implement the method

            Product productList = null;
            var allProducts = _productRepository.GetAllProducts();

            foreach (var product in allProducts)
            {
                if (product.Id == id)
                {
                    productList = product;
                }
            }

            return productList;
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            // TODO implement the method
            // update product inventory by using _productRepository.UpdateProductStocks() method.
            cart = new Cart();
            int getQtty = 0;

            foreach (var c in cart.Lines)
            {
                getQtty += c.Quantity;
            }
            _productRepository.UpdateProductStocks(cart.Lines.Count(), getQtty);
        }
    }
}
