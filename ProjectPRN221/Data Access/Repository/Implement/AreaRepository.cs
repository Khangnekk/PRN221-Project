using AutoMapper;
using Data_Access.Mapper;

namespace Data_Access.Repository.Implement
{
	public class AreaRepository : IAreaRepository
	{
		private IMapper mapper;

		public AreaRepository()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new ApplicationMapper());
			});
			mapper = config.CreateMapper();
		}
	}
}
