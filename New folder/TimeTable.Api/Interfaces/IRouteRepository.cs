namespace TimeTable.Api.Interfaces
{
	public interface IRouteRepository
	{
		void CreateRoute(Entities.Models.Route route);
		Task<IEnumerable<Entities.Models.Route>> GetAll();
		Task<Entities.Models.Route> GetById(int id, Boolean trackChanges);
		Task<Entities.Models.Route> GetByName(string name);
		void  DeleteRoute(Entities.Models.Route route);

	}
}
