using FluentAssertions.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Shared.DTO;
using System.Text.Json.Serialization;
using WebApplication_BusTimeline.Service;
//using WebAPI.Data;
//using WebAPI.Models;

namespace WebApplication_BusTimeline.Pages.Login
{
    public class LoginModel : PageModel
    {
        public IServiceManager _service;

        [BindProperty]
        public UserLoginDTO UserLoginDTO { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string? ErrorMessage { get; set; }

        public LoginModel(IServiceManager service)
        {
            _service = service;
        }
        public async Task OnGetAsync()
        {

        }

        public async Task<IActionResult> OnGetAsyncLogout()
        {
			HttpContext.Session.Remove("username");
			return Page();
        }

        public async Task<IActionResult> OnPostAsync(UserLoginDTO userLoginDTO)
        {
			if (userLoginDTO.Username != null && userLoginDTO.Password != null)
			{
                try
                {
                    await _service.Login(userLoginDTO);


                }
                catch(Exception ex)
                {
                    ErrorMessage = ex.Message;
                }


			}
			return Page();
		}

    }
}