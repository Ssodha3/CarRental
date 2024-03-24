using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Ssodha_CarRental.Pages
{
    public class IndexModel : PageModel
    {
       
        public class carList
        {
            public string? Brand { get; set; }
            public string? Model { get; set; }
            public string? Description { get; set; }
            public string? Price { get; set; }
            public string? imgSet { get; set; }
            public bool Available { get; set; } = true;
        }

        //company details 
        public string companyName { get; } = "Shyama Sodha's CarRental";
        public string add { get; } = "Conestoga College, Waterloo, Canada";
        public string contactNo { get; } = "1234567890";

        //list to store cars from json
        public List<carList> cars { get; private set; } = new List<carList>();

        public void OnGet()
        {
            //method for get data from jsonFile
            LoadCars();
        }

     
        private void LoadCars()
        {
            // give path of json file
            string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "cars.json");

            if (System.IO.File.Exists(jsonPath))
            {
                // Read car data 
                string json = System.IO.File.ReadAllText(jsonPath);

                // store car data from json to list
                cars = JsonConvert.DeserializeObject<List<carList>>(json);
            }
        }
    }
}
