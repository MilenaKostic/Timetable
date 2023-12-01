using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;


namespace WebApplication_BusTimeline.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }

        public void OnGet()
        {

            Username = HttpContext.Session.GetString("username");

            //if(string.IsNullOrEmpty(username))
            //{
            //    username = string.Empty;
            //}


        }


    }
}