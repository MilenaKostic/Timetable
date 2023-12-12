using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.DTO;
using WebApplication_BusTimeline.Service;

namespace WebApplication_BusTimeline.Pages.Routes
{
    public class AddShapeModel : PageModel
    {
        public IServiceManager _service;
        public string ErrorMessage { get; set; }
        public List<ShapeDTO> Shapes { get; set; }

        public AddShapeModel(IServiceManager service)
        {
            _service = service;
        }
        public async void OnGet()
        {
            try
            {
                Shapes = (await _service.GetAllShape()).ToList(); 
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message; 
            }
        }

        public async Task OnPostDeleteShape(int id)
        {
            try
            {
                await _service.DeleteShapeById(id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

			try
			{
				Shapes = (await _service.GetAllShape()).ToList();
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}


		}
    }
}
