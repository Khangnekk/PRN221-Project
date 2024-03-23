using Data_Access.DTOs;

namespace Data_Access.Repository
{
	public interface IAreaRepository
	{
		List<AreaDTO> GetAllAreas();
	}
}
