using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shared.DTO;
using WebAPI.Models;

namespace WebApplication_BusTimeline.Pages.Routes;
public class RoutesView2Model : PageModel
{

    public List<RouteGetBasicDTO> Routes { get; set; }

    public string? ErrorMessage { get; set; }
    public async Task OnGetAsync()
    {

        using (var httpClient = new HttpClient())
        {
            try
            {
                using (HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7151/Route/AllRoutes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    try
                    {
                        var _routes = JsonConvert.DeserializeObject<List<RouteGetBasicDTO>>(apiResponse);
                        Routes = _routes.ToList();
                    }
                    catch (JsonSerializationException)
                    {
                        ErrorMessage = "Željena ruta je trenutno nedostupna, pokušajte kasnije";
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = "Željena ruta je trenutno nedostupna, pokušajte kasnije";
            }
        }


    }

    public async Task OnPostDeleteRouteAsync(int routeId)
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                using (HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7151/Route/{routeId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    try
                    {
                        using (HttpResponseMessage response2 = await httpClient.GetAsync("https://localhost:7151/Route/AllRoutes"))
                        {
                            string apiResponse2 = await response2.Content.ReadAsStringAsync();
                            var _routes = (JsonConvert.DeserializeObject<List<RouteGetBasicDTO>>(apiResponse2)).ToList();

                            Routes = _routes.ToList();

                        }
                    }
                    catch (Exception e)
                    {
                        ErrorMessage = "Lista stanica je trenutno nedostupna, pokušajte kasnije";
                    }
                    

                }

            }
            catch (Exception e)
            {
                ErrorMessage = "Došlo je do greške, pokušajte kasnije";
            }


        }
    }
}

