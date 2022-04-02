using HomeBudgetApi_CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetApi_CQRS.Services
{
    public interface IFeesService
    {
        Task<IEnumerable<Fee>> GetFees();
        Task<Fee> GetFeeById(int id);
        Task<Fee> CreateFee(Fee fee);
        Task<int> UpdateFee(Fee fee);
        Task<int> DeleteFee(Fee fee);
    }
}
