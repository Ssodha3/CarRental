using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ssodha_CarRental.Pages
{
    public class ConfirmationMsgModel : PageModel
    {

        public string ? Car {  get; set; }
        public string CusName { get; set; }
        public string CNo { get; set; }
        public DateTime DateTime { get; set; }

        //get the data from form to display after success
        public void OnGet(string car, string cusName, string cNo, DateTime dateTime)
        {
            Car = car;
            CusName = cusName;
            CNo = cNo;
            DateTime = dateTime;
        }


    }
}
