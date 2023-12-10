using System.Linq.Expressions;
using TimeTable.Api.Interfaces;

namespace TimeTable.Api.Repositories
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly RepositoryContext _repositoryContext;

		private readonly  Lazy<IRouteRepository> _routeRepository;
		private readonly Lazy<IStopRepository> _stopRepository;
		private readonly Lazy<IUserRepository> _userRepository;
		private readonly Lazy<IRouteStopRepository> _routestopRepository;

		public RepositoryManager(RepositoryContext repositoryContext)
		{
			_repositoryContext = repositoryContext;

			_routeRepository = new Lazy<IRouteRepository>(()=> new RouteRepository(repositoryContext));
			_stopRepository =  new Lazy<IStopRepository>(() => new StopRepository(repositoryContext));
			_userRepository =  new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
			_routestopRepository =  new Lazy<IRouteStopRepository>(() => new RouteStopRepository(repositoryContext));
			
		}

		public IRouteRepository Route => _routeRepository.Value;
		public IStopRepository Stop => _stopRepository.Value;
		public IUserRepository User => _userRepository.Value;
		public IRouteStopRepository RouteStop => _routestopRepository.Value;

		public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
	}
}
