using Data_Access.DTOs;

namespace Data_Access.Repository
{
	public interface IGroupRepository
	{
		public GroupDTOCreate GetGroupByGroupDTOCreateNameAndSubjectId(string groupname, string subjectId);
		public void SaveGroupDTO(GroupDTOCreate groupDTO);
		public GroupDTO GetGroupByGroupDTONameAndSubjectId(string groupname, string subjectId);
	}
}
