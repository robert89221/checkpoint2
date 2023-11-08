
namespace CheckPoint2
{
    //  klass som wrappar List<ProductItem> för att representera inventariet

    internal sealed class ProductInventory
    {
        private List<ProductItem> Items { get; }
        public int Length { get; private set; }

        public ProductInventory()
        {
            Items = new List<ProductItem>();
            Length = 0;
        }

        //  lägg till ny produkt, och håll listan sorterad

        public void AddProductItem(ProductItem p)
        {
            Items.Add(p);
            Items.Sort();
            ++Length;
        }

        //  för att foreach ska fungera på inventariet

        public IEnumerator<ProductItem> GetEnumerator()
        {
            foreach (var item in Items)    yield return item;
        }
    }

}
