
using CheckPoint2;

var inventory = new ProductInventory();
inventory.AddProductItem(new ProductItem("Mat", "Korv", 10));
inventory.AddProductItem(new ProductItem("Elektronik", "Dator", 1200));
inventory.AddProductItem(new ProductItem("Kläder", "Hatt", 350));


//  huvudmenyn

while (true)
{
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("----------------------- \n" +
                      "(V) Visa inventarie     \n" +
                      "(L) Lägg till produkter \n" +
                      "(S) Sök i inventariet   \n" +
                      "(A) Avsluta             \n");

    string choice;
    do
    {
        Console.Write("Ditt val: ");
        choice = Console.ReadLine().Trim().ToLower();

    } while (!"vlsa".Contains(choice));

    if      (choice == "v")    ViewInventory();
    else if (choice == "l")    AddProducts();
    else if (choice == "s")    SearchInventory();
    else if (choice == "a")    System.Environment.Exit(0);
}



//  visa inventariet

void ViewInventory()
{
    if (inventory.Length > 0)
    {
        Console.WriteLine($"Dina {inventory.Length} produkter:");
        foreach (var prod in inventory)     Console.WriteLine(prod.PrettyPrint());

    } else {

        Console.WriteLine("Ditt inventarie är tomt");
    }
}



//  lägg till produkter

void AddProducts()
{
    Console.WriteLine("Lägg till nya produkter i formatet \"kategori, namn, pris\", eller A för att avsluta");

    while (true)
    {
        Console.Write("Ny produkt: ");
        var newProd = Console.ReadLine().Trim();

        if (newProd.ToLower() == "a")
        {
            return;

        } else {

            if (ProductItem.TryParse(newProd, out var prod))
            {
                inventory.AddProductItem(prod);
                Console.WriteLine("Produkten tillagd");

            } else {

                Console.WriteLine("Ogiltigt produktformat");
            }
        }
    }
}



//  sök i inventariet

void SearchInventory()
{
    Console.WriteLine("(search)");
}

