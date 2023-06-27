using Microsoft.AspNetCore.Mvc;
using Hotel.Models;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Hotel.Controllers
{
		public class SignUpController : Controller
		{
			public IActionResult Signing_up()
			{
				return View();
			}


			[HttpPost]
			public IActionResult Signing_up(SignUpModel signUpModel)
			{
				if (ModelState.IsValid)
				{
					// Access the form data from the signUpModel object
					string? fullname = signUpModel.Fullname;
					string? email = signUpModel.Email;
					string? password = signUpModel.Password;
					string hashedPassword = HashPassword(password);

				using (StreamWriter writer = new StreamWriter("Accounts.txt"))
					{
					
						writer.WriteLine($"| {fullname} | {email} | {hashedPassword} |");
					
					}
					// Redirect to a success page or perform any other action
					return RedirectToAction("LoginPage");
				}
				else
				{
					// If the model state is not valid, return the view with validation errors
					return View(signUpModel);
				}
				
			}

		private string HashPassword(string password)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
				return Convert.ToBase64String(hashedBytes);
			}
		}

	}
	}

