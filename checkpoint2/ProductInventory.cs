
namespace CheckPoint2
{
    internal sealed class ProductInventory
    {
        private List<ProductItem> Items { get; }
        public int Length { get; private set; }

        public ProductInventory()
        {
            Items = new List<ProductItem>();
            Length = 0;
        }

        public void AddProductItem(ProductItem p)
        {
            Items.Add(p);
            ++Length;
        }

        public IEnumerator<ProductItem> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }

}
