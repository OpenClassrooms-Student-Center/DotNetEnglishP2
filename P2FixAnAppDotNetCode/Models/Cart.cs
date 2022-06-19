using System;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        private List<CartLine> _myCartList = new List<CartLine>();
        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            //return new List<CartLine>();
            return _myCartList;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // TODO implement the method
            var cartLines = _myCartList;
            var orderLineId = 0;

            if (cartLines.Exists(item => item.Product.Id == product.Id))
            {
                for (var i = 0; i < cartLines.Count; i++)
                {
                    if (cartLines[i].Product.Id == product.Id)
                    {
                        var quantityToAdd = new CartLine() { OrderLineId = orderLineId, Product = product, Quantity = quantity + cartLines[i].Quantity };
                        cartLines.Remove(cartLines[i]);
                        cartLines.Insert(i, quantityToAdd);
                    }
                }
            }
            else
            {
                if (quantity != 0 && product != null)
                {
                    orderLineId++;
                    var productToAdd = new CartLine() { OrderLineId = orderLineId, Product = product, Quantity = quantity };

                    cartLines.Add(productToAdd);
                }

            }
            _myCartList = cartLines;
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            List<double> getTotalValueList = new List<double>();
            var cartListCount = _myCartList;
            var totalValue = 0.0;

            foreach (var thisCartLine in cartListCount)
            {
                double cartLinePrice = thisCartLine.Product.Price;
                double cartLineQtty = thisCartLine.Quantity;
                double cartLineTotal = cartLineQtty * cartLinePrice;

                getTotalValueList.Add(cartLineTotal);
            }

            totalValue = getTotalValueList.Sum();

            return totalValue;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            var cartListCount = _myCartList;
            var productCount = 0;

            if (cartListCount.Count() > 1)
            {
                foreach (var cartLine in cartListCount)
                {
                    productCount += cartLine.Quantity;
                }
            }
            else
            {
                productCount = 1;
            }

            var totalValueByLineCount = (GetTotalValue()) / productCount;

            return totalValueByLineCount;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            return null;
        }

        /// <summary>
        /// Get a specifid cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
