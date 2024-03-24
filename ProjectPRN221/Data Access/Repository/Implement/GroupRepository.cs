using AutoMapper;
using Business_Object.Models;
using Data_Access.DAO;
using Data_Access.DTOs;
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

		public GroupDTOCreate GetGroupByGroupDTOCreateNameAndSubjectId(string groupname, string subjectId)
		{
			return mapper.Map<Group, GroupDTOCreate>(GroupDAO.Instance.GetGroupByGroupNameAndSubjectId(groupname, subjectId));
		}

		public GroupDTO GetGroupByGroupDTONameAndSubjectId(string groupname, string subjectId)
		{
			return mapper.Map<Group, GroupDTO>(GroupDAO.Instance.GetGroupByGroupNameAndSubjectId(groupname, subjectId));
		}

		public void SaveGroupDTO(GroupDTOCreate groupDTO)
		{
			GroupDAO.Instance.SaveGroup(mapper.Map<GroupDTOCreate, Group>(groupDTO));
		}
	}
}
