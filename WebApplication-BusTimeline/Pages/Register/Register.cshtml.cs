using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

        private readonly DataContext _context;
        private readonly ILogger<RegisterModel> _logger;

        public string? ErrorMessage { get; set; }
        public RegisterModel(DataContext context,  ILogger<RegisterModel> logger)
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

            var _userExist = await _context.users.FirstOrDefaultAsync(u => u.username.Equals(UserRegisterDTO.Username));

            if (_userExist != null)
            {
                ErrorMessage = "Već postoji korisnik sa ovim korisničkim imenom, pokušajte ponovo!"; 
                
            }
            else
            {
                if (UserRegisterDTO.Password.Equals(UserRegisterDTO.ConfirmPassword))
                {
                    var _user = new User()
                    {
                        name = UserRegisterDTO.Name,
                        lastname = UserRegisterDTO.Lastname,
                        address = UserRegisterDTO.Address,
                        email = UserRegisterDTO.Email,
                        username = UserRegisterDTO.Username,
                        password = UserRegisterDTO.Password   //DODATI HASH!
                    };               

                    _context.users.Add(_user);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("../Login/Login");

                }
                else
                {
                    ErrorMessage = "Šifre se ne podudaraju, pokušajte ponovo!";
                }
               

            }

            return Page();

        }
    }
}
