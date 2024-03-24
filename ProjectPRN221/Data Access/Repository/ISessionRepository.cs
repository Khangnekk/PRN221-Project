using Data_Access.DTOs;

namespace Data_Access.Repository
{
	public interface ISessionRepository
	{
		public List<SessionDTO> GetAllSessions();
		public void SaveRangeSession(List<SessionDTOCreate> sessionDTOCreates);

		public void SaveSession(SessionDTOCreate sessionDTOCreate);
	}
}
