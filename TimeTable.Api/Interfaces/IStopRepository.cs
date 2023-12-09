using System.Threading.Tasks;
using TimeTable.Api.Entities.Models;

namespace TimeTable.Api.Interfaces
{
	public interface IStopRepository
	{
		void CreateStop(Stop stop);
		Task<IEnumerable<Stop>> GetAll();
		Task<Stop> GetById(int Id, Boolean trackChanges);
		Task<Stop> GetByName(string Name);
		void DeleteStop(Stop stop);
	}
}
