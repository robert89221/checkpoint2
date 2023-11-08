
namespace CheckPoint2
{
    internal sealed class ProductItem
    {
        string Category { get; }
        string Name { get; }
        int Price { get; }

        public ProductItem(string c, string n, int p)
        {
            Category = c;
            Name = n;
            Price = p;
        }

        public string PrettyPrint()
        {
            return Category + ", " + Name + ", " + Price + " kr";
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
