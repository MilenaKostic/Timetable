namespace TimeTable.Api.Interfaces
{
	public interface IRepositoryManager
	{
		IRouteRepository Route { get; }
		IStopRepository Stop { get; }
		IRouteStopRepository RouteStop { get; }
		IUserRepository User { get; }
		IShapeRepository Shape { get; }
		Task SaveAsync();
	}
}
