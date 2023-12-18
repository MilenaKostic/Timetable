using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.DTO;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using WebApplication_BusTimeline.Service;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication_BusTimeline.Pages.Login
{
    public class LoginModel : PageModel
    {
        //private readonly IConfiguration configuration;
        public IServiceManager _service;
       // public IAuthenticationService authservice;

        [BindProperty]
        public UserLoginDTO UserLoginDTO { get; set; }

        [BindProperty]
        public string Username { get; set; }
		[BindProperty, DataType(DataType.Password)]
		public string Password { get; set; }

        public string? ErrorMessage { get; set; }

        public UserDTO userCheck { get; set; }

        //public LoginModel(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}
        public LoginModel(IServiceManager service)
        {
            _service = service;
        }
        public async Task OnGetAsync()
        {

        }


        public async Task<IActionResult> OnPostAsync()
        {

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
                string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();


                UserLoginDTO userInput = new UserLoginDTO() { Username = Username, Password = hashedPassword };

                try
                {
                    userCheck = await _service.GetUserByUsername(Username);

					if (userCheck.Password == userInput.Password)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, Username)
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("../Index");

                    }
                    else
                    {
                        ErrorMessage = "Neispravnan username ili password";
                    }



                }
                catch (Exception ex)
                {
                    ErrorMessage = "Neispravnan username ili password";

				}
            }

            return Page();
		}

    }
}