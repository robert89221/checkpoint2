
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
            Items.Sort();
            ++Length;
        }

        public IEnumerator<ProductItem> GetEnumerator()
        {
            foreach (var item in Items)    yield return item;
        }

/*        public List<ProductItem> Search(string term)
        {
            var results = new List<ProductItem>();

            var hasPrice = Int32.TryParse(term.Trim(), out int price);

            foreach (var item in Items)
            {
                if (hasPrice ? item.Matches(price) : item.Matches(term))     results.Add(item);
            }

            return results;
        }
*/
    }

}
