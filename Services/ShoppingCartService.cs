namespace AspHw6
{
    public class ShoppingCartService
    {
        private readonly List<string> _products = new();

        public void AddProduct(string product)
        {
            _products.Add(product);
        }

        public List<string> GetProducts()
        {
            return _products;
        }
    }
}