using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CheckoutSystem
{
    class CheckoutSystem {
        public static int menuChoice = 0;
        static void Main(string[] args)
        {
            // Initialize list here by reading from JSON file

            /*            // Main event loop for program menu
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Enter a menu option:\n");
                                Console.WriteLine("1. Review Inventory");
                                Console.WriteLine("2. Add item to inventory");
                                Console.WriteLine("3. Take item from inventory");
                                Console.WriteLine("4. Calculate total value of inventory");
                                Console.Write("Your choice: ");
                                menuChoice = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine(menuChoice + " option is");
                            }
                            catch(System.FormatException e)
                            {
                                Console.WriteLine(e.Message);
                                continue;
                            }


                        }*/

/*            // Creating new instance of the json reader
            JsonReader data = new JsonReader();

            // Read data from JSON file
            data.readJSON();*/


            Console.WriteLine("Starting to write JSON");

            string filename = "inventory.json";
            string path = Path.Combine(Environment.CurrentDirectory, @"", filename);

            // Test of creating list of items to add to json list
            List<InventoryItem> testList = new List<InventoryItem>();

            // Dynamically creating new inventory item objects and adding them to the list of inventory items
            int max = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < max; i++)
            {
                dynamic newItem = new InventoryItem();

                switch (i)
                {
                    case 0:
                        newItem.id = 1000;
                        newItem.name = "potatos";
                        newItem.cost = 12.99f;
                        newItem.description = "A bag of 12 potatos";
                        newItem.quantity = 12;
                        break;
                    case 1:
                        newItem.id = 4000;
                        newItem.name = "Oranges";
                        newItem.cost = 6.99f;
                        newItem.description = "A bag of oranges";
                        newItem.quantity = 6;
                        break;
                    case 2:
                        newItem.id = 500;
                        newItem.name = "onions";
                        newItem.cost = 5.00f;
                        newItem.description = "A bag of onions";
                        newItem.quantity = 3;
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
                testList.Add(newItem);
            }


            // Printing JSOn to check what it looks like
/*            Console.WriteLine(testList[0].name + "\n");
            testList[0].name = "changed name";
            Console.WriteLine(testList[0].name + "\n");*/

            // Convert to a JSON format string
            var jsonString = JsonConvert.SerializeObject(testList);

            // Create an array to add the json string to, needed to prevent errors when writing to file
            JArray testArray = JArray.Parse(jsonString);

            // Need to make the JSON object a list of things to properly work


            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, testArray);
            }

            Console.WriteLine("end of writing json");
            Console.WriteLine("\nTest of reading from JSON file now\n\n");


            // Try read from the JSOn file to check changes
            JsonReader data2 = new JsonReader(path);
            // Read data from JSON file
            List<InventoryItem> InventoryItemsList = data2.readJSON();
            Console.WriteLine("There are this many items in the list: " + InventoryItemsList.Count);
            Console.WriteLine("There are this many items in the list: " + InventoryItemsList[0].name);
            Console.WriteLine("There are this many items in the list: " + InventoryItemsList[1].name);
            //Console.WriteLine("There are this many items in the list: " + InventoryItemsList[2].name);

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            data2.inventorySummary();

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


        }
    }
}