using System.Collections.Generic;
using System.Linq;
using P2FixAnAppDotNetCode.Models;
using P2FixAnAppDotNetCode.Models.Repositories;
using P2FixAnAppDotNetCode.Models.Services;
using Xunit;

namespace P2FixAnAppDotNetCode.Tests
{
    /// <summary>
    /// The ProductService test class
    /// </summary>
    public class ProductServiceTests
    {

        [Fact]
        public void Product()
        {
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductService productService = new ProductService(productRepository, orderRepository);

            var products = productService.GetAllProducts();

            //Assert.IsType<List<Product>>(products);
            Assert.IsType<Product[]>(products);

        }

        [Fact]
        public void UpdateProductQuantities()
        {
            Cart cart = new Cart();
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductService productService = new ProductService(productRepository, orderRepository);

            IEnumerable<Product> products = productService.GetAllProducts();
            cart.AddItem(products.First(p => p.Id == 1), 1);
            cart.AddItem(products.First(p => p.Id == 3), 2);
            cart.AddItem(products.First(p => p.Id == 5), 3);

            productService.UpdateProductQuantities(cart);

            Assert.Equal(19, products.First(p => p.Id == 1).Stock);
            Assert.Equal(28, products.First(p => p.Id == 3).Stock);
            Assert.Equal(37, products.First(p => p.Id == 5).Stock);
        }

        [Fact]
        public void GetProductById()
        {
            IProductRepository productRepository = new ProductRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductService productService = new ProductService(productRepository, orderRepository);
            int id = 3;

            Product product = productService.GetProductById(id);

            Assert.Same("JVC HAFX8R Headphone", product.Name);
            Assert.Equal(69.99, product.Price);
        }
    }
}
