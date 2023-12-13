using TimeTable.Api.Entities.Models;

namespace TimeTable.Api.Interfaces
{
	public interface IShapeRepository
	{
		void DeleteShape(Shape shape);
		void CreateShape(Shape shape);
		Task<Shape> GetById(int Id, Boolean trackChanges);
		Task<IEnumerable<Shape>> GetAll();
		Task<IEnumerable<Shape>> GetByRoute( int routeId);
		Task <int?> GetLastRbrByRoute (int routeId);

	}
}
