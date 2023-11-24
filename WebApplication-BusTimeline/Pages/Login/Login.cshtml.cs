using FluentAssertions.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Shared.DTO.User;
using System.Text.Json.Serialization;
using WebAPI.Data;
using WebAPI.Models;

namespace WebApplication_BusTimeline.Pages.Login
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public UserLoginDTO UserLoginDTO { get; set; }

       
        public string? ErrorMessage { get; set; }
        //[BindProperty]
        //public string? Error {  get; set; }

        public DataContext _context; 
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(DataContext context, ILogger<LoginModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet() {
            
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid == false)
            {
                return Page();
            }

            var _user =  await _context.users.FirstOrDefaultAsync(u => u.username == UserLoginDTO.Username && u.password == UserLoginDTO.Password);

            if(_user == null)
            {
                ErrorMessage = "Pogrešno korisničko ime ili šifra, pokušajte ponovo!";
                
            }
            else
            {
                return RedirectToPage("../Index", new { _user.username });

            }

            return Page();
            
        }


    }
}
