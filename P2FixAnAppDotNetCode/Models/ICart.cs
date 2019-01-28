
namespace P2FixAnAppDotNetCode.Models
{
    public interface ICart
    {
        void AddItem(Product product, int quantity);

        void RemoveLine(Product product);

        void Clear();

        double GetTotalValue();

        double GetAverageValue();
    }
}