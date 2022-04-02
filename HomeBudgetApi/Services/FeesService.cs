using HomeBudgetApi_CQRS.Data;
using HomeBudgetApi_CQRS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetApi_CQRS.Services
{
    public class FeesService : IFeesService
    {
        private readonly DatabaseContext _context;

        public FeesService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fee>> GetFees()
        {
            return await _context.Fee.Include(x => x.Payments).ToListAsync();
        }

        public  async Task<Fee> GetFeeById(int id)
        {
            return await _context.Fee.Include(x => x.Payments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Fee> CreateFee(Fee fee)
        {
            _context.Fee.Add(fee);
            await _context.SaveChangesAsync();
            return fee;
        }

        public async Task<int> UpdateFee(Fee fee)
        {
            _context.Fee.Update(fee);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteFee(Fee fee)
        {
            _context.Fee.Remove(fee);
            return await _context.SaveChangesAsync();
        }
    }
}
