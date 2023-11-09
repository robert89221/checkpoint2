
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

        //  implementation av IEnumerable för LINQ

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        //  klass som implementerar IEnumerator för internt bruk

        private sealed class Enumerator:IEnumerator
        {
            private int index { get; set; }
            private ProductInventory inventory { get; }

            public object Current { get  =>  inventory[index]; }

            public Enumerator(ProductInventory inv)
            {
                index = -1;
                inventory = inv;
            }

            public bool MoveNext()
            {
                ++index;
                return index < inventory.Length;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }

}
