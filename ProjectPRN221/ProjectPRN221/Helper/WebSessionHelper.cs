using Data_Access.DTOs;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectPRN221.Helper
{
	public class WebSessionHelper
	{
		private ISession _session;
		private List<SessionDTO> CurrentSessions;

		public WebSessionHelper(ISession session)
		{
			_session = session;
			if (session.GetString("CurrentSessions") != null)
			{
				string data = _session.GetString("CurrentSessions");
				var options = new JsonSerializerOptions
				{
					ReferenceHandler = ReferenceHandler.Preserve
				};
				List<SessionDTO> sessions = JsonSerializer.Deserialize<List<SessionDTO>>(data, options);
				CurrentSessions = sessions;
			}
			if (CurrentSessions == null)
			{
				CurrentSessions = new List<SessionDTO>();
				var options = new JsonSerializerOptions
				{
					ReferenceHandler = ReferenceHandler.Preserve
				};
				string data = JsonSerializer.Serialize(CurrentSessions, options);
				_session.SetString("CurrentSessions", data);
			}
		}

		public List<SessionDTO> GetSessionDTOs()
		{
			return CurrentSessions;
		}

		public void SetSessionDTOs(List<SessionDTO> sessions)
		{
			var options = new JsonSerializerOptions
			{
				ReferenceHandler = ReferenceHandler.Preserve
			};
			string data = JsonSerializer.Serialize(sessions, options);
			_session.SetString("CurrentSessions", data);
		}

		public void SetCurrentLecturerId(string LecturerId)
		{
			var options = new JsonSerializerOptions
			{
				ReferenceHandler = ReferenceHandler.Preserve
			};
			string data = JsonSerializer.Serialize(LecturerId, options);
			_session.SetString("LecturerId", data);
		}

		public string GetCurrentLecturerId()
		{
			string dataRaw = _session.GetString("LecturerId");
			var options = new JsonSerializerOptions
			{
				ReferenceHandler = ReferenceHandler.Preserve
			};
			string data = JsonSerializer.Deserialize<string>(dataRaw, options);
			return data;
		}
	}
}
