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
        public void readJSON()
        {
            string filename = "inventory.json";
            string path = Path.Combine(Environment.CurrentDirectory, @"", filename);


            // Get the JSON file for inventory and assign it to a variable
            using (StreamReader r = new StreamReader(path))
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
                        foreach (var output in InventoryList)
                        {
                            Console.WriteLine(output.id);
                            Console.WriteLine(output.name);

                        }
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
