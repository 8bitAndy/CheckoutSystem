using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CheckoutSystem
{
    class CheckoutSystem {
        public static int menuChoice = 0;
        static void Main(string[] args)
        {
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

            InventoryItem test3 = new InventoryItem();
            test3.id = 519284029;
            test3.name = "Oranges";
            test3.cost = 6.99f;
            test3.description = "A bag of oranges";

            InventoryItem test = new InventoryItem();
            test.id = 123456789;
            test.name = "potatos";
            test.cost = 12.99f;
            test.description = "A bag of 12 potatos";

            InventoryItem test2 = new InventoryItem();
            test2.id = 5123123;
            test2.name = "onions";
            test2.cost = 5.00f;
            test2.description = "A bag of onions";

            // Test of creating list of items to add to json list
            List<InventoryItem> testList = new List<InventoryItem>();
            testList.Add(test3);
            testList.Add(test);
            testList.Add(test2);

            

            // Convert to a JSOn format string
            var jsonString = JsonConvert.SerializeObject(testList);
            // Printing JSOn to check what it looks like
            Console.WriteLine(jsonString);
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
            JsonReader data2 = new JsonReader();
            // Read data from JSON file
            data2.readJSON();
        }
    }

    //
    class InventoryItem
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string ?name { get; set; }
        [JsonProperty("description")]
        public string ?description { get; set; }
        [JsonProperty("cost")]
        public float cost { get; set; }
    }
}