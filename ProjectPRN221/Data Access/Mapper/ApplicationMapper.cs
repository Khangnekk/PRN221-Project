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
			CreateMap<AreaDTOCreate, Area>();

			// Map TimeSlot
			CreateMap<TimeSlot, TimeSlotDTO>();
			CreateMap<TimeSlotDTOCreate, TimeSlot>();

			// Map Session
			CreateMap<Session, SessionDTO>();
			CreateMap<SessionDTOCreate, Session>();
			//.ForMember(dest => dest.SessionNo, opt => opt.Ignore())
			//.ForMember(dest => dest.Discontinued, opt => opt.MapFrom(src => false))
			//.ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
			//.ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => RoomDAO.GetRoomIdByRoomRaw(src.RoomRaw)))
			//.ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
			//.ForMember(dest => dest.TimeslotId, opt => opt.MapFrom(src => GetTimeslotId(src.TimeslotRaw)))
			//.ForMember(dest => dest.LecturerId, opt => opt.MapFrom(src => src.LecturerId))
			//.ForMember(dest => dest.Online, opt => opt.MapFrom(src => src.Online));
		}
	}
}
