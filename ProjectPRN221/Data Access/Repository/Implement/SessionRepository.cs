using AutoMapper;
using Business_Object.Models;
using Data_Access.DAO;
using Data_Access.DTOs;
using Data_Access.Mapper;

namespace Data_Access.Repository.Implement
{
	public class SessionRepository : ISessionRepository
	{
		private IMapper mapper;

		public SessionRepository()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new ApplicationMapper());
			});
			mapper = config.CreateMapper();
		}

		public List<SessionDTO> GetAllSessions()
		{
			return mapper.Map<List<Session>, List<SessionDTO>>(SessionDAO.Instance.GetSessions());
		}

		public SessionDTO GetSession(int id)
		{
			return mapper.Map<Session, SessionDTO>(SessionDAO.Instance.GetSessionById(id));
		}

		public void SaveRangeSession(List<SessionDTOCreate> sessionDTOCreates)
		{
			SessionDAO.Instance.SaveRangeSession(mapper.Map<List<SessionDTOCreate>, List<Session>>(sessionDTOCreates));
		}

		public void SaveSessionDTO(SessionDTOCreate sessionDTOCreate)
		{
			SessionDAO.Instance.SaveSession(mapper.Map<SessionDTOCreate, Session>(sessionDTOCreate));
		}

		public List<SessionDTO> GetSessionsByLecturerId(string lecturerId)
		{
			return mapper.Map<List<Session>, List<SessionDTO>>(SessionDAO.Instance.GetSessionsByLecturerId(lecturerId));
		}

		public List<SessionDTO> GetSessionsByLecturerIdAreaAndDate()
		{
			return mapper.Map<List<Session>, List<SessionDTO>>(SessionDAO.Instance.GetSessions());
		}

		public string UpdateSession(SessionDTO sessionDTO)
		{
			return SessionDAO.Instance.UpdateSessionAsync(mapper.Map<SessionDTO, Session>(sessionDTO));
		}
	}
}
