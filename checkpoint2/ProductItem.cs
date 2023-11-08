
namespace CheckPoint2
{
    internal sealed class ProductItem:IComparable
    {
        public string Category { get; }
        public string Name { get; }
        public int Price { get; }

        public ProductItem(string c, string n, int p)
        {
            Category = c;
            Name = n;
            Price = p;
        }

        public int CompareTo(object? other)  =>  this.Price - (other as ProductItem).Price;

        public string PrettyPrint()  =>  $"{Category,-15}{Name,-15}{Price,10} kr";

        public bool Matches(string term)
        {
            term = term.Trim().ToLower();

            bool priceMatches = false;
            if (Int32.TryParse(term, out int p))    priceMatches = p == Price;

            return Category.ToLower().Contains(term)  ||  Name.ToLower().Contains(term)  ||  priceMatches;
        }
    
        public static bool TryParse(string s, out ProductItem? prod)
        {
            prod = null;
            var strings = s.Split(',');

            if (strings.Length == 3)
            {
                var c = strings[0].Trim();
                var n = strings[1].Trim();
                var havePrice = Int32.TryParse(strings[2].Trim(), out int p);

                if (c != ""  &&  n != ""  &&  havePrice)    prod = new ProductItem(c, n, p);
            }

            return prod != null;
        }
    }
}
