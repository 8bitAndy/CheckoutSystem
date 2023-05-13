using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CheckoutSystem
{
    class CheckoutSystem {
        public static int menuChoice = 0;
        static void Main(string[] args)
        {
            // Initialize list here by reading from JSON file
            string filename = "inventory.json";
            string path = Path.Combine(Environment.CurrentDirectory, @"", filename);

            // Creating JSON reader object
            // Try read from the JSOn file to check changes
            JsonReader data = new JsonReader(path);

            // Test of creating list of items to add to json list
            // Read data from JSON file
            List<InventoryItem> InventoryItemsList = data.readJSON();
            Console.WriteLine("Starting to write JSON");

            // Main event loop for program menu
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Enter a menu option:");
                    Console.WriteLine("1. Review Inventory");
                    Console.WriteLine("2. Add item to inventory");
                    Console.WriteLine("3. Edit inventory item");
                    Console.WriteLine("4. Change stock quantity level");
                    Console.WriteLine("5. Calculate total value of inventory");
                    Console.WriteLine("6. Exit program");
                    Console.Write("Your choice: ");
                    menuChoice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    switch (menuChoice)
                    {
                        case 1:
                            data.inventorySummary(InventoryItemsList);
                            break;
                        case 2:
                            // Create a new temporary dynamic object instance to add to inventory list
                            dynamic newItem = new InventoryItem();

                            // Prevent errors if user doesn't use proper input
                            try
                            {
                                Console.Write("Enter a new ID number for new product: ");
                                int newProductId = Convert.ToInt32(Console.ReadLine());

                                // See if item ID already exists in the inventory list, returns -1 if not found
                                if (data.searchInventory(InventoryItemsList, newProductId) == -1)
                                {
                                    newItem.id = newProductId;

                                    Console.Write("Enter a name for new product: ");
                                    string newProductName = Console.ReadLine();
                                    newItem.name = newProductName;

                                    Console.Write("Enter how much the new item is worth: ");
                                    float newProductCost = float.Parse(Console.ReadLine());
                                    newItem.cost = newProductCost;

                                    Console.Write("Enter a description for new item: ");
                                    string newProductDesc = Console.ReadLine();
                                    newItem.description = newProductDesc;

                                    Console.Write("Enter a quantity for this item: ");
                                    int newProductQuantity = Convert.ToInt32(Console.ReadLine());
                                    newItem.quantity = newProductQuantity;

                                    // Add new item to inventory list
                                    InventoryItemsList.Add(newItem);
                                    Console.Clear();
                                    Console.WriteLine("Added new item");
                                    data.saveJSON(InventoryItemsList);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Error product with ID already exists...");
                                }
                            }
                            catch (System.FormatException e)
                            {
                                Console.Clear();
                                Console.WriteLine("Error, " + e.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Press [ENTER] to return to menu");
                                Console.ReadLine();
                            }


                            break;
                        case 3:
                            try
                            {
                                Console.Clear();
                                data.listInventoryItems(InventoryItemsList);
                                Console.Write("\nEnter the ID number of the item you wish to edit: ");
                                int editChoice = Convert.ToInt32(Console.ReadLine());
                                // Search the inventory list for the item and get the index
                                int itemIndex = data.searchInventory(InventoryItemsList, editChoice);
                                if ( itemIndex != -1)
                                {
                                    Console.Clear();
                                    InventoryItemsList = data.editInventoryItem(InventoryItemsList, itemIndex);
                                    data.saveJSON(InventoryItemsList);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Error item ID not found");
                                }
                                
                            }
                            catch (System.FormatException e)
                            {
                                Console.Clear();
                                Console.WriteLine("Error, " + e.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Press [ENTER] to return to menu");
                                Console.ReadLine();
                            }
                            break;
                        case 4:
                            try
                            {
                                Console.Clear();
                                data.listInventoryItems(InventoryItemsList);
                                Console.Write("\nEnter the ID number of the item you wish to change the quantity of: ");
                                int editChoice = Convert.ToInt32(Console.ReadLine());
                                // Search the inventory list for the item and get the index
                                int itemIndex = data.searchInventory(InventoryItemsList, editChoice);
                                if (itemIndex != -1)
                                {
                                    Console.Clear();
                                    InventoryItemsList = data.changeQuantityLevel(InventoryItemsList, itemIndex);
                                    data.saveJSON(InventoryItemsList);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Error item ID not found");
                                }

                            }
                            catch (System.FormatException e)
                            {
                                Console.Clear();
                                Console.WriteLine("Error, " + e.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Press [ENTER] to return to menu");
                                Console.ReadLine();
                            }
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("There are a total of " + data.calculateInventoryAmount(InventoryItemsList) + " items in inventory worth a total of $" + String.Format("{0:0.00}", data.calculateInventoryValue(InventoryItemsList)));
                            Console.WriteLine("Press [ENTER] to return to menu");
                            Console.ReadLine();
                            break;
                        case 6:
                            break;
                    }

                    if(menuChoice == 6)
                    {
                        break;
                    }
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }


            }





            /*            // Dynamically creating new inventory item objects and adding them to the list of inventory items
                        int max = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < max; i++)
                        {
                            dynamic newItem = new InventoryItem();

                            switch (i)
                            {
                                case 0:
                                    newItem.id = 1000;
                                    if (data2.searchInventory(InventoryItemsList, newItem.id) == -1)
                                    {
                                        newItem.name = "potatos";
                                        newItem.cost = 12.99f;
                                        newItem.description = "A bag of 12 potatos";
                                        newItem.quantity = 12;
                                        InventoryItemsList.Add(newItem);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Item with ID " + newItem.id + " already exists in JSON file");
                                    }

                                    break;
                                case 1:
                                    newItem.id = 4000;
                                    if (data2.searchInventory(InventoryItemsList, newItem.id) == -1)
                                    {
                                        newItem.name = "Oranges";
                                        newItem.cost = 6.99f;
                                        newItem.description = "A bag of oranges";
                                        newItem.quantity = 6;
                                        InventoryItemsList.Add(newItem);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Item with ID " + newItem.id + " already exists in JSON file");
                                    }

                                    break;
                                case 2:
                                    newItem.id = 500;
                                    if (data2.searchInventory(InventoryItemsList, newItem.id) == -1)
                                    {
                                        newItem.name = "onions";
                                        newItem.cost = 5.00f;
                                        newItem.description = "A bag of onions";
                                        newItem.quantity = 3;
                                        InventoryItemsList.Add(newItem);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Item with ID " + newItem.id + " already exists in JSON file");
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("Enter details id, name, cost and description for new item and quantity");
                                    newItem.id = Convert.ToInt32(Console.ReadLine());
                                    newItem.name = Console.ReadLine();
                                    newItem.cost = Single.Parse(Console.ReadLine());
                                    newItem.description = Console.ReadLine();
                                    newItem.quantity = Convert.ToInt32(Console.ReadLine());
                                    break;
                            }
                        }

                        data2.saveJSON(InventoryItemsList);
                        Console.WriteLine("saving file now");*/

            /*// Test of writing to file


            Console.WriteLine("end of writing json");
            Console.WriteLine("\nTest of reading from JSON file now\n\n");



            
            Console.WriteLine("There are this many items in the list: " + InventoryItemsList.Count);
            Console.WriteLine("There are this many items in the list: " + InventoryItemsList[0].name);
            Console.WriteLine("There are this many items in the list: " + InventoryItemsList[1].name);
            //Console.WriteLine("There are this many items in the list: " + InventoryItemsList[2].name);

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            data2.inventorySummary(InventoryItemsList);

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            Console.WriteLine("The index of search item is: " + data2.searchInventory(InventoryItemsList, 500));
            Console.WriteLine("This item should be -1: " + data2.searchInventory(InventoryItemsList, 9801));

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            // Test of search, getting item index from the search and then editing this item with the edit method
            int testIndex = data2.searchInventory(InventoryItemsList, 4000);
            data2.editInventoryItem(InventoryItemsList, testIndex);

            // Test of changing quantity levels
            InventoryItemsList = data2.changeQuantityLevel(InventoryItemsList, testIndex);

            // Test of writing to file with changes
            data2.saveJSON(InventoryItemsList);

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            data2.inventorySummary(InventoryItemsList);*/
        }
    }
}