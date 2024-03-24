using Data_Access.DTOs;

namespace Data_Access.Repository
{
	public interface ISubjectRepository
	{
		SubjectDTOCreate GetSubjectById(string subjectId);
	}
}
