
using System.Collections;

namespace CheckPoint2
{
    //  klass som wrappar List<ProductItem> för att representera inventariet

    internal sealed class ProductInventory:IEnumerable
    {
        private List<ProductItem> Items { get; }
        public int Length { get; private set; }

        public ProductInventory()
        {
            Items = new List<ProductItem>();
            Length = 0;
        }

        //  för att index-operatorn ska fungera på inventory

        public ProductItem this[int index]  =>  Items[index];

        //  lägg till ny produkt

        public void AddProductItem(ProductItem p)
        {
            Items.Add(p);
            ++Length;
        }

        //  implementation av IEnumerable för LINQ, returnerar enumeratorn i List

        public IEnumerator GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }

}
