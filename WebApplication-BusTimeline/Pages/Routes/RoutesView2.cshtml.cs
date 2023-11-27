using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Shared.DTO;

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
                        ErrorMessage = "�eljena ruta je trenutno nedostupna, poku�ajte kasnije";
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = "�eljena ruta je trenutno nedostupna, poku�ajte kasnije";
            }
        }


    }
}

