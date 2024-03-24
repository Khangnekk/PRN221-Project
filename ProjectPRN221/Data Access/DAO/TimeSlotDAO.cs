using Business_Object.Models;

namespace Data_Access.DAO
{
	public class TimeSlotDAO
	{
		private static readonly ProjectPRN221Context context = new ProjectPRN221Context();

		public static List<TimeSlot> GetTimeSlots()
		{
			return context.TimeSlots.Where(a => a.Discontinued == false).ToList();
		}

		public static TimeSlot GetTimeSlotById(int timeslotId)
		{
			return context.TimeSlots.SingleOrDefault(t => t.TimeslotId == timeslotId);
		}
	}
}
