using AutoMapper;
using Business_Object.Models;
using Data_Access.DTOs;

namespace Data_Access.Mapper
{
	public class ApplicationMapper : Profile
	{
		public ApplicationMapper()
		{
			// Map Area
			CreateMap<Area, AreaDTO>();
			CreateMap<AeraDTOCreate, Area>();
			CreateMap<AreaDTO, Area>();
		}
	}
}
