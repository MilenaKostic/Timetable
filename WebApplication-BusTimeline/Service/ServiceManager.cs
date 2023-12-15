using Newtonsoft.Json;
using Shared.DTO;
using System.Net.Http;
using System.Text.Json;

namespace WebApplication_BusTimeline.Service
{
	public class ServiceManager : IServiceManager
	{
		private readonly HttpClient _httpClient;

		public ServiceManager(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		async Task<String> GetToken()
		{
			var request = new HttpRequestMessage(HttpMethod.Post, "login");

			var user = new UserLoginDTO()
			{
				Username = "string1",
				Password = "string1",
			};

			request.Content = JsonContent.Create(user);
			var response = await _httpClient.SendAsync(request);
			response.EnsureSuccessStatusCode();

			var t = await System.Text.Json.JsonSerializer.DeserializeAsync<TokenBasicDto>(
							 (await response.Content.ReadAsStreamAsync()),
							new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

			return t.Token;
		}

		public async Task<IEnumerable<StopGetBasicDTO>> GetAllBasicStop()
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, $"api/Stop");

				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
				var content = new StringContent("", null, "application/json");
				request.Content = content;

				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<StopGetBasicDTO>>(
					(await response.Content.ReadAsStreamAsync()),
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				return _d;
			}
			catch (Exception e)
			{
				throw new Exception("Lista stanica je trenutno nedostupna, pokušajte kasnije");
			}
		}

