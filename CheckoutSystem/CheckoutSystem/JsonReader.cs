using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutSystem
{
    internal class JsonReader
    {
        // File path for the inventory file
        private string path;

        // Give the reader the JSON file path when creating it
        public JsonReader(string path) { 
            this.path = path;
        }

        // Gets all of the inventory items and returns them in a list so that the data can be manipulated
        public List<InventoryItem> readJSON()
        {
            // Get the JSON file for inventory and assign it to a variable
            using (StreamReader r = new StreamReader(this.path))
            {
                // Get all data from JSON file and assign to string
                string json = r.ReadToEnd();

                // Prevents exception with empty JSON file
                if (!string.IsNullOrEmpty(json))
                {
                    // Ignore error, some issue with Newtonsoft package
                    List<InventoryItem> InventoryList = JsonConvert.DeserializeObject<List<InventoryItem>>(json);

                    // Check file contains items in it, then loop through and print values
                    if (InventoryList.Count > 0)
                    {
                        Console.WriteLine("Fgood");
                        return InventoryList;
                    }
                    else
                    {
                        Console.WriteLine("File is empty");
                        return InventoryList;
                    }
                }
                else
                {
                    List<InventoryItem> InventoryList = new List<InventoryItem>();
                    Console.WriteLine("list was empty");
                    return InventoryList;
                }
            }
        }

        public void inventorySummary(List<InventoryItem> InventoryList)
        {
            // Check file contains items in it, then loop through and print values
            if (InventoryList.Count > 0)
            {
                Console.WriteLine("Current Inventory List:\n");
                int currentIndex = 0;
                float totalCost = 0.00f;
                foreach (var output in InventoryList)
                {
                    // Print the listing number of the current item so staff can access it
                    Console.WriteLine((currentIndex + 1) + ". ");
                    Console.WriteLine("ID: " + output.id);
                    Console.WriteLine("Item name: " + output.name);
                    Console.WriteLine("Price: " + output.cost);
                    Console.WriteLine("Description: " + output.description);
                    Console.WriteLine("Quantity: " + output.quantity + "\n");
                    currentIndex++;
                    totalCost += (output.cost * output.quantity);
                }
                Console.WriteLine("Total value of inventory is: $" + String.Format("{0:0.00}", totalCost));
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("File is empty");
                Console.ReadLine();
            }
        }

        public void listInventoryItems(List<InventoryItem> InventoryList)
        {
            // Check file contains items in it, then loop through and print values
            if (InventoryList.Count > 0)
            {
                Console.WriteLine("Current items in inventory:\n");
                int currentIndex = 0;

                foreach (var output in InventoryList)
                {
                    // Print the listing number of the current item so staff can access it
                    Console.WriteLine("ID: " + output.id + " Name: " + output.name);
                    currentIndex++;
                }
            }
            else
            {
                Console.WriteLine("File is empty");
            }
        }



        // Will return the index of the item if it's in the list or return null if it doesn't exist
        public int searchInventory(List<InventoryItem> itemList, int searchID)
        {
            int currentIndex = 0;
            // Loop through list of items and check ID for our searchID
            foreach(var item in itemList)
            {
                // If we find the item in our list of inventory then return the index to our calling function
                if(item.id == searchID)
                {
                    return currentIndex;
                }
                currentIndex++;
            }
            // Search item was not found
            return -1;
        }

        // Will return the index of the item if it's in the list or -1 if not in the list
        // Uses a case sensitive string search term, searches for name of item
        public int searchInventory(List<InventoryItem> itemList, string searchName)
        {
            int currentIndex = 0;
            // Loop through list of items and check ID for our searchID
            foreach (var item in itemList)
            {
                // If we find the item in our list of inventory then return the index to our calling function
                if (item.name == searchName)
                {
                    return currentIndex;
                }
                currentIndex++;
            }
            return -1;
        }

        // Allows user to edit an inventory item
        public List<InventoryItem> editInventoryItem(List<InventoryItem> itemList, int itemIndex)
        {
            Console.WriteLine("The current item details: ");
            Console.WriteLine("Item ID: " + itemList[itemIndex].id);
            Console.WriteLine("Item name: " + itemList[itemIndex].name);
            Console.WriteLine("Item description: " + itemList[itemIndex].description);
            Console.WriteLine("Item cost: " + itemList[itemIndex].cost);
            Console.WriteLine("Item quantity: " + itemList[itemIndex].quantity);

            Console.WriteLine("\nItem name is currently: " + itemList[itemIndex].name);
            Console.Write("Enter a new value or enter 'y' to keep the same value and move to next field: ");
            string userInput = Console.ReadLine();
            if (!(userInput.Equals("y") || userInput.Equals("Y")))
            {
                Console.WriteLine("Changing name");
                itemList[itemIndex].name = userInput;
            }

            Console.WriteLine("\nItem description is currently: " + itemList[itemIndex].description);
            Console.Write("Enter a new value or enter 'y' to keep the same value and move to next field: ");
            userInput = Console.ReadLine();
            if (!(userInput.Equals("y") || userInput.Equals("Y")))
            {
                Console.WriteLine("Changing descp");
                itemList[itemIndex].description = userInput;
            }

            Console.WriteLine("\nItem cost is currently: " + itemList[itemIndex].cost);
            Console.Write("Enter a new value or enter 'y' to keep the same value and move to next field: ");
            userInput = Console.ReadLine();
            if (!(userInput.Equals("y") || userInput.Equals("Y")))
            {
                Console.WriteLine("Changing price");
                itemList[itemIndex].cost = float.Parse(userInput);
                Console.WriteLine("Changed price");
            }

            Console.WriteLine("\nItem quantity is currently: " + itemList[itemIndex].quantity);
            Console.Write("Enter a new value or enter 'y' to keep the same value and move to next field: ");
            userInput = Console.ReadLine();
            if (!(userInput.Equals("y") || userInput.Equals("Y")))
            {
                Console.WriteLine("Changing quantity");
                itemList[itemIndex].quantity = Convert.ToInt32(userInput);
            }


            Console.WriteLine("\nThe updated item details: ");
            Console.WriteLine("Item ID: " + itemList[itemIndex].id);
            Console.WriteLine("Item name: " + itemList[itemIndex].name);
            Console.WriteLine("Item description: " + itemList[itemIndex].description);
            Console.WriteLine("Item cost: " + itemList[itemIndex].cost);
            Console.WriteLine("Item quantity: " + itemList[itemIndex].quantity);

            return itemList;
        }


        // Changes quantity of stock by either adding or subtracting from it
        // Requires the index of the item in the inventory list
        public List<InventoryItem> changeQuantityLevel(List<InventoryItem> itemList, int itemIndex)
        {
            Console.WriteLine("\nThe current item details: ");
            Console.WriteLine("Item ID: " + itemList[itemIndex].id);
            Console.WriteLine("Item name: " + itemList[itemIndex].name);
            Console.WriteLine("Item quantity: " + itemList[itemIndex].quantity);

            Console.Write("Enter the new quantity for the current item: ");
            string userInput = Console.ReadLine();
            itemList[itemIndex].quantity = Convert.ToInt32(userInput);


            Console.WriteLine("\nThe updated item details: ");
            Console.WriteLine("Item ID: " + itemList[itemIndex].id);
            Console.WriteLine("Item name: " + itemList[itemIndex].name);
            Console.WriteLine("Item quantity: " + itemList[itemIndex].quantity + "\n");

            return itemList;
        }


        public float calculateInventoryValue(List<InventoryItem> itemList)
        {
            float totalValue = 0.00f;
            int totalItemCount = 0;

            foreach (InventoryItem item in itemList)
            {
                totalValue += (item.cost * item.quantity);
                totalItemCount += item.quantity;
            }
            
            return totalValue;
        }

        public int calculateInventoryAmount(List<InventoryItem> itemList)
        {
            int totalItemCount = 0;

            foreach (InventoryItem item in itemList)
            {
                totalItemCount += item.quantity;
            }

            return totalItemCount;
        }


        public void saveJSON(List<InventoryItem> itemList)
        {
            // Convert the Inventoryitem list to a JSON format string
            var jsonString = JsonConvert.SerializeObject(itemList);

            // Create an array to add the json string to, needed to prevent errors when writing to file
            JArray testArray = JArray.Parse(jsonString);

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(this.path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, testArray);
            }
        }
    }
}
