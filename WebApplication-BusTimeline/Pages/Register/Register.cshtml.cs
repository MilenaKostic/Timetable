using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.DTO;
using Shared.DTO.User;
using WebAPI.Data;
using WebAPI.Models;
using WebApplication_BusTimeline.Pages.Login;

namespace WebApplication_BusTimeline.Pages
{
    public class RegisterModel : PageModel
    {
     
        [BindProperty]
        public UserRegisterDTO UserRegisterDTO { get; set; }
        public string? ErrorMessage { get; set; }

        private readonly DataContext _context;
        private readonly ILogger<RegisterModel> _logger;
        public RegisterModel(DataContext context, ILogger<RegisterModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7151/User/ByUsername:{UserRegisterDTO.Name}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();                  
                        var _user = (JsonConvert.DeserializeObject<UserRegisterDTO>(apiResponse));

                        if(_user != null)
                        {
                            ErrorMessage = "Već postoji korisnik sa ovim korisničkim imenom, pokušajte ponovo!";
                            return Page();
                        }                       
                        else
                        {
                            if (UserRegisterDTO.Password.Equals(UserRegisterDTO.ConfirmPassword))
                            {
                                var _userNew = new User()
                                {
                                    name = UserRegisterDTO.Name,
                                    lastname = UserRegisterDTO.Lastname,
                                    address = UserRegisterDTO.Address,
                                    email = UserRegisterDTO.Email,
                                    username = UserRegisterDTO.Username,
                                    password = UserRegisterDTO.Password   //DODATI HASH!
                                };

                                _context.users.Add(_userNew);
                                await _context.SaveChangesAsync();
                                return RedirectToPage("../Login/Login");

                            }
                            else
                            {
                                ErrorMessage = "Šifre se ne podudaraju, pokušajte ponovo!";
                                return Page();
                            }
                        }

                    }
                }
                catch (Exception exp)
                {
                    ErrorMessage = "Došlo je do greške, pokušajte ponovo!";
                    return Page();
                }
            }
        }
    }
}
