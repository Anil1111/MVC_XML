using System.Collections.Generic;
using System.Web.Mvc;
using XmlApp.Models;

namespace XmlCoutriesApp.Controllers
{
    public class HomeController : Controller
    {
        List<string> listToDisplay = new List<string>();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CountryModel country)
        {
            string countryName = country.CountryName;
            string capital = country.Capital;
            var ob1 = new Program();
            listToDisplay = ob1.Main(countryName, capital);
            for (int i = 0; i < listToDisplay.Count/2; i++)
            {
                ViewBag.listToDisplay = listToDisplay;
            }
            return View();
        }

    }
}