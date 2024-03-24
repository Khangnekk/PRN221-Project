using Data_Access.DTOs;

namespace Data_Access.Repository
{
	public interface ISessionRepository
	{
		List<SessionDTO> GetAllSessions();

	}
}
