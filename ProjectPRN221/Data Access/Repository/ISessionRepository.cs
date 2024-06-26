﻿using Data_Access.DTOs;

namespace Data_Access.Repository
{
	public interface ISessionRepository
	{
		public List<SessionDTO> GetAllSessions();
		public void SaveRangeSession(List<SessionDTOCreate> sessionDTOCreates);

		public void SaveSessionDTO(SessionDTOCreate sessionDTOCreate);
		public List<SessionDTO> GetSessionsByLecturerId(string lecturerId);
		public SessionDTO GetSession(int id);
		public string UpdateSession(SessionDTO sessionDTO);
	}
}
