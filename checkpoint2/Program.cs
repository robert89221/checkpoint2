
using CheckPoint2;

const ConsoleColor GRAY = ConsoleColor.Gray;
const ConsoleColor DARK = ConsoleColor.DarkGray;
const ConsoleColor RED = ConsoleColor.Red;
const ConsoleColor GREEN = ConsoleColor.Green;

var inventory = new ProductInventory();
/*inventory.AddProductItem(new ProductItem("Mat", "Korv", 10));
inventory.AddProductItem(new ProductItem("Elektronik", "Dator", 1200));
inventory.AddProductItem(new ProductItem("Kläder", "Hatt", 350));
*/

//  huvudmenyn

while (true)
{
    PrintLine(GRAY, "(V) Visa inventarie     \n" +
                    "(L) Lägg till produkter \n" +
                    "(S) Sök i inventariet   \n" +
                    "(A) Avsluta             \n");

    string choice;
    do
    {
        Print(GRAY, "Ditt val: ");
        choice = Console.ReadLine().Trim().ToLower();

    } while (!"vlsa".Contains(choice));

    if      (choice == "v")    ViewInventory();
    else if (choice == "l")    AddProducts();
    else if (choice == "s")    SearchInventory();
    else if (choice == "a")    System.Environment.Exit(0);
}



//  hjälpfunktioner

void Print(ConsoleColor c, string s)
{
    Console.ForegroundColor = c;
    Console.Write(s);
}

void PrintLine(ConsoleColor c, string s)  =>  Print(c, s + "\n");



//  visa inventariet

void ViewInventory()
{
    if (inventory.Length > 0)
    {
        PrintLine(GRAY, $"\nDina {inventory.Length} produkter: \n");
        int total = 0;

        foreach (var prod in inventory)
        {
            PrintLine(GRAY, prod.PrettyPrint());
            total += prod.Price;
        }

        PrintLine(GRAY, $"-------------------------------------------\nSumma {total,34} kr \n");

    } else {

        PrintLine(GRAY, "\nDitt inventarie är tomt \n");
    }
}



//  lägg till produkter

void AddProducts()
{
    PrintLine(GRAY, "\nLägg till nya produkter i formatet \"kategori, namn, pris\", A för att avsluta\n");

    while (true)
    {
        Print(GRAY, "Ny produkt: ");
        var newProd = Console.ReadLine().Trim();

        if (newProd.ToLower() == "a")
        {
            Console.WriteLine();
            return;

        } else {

            if (ProductItem.TryParse(newProd, out var prod))
            {
                inventory.AddProductItem(prod);
                PrintLine(GRAY, "Produkten tillagd");

            } else {

                PrintLine(RED, "Ogiltigt format");
            }
        }
    }
}



//  sök i inventariet

void SearchInventory()
{
    if (inventory.Length > 0)
    {
        Print(GRAY, "\nSök på pris eller fritext, A för att avsluta: ");
        var term = Console.ReadLine().Trim().ToLower();
        Console.WriteLine();

        if (term == "a")
        {
            return;

        } else {

            int total = 0;
            foreach (var prod in inventory)
            {
                if (prod.Matches(term))
                {
                    total += prod.Price;
                    PrintLine(GREEN, prod.PrettyPrint());

                }
                else {

                    PrintLine(DARK, prod.PrettyPrint());
                }

            }

            if (total > 0)    PrintLine(GRAY, $"-------------------------------------------\nSumma {total,34} kr \n");
            else              PrintLine(DARK, "\nInga sökträffar \n");
        }
 
    } else {

        PrintLine(GRAY, "\nDitt inventarie är tomt \n");
    }
}
