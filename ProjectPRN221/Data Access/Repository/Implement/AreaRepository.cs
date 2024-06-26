﻿using AutoMapper;
using Business_Object.Models;
using Data_Access.DAO;
using Data_Access.DTOs;
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

		public List<AreaDTO> GetAllAreas()
		{
			return mapper.Map<List<Area>, List<AreaDTO>>(AreaDAO.Instance.GetAreas());
		}
	}
}
