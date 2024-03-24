using Business_Object.Models;

namespace Data_Access.DAO
{
	public class TimeSlotDAO : DAO<TimeSlot>
	{
		private static TimeSlotDAO instance;
		private static readonly object padlock = new object();

		private TimeSlotDAO() { }
		public static TimeSlotDAO Instance
		{
			get
			{
				// Double-check locking for thread safety
				if (instance == null)
				{
					lock (padlock)
					{
						if (instance == null)
						{
							instance = new TimeSlotDAO();
						}
					}
				}
				return instance;
			}
		}

		public List<TimeSlot> GetTimeSlots()
		{
			return context.TimeSlots.Where(a => a.Discontinued == false).ToList();
		}

		public TimeSlot GetTimeSlotById(int timeslotId)
		{
			return context.TimeSlots.SingleOrDefault(t => t.TimeslotId == timeslotId);
		}
	}
}
