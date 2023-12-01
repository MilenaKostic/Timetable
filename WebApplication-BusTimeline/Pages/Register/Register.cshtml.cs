using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.DTO;
using System.Text;
using WebAPI.Data;
using WebAPI.Models;
using WebApplication_BusTimeline.Pages.Login;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebApplication_BusTimeline.Pages
{
    public class RegisterModel : PageModel
    {
     
        [BindProperty]
        public UserRegisterDTO userRegisterDTO { get; set; }
        public string? ErrorMessage { get; set; }

        public List<UserGetBasicDTO> users { get; set; }
      

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(UserRegisterDTO userRegisterDTO)
        {
            if (ModelState.IsValid == false)
            {
                if (userRegisterDTO.Password.Length < 6)
                    ErrorMessage = "Šifra mora imati minimum 6 karaktera.";
                return Page();
            }
            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7151/User/ByUsername:{userRegisterDTO.Username}"))
                    {
                        if(response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();                  
                            var _user = (JsonConvert.DeserializeObject<UserRegisterDTO>(apiResponse));
							ErrorMessage = "Već postoji korisnik sa ovim korisničkim imenom, pokušajte ponovo!";
							return Page();
						}                      
                        else
                        {
                            if (userRegisterDTO.Password.Equals(userRegisterDTO.ConfirmPassword))
                            {

                                try
                                {
                                    using (HttpResponseMessage response2 = await httpClient.GetAsync($"https://localhost:7151/User/AllUsers"))
                                    {
                                        string apiResponse = await response2.Content.ReadAsStringAsync();

                                        try
                                        {
                                            var _users = JsonConvert.DeserializeObject<List<UserGetBasicDTO>>(apiResponse);
                                            users = _users.ToList();
                                        }
                                        catch (JsonSerializationException)
                                        {
                                            ErrorMessage = "Lista korisnika je trenutno nedostupna, pokušajte kasnije";
                                            return Page();
                                        }

                                        foreach(var u in users)
                                        {
                                            if (u.Email.Equals(userRegisterDTO.Email))
                                            {
                                                ErrorMessage = "Ovaj mejl već postoji u bazi, pokušajte ponovo.";
                                                return Page();
                                            }
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    ErrorMessage = "Lista korisnika je trenutno nedostupna, pokušajte kasnije";
                                    return Page();
                                }

                                UserPostDTO _userNew = new UserPostDTO()
                                {
                                    Name = userRegisterDTO.Name,
                                    Lastname = userRegisterDTO.Lastname,
                                    Address = userRegisterDTO.Address,
                                    Email = userRegisterDTO.Email,
                                    Username = userRegisterDTO.Username,
                                    Password = userRegisterDTO.Password   //DODATI HASH!
                                };

                                var _httpClient = new HttpClient();
                                var result = await _httpClient.PostAsync("https://localhost:7151/User", new StringContent(JsonSerializer.Serialize(_userNew), Encoding.UTF8, "application/json"));

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
