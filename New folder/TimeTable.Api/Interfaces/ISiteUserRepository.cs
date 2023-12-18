using TimeTable.Api.Entities.Models;

namespace TimeTable.Api.Interfaces
{
	public interface ISiteUserRepository
	{
		void CreateUser(SiteUser user);
		Task<SiteUser> GetByName(string Name);
	}
}
