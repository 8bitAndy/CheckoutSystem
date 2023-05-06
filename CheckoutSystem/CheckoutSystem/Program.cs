using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CheckoutSystem
{
    class CheckoutSystem {
        public static int menuChoice = 0;
        static void Main(string[] args)
        {
            // Main event loop for program menu
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
                

            }

            // Creating new instance of the json reader
            JsonReader data = new JsonReader();

            // Read data from JSON file
            data.readJSON();
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