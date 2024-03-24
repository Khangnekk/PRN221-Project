using AutoMapper;
using Data_Access.Mapper;

namespace Data_Access.Repository.Implement
{
	public class RoomRepository : IRoomRepository
	{
		private IMapper mapper;

		public RoomRepository()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new ApplicationMapper());
			});
			mapper = config.CreateMapper();
		}


	}
}
