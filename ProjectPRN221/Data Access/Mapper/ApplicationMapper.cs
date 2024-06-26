﻿using AutoMapper;
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
			CreateMap<AreaDTOCreate, Area>();

			// Map Room
			CreateMap<Room, RoomDTO>();

			// Map TimeSlot
			CreateMap<TimeSlot, TimeSlotDTO>();
			CreateMap<TimeSlotDTOCreate, TimeSlot>();

			// Map Session
			CreateMap<Session, SessionDTO>()
				.ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group))
				.ForMember(dest => dest.Lecturer, opt => opt.MapFrom(src => src.Lecturer))
				.ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room))
				.ForMember(dest => dest.Timeslot, opt => opt.MapFrom(src => src.Timeslot));
			CreateMap<SessionDTOCreate, Session>()
				.ForMember(dest => dest.Discontinued, opt => opt.MapFrom(src => false));
			CreateMap<SessionDTO, SessionDTOCreate>();
			CreateMap<SessionDTO, Session>();


			// Map Group
			CreateMap<Group, GroupDTO>();
			CreateMap<GroupDTOCreate, Group>();

			// Map Subject
			CreateMap<SubjectDTOCreate, Subject>();
			CreateMap<Subject, SubjectDTOCreate>();

			// Add mapping between Group and GroupDTOCreate
			CreateMap<Group, GroupDTOCreate>();
		}
	}
}
