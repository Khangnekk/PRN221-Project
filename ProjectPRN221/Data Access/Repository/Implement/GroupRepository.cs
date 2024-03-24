using AutoMapper;
using Data_Access.Mapper;

namespace Data_Access.Repository.Implement
{
	public class GroupRepository : IGroupRepository
	{
		private IMapper mapper;

		public GroupRepository()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new ApplicationMapper());
			});
			mapper = config.CreateMapper();
		}
	}
}
