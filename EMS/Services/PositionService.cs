using AutoMapper;
using EMS.Entities;
using EMS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EMS.Services
{
    public class PositionService : IPositionService
    {
        private readonly IEmsContext _emsContext;

        public PositionService(IEmsContext emsContext)
        {
            _emsContext = emsContext;
        }

        public async Task<List<Position>> GetPositions(CancellationToken cancellationToken)
        {
            var positionList = await _emsContext.Positions
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync(cancellationToken);

            return positionList;
        }
    }
}
