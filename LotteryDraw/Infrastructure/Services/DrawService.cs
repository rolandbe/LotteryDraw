using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DrawService : IDrawService
    {
        private readonly IAsyncRepository<DrawHistory> drawServiceRepo;

        public DrawService(IAsyncRepository<DrawHistory> drawServiceRepo)
        {
            this.drawServiceRepo = drawServiceRepo;
        }
        public async Task<IEnumerable<DrawHistory>> GetHistoryData()
        {
            var history = await drawServiceRepo.ListAllAsync();
            return history.OrderByDescending(x => x.DrawnAt);
        }

        public async Task SaveDraw(string numbers)
        {
            await drawServiceRepo.AddAsync(new DrawHistory
            {
                Numbers = numbers,
                DrawnAt = DateTimeOffset.UtcNow
            });
        }
    }
}