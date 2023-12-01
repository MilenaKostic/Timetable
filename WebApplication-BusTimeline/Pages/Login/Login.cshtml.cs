using FluentAssertions.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Shared.DTO;
using System.Text.Json.Serialization;
using WebAPI.Data;
using WebAPI.Models;

namespace WebApplication_BusTimeline.Pages.Login
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public UserLoginDTO UserLoginDTO { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string? ErrorMessage { get; set; }

        public async Task OnGetAsync()
        {

        }

        public async Task<IActionResult> OnPostAsync(string Username, string Password)
        {
			if (Username != null && Password != null)
			{
				using (var httpClient = new HttpClient())
				{
					try
					{
						using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7151/User/ByUsername:{Username}"))
						{
							string apiResponse = await response.Content.ReadAsStringAsync();
							var _user = (JsonConvert.DeserializeObject<UserLoginDTO>(apiResponse));

							if (_user.Password == Password)
							{
								
								return RedirectToPage("../Index", new { UserLoginDTO.Username });
							}
							else
							{
								ErrorMessage = "Pogrešna šifra, pokušajte ponovo!";
								return Page();
							}


						}
					}
					catch (Exception e)
					{
						ErrorMessage = "Ne postoji korisnik sa ovim korisničkim imenom, registrujte se!";
						return Page();

					}

				}


			}
			return Page();
		}

    }
}