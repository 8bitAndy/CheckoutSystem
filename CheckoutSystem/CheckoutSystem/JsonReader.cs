using Newtonsoft.Json;
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
                        return InventoryList;
                    }
                    else
                    {
                        Console.WriteLine("File is empty");
                        return null;
                    }
                }
                return null;
            }
        }

        public void inventorySummary()
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
                        Console.WriteLine("Current Inventory List:");
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
                            Console.WriteLine("Description: " + output.quantity + "\n");
                            currentIndex++;
                            totalCost += (output.cost * output.quantity);
                        }
                        Console.WriteLine("Total value of inventory is: $" + totalCost);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("File is empty");
                        Console.ReadLine();
                    }
                }
            }
        }

        public void writeJSON()
        {

        }
    }
}
