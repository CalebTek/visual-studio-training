﻿using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



		public IActionResult Index()
		{
			List<Property> Allproperties = ReadPropertiesFromFile("Allproperties.txt");

			//filter for most picks
			var mostpicks = Allproperties.Where(prop => prop.Popularity == "Most Picks").ToList();
			var first_mostpick = mostpicks.FirstOrDefault();
			ViewData["mostpicks"] = mostpicks;
            ViewData["first_mostpick"] = first_mostpick;

            //filter for Houses with beautiful Backyards
            var backyards = Allproperties.Where(prop => prop.Type == "Houses with beautiful Backyards").ToList();    
            ViewData["backyards"] = backyards;

            //filter for Hotels with large living rooms
            var livingRooms = Allproperties.Where(prop => prop.Type == "Hotels with large living rooms").ToList();
            ViewData["livingRooms"] = livingRooms;

            //filter for Apartments with Kitchen set
            var withKitchen = Allproperties.Where(prop => prop.Type == "Apartments with Kitchen set").ToList();
            ViewData["withKitchen"] = withKitchen;

            return View();
		}
































		public static List<Property> ReadPropertiesFromFile(string filePath)
		{
			List<Property> properties = new List<Property>();

			using (StreamReader reader = new StreamReader(filePath))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					if (!string.IsNullOrWhiteSpace(line))
					{
						string[] fields = line.Split('|');

						if (fields.Length >= 7)
						{
							string id = fields[1].Trim();
							string name = fields[2].Trim();
							string city = fields[3].Trim();
							string location = fields[4].Trim();
							string price = fields[5].Trim();
							string type = fields[6].Trim();
							string popularity = fields[7].Trim();

							Property property = new Property(id,name,city,location,price,type,popularity);
							properties.Add(property);
						}
					}
				}
			}

			return properties;
		}












		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}