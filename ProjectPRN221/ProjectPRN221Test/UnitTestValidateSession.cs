using Data_Access.DTOs;
using ProjectPRN221.Helper;

namespace ProjectPRN221Test
{
	public class Tests
	{

		[Test]
		public void ConvertToSessionDTOCreates_TestCountSessionCreate()
		{
			SessionDTORaw rawSession = new SessionDTORaw
			{
				SubjectId = "PRN211",
				GroupName = "SE1643",
				RoomRaw = "BE-102",
				FirstDate = new DateTime(2024, 3, 24),
				TimeslotRaw = "A24",
				LecturerId = "chilp",
				TotalSession = 20,
				Online = true
			};

			var sessionDTOCreates = SessionHelper.ConvertToSessionDTOCreates(rawSession);

			Assert.AreEqual(rawSession.TotalSession, sessionDTOCreates.Count);
		}

		[Test]
		public void ConvertToSessionDTOCreates_TestFirstDateOfFirstWeek()
		{
			SessionDTORaw rawSession = new SessionDTORaw
			{
				SubjectId = "PRN211",
				GroupName = "SE1643",
				RoomRaw = "BE-102",
				FirstDate = new DateTime(2024, 3, 24),
				TimeslotRaw = "A24",
				LecturerId = "chilp",
				TotalSession = 20,
				Online = true
			};

			var sessionDTOCreates = SessionHelper.ConvertToSessionDTOCreates(rawSession);

			Assert.AreEqual(new DateTime(2024, 3, 25), sessionDTOCreates.FirstOrDefault().Date);
		}

		[Test]
		public void ConvertToSessionDTOCreates_TestLastDateOfFirstWeek()
		{
			SessionDTORaw rawSession = new SessionDTORaw
			{
				SubjectId = "PRN211",
				GroupName = "SE1643",
				RoomRaw = "BE-102",
				FirstDate = new DateTime(2024, 3, 24),
				TimeslotRaw = "A24",
				LecturerId = "chilp",
				TotalSession = 20,
				Online = true
			};

			var sessionDTOCreates = SessionHelper.ConvertToSessionDTOCreates(rawSession);

			Assert.AreEqual(new DateTime(2024, 5, 29), sessionDTOCreates.LastOrDefault().Date);
		}

		[Test]
		public void ConvertToSessionDTOCreates_TestSessionNoOfLastDate()
		{
			SessionDTORaw rawSession = new SessionDTORaw
			{
				SubjectId = "PRN211",
				GroupName = "SE1643",
				RoomRaw = "BE-102",
				FirstDate = new DateTime(2024, 3, 24),
				TimeslotRaw = "A24",
				LecturerId = "chilp",
				TotalSession = 20,
				Online = true
			};

			var sessionDTOCreates = SessionHelper.ConvertToSessionDTOCreates(rawSession);

			Assert.AreEqual(20, sessionDTOCreates.LastOrDefault().SessionNo);
		}


		[Test]
		public void ConvertToSessionDTOCreates_TestTimeSlotIdOfFirstDate()
		{
			SessionDTORaw rawSession = new SessionDTORaw
			{
				SubjectId = "PRN211",
				GroupName = "SE1643",
				RoomRaw = "BE-102",
				FirstDate = new DateTime(2024, 3, 24),
				TimeslotRaw = "A24",
				LecturerId = "chilp",
				TotalSession = 20,
				Online = true
			};

			var sessionDTOCreates = SessionHelper.ConvertToSessionDTOCreates(rawSession);

			Assert.AreEqual(1, sessionDTOCreates.FirstOrDefault().TimeslotId);
		}

		[Test]
		public void ConvertToSessionDTOCreates_TestTimeSlotIdOfLastDate()
		{
			SessionDTORaw rawSession = new SessionDTORaw
			{
				SubjectId = "PRN211",
				GroupName = "SE1643",
				RoomRaw = "BE-102",
				FirstDate = new DateTime(2024, 3, 24),
				TimeslotRaw = "A24",
				LecturerId = "chilp",
				TotalSession = 20,
				Online = true
			};

			var sessionDTOCreates = SessionHelper.ConvertToSessionDTOCreates(rawSession);

			Assert.AreEqual(2, sessionDTOCreates.LastOrDefault().TimeslotId);
		}
	}
}