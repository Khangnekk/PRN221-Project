using AutoMapper;
using Business_Object.Models;
using Data_Access.DAO;
using Data_Access.DTOs;
using Data_Access.Mapper;

namespace Data_Access.Repository.Implement
{
	public class SubjectRepository : ISubjectRepository
	{
		private IMapper mapper;

		public SubjectRepository()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new ApplicationMapper());
			});
			mapper = config.CreateMapper();
		}

		public SubjectDTOCreate GetSubjectById(string subjectId)
		{
			return mapper.Map<Subject, SubjectDTOCreate>(SubjectDAO.Instance.GetSubjectById(subjectId));
		}
	}
}