		public async Task<StopDTO> GetStopById(int id)
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, $"api/Stop/{id}");

				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
				var content = new StringContent("", null, "application/json");
				request.Content = content;

				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<StopDTO>(
					(await response.Content.ReadAsStreamAsync()),
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				return _d;
			}
			catch (Exception e)
			{
				throw new Exception("Lista stanica je trenutno nedostupna, pokušajte kasnije");
			}

		}

		public async Task<StopGetBasicDTO> CreateStop(StopPostDTO stop)
		{
			try
			{

				var request = new HttpRequestMessage(HttpMethod.Post, $"api/Stop");
				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");

				request.Content = JsonContent.Create(stop);
				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<StopGetBasicDTO>(
					(await response.Content.ReadAsStreamAsync()),
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				return _d;
			}
			catch (Exception e)
			{
				throw new Exception("Nemoguce kreirati stanicu");
			}
		}


		public async Task<IEnumerable<RouteGetBasicDTO>> GetAllBasicRoute()
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, $"api/Route");

				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
				var content = new StringContent("", null, "application/json");
				request.Content = content;

				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<RouteGetBasicDTO>>(
					(await response.Content.ReadAsStreamAsync()),
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				return _d;
			}
			catch (Exception e)
			{
				throw new Exception("Lista ruta je trenutno nedostupna, pokušajte kasnije");
			}
		}

		public async Task<RouteDTO> GetRouteById(int id)
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, $"api/Route/{id}");

				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
				var content = new StringContent("", null, "application/json");
				request.Content = content;

				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<RouteDTO>(
					(await response.Content.ReadAsStreamAsync()),
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				return _d;
			}
			catch (Exception e)
			{
				throw new Exception("Ne postoji ruta sa ovim Idem, pokušajte kasnije");
			}

		}

		public async Task<RouteDTO> GetRouteByName(string routeName)
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, $"api/Route/{routeName}");

				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
				var content = new StringContent("", null, "application/json");
				request.Content = content;

				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<RouteDTO>(
					(await response.Content.ReadAsStreamAsync()),
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				return _d;
			}
			catch (Exception e)
			{
				throw new Exception("Ne postoji ruta sa ovim nazivom, pokušajte kasnije");
			}

		}

		public async Task<RouteGetBasicDTO> CreateRoute(RoutePostDTO route)
		{
			try
			{

				var request = new HttpRequestMessage(HttpMethod.Post, $"api/Route");
				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");

				request.Content = JsonContent.Create(route);
				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<RouteGetBasicDTO>(
					(await response.Content.ReadAsStreamAsync()),
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				return _d;
			}
			catch (Exception e)
			{
				throw new Exception("Nemoguce kreirati rutu");
			}

		}

		public async Task DeleteRoute(int id)
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Delete, $"api/Route?id={id}");

				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
				var content = new StringContent("", null, "application/json");
				request.Content = content;

				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				//var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<RouteStopListDTO>>(
				//	(await response.Content.ReadAsStreamAsync()),
				//	new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				//return _d;

				return;
			}
			catch (Exception e)
			{
				throw new Exception("Lista stanica na ruti je trenutno nedostupna, pokušajte kasnije");
			}
		}


		public async Task<IEnumerable<RouteStopListDTO>> GetRouteStopByRouteId(int routeId)
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, $"api/RouteStop/ByRouteId?Id={routeId}");

				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
				var content = new StringContent("", null, "application/json");
				request.Content = content;

				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<RouteStopListDTO>>(
					(await response.Content.ReadAsStreamAsync()),
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				return _d;
			}
			catch (Exception e)
			{
				throw new Exception("Lista stanica na ruti je trenutno nedostupna, pokušajte kasnije");
			}

		}

		public async Task DeleteRouteStopById(int id)
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Delete, $"api/RouteStop?Id={id}");

				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
				var content = new StringContent("", null, "application/json");
				request.Content = content;

				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				//var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<RouteStopListDTO>>(
				//	(await response.Content.ReadAsStreamAsync()),
				//	new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				//return _d;

				return;
			}
			catch (Exception e)
			{
				throw new Exception("Lista stanica na ruti je trenutno nedostupna, pokušajte kasnije");
			}
		}

		public async Task<RouteStopGetDTO> CreateRouteStop(RouteStopPostDTO routeStop)
		{
			try
			{

				var request = new HttpRequestMessage(HttpMethod.Post, $"api/RouteStop");
				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");

				request.Content = JsonContent.Create(routeStop);
				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<RouteStopGetDTO>(
					(await response.Content.ReadAsStreamAsync()),
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				return _d;
			}
			catch (Exception e)
			{
				throw new Exception("Nemoguce kreirati rutu");
			}

		}

		public async Task<RouteWithStopsDTO> GetRouteWithStops(int routeId)
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, $"api/Route/{routeId}");

				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
				var content = new StringContent("", null, "application/json");
				request.Content = content;

				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<RouteWithStopsDTO>(
					(await response.Content.ReadAsStreamAsync()),
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				return _d;
			}
			catch (Exception e)
			{
				throw new Exception("Stanica je trenutno nedostupna, pokušajte kasnije");
			}

		}


		public async Task<IEnumerable<ShapeDTO>> GetAllShape()
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, $"api/Shape");

				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
				var content = new StringContent("", null, "application/json");
				request.Content = content;

				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<ShapeDTO>>(
					(await response.Content.ReadAsStreamAsync()),
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				return _d;
			}
			catch (Exception e)
			{
				throw new Exception("Lista tacaka u obliku je trenutno nedostupna, pokušajte kasnije");
			}
		}

		public async Task DeleteShapeById(int id)
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Delete, $"api/Shape?Id={id}");

				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
				var content = new StringContent("", null, "application/json");
				request.Content = content;

				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				
				return;
			}
			catch (Exception e)
			{
				throw new Exception("Lista stanica na ruti je trenutno nedostupna, pokušajte kasnije");
			}
		}

		public async Task<IEnumerable<ShapeDTO>> GetShapeByRoute(int routeId)
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, $"api/Shape/GetShapeByRoute?routeId={routeId}");

				//request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
				//var content = new StringContent("", null, "application/json");
				//request.Content = content;

				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<ShapeDTO>>(
					(await response.Content.ReadAsStreamAsync()),
					new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				return _d;
			}
			catch (Exception e)
			{
				throw new Exception("Lista tacaka u obliku je trenutno nedostupna, pokušajte kasnije");
			}
			
		}

		public async Task CreateShape(ShapePostDTO shape)
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Post, $"api/Shape");

				request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
				

				request.Content = JsonContent.Create(shape);

				var response = await _httpClient.SendAsync(request);
				response.EnsureSuccessStatusCode();

				//var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<ShapeDTO>>(
				//	(await response.Content.ReadAsStreamAsync()),
				//	new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

				//return _d;
			}
			catch (Exception e)
			{
				throw new Exception("Lista tacaka u obliku je trenutno nedostupna, pokušajte kasnije");
			}
		}

		public async Task Login(UserLoginDTO userLoginDTO)
		{
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"login");

                request.Headers.Add("Authorization", $"Bearer {await GetToken()}");
                var content = new StringContent("", null, "application/json");
                request.Content = content;

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                //var _d = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<ShapeDTO>>(
                //    (await response.Content.ReadAsStreamAsync()),
                //    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

               
            }
            catch (Exception e)
            {
                throw new Exception("Lista tacaka u obliku je trenutno nedostupna, pokušajte kasnije");
            }
        }

	}
	
}
