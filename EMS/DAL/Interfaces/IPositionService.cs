using EMS.Entities;

namespace EMS.Interfaces;

public interface IPositionService
{
    Task<List<Position>> GetPositions();
    Task<Position> GetPositionById(Guid positionId);
}