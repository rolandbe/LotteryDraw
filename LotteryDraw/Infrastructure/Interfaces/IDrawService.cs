using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDrawService
    {
        Task SaveDraw(string numbers);
        Task<IEnumerable<DrawHistory>> GetHistoryData();
    }
}