using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using static Ssodha_CarRental.Pages.IndexModel;

namespace Ssodha_CarRental.Pages
{
    public class ReservationFormModel : PageModel
    {
        public string? Car { get; set; }

        public string CusName { get; set; }
        public string CNo { get; set; }
        public DateTime DateTime { get; set; }

        //list for booked car
        public List<carList> notAvailable { get; set; } = new List<carList>();

        public List<carList> cars = new List<carList>();



        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReservationFormModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
            //method to get data from json
            LoadCars();
        }

        //when form filled
        public IActionResult OnPost(string car, string cusName, string cNo, DateTime dateTime)
        {
            //check if valid data enter by user 
            if (!ModelState.IsValid)
            {
                LoadCars();
                return RedirectToPage("/Error");
            }


            LoadCars();

            var carBooked = cars.FirstOrDefault(C => $"{C.Brand} {C.Model}" == car);
            //if car booked make it unavailable and call method savecars
            if (carBooked != null)
            {
                carBooked.Available = false;

                SaveCars();
            }

            //add car to list of not available
            notAvailable.Add(carBooked);

            //if booked conformation page shown
            return RedirectToPage("/ConfirmationMsg", new { car = car, cusName = cusName, cNo = cNo, dateTime = dateTime });
        }

        //method to load data from json to list
        private void LoadCars()
        {
            //give json file path
            string jsonFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "cars.json");

            if (System.IO.File.Exists(jsonFilePath))
            {
                //reaf json and store in list
                string json = System.IO.File.ReadAllText(jsonFilePath);
                cars = JsonConvert.DeserializeObject<List<carList>>(json);
            }
           

            cars = cars.Where(c => c.Available).ToList();
        }

        //update json file according to reservation
        private void SaveCars()
        {
            string jsonPath = Path.Combine(_webHostEnvironment.ContentRootPath, "cars.json");

            //list to json
            string json = JsonConvert.SerializeObject(cars);
            System.IO.File.WriteAllText(jsonPath, json);
        }
    }
}
