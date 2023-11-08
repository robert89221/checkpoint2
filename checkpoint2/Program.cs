
using CheckPoint2;

var inventory = new ProductInventory();


//  huvudmenyn

while (true)
{
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("(V) View inventory   \n" +
                      "(A) Add products     \n" +
                      "(S) Search inventory \n" +
                      "(Q) Quit             \n");

    string choice;
    do
    {
        Console.Write("Your choice: ");
        choice = Console.ReadLine().Trim().ToLower();

    } while (!"vasq".Contains(choice));

    if (choice == "v") ViewInventory();
    else if (choice == "a") AddProducts();
    else if (choice == "s") SearchInventory();
    else if (choice == "q") System.Environment.Exit(0);
}



//  visa inventariet

void ViewInventory()
{
    Console.WriteLine("(view inventory)");
}



//  lägg till produkter

void AddProducts()
{
    Console.WriteLine("(add products)");
}



//  sök i inventariet

void SearchInventory()
{
    Console.WriteLine("(search)");
}

